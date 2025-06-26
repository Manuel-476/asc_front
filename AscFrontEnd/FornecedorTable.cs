using AscFrontEnd.DTOs.Cliente;
using AscFrontEnd.DTOs.Fornecedor;
using AscFrontEnd.DTOs.StaticsDto;
using ERP_Buyer.Application.DTOs.Documentos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd
{
    public partial class FornecedorTable : Form
    {
        int id = 0;
        public List<FornecedorDTO> fornecedores;
        HttpClient client;
        public FornecedorTable()
        {
            InitializeComponent();
            fornecedores = new List<FornecedorDTO>();


            client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            client.BaseAddress = new Uri("http://localhost:7200/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void FornecedorTable_Load(object sender, EventArgs e)
        {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Nome", typeof(string));
                dt.Columns.Add("email", typeof(string));
                dt.Columns.Add("nif", typeof(string));
                dt.Columns.Add("pessoa", typeof(string));
                dt.Columns.Add("localizacao", typeof(string));

            if (StaticProperty.fornecedores != null)
            {
                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.fornecedores.Where(f => f.status == Status.activo && f.id != 1 && f.empresaid == StaticProperty.empresaId))
                {
                    dt.Rows.Add(item.id, item.nome_fantasia, item.email, item.nif, item.pessoa, item.localizacao);

                }
                    tabelaFornecedor.DataSource = dt;
            }
                editarPicture.Enabled = false;
        }

        private void editarPicture_MouseLeave(object sender, EventArgs e)
        {
           editarPicture.BackColor = Color.Transparent;
        }

        private void editarPicture_MouseMove(object sender, MouseEventArgs e)
        {
            editarPicture.BackColor = Color.Gray;
        }

        private void eliminarPicture_MouseMove(object sender, MouseEventArgs e)
        {
            eliminarPicture.BackColor = Color.Gray;
        }

        private async void transformar_Click(object sender, EventArgs e)
        {
            if (StaticProperty.fornecedores != null)
            {
                var fornecedor = StaticProperty.fornecedores.Where(f => f.id == id).First();


                if (fornecedor.nif == "999999999")
                {
                    fornecedor.nif = string.Empty;
                }
                // Conversão do objeto Film para JSON
                string json = JsonSerializer.Serialize(fornecedor);

                // Envio dos dados para a API
                HttpResponseMessage response = await client.PostAsync($"api/Fornecedor/Transformacao/{StaticProperty.funcionarioId}", new StringContent(json, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"O fornecedor {fornecedor.nome_fantasia} foi transformando em fornecedor", "Feito Com Sucesso", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao tentar Transformar cliente em cliente", "Erro", MessageBoxButtons.RetryCancel);
                }
            }
        }

        private void eliminarPicture_MouseLeave(object sender, EventArgs e)
        {
            eliminarPicture.BackColor = Color.Transparent;
        }

        private void transformar_MouseMove(object sender, MouseEventArgs e)
        {
            transformar.BackColor = Color.Gray;
        }

        private void transformar_MouseLeave(object sender, EventArgs e)
        {
            transformar.BackColor =Color.Transparent;
        }

        private void tabelaCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(tabelaFornecedor.Rows[e.RowIndex].Cells[0].Value.ToString());

            if (hasBuyFornecedor(id)) 
            {
                editarPicture.Enabled = true;
            }
            else 
            {
                editarPicture.Enabled = false;
            }
        }

        private async void eliminarPicture_Click(object sender, EventArgs e)
        {
            if (StaticProperty.clientes != null)
            {
                string nome = StaticProperty.clientes.Where(c => c.id == id).First().nome_fantasia;
                HttpResponseMessage response = new HttpResponseMessage();

                try
                {

                    // Conversão do objeto Film para JSON
                    string json = JsonSerializer.Serialize(id);

                    if (MessageBox.Show($"Tens certeza que pretendes eliminar {nome}", "Atencao", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        // Envio dos dados para a API


                        if (hasBuyFornecedor(id))
                        {
                            response = await client.DeleteAsync($"api/Fornecedor/{id}");
                        }
                        else { response = await client.PutAsync($"api/Fornecedor/disable/{id}", new StringContent(json, Encoding.UTF8, "application/json")); }
                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Fornecedor foi eliminado com Sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao desactivar fornecedor: {ex.Message}", "Ocorreu um erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private async void pesqText_TextChanged(object sender, EventArgs e)
        {
           
            List<FornecedorDTO> dados = null;


            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("Nome", typeof(string));
            dt.Columns.Add("email", typeof(string));
            dt.Columns.Add("nif", typeof(string));
            dt.Columns.Add("pessoa", typeof(string));
            dt.Columns.Add("localizacao", typeof(string));

            var response = await client.GetAsync($"api/Fornecedor/Search/{pesqText.Text}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                dados = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FornecedorDTO>>(content);
            }
            if (dados != null)
            {
                // Adicionando linhas ao DataTable
                foreach (var item in dados)
                {
                    dt.Rows.Add(item.id, item.nome_fantasia, item.email, item.nif, item.pessoa, item.localizacao);

                    tabelaFornecedor.DataSource = dt;
                }
            }
        }

        private void editarPicture_Click(object sender, EventArgs e)
        {
            new FornecedorEditar(id).ShowDialog();
        }

        private bool hasBuyFornecedor(int fornecedorId) 
        {
            if(!StaticProperty.vfrs.Where(x => x.fornecedorId == fornecedorId).Any() &&
               !StaticProperty.vfts.Where(x => x.fornecedorId == fornecedorId).Any() &&
               !StaticProperty.ecfs.Where(x => x.fornecedorId == fornecedorId).Any() &&
               !StaticProperty.cots.Where(x => x.fornecedorId == fornecedorId).Any() &&
               !StaticProperty.pcos.Where(x => x.fornecedorId == fornecedorId).Any() )
            { return true; }
            else { return false; }

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
            FornecedorTable_Load(this, EventArgs.Empty);
        }
    }
}
