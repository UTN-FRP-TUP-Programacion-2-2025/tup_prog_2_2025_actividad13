using Ejercicio1_Models;
using System.IO;

namespace Ejercicio2_DesktopApp;

public partial class FormPrincipal : Form
{
    Sistema MiEmpresa = new Sistema();
    int camionElegido = 0;

    private void MostrarListaZonas()
    {
        listBox1.Items.Clear();
        listBox2.Items.Clear();
        listBox3.Items.Clear();
        foreach (Paquete paquete in MiEmpresa.listaPaquetes)
        {
            if (paquete.ZonaDestino == "1")
            {
                listBox1.Items.Add(paquete);
            }
            else if (paquete.ZonaDestino == "2")
            {
                listBox2.Items.Add(paquete);
            }
            else if (paquete.ZonaDestino == "3")
            {
                listBox3.Items.Add(paquete);
            }
        }
    }

    private void VerCarga()
    {
        if (camionElegido > -1)
        {
            listBcarga.Items.Clear();
            listBcarga.Items.AddRange(MiEmpresa.VerCargaCamion(camionElegido));
        }
    }

    public FormPrincipal()
    {
        InitializeComponent();
    }

    private void btnImportarPaquetes_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            string path = openFileDialog1.FileName;

            FileStream fs = null;
            try
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                MiEmpresa.Descargar(fs);

                MostrarListaZonas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }
    }

    private void FormPrincipal_Load(object sender, EventArgs e)
    {
        cBoxCamiones.Items.AddRange(MiEmpresa.CamionesCargados());
    }

    private void btnIniciar_Click(object sender, EventArgs e)
    {
        camionElegido = cBoxCamiones.SelectedIndex;

    }

    private void btnAgregar_Click(object sender, EventArgs e)
    {
        Paquete seleccionado = null;
        if (listBox3.Items.Count > 0)
        {
            seleccionado = listBox3.Items[0] as Paquete;
        }
        else if (listBox2.Items.Count > 0)
        {
            seleccionado = listBox2.Items[0] as Paquete;
        }
        else if (listBox1.Items.Count > 0)
        {
            seleccionado = listBox1.Items[0] as Paquete;
        }

        try
        {
            if (seleccionado != null)
            {
                double peso = MiEmpresa.CargarPaquete(camionElegido, seleccionado);
                tBkg.Text = peso.ToString("0.00");
                MostrarListaZonas();
                VerCarga();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
    }

    private void btnRetirar_Click(object sender, EventArgs e)
    {
        double peso = MiEmpresa.RetirarPaquete(camionElegido);
        tBkg.Text = peso.ToString("0.00");
        MostrarListaZonas();
        VerCarga();
    }

    private void btnEnviar_Click(object sender, EventArgs e)
    {
        FileStream fs = null;
        try
        {
            string path= $"{camionElegido.ToString("000")}carga.CSV";
            fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            MiEmpresa.RetirarCamion(fs, camionElegido);

        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
        finally
        {
            if (fs != null) fs.Close();
        }
    }
}
