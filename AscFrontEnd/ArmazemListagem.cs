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

namespace AscFrontEnd
{
    public partial class ArmazemListagem : Form
    {
        int id;
        public ArmazemListagem()
        {
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

            // Adicionando linhas ao DataTable
            foreach (var item in StaticProperty.armazens.Where(arm => arm.empresaId == StaticProperty.empresaId))
            {
                dt.Rows.Add(item.id, item.codigo, item.descricao);

                dataGridView1.DataSource = dt;
            }
        }

        private void editarPicture_MouseMove(object sender, MouseEventArgs e)
        {
            editarPicture.BackColor = Color.Gray;
        }

        private void editarPicture_MouseLeave(object sender, EventArgs e)
        {
            editarPicture.BackColor= Color.Transparent;
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

            // Adicionando linhas ao DataTable
            foreach (var item in StaticProperty.armazens.Where(arm => arm.empresaId == StaticProperty.empresaId && (arm.codigo.Contains(pesqText.Text) || arm.descricao.Contains(pesqText.Text))))
            {
                dt.Rows.Add(item.id, item.codigo, item.descricao);

                dataGridView1.DataSource = dt;
            }
        }

        private void editarPicture_Click(object sender, EventArgs e)
        {
            new ArmazemEditar(id).ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private async void eliminarPicture_Click(object sender, EventArgs e)
        {
            string nome = StaticProperty.armazens.Where(c => c.id == id).First().codigo;


            try
            {
                HttpResponseMessage response = null;
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
                client.BaseAddress = new Uri("https://sua-api.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Conversão do objeto Film para JSON
                string json = JsonSerializer.Serialize(id);

                if (MessageBox.Show($"Tens certeza que pretendes eliminar {nome}", "Atencao", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    response = await client.PutAsync($"https://localhost:7200/api/Armazem/disable/{id}", new StringContent(json, Encoding.UTF8, "application/json")); 

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
    }
}
