using AscFrontEnd.DTOs.Cliente;
using AscFrontEnd.DTOs.StaticsDto;
using DocumentFormat.OpenXml.Office2010.Excel;
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
    public partial class ClienteListagem : Form
    {
        bool _multi = false;
        List<int> _clienteIds;
        public ClienteListagem()
        {
            InitializeComponent();
         
        }
        public ClienteListagem(bool multi,List<int> clienteIds)
        {
            InitializeComponent();

            _multi = multi;
            _clienteIds = clienteIds ?? new List<int>();
        }

        private void ClienteListagem_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("Nome", typeof(string));
            dt.Columns.Add("email", typeof(string));
            dt.Columns.Add("nif", typeof(string));
            dt.Columns.Add("pessoa", typeof(string));
            dt.Columns.Add("localizacao", typeof(string));

            if (_multi)
            {
                tabelaCliente.MultiSelect = true;
                checkDesconhecido.Visible = false;

                // Adiciona linhas ao DataTable
                foreach (var item in StaticProperty.clientes.Where(x => x.empresaid == StaticProperty.empresaId && x.id != 1 && x.status == DTOs.Enums.Enums.Status.activo))
                {
                    dt.Rows.Add(item.id, item.nome_fantasia, item.email, item.nif, item.pessoa, item.localizacao);
             
                }
                // Define o DataSource do DataGridView (fora do loop)
                tabelaCliente.DataSource = dt;

                // Seleciona automaticamente as linhas cujos IDs estão em _artigoIds
                if (_clienteIds != null && _clienteIds.Any())
                {
                    foreach (DataGridViewRow row in tabelaCliente.Rows)
                    {
                        int id = Convert.ToInt32(row.Cells["id"].Value); // Pega o valor da coluna "id"
                        if (_clienteIds.Contains(id))
                        {
                            row.Selected = true; // Seleciona a linha
                        }
                    }
                }
            }
            else
            {
                tabelaCliente.MultiSelect = false;

                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.clientes.Where(x => x.empresaid == StaticProperty.empresaId && x.id != 1 && x.status == DTOs.Enums.Enums.Status.activo))
                {
                    dt.Rows.Add(item.id, item.nome_fantasia, item.email, item.nif, item.pessoa, item.localizacao);

                }
                    tabelaCliente.DataSource = dt;

                if (StaticProperty.entityId == 1)
                {
                    checkDesconhecido.Checked = true;
                }
                else
                {
                    checkDesconhecido.Checked = false;
                }

 
            }
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            var response = await client.GetAsync($"https://localhost:7200/api/Cliente/Search/{pesqText.Text}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var dados = JsonConvert.DeserializeObject<List<ClienteDTO>>(content);

                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Nome", typeof(string));
                dt.Columns.Add("email", typeof(string));
                dt.Columns.Add("nif", typeof(string));
                dt.Columns.Add("pessoa", typeof(string));
                dt.Columns.Add("localizacao", typeof(string));


                // Adicionando linhas ao DataTable
                foreach (var item in dados.Where(x => x.empresaid == StaticProperty.empresaId))
                {
                    dt.Rows.Add(item.id, item.nome_fantasia, item.email, item.nif, item.pessoa, item.localizacao);

                    tabelaCliente.DataSource = dt;
                }
            }
        }

        private void tabelaCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string id = string.Empty;
                string nome = string.Empty;

                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Obtém o valor da célula clicada
                     id = tabelaCliente.Rows[e.RowIndex].Cells[0].Value.ToString();
                     nome = tabelaCliente.Rows[e.RowIndex].Cells[1].Value.ToString();
                }

                if (!_multi)
                {
                    if (checkDesconhecido.Checked) 
                    {
                        checkDesconhecido.Checked = false;                  
                    }

                    StaticProperty.entityId = int.Parse(id);
                    StaticProperty.nome = nome;
                    this.Close();
                }
                else 
                {
                    if (!_clienteIds.Contains(int.Parse(id))) 
                    {
                        _clienteIds.Add(int.Parse(id));
                    }
                    else 
                    {
                        _clienteIds.Remove(int.Parse(id));
                    }
                }
            }
            catch { return; }
        }

        private void tabelaCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDesconhecido.Checked) 
            {
                StaticProperty.entityId = 1;
            }
        }

        private void tabelaCliente_MultiSelectChanged(object sender, EventArgs e)
        {
           // MessageBox.Show("Estou funcionando");
        }

        public List<int> GetClienteIdList() 
        {
            return _clienteIds;
        }
    }
}
