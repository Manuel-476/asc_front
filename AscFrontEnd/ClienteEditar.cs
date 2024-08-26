using AscFrontEnd.DTOs.Cliente;
using AscFrontEnd.DTOs.Deposito;
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
    public partial class ClienteEditar : Form
    {
        List<ClienteFilialDTO> filiais;
        DataTable dtFilial;
        ClienteDTO _cliente;
        int _clienteId;
        public ClienteEditar(int clienteId)
        {
            InitializeComponent();
            filiais = new List<ClienteFilialDTO>();
            dtFilial = new DataTable();
            _clienteId = clienteId;
            _cliente = StaticProperty.clientes.Where(x => x.id == _clienteId).First();
        }

        private void ClienteEditar_Load(object sender, EventArgs e)
        {
            pessoaCombo.Items.Add("Singular");
            pessoaCombo.Items.Add("Colectiva");

            espacoFiscalCombo.Items.Add("Nacional");
            espacoFiscalCombo.Items.Add("Internacional");

            dtFilial.Columns.Add("id", typeof(int));
            dtFilial.Columns.Add("Codigo", typeof(string));
            dtFilial.Columns.Add("Email", typeof(string));
            dtFilial.Columns.Add("Telefone", typeof(string));
            dtFilial.Columns.Add("Localizacao", typeof(string));

            foreach (var cl in _cliente.clienteFiliais) 
            {
                dtFilial.Rows.Add(cl);
            }
            tabelaFilial.DataSource = dtFilial;

            nomeFantasiatxt.Text = _cliente.nome_fantasia.ToString();
            nomeFiscal.Text = _cliente.nome_fantasia.ToString();
            nifText.Text = _cliente.nif.ToString();
            localizacaotxt.Text = _cliente.localizacao.ToString();
            emailText.Text = _cliente.email.ToString();
            telefonetxt.Text = _cliente.phones.First().ToString();

        }
        private async void salvarBtn_Click(object sender, EventArgs e)
        {
            List<ClientePhoneDTO> phone = new List<ClientePhoneDTO>() { new ClientePhoneDTO() { telefone = telefonetxt.Text } };
            List<ClienteFilialDTO> filias = new List<ClienteFilialDTO> { new ClienteFilialDTO() { email = emailText.Text,codigo=codigotxt
           .Text,localizacao=FiliallocalTxt.Text,nif=nifText.Text,filialPhones=null,foto="string"} };

            var cliente = new ClienteDTO()
            {
                nome_fantasia = nomeFantasiatxt.Text,
                razao_social = razaoSocialtxt.Text,
                localizacao = localizacaotxt.Text,
                email = emailText.Text,
                espaco_fiscal = espacoFiscalCombo.Text,
                pessoa = pessoaCombo.Text,
                nif = nifText.Text,
                phones = phone,
                foto = "string",
                clienteFiliais = filias,
                empresaid = StaticProperty.empresaId
            };

            // Configuração do HttpClient
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            client.BaseAddress = new Uri("https://sua-api.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Conversão do objeto Film para JSON
            string json = JsonSerializer.Serialize(cliente);
            if (MessageBox.Show("Tens certeza que queres salvar estas alterações?", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
            {
                // Envio dos dados para a API
                HttpResponseMessage response = await client.PutAsync($"https://localhost:7200/api/Cliente/{StaticProperty.funcionarioId}", new StringContent(json, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cliente alterado Com Sucesso", "Feito Com Sucesso", MessageBoxButtons.OK);

                    var responseCliente = await client.GetAsync($"https://localhost:7200/api/Cliente/ClientesByRelations");

                    if (responseCliente.IsSuccessStatusCode)
                    {
                        var contentCliente = await responseCliente.Content.ReadAsStringAsync();
                        StaticProperty.clientes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ClienteDTO>>(contentCliente);
                    }

                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao tentar Salvar", "Erro", MessageBoxButtons.RetryCancel);
                }
            }
        }
        private void addFilialBtn_Click(object sender, EventArgs e)
        {
            int idFilais = tabelaFilial.Rows.Count;
            int id = 1;

            dtFilial.Rows.Clear();

            var telefone = new List<FilialPhoneDTO>();
            telefone.Add(new FilialPhoneDTO() { telefone = filialTel.Text });

            filiais.Add(new ClienteFilialDTO()
            {
                codigo = codigotxt.Text,
                email = Emailfilialtxt.Text,
                filialPhones = telefone,
                localizacao = FiliallocalTxt.Text,
            });

            foreach (var f in filiais)
            {

                dtFilial.Rows.Add(id, f.codigo, f.email, f.filialPhones.First().telefone, f.localizacao);

                id++;
            }
            tabelaFilial.DataSource = dtFilial;
        }
    }
}
