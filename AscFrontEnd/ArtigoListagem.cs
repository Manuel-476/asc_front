using AscFrontEnd.DTOs.Cliente;
using AscFrontEnd.DTOs.StaticsDto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AscFrontEnd
{
    public partial class ArtigoListagem : Form
    {
        public ArtigoListagem()
        {
            InitializeComponent();
        }

        private async void ArtigoListagem_Load(object sender, EventArgs e)
        {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Codigo", typeof(string));
                dt.Columns.Add("descricao", typeof(string));
                dt.Columns.Add("P. Unitario", typeof(string));
                dt.Columns.Add("mov. Stock", typeof(string));
                dt.Columns.Add("mov. Lote", typeof(string));


                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.artigos)
                {
                    dt.Rows.Add(item.id, item.codigo, item.descricao, item.preco_unitario, item.mov_stock, item.mov_lote);

                    dataGridView1.DataSource = dt;
                }     
        }

        private async void pesqText_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"https://localhost:7200/api/Artigo/Search/{pesqText.Text}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var dados = JsonConvert.DeserializeObject<List<ArtigoDTO>>(content);


                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Codigo", typeof(string));
                dt.Columns.Add("descricao", typeof(string));
                dt.Columns.Add("P. Unitario", typeof(string));
                dt.Columns.Add("mov. Stock", typeof(string));
                dt.Columns.Add("mov. Lote", typeof(string));


                // Adicionando linhas ao DataTable
                foreach (var item in dados)
                {
                    dt.Rows.Add(item.id, item.codigo, item.descricao, item.preco_unitario, item.mov_stock, item.mov_lote);

                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
