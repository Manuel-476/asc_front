using AscFrontEnd.DTOs.Cliente;
using AscFrontEnd.DTOs.Funcionario;
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

        UserDTO _user;
        HttpClient client;
        public ArtigoListagem(UserDTO user)
        {
            InitializeComponent();

            _user = user;
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:7200/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public ArtigoListagem(bool multi,List<int> artigoIds)
        {
            InitializeComponent();

            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:7200/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _multi = multi;
            _artigoIds = artigoIds ?? new List<int>();


        }

        private void ArtigoListagem_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Codigo", typeof(string));
            dt.Columns.Add("descricao", typeof(string));
            dt.Columns.Add("P. Unitario", typeof(string));
            dt.Columns.Add("mov. Stock", typeof(string));
            dt.Columns.Add("mov. Lote", typeof(string));

            // Adicionando linhas ao DataTable
            if (_multi)
            {
                editarPicture.Visible = false;
                eliminarPicture.Visible = false;

                // Adiciona linhas ao DataTable
                if (StaticProperty.artigos != null)
                {
                    foreach (var item in StaticProperty.artigos.Where(x => x.empresaId == StaticProperty.empresaId))
                    {
                        dt.Rows.Add(item.id, item.codigo, item.descricao, item.preco_unitario, item.mov_stock, item.mov_lote);
                    }
                }
                // Define o DataSource do DataGridView (fora do loop)
                dataGridView1.DataSource = dt;
                dataGridView1.ClearSelection();

                // Seleciona automaticamente as linhas cujos IDs estão em _artigoIds
                if (_artigoIds != null && _artigoIds.Any())
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        int id = Convert.ToInt32(row.Cells["id"].Value); // Pega o valor da coluna "id"
                        if (_artigoIds.Contains(id))
                        {
                            row.Selected = true; // Seleciona a linha
                        }
                    }
                }

                // Opcional: Garante que o DataGridView permita seleção múltipla
                dataGridView1.MultiSelect = true;
            }
            else
            {
                if (StaticProperty.artigos != null)
                {
                    foreach (var item in StaticProperty.artigos.Where(x => x.empresaId == StaticProperty.empresaId))
                    {
                        dt.Rows.Add(item.id, item.codigo, item.descricao, item.preco_unitario, item.mov_stock, item.mov_lote);
                    }
                }
                dataGridView1.DataSource = dt;

                dataGridView1.MultiSelect = false;
            }

            editarPicture.Enabled = false;

            if (_user != null)
            {
                if (!_user.userPermissions.Where(x => x.Permission.descricao == "Editar artigo.").Any())
                {
                    editarPicture.Visible = false;
                    eliminarPicture.Visible = false;

                }
            }
        }

        private async void pesqText_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
         
            var response = await client.GetAsync($"api/Artigo/Search/{pesqText.Text}");

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
                if (dados != null)
                {
                    foreach (var item in dados.Where(x => x.empresaId == StaticProperty.empresaId))
                    {
                        dt.Rows.Add(item.id, item.codigo, item.descricao, item.preco_unitario, item.mov_stock, item.mov_lote);

                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void pesqText_TextChanged(object sender, EventArgs e)
        {
            var response = await client.GetAsync($"api/Artigo/Search/{pesqText.Text}");

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
                if (dados != null)
                {
                    foreach (var item in dados.Where(x => x.empresaId == StaticProperty.empresaId))
                    {
                        dt.Rows.Add(item.id, item.codigo, item.descricao, item.preco_unitario, item.mov_stock, item.mov_lote);

                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var rowsselected = dataGridView1.SelectedRows;

                _artigoIds.Clear();

                foreach (DataGridViewRow row in rowsselected)
                {
                   var id = int.Parse(row.Cells[0].Value.ToString());

                   _artigoIds.Add(id);


                    if (
                        StaticProperty.frs.Where(x => x.frArtigo.Where(f => f.artigoId == id).Any() && x.empresaId == StaticProperty.empresaId).FirstOrDefault() != null &&
                        StaticProperty.fts.Where(x => x.ftArtigo.Where(f => f.artigoId == id).Any() && x.empresaId == StaticProperty.empresaId).FirstOrDefault() != null &&
                        StaticProperty.fps.Where(x => x.fpArtigo.Where(f => f.artigoId == id).Any() && x.empresaId == StaticProperty.empresaId).FirstOrDefault() != null &&
                        StaticProperty.ecls.Where(x => x.eclArtigo.Where(f => f.artigoId == id).Any() && x.empresaId == StaticProperty.empresaId).FirstOrDefault() != null &&
                        StaticProperty.vfrs.Where(x => x.vfrArtigo.Where(f => f.artigoId == id).Any() && x.empresaId == StaticProperty.empresaId).FirstOrDefault() != null &&
                        StaticProperty.vfts.Where(x => x.vftArtigo.Where(f => f.artigoId == id).Any() && x.empresaId == StaticProperty.empresaId).FirstOrDefault() != null &&
                        StaticProperty.ecfs.Where(x => x.ecfArtigo.Where(f => f.artigoId == id).Any() && x.empresaId == StaticProperty.empresaId).FirstOrDefault() != null &&
                        StaticProperty.cots.Where(x => x.cArtigo.Where(f => f.artigoId == id).Any() && x.empresaId == StaticProperty.empresaId).FirstOrDefault() != null &&
                        StaticProperty.pcos.Where(x => x.pcArtigo.Where(f => f.artigoId == id).Any() && x.empresaId == StaticProperty.empresaId).FirstOrDefault() != null
                    )
                    {
                        editarPicture.Enabled = true;
                    }
                    else { editarPicture.Enabled = false; }

                }
            }
            catch { return; }
        }

        private void editarPicture_Click(object sender, EventArgs e)
        {
            new ArtigoEditar(id).ShowDialog();
        }

        private async void eliminarPicture_Click(object sender, EventArgs e)
        {

     
            try
            {
                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(id);

                // Envio dos dados para a API
                HttpResponseMessage response = await client.PutAsync($"api/Artigo/disable/{id}", new StringContent(json, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Artigo desactivado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Artigo
                    var responseArtigo = await client.GetAsync($"api/Artigo");

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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ArtigoListagem_Load(this, EventArgs.Empty);
        }

        private void btnActualizar_MouseMove(object sender, MouseEventArgs e)
        {
            btnActualizar.BackColor = Color.White;
            btnActualizar.ForeColor = Color.Black;
        }

        private void btnActualizar_MouseLeave(object sender, EventArgs e)
        {
            btnActualizar.BackColor = Color.Transparent;
            btnActualizar.ForeColor = Color.White;
        }
    }
}
