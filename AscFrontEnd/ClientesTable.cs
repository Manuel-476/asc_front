using AscFrontEnd.DTOs.Cliente;
using AscFrontEnd.DTOs.StaticsDto;
using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AscFrontEnd.DTOs.Enums.Enums;


namespace AscFrontEnd
{
    public partial class ClientesTable : Form
    {
        int id=0;
        public List<ClienteDTO> clientes;
        HttpClient client;
        public ClientesTable()
        {
            InitializeComponent();
            clientes = new List<ClienteDTO>();

             client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            client.BaseAddress = new Uri("http://localhost:7200/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private  void ClientesTable_Load(object sender, EventArgs e)
        {

                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Nome", typeof(string));
                dt.Columns.Add("email", typeof(string));
                dt.Columns.Add("nif", typeof(string));
                dt.Columns.Add("pessoa", typeof(string));
                dt.Columns.Add("localizacao", typeof(string));

            if (StaticProperty.clientes != null)
            {
                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.clientes.Where(c => c.status == Status.activo && c.id != 1 && c.empresaid == StaticProperty.empresaId))
                {
                    dt.Rows.Add(item.id, item.nome_fantasia, item.email, item.nif, item.pessoa, item.localizacao);

                   
                }
                tabelaCliente.DataSource = dt;
            }
                editarPicture.Enabled = false;
        }

        private async void pesqText_TextChanged(object sender, EventArgs e)
        {
            var response = await client.GetAsync($"api/Cliente/Search/{pesqText.Text}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                clientes= Newtonsoft.Json.JsonConvert.DeserializeObject<List<ClienteDTO>>(content);

                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Nome", typeof(string));
                dt.Columns.Add("email", typeof(string));
                dt.Columns.Add("nif", typeof(string));
                dt.Columns.Add("pessoa", typeof(string));
                dt.Columns.Add("localizacao", typeof(string));

                // Adicionando linhas ao DataTable
                if (clientes != null)
                {
                    foreach (var item in clientes.Where(x => x.empresaid == StaticProperty.empresaId))
                    {
                        dt.Rows.Add(item.id, item.nome_fantasia, item.email, item.nif, item.pessoa, item.localizacao);

                    }
                        tabelaCliente.DataSource = dt;
                }
            }
        }

        private void tabelaCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(tabelaCliente.Rows[e.RowIndex].Cells[0].Value.ToString());

            if(hasSellCliente(id))
            {
                editarPicture.Enabled = true;
            }
            else { editarPicture.Enabled = false; }
        }

        private async void transformar_Click(object sender, EventArgs e)
        {
            var cliente = !StaticProperty.clientes.Where(cl => cl.id == id).Any() || StaticProperty.clientes.Where(cl => cl.id == id).First() == null ?
                           new ClienteDTO(): StaticProperty.clientes.Where(cl => cl.id == id).First();

            if(cliente.id <= 0) 
            {
                MessageBox.Show($"O cliente não foi encontrado", "Sem Sucesso", MessageBoxButtons.OK);

                return;
            }

            if(cliente.nif == "999999999") 
            {
                cliente.nif = string.Empty;
            }
            // Conversão do objeto Film para JSON
            string json = JsonSerializer.Serialize(cliente);

            // Envio dos dados para a API
            HttpResponseMessage response = await client.PostAsync($"api/Cliente/Transformacao/{StaticProperty.funcionarioId}", new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show($"O cliente {cliente.nome_fantasia} foi transformando em fornecedor", "Feito Com Sucesso", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Ocorreu um erro ao tentar Transformar cliente em fornecedor", "Erro", MessageBoxButtons.RetryCancel);
            }
        }

        private void editarPicture_Click(object sender, EventArgs e)
        {
            new ClienteEditar(id).ShowDialog();
        }

        private void editarPicture_MouseMove(object sender, MouseEventArgs e)
        {
            editarPicture.BackColor = Color.Gray;
        }

        private void editarPicture_MouseLeave(object sender, EventArgs e)
        {
            editarPicture.BackColor= Color.Transparent;
        }

        private void transformar_MouseMove(object sender, MouseEventArgs e)
        {
            transformar.BackColor = Color.Gray;
        }

        private void transformar_MouseLeave(object sender, EventArgs e)
        {
            transformar.BackColor = Color.Transparent;
        }

        private void eliminarPicture_MouseMove(object sender, MouseEventArgs e)
        {
            eliminarPicture.BackColor= Color.Gray;
        }

        private void eliminarPicture_MouseLeave(object sender, EventArgs e)
        {
            eliminarPicture.BackColor = Color.Transparent;
        }

        private async void eliminarPicture_Click(object sender, EventArgs e)
        {
            string nome = StaticProperty.clientes.Where(c => c.id == id).First().nome_fantasia;

            if (MessageBox.Show($"Tens certeza que pretendes desativar {nome}", "Atencao", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    HttpResponseMessage response = null;
         

                    // Conversão do objeto Film para JSON
                    string json = JsonSerializer.Serialize(id);

                    // Envio dos dados para a API
                    if (hasSellCliente(id)) 
                    {
                        response = await client.DeleteAsync($"api/Cliente/{id}");
                    }
                    else 
                    {
                        response = await client.PutAsync($"api/Cliente/disable/{id}", new StringContent(json, Encoding.UTF8, "application/json"));
                    }
                  

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Cliente foi eliminado com Sucesso", "Feito Com Sucesso", MessageBoxButtons.OK);
                    }
                    else 
                    {
                        MessageBox.Show("Erro ao eliminar cliente", "Sem Sucesso", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao eliminar cliente: {ex.Message}", "Ocorreu um erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }
        }

        private bool hasSellCliente(int clienteId)
        {
            if (StaticProperty.frs.Where(x => x.clienteId == clienteId).ToList() != null && StaticProperty.fts.Where(x => x.clienteId == clienteId).ToList() != null && StaticProperty.fps.Where(x => x.clienteId == clienteId).ToList() != null &&
               StaticProperty.ecls.Where(x => x.clienteId == clienteId).ToList() != null)
            {
                if (!StaticProperty.frs.Where(x => x.clienteId == clienteId).Any() && !StaticProperty.fts.Where(x => x.clienteId == clienteId).Any() && !StaticProperty.fps.Where(x => x.clienteId == clienteId).Any() &&
               !StaticProperty.ecls.Where(x => x.clienteId == clienteId).Any())
                {
                    return true;
                }
                else { return false; }
            }
            return false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ClientesTable_Load(this, EventArgs.Empty);
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
