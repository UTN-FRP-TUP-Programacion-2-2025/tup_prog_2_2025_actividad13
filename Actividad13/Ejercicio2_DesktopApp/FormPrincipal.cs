using Ejercicio1_Models;
using System.Runtime.Serialization.Formatters.Binary;

namespace Ejercicio2_DesktopApp;

public partial class FormPrincipal : Form
{
    Sistema miEmpresa = new Sistema();
    int camionElegido = -1;

    public FormPrincipal()
    {
        InitializeComponent();
    }

    private void VerCarga()
    {
        listBcarga.Items.Clear();
        if (camionElegido > -1)
        {
            listBcarga.Items.AddRange(miEmpresa.VerCargaCamion(camionElegido));
        }
    }

    private void MostrarListaZonas()
    {
        listBox1.Items.Clear();
        listBox2.Items.Clear();
        listBox3.Items.Clear();
        foreach (Paquete p in miEmpresa.listaPaquetes)
        {
            switch (p.ZonaDestino)
            {
                case "1":
                    listBox1.Items.Add(p);
                    break;
                case "2":
                    listBox2.Items.Add(p);
                    break;
                case "3":
                    listBox3.Items.Add(p);
                    break;
            }
        }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        FileStream fs = null;
        try
        {
            fs = new FileStream("data.bin", FileMode.Open, FileAccess.Read);

            // Remueve las advertencias del compilador
#pragma warning disable SYSLIB0011
            BinaryFormatter bf = new BinaryFormatter();
            miEmpresa = bf.Deserialize(fs) as Sistema;
            // Remueve las advertencias del compilador sobre obsolescencia
#pragma warning restore SYSLIB0011
        }
        catch (Exception)
        {
            miEmpresa = new Sistema();
        }
        finally
        {
            if (fs != null) fs.Close();
        }

        if (miEmpresa != null)
            cBoxCamiones.Items.AddRange(miEmpresa.CamionesCargados());

        VerCarga();
        MostrarListaZonas();
    }

    private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
    {
        FileStream fs = null;
        try
        {
            fs = new FileStream("data.bin", FileMode.OpenOrCreate, FileAccess.Write);

            // Remueve las advertencias del compilador
#pragma warning disable SYSLIB0011
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, miEmpresa);
            // Remueve las advertencias del compilador sobre obsolescencia
#pragma warning restore SYSLIB0011
        }
        finally
        {
            if (fs != null) fs.Close();
        }
    }

    private void btnImportarPaquetes_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            FileStream fs = null;
            try
            {
                string path = openFileDialog1.FileName;
                fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);

                miEmpresa.Descargar(fs);

                MostrarListaZonas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al importar los paquetes: " + ex.Message);
            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }
    }

    private void btnAgregar_Click(object sender, EventArgs e)
    {
        Paquete seleccionado = null;

        if (listBox3.Items.Count > 0)
            seleccionado = listBox3.Items[0] as Paquete;
        else if (listBox2.Items.Count > 0)
            seleccionado = listBox2.Items[0] as Paquete;
        else if (listBox1.Items.Count > 0)
            seleccionado = listBox1.Items[0] as Paquete;

        if (seleccionado != null && camionElegido > -1)
        {
            double peso = miEmpresa.CargarPaquete(camionElegido, seleccionado);

            tBkg.Text = peso.ToString();

            MostrarListaZonas();
            VerCarga();
        }
        else
        {
            MessageBox.Show("No hay paquetes para agregar o no se ha seleccionado un camión.");
        }
    }

    private void btnIniciar_Click(object sender, EventArgs e)
    {
        camionElegido = cBoxCamiones.SelectedIndex;
        VerCarga();
    }

    private void btnRetirar_Click(object sender, EventArgs e)
    {
        if (camionElegido > -1)
        {
            double peso = miEmpresa.RetirarPaquete(camionElegido);

            tBkg.Text = peso.ToString("0.00");
            MostrarListaZonas();
            VerCarga();
        }
    }

    private void btnEnviar_Click(object sender, EventArgs e)
    {
        FileStream fs = null;
        try
        {
            string nombre = $"{camionElegido.ToString("000")}carga.CSV";
            fs = new FileStream(nombre, FileMode.OpenOrCreate, FileAccess.Write);

            miEmpresa.RetirarCamion(fs, camionElegido);

            camionElegido = -1;
            cBoxCamiones.SelectedIndex = camionElegido;
            MostrarListaZonas();
            VerCarga();

        }
        catch (Exception ex)
        {
            MessageBox.Show($"{ex}");
        }
        finally
        {
            if (fs != null) fs.Close();
        }
    }

   
}
