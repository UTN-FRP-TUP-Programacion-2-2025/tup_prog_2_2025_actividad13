using Ejercicio4_ClientApiWebDesktopApp.DTOs;
using System.Net.Http.Json;
using System.Windows.Forms;

namespace Ejercicio4_ClientApiWebDesktopApp;

public partial class FormPrincipal : Form
{
    int camionElegido = -1;
    public FormPrincipal()
    {
        InitializeComponent();
    }

    async private void Form1_Load(object sender, EventArgs e)
    {
        await VerCamiones();
        await VerCarga();
        await MostrarListaZonas();

    }
    async private void btnImportarPaquetes_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            string path = openFileDialog1.FileName;

            FileStream fs = null;
            try
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.Read);

                #region llamada al restapi
                string url = "https://localhost:7071/api/Sistemas/DescargarCamion";
                using HttpClient client = new HttpClient();

                using var multipartContent = new MultipartFormDataContent();
                using var fileContent = new StreamContent(fs);
                multipartContent.Add(fileContent, "manifiesto", Path.GetFileName(path));

                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content = multipartContent
                };

                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Fichero importado");
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error: {errorMessage}");
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (fs != null) fs.Close();
            }

            await MostrarListaZonas();
        }
    }

    async Task VerCamiones()
    {
        #region llamada al restapi
        string url = "https://localhost:7071/api/Sistemas/CamionesCargados";

        using HttpClient client = new HttpClient();

        HttpRequestMessage request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(url)
        };

        HttpResponseMessage response = await client.SendAsync(request);

        cBoxCamiones.Items.Clear();
        if (response.IsSuccessStatusCode)
        {
            string[] camiones = await response.Content.ReadFromJsonAsync<string[]>();

            cBoxCamiones.Items.AddRange(camiones);
        }
        #endregion
    }

    async private Task MostrarListaZonas()
    {
        List<PaqueteDTO> paquetes = new List<PaqueteDTO>();

        #region llamada al restapi
        string url = $"https://localhost:7071/api/Sistemas/listaPaquetes";

        using HttpClient client = new HttpClient();

        HttpRequestMessage request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(url)
        };

        HttpResponseMessage response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            paquetes = await response.Content.ReadFromJsonAsync<List<PaqueteDTO>>();
        }
        #endregion

        listBox1.Items.Clear();
        listBox2.Items.Clear();
        listBox3.Items.Clear();
        foreach (PaqueteDTO p in paquetes)
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

    async private Task VerCarga()
    {
        if (camionElegido > -1)
        {
            #region llamada al restapi
            string url = $"https://localhost:7071/api/Sistemas/VerCargaCamion?posicion={camionElegido}";

            using HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url)
            };

            HttpResponseMessage response = await client.SendAsync(request);

            listBcarga.Items.Clear();
            if (response.IsSuccessStatusCode)
            {
                string[] paquetes = await response.Content.ReadFromJsonAsync<string[]>();
                listBcarga.Items.AddRange(paquetes);
            }
            #endregion
        }
    }

    async private void btnIniciar_Click(object sender, EventArgs e)
    {
        camionElegido = cBoxCamiones.SelectedIndex;
        await VerCarga();
    }

    async private void btnAgregar_Click(object sender, EventArgs e)
    {
        #region llamada al restapi
        string url = $"https://localhost:7071/api/Sistemas/AgregarPaqueteDelCamion/{camionElegido}";

        using HttpClient client = new HttpClient();

        HttpRequestMessage request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(url)
        };

        HttpResponseMessage response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            double pesoCamionActual = await response.Content.ReadFromJsonAsync<double>();
            textBox1.Text = pesoCamionActual.ToString("0.00");
        }
        #endregion

        await VerCarga();
        await MostrarListaZonas();
    }

    async private void btnRetirar_Click(object sender, EventArgs e)
    {
        #region llamada al restapi
        string url = $"https://localhost:7071/api/Sistemas/QuitarPaqueteDelCamion?posicion={camionElegido}";

        using HttpClient client = new HttpClient();

        HttpRequestMessage request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(url)
        };

        HttpResponseMessage response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            double pesoCamionActual = await response.Content.ReadFromJsonAsync<double>();
            textBox1.Text = pesoCamionActual.ToString("0.00");
        }
        #endregion

        await VerCarga();
        await MostrarListaZonas();
    }
}
