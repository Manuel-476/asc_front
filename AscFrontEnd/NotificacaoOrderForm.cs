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
using AscFrontEnd.Application;
using AscFrontEnd.DTOs;
using AscFrontEnd.DTOs.Funcionario;
using AscFrontEnd.DTOs.StaticsDto;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd
{
    public partial class NotificacaoOrderForm : Form
    {
        public static List<EncomendaClienteDTO> _encomendas;
        public static List<EncomendaFornecedorDTO> _encomendasForn;
        DataTable _dataTable;
        string id = string.Empty;
        string documentoDoc = string.Empty;
        HttpClient client = null;
        Entidade _entidade;
        UserDTO _user;

        public NotificacaoOrderForm(Entidade entidade,UserDTO user)
        {
            InitializeComponent();

            _entidade = entidade;
            _user = user;

            client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            client.BaseAddress = new Uri("http://localhost:7200/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        private void NotificacaoOrderForm_Load(object sender, EventArgs e)
        {

            FillTable();
            timer1.Start();
        }

        private void notificationTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void resolverPicture_Click(object sender, EventArgs e)
        {
           
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnResolver_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ao continuar a ação você mudará o estado do documento para concluído", "Informação", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
            {
                return;
            }

            HttpResponseMessage response = null;

            string json = System.Text.Json.JsonSerializer.Serialize(DocState.resolvido);

            if (_entidade == Entidade.cliente)
            {
                // Envio dos dados para a API
                response = await client.PutAsync($"api/Venda/Ecl/Change/State/{id}/{DocState.resolvido}", new StringContent(json, Encoding.UTF8, "application/json"));

                await new Requisicoes().GetEcl();
            }
            else if (_entidade == Entidade.fornecedor)
            {
                // Envio dos dados para a API
                response = await client.PutAsync($"api/Compra/Ecf/Change/State/{id}/{DocState.resolvido}", new StringContent(json, Encoding.UTF8, "application/json"));

                await new Requisicoes().GetEcf();
            }

            new MenuPrincipal(_user).RefreshSystem();

            notificationTable.DataSource = null;
            notificationTable.Rows.Clear();


            FillTable();

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show($"O documento {documentoDoc} foi resolvido com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        public void FillTable() 
        {
            _dataTable = new DataTable();

            _dataTable.Columns.Add("id", typeof(int));
            _dataTable.Columns.Add("Entidade", typeof(string));
            _dataTable.Columns.Add("Documento", typeof(string));
            _dataTable.Columns.Add("Data Entrega", typeof(DateTime));

            if (_entidade == Entidade.cliente)
            {
                if (_encomendas != null)
                {
                    foreach (var ecl in _encomendas)
                    {
                        var cliente = StaticProperty.clientes != null && StaticProperty.clientes.Where(cl => cl.id == ecl.clienteId).Any() ?
                                      StaticProperty.clientes.Where(cl => cl.id == ecl.clienteId).First().nome_fantasia : string.Empty;

                        _dataTable.Rows.Add(new object[] { ecl.id, cliente, ecl.documento, ecl.dataEntrega });
                    }
                }
            }
            else if (_entidade == Entidade.fornecedor)
            {
                if (_encomendasForn != null)
                {
                    foreach (var ecf in _encomendasForn)
                    {
                        var forn = StaticProperty.fornecedores.Where(f => f.id == ecf.fornecedorId).Any() ?
                                      StaticProperty.fornecedores.Where(f => f.id == ecf.fornecedorId).First().nome_fantasia : string.Empty;

                        _dataTable.Rows.Add(new object[] { ecf.id, forn, ecf.documento, ecf.dataEntrega });
                    }
                }
            }

            notificationTable.DataSource = _dataTable;
        }

        private void notificationTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = notificationTable.Rows[e.RowIndex].Cells[0].Value.ToString();

            documentoDoc = notificationTable.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FillTable();
        }

        private void NotificacaoOrderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            timer1.Dispose();
        }
    }
}
