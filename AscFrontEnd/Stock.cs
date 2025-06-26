using AscFrontEnd.Application.Validacao;
using AscFrontEnd.DTOs.Funcionario;
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
using System.Net.Http.Headers;
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
        HttpClient client;

        UserDTO _user;

        public Stock(UserDTO user)
        {
            InitializeComponent();

            dados = new List<StockDTO>();
          
            client = new HttpClient();

            _user = user;

            client.BaseAddress = new Uri("http://localhost:7200");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void pesqText_TextChanged(object sender, EventArgs e)
        {
          
            var response = await client.GetAsync($"api/Armazem/Stock/Artigo/{StaticProperty.empresaId}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                dados = JsonConvert.DeserializeObject<List<StockDTO>>(content);
                stockTable = new DataTable();
                stockTable.Columns.Add("id", typeof(int));
                stockTable.Columns.Add("Artigo", typeof(string));
                stockTable.Columns.Add("Descricao", typeof(string));
                stockTable.Columns.Add("Qtd", typeof(int));
                stockTable.Columns.Add("Estado", typeof(string));

                if (dados != null)
                {
                    // Adicionando linhas ao DataTable
                    foreach (var artigo in dados.Where(x => x.artigo.Contains(pesqText.Text) || x.descricao.Contains(pesqText.Text)))
                    {
                        string status = artigo.status == 0 ? "Nao Activo" : "Activo";
                        stockTable.Rows.Add(artigo.id, artigo.artigo, artigo.descricao, artigo.qtd, status);

                        tabelaInventario.DataSource = stockTable;
                    }
                }
                transferPicture.Enabled = false;
                addStockPicture.Enabled = false;
                removeStockPicture.Enabled = false;
            }
        }

        private void tabelaCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void Stock_Load(object sender, EventArgs e)
        {
            stockTable = new DataTable();
            var response = await client.GetAsync($"api/Armazem/Stock/Artigo/{StaticProperty.empresaId}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                dados = JsonConvert.DeserializeObject<List<StockDTO>>(content);

                stockTable.Columns.Add("id", typeof(int));
                stockTable.Columns.Add("Artigo", typeof(string));
                stockTable.Columns.Add("Descricao", typeof(string));
                stockTable.Columns.Add("Qtd", typeof(int));
                stockTable.Columns.Add("Estado", typeof(string));

                if (dados != null)
                {
                    // Adicionando linhas ao DataTable
                    foreach (var artigo in dados)
                    {
                        string status = artigo.status == 0 ? "Nao Activo" : "Activo";
                        stockTable.Rows.Add(artigo.id, artigo.artigo, artigo.descricao, artigo.qtd, status);

                    }
                        tabelaInventario.DataSource = stockTable;
                }
                if (_user.userPermissions.FirstOrDefault().Permission != null)
                {
                    if (!_user.userPermissions.Where(x => x.Permission.descricao == "Gerenciar movimentações de estoque.").Any())
                    {
                        transferPicture.Visible = false;
                        addStockPicture.Visible = false;
                        removeStockPicture.Visible = false;
                    }
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

                artigoTexto.Text ="Artigo: " + StaticProperty.artigos != null && StaticProperty.artigos.Where(art => art.id == id && art.empresaId == StaticProperty.empresaId).Any()? StaticProperty.artigos.Where(art => art.id == id && art.empresaId == StaticProperty.empresaId).First().codigo : string.Empty;
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

        private void addStockPicture_Click(object sender, EventArgs e)
        {
            var dado = dados.Where(x => x.id == id).First();
            var artigo = StaticProperty.artigos != null && StaticProperty.artigos.Where(x => x.codigo == dado.artigo && x.empresaId == StaticProperty.empresaId).Any() ? StaticProperty.artigos.Where(x => x.codigo == dado.artigo && x.empresaId == StaticProperty.empresaId).First() : new ArtigoDTO();

            IncrementarStock incrementar = new IncrementarStock(artigo,dado.qtd);
            incrementar.ShowDialog();
        }

        private void removeStockPicture_Click(object sender, EventArgs e)
        {
            var dado = dados != null && dados.Where(x => x.id == id).Any() ? dados.Where(x => x.id == id).First() : new StockDTO();
            var artigo = StaticProperty.artigos != null && StaticProperty.artigos.Where(x => x.codigo == dado.artigo && x.empresaId == StaticProperty.empresaId).Any() ? StaticProperty.artigos.Where(x => x.codigo == dado.artigo && x.empresaId == StaticProperty.empresaId).First() : new ArtigoDTO();

            DecrementarStock decrementar = new DecrementarStock(artigo, dado.qtd);
            decrementar.ShowDialog();
        }

        private void transferPicture_MouseMove(object sender, MouseEventArgs e)
        {
            transferPicture.BackColor = Color.Gray;
        }

        private void transferPicture_MouseLeave(object sender, EventArgs e)
        {
            transferPicture.BackColor = Color.Transparent;
        }

        private void addStockPicture_MouseMove(object sender, MouseEventArgs e)
        {
            addStockPicture.BackColor = Color.Gray;
        }

        private void addStockPicture_MouseLeave(object sender, EventArgs e)
        {
            addStockPicture.BackColor= Color.Transparent;
        }

        private void removeStockPicture_MouseMove(object sender, MouseEventArgs e)
        {
            removeStockPicture.BackColor = Color.Gray;
        }

        private void removeStockPicture_MouseLeave(object sender, EventArgs e)
        {
            removeStockPicture.BackColor = Color.Transparent;
        }

        private void transferPicture_MouseEnter(object sender, EventArgs e)
        {
            transferPicture.BackColor = Color.Gray;
        }
    }
}
