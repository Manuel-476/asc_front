
using AscFrontEnd.DTOs.Cliente;
using AscFrontEnd.DTOs.Venda;
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
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using EAscFrontEnd;
using System.IO;

namespace AscFrontEnd
{
    public partial class Venda : Form
    {
        List<FrArtigoDTO> artigos = new List<FrArtigoDTO>();
        List<FtArtigoDTO> ftArtigos = new List<FtArtigoDTO>();
        List<EclArtigoDTO> eclArtigos = new List<EclArtigoDTO>();
       static  int artigoId = 0;
       static float precoArtigo = 0;
        public Venda()
        {
            InitializeComponent();
        }

        private async void Venda_Load(object sender, EventArgs e)
        {
            clientetxt.Text = "cliente: " + ClienteDTO.clienteId;
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

        private void clienteBtn_Click(object sender, EventArgs e)
        {
            ClienteListagem clienteListagem = new ClienteListagem();
            clienteListagem.ShowDialog();
        }

        private void tabelaArtigos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtém o valor da célula clicada
                string id = tabelaArtigos.Rows[e.RowIndex].Cells[0].Value.ToString();
                string preco = tabelaArtigos.Rows[e.RowIndex].Cells[3].Value.ToString();

                artigoId = int.Parse(id);
                precoArtigo = float.Parse(preco);


            }
        }

        private async void salvarBtn_Click(object sender, EventArgs e)
        {
            if (documento.Text == "Fr")
            {
                FrDTO frs = new FrDTO()
                {
                    documento = codigoDocumento.Text,
                    data = DateTime.Now,
                    clienteId = ClienteDTO.clienteId,
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
                FtDTO frs = new FtDTO()
                {
                    documento = codigoDocumento.Text,
                    data = DateTime.Now,
                    clienteId = ClienteDTO.clienteId,
                    ftArtigo = ftArtigos,
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

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"https://localhost:7200/api/Artigo/Search/{textBox1.Text}");

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

        private async void documento_SelectedIndexChanged(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"https://localhost:7200/api/serie/codigoDocumento/{documento.Text}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var dados = JsonConvert.DeserializeObject<string>(content);

                codigoDocumento.Text = dados;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (documento.Text == "Fr")
            {
                artigos.Add(new FrArtigoDTO()
                {
                    artigoId = artigoId,
                    preco = precoArtigo,
                    qtd = int.Parse(Qtd.Text),
                    iva = float.Parse(iva.Text)
                });

                listBox1.Items.Clear();

                foreach (FrArtigoDTO ft in artigos)
                {
                    listBox1.Items.Add(ft.artigoId + "-" + ft.preco + "-" + ft.qtd + "-" + ft.iva);
                }
            }

            if (documento.Text == "Ft")
            {
                ftArtigos.Add(new FtArtigoDTO()
                {
                    artigoId = artigoId,
                    preco = precoArtigo,
                    qtd = int.Parse(Qtd.Text),
                    iva = float.Parse(iva.Text)
                });

                listBox1.Items.Clear();

                foreach (FtArtigoDTO ft in ftArtigos)
                {
                    listBox1.Items.Add(ft.artigoId + "-" + ft.preco + "-" + ft.qtd + "-" + ft.iva);
                }
            }

        }

        private async void excelBtn_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"https://localhost:7200/api/Venda/Fr/DownloadExcel");

            if (response.IsSuccessStatusCode)
            {
                using (var streamContent = await response.Content.ReadAsStreamAsync())
                {
                    // Define o caminho onde o arquivo será salvo

                    var filePath = Path.Combine(Directory.GetCurrentDirectory() ,"Download.xlsx"); // Altere o nome do arquivo conforme necessário

                    // Salva o conteúdo da resposta em um arquivo local
                    using (var fileStream = File.Create(filePath))
                    {
                        await streamContent.CopyToAsync(fileStream);
                    }
                    MessageBox.Show("Excel Gerado", "Feito Com Sucesso", MessageBoxButtons.OK);
                }
            }
        }
    }
}