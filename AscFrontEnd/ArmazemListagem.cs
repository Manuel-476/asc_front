using AscFrontEnd.DTOs.StaticsDto;
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
using System.Text.Json;
using AscFrontEnd.DTOs.Venda;
using DocumentFormat.OpenXml.Spreadsheet;
using Color = System.Drawing.Color;

namespace AscFrontEnd
{
    public partial class ArmazemListagem : Form
    {
        int id = 0;
        bool _multi = false;

        List<int> _armazemIds;
        public ArmazemListagem()
        {
            InitializeComponent();
            _armazemIds =  new List<int>();
        }
        public ArmazemListagem(bool multi, List<int> armazemIds)
        {
            _multi = multi;

            _armazemIds = armazemIds ?? new List<int>();
            InitializeComponent();
        }

        private void ArmazemListagem_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("Codigo", typeof(string));
            dt.Columns.Add("descricao", typeof(string));
            dt.Columns.Add("P. Unitario", typeof(string));
            dt.Columns.Add("mov. Stock", typeof(string));
            dt.Columns.Add("mov. Lote", typeof(string));
            if (_multi)
            {
                dataGridView1.MultiSelect = true;
                editarPicture.Visible = false;
                eliminarPicture.Visible = false;

                // Adiciona linhas ao DataTable
                if (StaticProperty.armazens != null)
                {
                    foreach (var item in StaticProperty.armazens.Where(arm => arm.empresaId == StaticProperty.empresaId))
                    {
                        dt.Rows.Add(item.id, item.codigo, item.descricao);

                    }
                    dataGridView1.ClearSelection();
                    dataGridView1.DataSource = dt;
                }

                // Seleciona automaticamente as linhas cujos IDs estão em _artigoIds
                if (_armazemIds != null && _armazemIds.Any())
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        int id = Convert.ToInt32(row.Cells["id"].Value); // Pega o valor da coluna "id"
                        if (_armazemIds.Contains(id))
                        {
                            row.Selected = true; // Seleciona a linha
                        }
                    }
                }
            }
            else
            {
                dataGridView1.MultiSelect = false;

                if (StaticProperty.armazens != null)
                {
                    // Adicionando linhas ao DataTable
                    foreach (var item in StaticProperty.armazens.Where(arm => arm.empresaId == StaticProperty.empresaId))
                    {
                        dt.Rows.Add(item.id, item.codigo, item.descricao);

                    }
                    dataGridView1.DataSource = dt;
                }

            }
        }

        private void editarPicture_MouseMove(object sender, MouseEventArgs e)
        {
            editarPicture.BackColor = Color.Gray;
        }

        private void editarPicture_MouseLeave(object sender, EventArgs e)
        {
            editarPicture.BackColor = Color.Transparent;
        }

        private void eliminarPicture_MouseLeave(object sender, EventArgs e)
        {
            eliminarPicture.BackColor = Color.Transparent;
        }

        private void eliminarPicture_MouseMove(object sender, MouseEventArgs e)
        {
            eliminarPicture.BackColor = Color.Gray;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pesqText_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("Codigo", typeof(string));
            dt.Columns.Add("descricao", typeof(string));
            dt.Columns.Add("P. Unitario", typeof(string));
            dt.Columns.Add("mov. Stock", typeof(string));
            dt.Columns.Add("mov. Lote", typeof(string));
            if (StaticProperty.armazens != null)
            {
                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.armazens.Where(arm => arm.empresaId == StaticProperty.empresaId && (arm.codigo.Contains(pesqText.Text) || arm.descricao.Contains(pesqText.Text))))
                {
                    dt.Rows.Add(item.id, item.codigo, item.descricao);

                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void editarPicture_Click(object sender, EventArgs e)
        {
            if (id <= 0)
            {
                MessageBox.Show("Atenção", "Nenhum armazem selecionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            new ArmazemEditar(id).ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string nome = string.Empty;
                var rowsSelected = dataGridView1.SelectedRows;

                if (_armazemIds != null)
                {
                    _armazemIds.Clear();
              
                foreach (DataGridViewRow row in rowsSelected)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {
                 
                        // Obtém o valor da célula clicada
                        id = int.Parse(row.Cells[0].Value.ToString());

                        _armazemIds.Add(id);
                    }
                }
                }
            }
            catch { return; }
        }

        private async void eliminarPicture_Click(object sender, EventArgs e)
        {
            if (id <= 0)
            {
                MessageBox.Show("Atenção", "Nenhum armazem selecionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string nome = StaticProperty.armazens.Where(c => c.id == id).First().codigo;

            try
            {
                HttpResponseMessage response = null;
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
                client.BaseAddress = new Uri("http://localhost:7200/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Conversão do objeto Film para JSON
                string json = JsonSerializer.Serialize(id);

                if (MessageBox.Show($"Tens certeza que pretendes eliminar {nome}", "Atencao", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    response = await client.PutAsync($"api/Armazem/disable/{id}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Armazem foi eliminado com Sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao desactivar Armazem: {ex.Message}", "Ocorreu um erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<int> GetArmazemIdList()
        {
            return _armazemIds;
        }

        private void btnAtualizar_MouseMove(object sender, MouseEventArgs e)
        {
            btnAtualizar.BackColor = Color.White;
            btnAtualizar.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void btnAtualizar_MouseLeave(object sender, EventArgs e)
        {
            btnAtualizar.BackColor = Color.Transparent;
            btnAtualizar.ForeColor = Color.White;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
             ArmazemListagem_Load(this, EventArgs.Empty);
        }
    }
}
