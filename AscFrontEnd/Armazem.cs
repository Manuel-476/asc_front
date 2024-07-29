using AscFrontEnd.DTOs.StaticsDto;
using AscFrontEnd.DTOs.Stock;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;

namespace AscFrontEnd
{
    public partial class Armazem : Form
    {
        DataTable dt;
        List<LocationStoreDTO> localizacao;
        List<int> idLocal;
        public Armazem()
        {
            InitializeComponent();
            dt = new DataTable();
            localizacao = new List<LocationStoreDTO>();
            idLocal = new List<int>();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Armazem_Load(object sender, EventArgs e)
        {
            pictureBox4.Enabled = false;
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Codigo", typeof(string));
            dt.Columns.Add("Descricao", typeof(string));
            dt.Columns.Add("Localizacao Fisica", typeof(string));

            localizacaoTable.DataSource = dt;
        }

        private void adicionarLocalizacao_Click(object sender, EventArgs e)
        {
          
        }

        private async void salvar_Click(object sender, EventArgs e)
        {
            List<LocationStoreDTO> location = new List<LocationStoreDTO>();
            foreach (var local in localizacao)
            {
                local.id = 0;
                location.Add(local);
            }
            var armazem = new ArmazemDTO() 
            {
                codigo = codigoArmazemtxt.Text,
                descricao = descricaoArmazem.Text,
                sectorId = 0,
                funcionarioId = 0,
                empresaId = 0,
                status = 1,
                storeLocations = location
            };

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://sua-api.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Conversão do objeto Film para JSON
            string json = System.Text.Json.JsonSerializer.Serialize(armazem);

            // Envio dos dados para a API
            HttpResponseMessage response = await client.PostAsync($"https://localhost:7200/api/Armazem/{1}", new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Armazem Com Sucesso", "Feito Com Sucesso", MessageBoxButtons.OK);
                //Actualizar propriedade estatica armazem
                // Amazem
                var responseArmazem = await client.GetAsync($"https://localhost:7200/api/Armazem/ArmazensByRelations");

                if (responseArmazem.IsSuccessStatusCode)
                {
                    var contentArmazem = await responseArmazem.Content.ReadAsStringAsync();
                    StaticProperty.armazens = JsonConvert.DeserializeObject<List<ArmazemDTO>>(contentArmazem);
                }
            }
            else
            {
                MessageBox.Show("Ocorreu um erro ao tentar Salvar", "Erro", MessageBoxButtons.RetryCancel);
            }

        }

        private void localizacaoTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            pictureBox4.Enabled = true;

        }

        private void eliminarBtn_Click(object sender, EventArgs e)
        {
          
        }

        private void localizacaoTable_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void localizacaoTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pictureBox4.Enabled = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            int id = localizacaoTable.Rows.Count;
            dt.Rows.Clear();
            localizacaoTable.DataSource = dt;


            localizacao.Add(new LocationStoreDTO
            {
                id = id,
                codigo = codigoLocalizacao.Text.ToString(),
                descricao = descricaoLocalizacao.Text.ToString(),
                localizacao_fisica = localizacaoFisica.Text.ToString()
            });

            foreach (var local in localizacao)
            {
                string fisica = local.localizacao_fisica.ToString();
                dt.Rows.Add(local.id, local.codigo.ToString(), local.descricao.ToString(), local.localizacao_fisica.ToString());

                localizacaoTable.DataSource = dt;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            var selectedRows = localizacaoTable.SelectedRows;

            foreach (DataGridViewRow row in selectedRows)
            {
                if (row != null && row.Index >= 0) // Verifica se a linha está válida
                {
                    int id = int.Parse(row.Cells[0].Value?.ToString()); // Substitua 0 pelo índice da coluna desejada
                                                                        // Ou faça algo mais útil com o valor
                    idLocal.Add(id);
                }
            }

            foreach (int id in idLocal)
            {
                var result = localizacao.Where(c => c.id == id).First();

                int index = localizacao.IndexOf(result);

                localizacao.RemoveAt(index);
            }

            dt.Rows.Clear();
            localizacaoTable.DataSource = dt;


            foreach (var local in localizacao)
            {
                string fisica = local.localizacao_fisica.ToString();
                dt.Rows.Add(local.id, local.codigo.ToString(), local.descricao.ToString(), local.localizacao_fisica.ToString());

                localizacaoTable.DataSource = dt;
            }
            idLocal.Clear();
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
            button1.ForeColor = Color.White;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.White;
            button1.ForeColor = Color.Black;
        }
    }
}
