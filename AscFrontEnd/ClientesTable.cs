using AscFrontEnd.DTOs.Cliente;
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
    public partial class ClientesTable : Form
    {
        int id=0;
        public ClientesTable()
        {
            InitializeComponent();
        }

        private async void ClientesTable_Load(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7200/api/Cliente");

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
                foreach (var item in dados)
                {
                    dt.Rows.Add(item.id, item.nome_fantasia, item.email, item.nif, item.pessoa, item.localizacao);

                    tabelaCliente.DataSource = dt;
                }
            }
        }

        private async void pesqText_TextChanged(object sender, EventArgs e)
        {
            var client = new HttpClient();
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
                foreach (var item in dados)
                {
                    dt.Rows.Add(item.id, item.nome_fantasia, item.email, item.nif, item.pessoa, item.localizacao);

                    tabelaCliente.DataSource = dt;
                }
            }
        }

        private void tabelaCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(tabelaCliente.Rows[e.RowIndex].Cells[0].Value.ToString());
        }
    }
}
