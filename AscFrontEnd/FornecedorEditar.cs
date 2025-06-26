using AscFrontEnd.DTOs.Deposito;
using AscFrontEnd.DTOs.Fornecedor;
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
    public partial class FornecedorEditar : Form
    {
        int _fornecedorId;
        FornecedorDTO _fornecedor;
        List<FornecedorFilialDTO> filiais;
        DataTable dtFilial;
        HttpClient client;
        public FornecedorEditar(int fornecedorId)
        {
            InitializeComponent();
            filiais = new List<FornecedorFilialDTO>();
            dtFilial = new DataTable();
            _fornecedorId = fornecedorId;
            _fornecedor = StaticProperty.fornecedores.Where(x => x.id == _fornecedorId).First();

            client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            client.BaseAddress = new Uri("http://localhost:7200/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void FornecedorEditar_Load(object sender, EventArgs e)
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

            foreach (var cl in _fornecedor.fornecedorFiliais)
            {
                dtFilial.Rows.Add(cl);
            }

            tabelaFilial.DataSource = dtFilial;

            nomeFantasiatxt.Text = _fornecedor.nome_fantasia.ToString();
            nomeFiscal.Text = _fornecedor.nome_fantasia.ToString();
            nifText.Text = _fornecedor.nif.ToString();
            localizacaotxt.Text = _fornecedor.localizacao.ToString();
            emailText.Text = _fornecedor.email.ToString();
            telefonetxt.Text = _fornecedor.phones.First().ToString();
        }

        private void addFilialBtn_Click(object sender, EventArgs e)
        {
            int idFilais = tabelaFilial.Rows.Count;
            int id = 1;

            dtFilial.Rows.Clear();

            var telefone = new List<FornFilialPhoneDTO>();
            telefone.Add(new FornFilialPhoneDTO() { telefone = filialTel.Text });

            filiais.Add(new FornecedorFilialDTO()
            {
                codigo = codigotxt.Text,
                email = Emailfilialtxt.Text,
                fornFilialPhones = telefone,
                localizacao = FiliallocalTxt.Text,
            });

            foreach (var f in filiais)
            {

                dtFilial.Rows.Add(id, f.codigo, f.email, f.fornFilialPhones.First().telefone, f.localizacao);

                id++;
            }
            tabelaFilial.DataSource = dtFilial;
        }

        private async void salvarBtn_Click(object sender, EventArgs e)
        {
            List<FornecedorPhoneDTO> phone = new List<FornecedorPhoneDTO>() { new FornecedorPhoneDTO() { telefone = telefonetxt.Text } };
            List<FornecedorFilialDTO> filias = new List<FornecedorFilialDTO> { new FornecedorFilialDTO() { email = emailText.Text,codigo=codigotxt
           .Text,localizacao=FiliallocalTxt.Text,nif=nifText.Text,fornFilialPhones=null,foto="string"} };
            var fornecedor = new FornecedorDTO()
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
                fornecedorFiliais = filias,
                empresaid = StaticProperty.empresaId
            };



            // Conversão do objeto Film para JSON
            string json = JsonSerializer.Serialize(fornecedor);

            if (MessageBox.Show("Tens certeza que queres salvar estas alterações?", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
            {
                // Envio dos dados para a API
                HttpResponseMessage response = await client.PostAsync($"api/Fornecedor/{_fornecedorId}/{StaticProperty.funcionarioId}", new StringContent(json, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Fornecedor Alterado Com Sucesso", "Feito Com Sucesso", MessageBoxButtons.OK);
                    // Actualizar dados nas propriedades estaticas

                    // Fornecedor
                    var responseFornecedor = await client.GetAsync($"api/Fornecedor/FornecedoresByRelation");

                    if (responseFornecedor.IsSuccessStatusCode)
                    {
                        var contentFornecedor = await responseFornecedor.Content.ReadAsStringAsync();
                        StaticProperty.fornecedores = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FornecedorDTO>>(contentFornecedor);
                    }

                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao tentar alterar os dados", "Erro", MessageBoxButtons.RetryCancel);
                }
            }
        }
    }
}
