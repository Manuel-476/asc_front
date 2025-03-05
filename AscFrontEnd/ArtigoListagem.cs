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
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd
{
    public partial class ArtigoListagem : Form
    {
        int id = 0;
        bool _multi = false;
        List<int> _artigoIds;
        public ArtigoListagem()
        {
            InitializeComponent();
        }

        public ArtigoListagem(bool multi)
        {
            InitializeComponent();

            _multi = multi;
            _artigoIds = new List<int>();
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
            foreach (var item in StaticProperty.artigos.Where(x => x.empresaId == StaticProperty.empresaId))
            {
                dt.Rows.Add(item.id, item.codigo, item.descricao, item.preco_unitario, item.mov_stock, item.mov_lote);

                dataGridView1.DataSource = dt;
            }

            if (_multi)
            {
                editarPicture.Visible = false;
                eliminarPicture.Visible = false;

                dataGridView1.MultiSelect = true;
            }
            else 
            {
                dataGridView1.MultiSelect = false;
            }

                editarPicture.Enabled = false;
        }

        private async void pesqText_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
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
                foreach (var item in dados.Where(x => x.empresaId == StaticProperty.empresaId))
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

        private async void pesqText_TextChanged(object sender, EventArgs e)
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
                foreach (var item in dados.Where(x => x.empresaId == StaticProperty.empresaId))
                {
                    dt.Rows.Add(item.id, item.codigo, item.descricao, item.preco_unitario, item.mov_stock, item.mov_lote);

                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

                if (_multi)
                {
                    var id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

                    if (!_artigoIds.Contains(id))
                    {
                        _artigoIds.Add(id);
                    }
                    else
                    {
                        _artigoIds.Remove(id);
                    }
                }

                if (StaticProperty.frs.Where(x => x.frArtigo.Where(f => f.artigoId == id).First().artigoId == id).First() == null &&
                   StaticProperty.fts.Where(x => x.ftArtigo.Where(f => f.artigoId == id).First().artigoId == id).First() == null &&
                   StaticProperty.fps.Where(x => x.fpArtigo.Where(f => f.artigoId == id).First().artigoId == id).First() == null &&
                   StaticProperty.ecls.Where(x => x.eclArtigo.Where(f => f.artigoId == id).First().artigoId == id).First() != null &&
                   StaticProperty.vfrs.Where(x => x.vfrArtigo.Where(f => f.artigoId == id).First().artigoId == id).First() != null &&
                   StaticProperty.vfts.Where(x => x.vftArtigo.Where(f => f.artigoId == id).First().artigoId == id).First() != null &&
                   StaticProperty.ecfs.Where(x => x.ecfArtigo.Where(f => f.artigoId == id).First().artigoId == id).First() != null &&
                   StaticProperty.cots.Where(x => x.cArtigo.Where(f => f.artigoId == id).First().artigoId == id).First() != null &&
                   StaticProperty.pcos.Where(x => x.pcArtigo.Where(f => f.artigoId == id).First().artigoId == id).First() != null)
                {
                    editarPicture.Enabled = true;
                }
                else { editarPicture.Enabled = false; }


            }
            catch { return; }
        }

        private void editarPicture_Click(object sender, EventArgs e)
        {
            new ArtigoEditar(id).ShowDialog();
        }

        private async void eliminarPicture_Click(object sender, EventArgs e)
        {
            string documento = string.Empty;
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://sua-api.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(id);

                // Envio dos dados para a API
                HttpResponseMessage response = await client.PutAsync($"https://localhost:7200/api/Artigo/disable/{id}", new StringContent(json, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Artigo desactivado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Artigo
                    var responseArtigo = await client.GetAsync($"https://localhost:7200/api/Artigo");

                    if (responseArtigo.IsSuccessStatusCode)
                    {
                        var contentArtigo = await responseArtigo.Content.ReadAsStringAsync();
                        StaticProperty.artigos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ArtigoDTO>>(contentArtigo);
                    }
                }
            }
            catch (Exception ex) 
            {
                throw new Exception($"Ocorreu um erro ao desactivar o artigo: {ex.Message}");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public List<int> GetArtigoIdList()
        {
            return _artigoIds;
        }
    }
}
