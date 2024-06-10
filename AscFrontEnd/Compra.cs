using AscFrontEnd.DTOs.Cliente;
using AscFrontEnd.DTOs.Fornecedor;
using AscFrontEnd.DTOs.Venda;
using EAscFrontEnd;
using ERP_Buyer.Application.DTOs.Documentos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AscFrontEnd
{
    public partial class Compra : Form
    {
        public Compra()
        {
            InitializeComponent();
        }

        private async void Compra_Load(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7200/api/Artigo");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var dados = JsonConvert.DeserializeObject<List<ArtigoDTO>>(content);

                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Artigo", typeof(string));
                dt.Columns.Add("Descricao", typeof(string));
                dt.Columns.Add("preco", typeof(float));


                // Adicionando linhas ao DataTable
                foreach (var item in dados)
                {
                    dt.Rows.Add(item.id, item.codigo, item.descricao, item.preco_unitario);

                    tabelaArtigos.DataSource = dt;
                }
            }
        }

        private async void salvarBtn_Click(object sender, EventArgs e)
        {
            
                List<VfrArtigoDTO> artigos = new List<VfrArtigoDTO>();
                List<VftArtigoDTO> ftArtigos = new List<VftArtigoDTO>();
                if (documento.Text == "Fr")
            {
                VfrDTO frs = new VfrDTO()
                {
                    documento = codigoDocumento.Text,
                    data = DateTime.Now,
                    fornecedorId = ClienteDTO.clienteId,
                    frArtigo = artigos,
                    status = 1,
                };

                // Configuração do HttpClient
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://sua-api.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(frs);

                // Envio dos dados para a API
                HttpResponseMessage response = await client.PostAsync("https://localhost:7200/api/Venda/Fr", new StringContent(json, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Venda Com Sucesso", "Feito Com Sucesso", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao tentar Salvar", "Erro", MessageBoxButtons.RetryCancel);
                }
            }
            if (documento.Text == "Ft")
            {
                FtDTO vfrs = new FtDTO()
                {
                    documento = codigoDocumento.Text,
                    data = DateTime.Now,
                    fornecedrId = ClienteDTO.clienteId,
                    vftArtigo = ftArtigos,
                    status = 1,
                };

                // Configuração do HttpClient
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://sua-api.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(frs);

                // Envio dos dados para a API
                HttpResponseMessage response = await client.PostAsync("https://localhost:7200/api/Ft", new StringContent(json, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Venda Com Sucesso", "Feito Com Sucesso", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao tentar Salvar", "Erro", MessageBoxButtons.RetryCancel);
                }
            }
    }

        private void clienteBtn_Click(object sender, EventArgs e)
        {
            FornecedorListagem clienteListagem = new FornecedorListagem();
            clienteListagem.ShowDialog();
        }
    }
