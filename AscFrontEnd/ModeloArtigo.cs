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
    public partial class ModeloArtigo : Form
    {
        public ModeloArtigo()
        {
            InitializeComponent();
        }

        private async void balvarBtn_Click(object sender, EventArgs e)
        {
            string codigo = codigotxt.Text;
            string descricao = descricaotxt.Text;

            var modelo = new ModeloDTO()
            {
                codigo = codigo,
                descricao = descricao,
                empresaId = StaticProperty.empresaId
            };

            // Configuração do HttpClient
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://sua-api.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Conversão do objeto Film para JSON
            string json = System.Text.Json.JsonSerializer.Serialize(modelo);

            // Envio dos dados para a API
            var response = await client.PostAsync("https://localhost:7200/api/Artigo/Modelo", new StringContent(json, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Modelo Com Sucesso", "Feito Com Sucesso", MessageBoxButtons.OK);

                //Atualizar a propriedade estatica
                // Modelo
                var responseModelo = await client.GetAsync($"https://localhost:7200/api/Artigo/Modelo");

                if (responseModelo.IsSuccessStatusCode)
                {
                    var contentModelo = await responseModelo.Content.ReadAsStringAsync();

                    StaticProperty.modelos = JsonConvert.DeserializeObject<List<ModeloDTO>>(contentModelo);
                }
            }
            else
            {
                MessageBox.Show("Ocorreu um erro ao tentar Salvar", "Erro", MessageBoxButtons.RetryCancel);
            }
        }

        private void ModeloArtigo_Load(object sender, EventArgs e)
        {

        }
    }
}
