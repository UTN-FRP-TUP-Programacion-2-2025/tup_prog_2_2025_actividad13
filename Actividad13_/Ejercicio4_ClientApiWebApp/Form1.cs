using System.Net.Http.Json;

namespace Ejercicio4_ClientApiWebApp;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    async private void Form1_Load(object sender, EventArgs e)
    {
        string url = "https://6g7gzp25-7071.brs.devtunnels.ms/api/Sistemas/CamionesCargados";

        using HttpClient client = new HttpClient();

        HttpRequestMessage request = new HttpRequestMessage
        {
            Method=HttpMethod.Get,
            RequestUri = new Uri(url)
        };

        HttpResponseMessage response= await client.SendAsync(request);

        comboBox1.Items.Clear();
        if (response.IsSuccessStatusCode)
        {
            string[] camiones=await response.Content.ReadFromJsonAsync<string[]>();

            comboBox1.Items.AddRange(camiones);
        }
    }
}
