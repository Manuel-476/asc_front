using AscFrontEnd.DTOs.StaticsDto;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
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
using Color = System.Drawing.Color;
using AscFrontEnd.DTOs.Fornecedor;
using AscFrontEnd.DTOs;
using AscFrontEnd.DTOs.Funcionario;
using ERP_Buyer.Application.DTOs.Documentos;
using Newtonsoft.Json;


namespace AscFrontEnd
{
    public partial class FuncionarioListagem : Form
    {
        public int id;
        HttpClient client;
        public FuncionarioListagem()
        {
            InitializeComponent();

            client = new HttpClient();
            
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            client.BaseAddress = new Uri("http://localhost:7200");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void editarPicture_MouseMove(object sender, MouseEventArgs e)
        {
            editarPicture.BackColor = Color.Gray;
        }

        private void editarPicture_MouseLeave(object sender, EventArgs e)
        {
            editarPicture.BackColor = Color.Transparent;
        }

        private void eliminarPicture_MouseMove(object sender, MouseEventArgs e)
        {
            eliminarPicture.BackColor = Color.Gray;
        }

        private void eliminarPicture_MouseLeave(object sender, EventArgs e)
        {
            eliminarPicture.BackColor = Color.Transparent;
        }

        private void FuncionarioListagem_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("Nome", typeof(string));
            dt.Columns.Add("email", typeof(string));
            dt.Columns.Add("nif", typeof(string));
            dt.Columns.Add("pessoa", typeof(string));
            dt.Columns.Add("localizacao", typeof(string));
            dt.Columns.Add("Data Nascimento", typeof(string));

            // Adicionando linhas ao DataTable
            if(StaticProperty.funcionarios != null) 
            { 
              foreach (var item in StaticProperty.funcionarios.Where(f => f.status == DTOs.Enums.Enums.Status.activo && f.empresaid == StaticProperty.empresaId))
              {
                  dt.Rows.Add(item.Id, item.Nome, item.email, item.nif, item.morada, item.data_nascimento);

              }
                   dataGridView1.DataSource = dt;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private async void eliminarPicture_Click(object sender, EventArgs e)
        {
            string nome = StaticProperty.funcionarios.Where(f => f.Id == id).First().Nome;
            if (MessageBox.Show($"Tens certeza que pretendes desativar {nome}", "Atencao", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try 
                { 
                   // Conversão do objeto Film para JSON
                   string json = System.Text.Json.JsonSerializer.Serialize(id);

                   // Envio dos dados para a API
                   HttpResponseMessage response = await client.PutAsync($"api/Funcionario/disable/{id}", new StringContent(json, Encoding.UTF8, "application/json"));

                   if (response.IsSuccessStatusCode)
                   {
                    MessageBox.Show("Funcionario foi desativado com Sucesso", "Feito Com Sucesso", MessageBoxButtons.OK);
                   }
                }
                catch(Exception ex) 
                {
                    MessageBox.Show($"Erro ao desactivar funcionario: {ex.Message}", "Ocorreu um erro", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            { 
                return;
            }
        }

        private async void pesqText_TextChanged(object sender, EventArgs e)
        {
            List<FuncionarioDTO> dados = null;
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("Nome", typeof(string));
            dt.Columns.Add("email", typeof(string));
            dt.Columns.Add("nif", typeof(string));
            dt.Columns.Add("pessoa", typeof(string));
            dt.Columns.Add("localizacao", typeof(string));
            dt.Columns.Add("Data Nascimento", typeof(string));

            var response = await client.GetAsync($"/api/Funcionario/Search/{pesqText.Text}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                dados = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FuncionarioDTO>>(content);
            }
            if (dados != null)
            {
                // Adicionando linhas ao DataTable
                foreach (var item in dados)
                {
                    dt.Rows.Add(item.Id, item.Nome, item.email, item.nif, item.morada, item.data_nascimento);

                    dataGridView1.DataSource = dt;
                }
            }
        }

        private async void editarPicture_Click(object sender, EventArgs e)
        {
            var response = await client.GetAsync($"/api/Funcionario/User/GetUser/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var user = JsonConvert.DeserializeObject<UserDTO>(content);

                if(user == null) 
                {
                    MessageBox.Show("Nenhum registro encontrado", "Funcionário Sem Credências de usuario", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                    return;
                }

                new PermissionsForm(user, DTOs.Enums.Enums.Acao.Editar).ShowDialog();
            }
            else 
            {
                MessageBox.Show("Ocorreu um Erro","Não foi possivel acessar as permissões do funcionario",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
            
                return;
            }
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.White; 
            button1.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(64, 64, 64);
            button1.ForeColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void FuncionarioListagem_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
