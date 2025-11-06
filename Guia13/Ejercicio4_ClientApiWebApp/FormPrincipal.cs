using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;

namespace Ejercicio4_ClientApiWebApp;

public partial class FormPrincipal : Form
{
    public FormPrincipal()
    {
        InitializeComponent();
    }

    async private void FormPrincipal_Load(object sender, EventArgs e)
    {
        await VerCamiones();
    }


    async Task VerCamiones()
    {
        string url = "https://r96hjft7-7024.brs.devtunnels.ms/api/Sistemas/CamionesCargados";
        using HttpClient client = new HttpClient();

        HttpRequestMessage request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(url)
        };

        HttpResponseMessage response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            string[] camiones = await response.Content.ReadFromJsonAsync<string[]>();
            cBoxCamiones.Items.AddRange(camiones);
        }
    }

    private void btnImportarPaquetes_Click(object sender, EventArgs e)
    {
        
    }

    async private void btnImportarPaquetes_Click_1(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            string path = openFileDialog1.FileName;

            FileStream fs = null;
            try
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.Read);


                string url = "https://r96hjft7-7024.brs.devtunnels.ms/api/Sistemas/DescargarCamion";
                using HttpClient client = new HttpClient();

                using var multipartContent = new MultipartFormDataContent();
                using var fileContent = new StreamContent(fs);
                multipartContent.Add(fileContent, "file", Path.GetFileName(path));

                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content= multipartContent
                };

                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Fichero importado");
                }
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
}
