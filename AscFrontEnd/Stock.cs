using AscFrontEnd.DTOs.StaticsDto;
using AscFrontEnd.DTOs.Stock;
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
    public partial class Stock : Form
    {
        List<StockDTO> dados;
        DataTable stockTable;
        int id;
        public Stock()
        {
            InitializeComponent();

            dados = new List<StockDTO>();
            stockTable = new DataTable();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pesqText_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabelaCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void Stock_Load(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"https://localhost:7200/api/Armazem/Stock/Artigo/{StaticProperty.empresaId}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                dados = JsonConvert.DeserializeObject<List<StockDTO>>(content);

                stockTable.Columns.Add("id", typeof(int));
                stockTable.Columns.Add("Artigo", typeof(string));
                stockTable.Columns.Add("Descricao", typeof(string));
                stockTable.Columns.Add("Qtd", typeof(int));
                stockTable.Columns.Add("Estado", typeof(string));

                // Adicionando linhas ao DataTable
                foreach (var artigo in dados)
                {
                    string status = artigo.status == 0 ? "Nao Activo" : "Activo";
                    stockTable.Rows.Add(artigo.id, artigo.artigo, artigo.descricao, artigo.qtd,status );

                    tabelaInventario.DataSource = stockTable;
                }

                transferPicture.Enabled = false;
                addStockPicture.Enabled = false;
                removeStockPicture.Enabled = false;
            }
        }

        private void tabelaInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                transferPicture.Enabled = true;
                addStockPicture.Enabled = true;
                removeStockPicture.Enabled = true;

                id = int.Parse(tabelaInventario.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            catch
            {
                return;
            }
        }

        private void transferPicture_Click(object sender, EventArgs e)
        {
            StockDTO stock = dados.Where(st => st.id == id).First();

            TransferenciaArmazem ta = new TransferenciaArmazem(stock);
            ta.ShowDialog();
        }
    }
}
