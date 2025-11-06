using Ejercicio1_Models;

namespace Ejercicio2_DesktopApp;

public partial class Form1 : Form
{
    Sistema MiEmpresa = new Sistema();
    int camionElegido = -1;

    public Form1()
    {
        InitializeComponent();
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

                MiEmpresa.Descargar(fs);

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
            double peso = MiEmpresa.CargarPaquete(camionElegido, seleccionado);

            textBox1.Text = peso.ToString();

            MostrarListaZonas();
            VerCarga();
        }
        else
        {
            MessageBox.Show("No hay paquetes para agregar o no se ha seleccionado un camión.");
        }

    }

    private void VerCarga()
    {
        listBox4.Items.Clear();
        if (camionElegido > -1)
        {
            listBox4.Items.AddRange(MiEmpresa.VerCargaCamion(camionElegido));
        }
    }

    private void MostrarListaZonas()
    {
        listBox1.Items.Clear();
        listBox2.Items.Clear();
        listBox3.Items.Clear();
        foreach (Paquete p in MiEmpresa.listaPaquetes)
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
        comboBox1.Items.AddRange(MiEmpresa.CamionesCargados());
    }

    private void btnIniciar_Click(object sender, EventArgs e)
    {
        camionElegido = comboBox1.SelectedIndex;
        VerCarga();
    }

    private void btnRetirar_Click(object sender, EventArgs e)
    {
        if (camionElegido > -1)
        {
            double peso = MiEmpresa.RetirarPaquete(camionElegido);

            textBox1.Text = peso.ToString("0.00");
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

            MiEmpresa.RetirarCamion(fs, camionElegido);

            camionElegido = -1;
            comboBox1.SelectedIndex = camionElegido;
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
