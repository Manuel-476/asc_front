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
        List<LocationArtigoDTO> dados;
        DataTable stockTable;
        public Stock()
        {
            InitializeComponent();

            dados = new List<LocationArtigoDTO>();
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
                dados = JsonConvert.DeserializeObject<List<LocationArtigoDTO>>(content);

                stockTable.Columns.Add("id", typeof(int));
                stockTable.Columns.Add("Artigo", typeof(string));
                stockTable.Columns.Add("Descricao", typeof(float));
                stockTable.Columns.Add("Qtd", typeof(int));
                stockTable.Columns.Add("Estado", typeof(float));

                // Adicionando linhas ao DataTable
                foreach (var artigo in dados)
                {
                    string status = artigo.Artigo.status == 0 ? "Nao Activo" : "Activo";
                    stockTable.Rows.Add(artigo.artigoId, artigo.Artigo.codigo, artigo.Artigo.descricao, artigo.qtd,status );

                    tabelaInventario.DataSource = stockTable;
                }

             //   eliminarBtn.Enabled = false;

            }
        }
    }
}
