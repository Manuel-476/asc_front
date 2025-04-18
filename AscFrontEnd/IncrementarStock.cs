using AscFrontEnd.DTOs.Serie;
using AscFrontEnd.DTOs.StaticsDto;
using DocumentFormat.OpenXml.Office2010.Excel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AscFrontEnd.DTOs.Enums.Enums;
using AscFrontEnd.DTOs.Stock;
using System.Globalization;

namespace AscFrontEnd
{
    public partial class IncrementarStock : Form
    {
        ArtigoDTO _artigo;
        int _qtd;
        public IncrementarStock(ArtigoDTO artigo, int qtd)
        {
            InitializeComponent();
            _artigo = artigo;
            _qtd = qtd;
        }

        private void IncrementarStock_Load(object sender, EventArgs e)
        {
            artigoLabel.Text = $"Artigo: {_artigo.codigo}";
            qtdLabel.Text = $"Qtd Stock: {_qtd:F2}";
        }

        private async void salvarBtn_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
                client.BaseAddress = new Uri("https://sua-api.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(_artigo.id);

                var qtd = !string.IsNullOrEmpty(qtdText.Text.ToString()) ? float.Parse(qtdText.Text.ToString().Replace(".", "").Replace(",", "."), CultureInfo.InvariantCulture) : 0f;

                // Envio dos dados para a API
                HttpResponseMessage response = await client.PutAsync($"https://localhost:7200/api/Armazem/Stock/Qtd/Artigo/Incremento/{_artigo.id}/{qtd}/{StaticProperty.funcionarioId}/{StaticProperty.empresaId}", new StringContent(json, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var responseLocationStore = await client.GetAsync($"https://localhost:7200/api/Armazem/LocationStore");

                    var contentLocationStore = await responseLocationStore.Content.ReadAsStringAsync();
                    StaticProperty.locationStores = JsonConvert.DeserializeObject<List<LocationStoreDTO>>(contentLocationStore);


                    var responseLocationArtigo = await client.GetAsync($"https://localhost:7200/api/Armazem/LocationArtigo");

                    var contentLocationArtigo = await responseLocationArtigo.Content.ReadAsStringAsync();
                    StaticProperty.locationArtigos = JsonConvert.DeserializeObject<List<LocationArtigoDTO>>(contentLocationArtigo);
                    

                    MessageBox.Show($"Quantidade acrescentada com sucesso",
                                     "Feito com sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Actualizar tabela

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao Activar Serie: {ex.Message}", "Ocorreu um erro", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }
        }
    }
}

