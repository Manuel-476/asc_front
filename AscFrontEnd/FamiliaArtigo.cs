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
using AscFrontEnd.DTOs.StaticsDto;
using Newtonsoft.Json;

namespace AscFrontEnd
{
    public partial class FamiliaArtigo : Form
    {
        public FamiliaArtigo()
        {
            InitializeComponent();
        }

        private async void balvarBtn_Click(object sender, EventArgs e)
        {
            string codigo = codigotxt.Text;
            string descricao = descricaotxt.Text;

            var familia = new FamiliaArtigoDTO()
            { 
                codigo = codigo,
                descricao = descricao,
                empresaId = StaticProperty.empresaId
            };

            // Configuração do HttpClient
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            client.BaseAddress = new Uri("https://sua-api.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Conversão do objeto Film para JSON
            string json = System.Text.Json.JsonSerializer.Serialize(familia);

            // Envio dos dados para a API
            var response = await client.PostAsync("https://localhost:7200/api/Artigo/Familia", new StringContent(json, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Familia Com Sucesso", "Feito Com Sucesso", MessageBoxButtons.OK);

                // Familia
                var responseFamilia = await client.GetAsync($"https://localhost:7200/api/Artigo/Familia");

                if (responseFamilia.IsSuccessStatusCode)
                {
                    var contentFamilia = await responseFamilia.Content.ReadAsStringAsync();

                    StaticProperty.familias = JsonConvert.DeserializeObject<List<FamiliaArtigoDTO>>(contentFamilia);
                }
            }
            else
            {
                MessageBox.Show("Ocorreu um erro ao tentar Salvar", "Erro", MessageBoxButtons.RetryCancel);
            }
        }

        private void FamiliaArtigo_Load(object sender, EventArgs e)
        {

        }
    }
}
