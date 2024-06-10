using AscFrontEnd.DTOs.Fornecedor;
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
using System.Text.Json;

namespace AscFrontEnd
{
    public partial class Artigo : Form
    {
        public Artigo()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var artigo = new ArtigoDTO()
            {
              codigo = codigotxt.Text,
              armazemId = 0,
              descricao = descricaotxt.Text,
              familiaId = 1,
              subFamiliaId = 1,
              marcaId = 1,
              modeloId = 1,
              mov_stock = checkBox1.Checked?1:0,
              mov_lote = checkBox1.Checked?1:0,
              localizacaoArtigoId = 0,

            };

            // Configuração do HttpClient
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://sua-api.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Conversão do objeto Film para JSON
            string json = JsonSerializer.Serialize(artigo);

            // Envio dos dados para a API
            HttpResponseMessage response = await client.PostAsync("https://localhost:7200/api/Artigo", new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Artigo Salvo Com Sucesso", "Feito Com Sucesso", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Ocorreu um erro ao tentar Salvar", "Erro", MessageBoxButtons.RetryCancel);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listagem_Click(object sender, EventArgs e)
        {
            ArtigoListagem artigoListagem = new ArtigoListagem();
            artigoListagem.ShowDialog();
        }
    }
}
