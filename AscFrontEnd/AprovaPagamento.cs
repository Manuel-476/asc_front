using AscFrontEnd.DTOs.Serie;
using AscFrontEnd.DTOs.StaticsDto;
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
using ERP_Buyer.Application.DTOs.Documentos;

namespace AscFrontEnd
{
    public partial class AprovaPagamento : Form
    {
        private int id;
        string fornecedor = string.Empty;
        public AprovaPagamento()
        {
            InitializeComponent();
        }

        private void AprovaPagamento_Load(object sender, EventArgs e)
        {
            
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("Fornecedor", typeof(string));
            dt.Columns.Add("Documento", typeof(string));
            dt.Columns.Add("Data", typeof(string));

            // Adicionando linhas ao DataTable
            foreach (var item in StaticProperty.vfts.Where(vft => vft.apr == DTOs.Enums.Enums.OpcaoBinaria.Nao && vft.status != DTOs.Enums.Enums.DocState.anulado ).ToList())
            {
                fornecedor = StaticProperty.fornecedores.Where(f => f.id == item.fornecedorId).First().nome_fantasia;
                dt.Rows.Add(item.id,fornecedor , item.documento, item.data);

                dataGridView1.DataSource = dt;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

            DocumentosDetalhesForm documentosDetalhes = new DocumentosDetalhesForm("vft",id,DTOs.Enums.Enums.Entidade.fornecedor);
            documentosDetalhes.ShowDialog();
        }

        private async void pictureBox2_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri("https://sua-api.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(id);

                // Envio dos dados para a API
                HttpResponseMessage response = await client.PutAsync($"https://localhost:7200/api/ContaCorrente/AutorizacaoPagamento/{id}/{OpcaoBinaria.Sim}", new StringContent(json, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var responseVft = await client.GetAsync($"https://localhost:7200/api/Compra/VftByRelations");

                    if (responseVft.IsSuccessStatusCode)
                    {
                        var contentVft = await responseVft.Content.ReadAsStringAsync();
                        StaticProperty.vfts = JsonConvert.DeserializeObject<List<VftDTO>>(contentVft);

                        DataTable dt = new DataTable();
                        dt.Columns.Add("id", typeof(int));
                        dt.Columns.Add("Fornecedor", typeof(string));
                        dt.Columns.Add("Documento", typeof(string));
                        dt.Columns.Add("Data", typeof(string));

                        // Adicionando linhas ao DataTable
                        foreach (var item in StaticProperty.vfts.Where(vft => vft.apr == DTOs.Enums.Enums.OpcaoBinaria.Nao && vft.status != DTOs.Enums.Enums.DocState.anulado).ToList())
                        {
                            fornecedor = StaticProperty.fornecedores.Where(f => f.id == item.fornecedorId).First().nome_fantasia;
                            dt.Rows.Add(item.id, fornecedor, item.documento, item.data);

                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao Activar Serie: {ex.Message}", "Ocorreu um erro", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
