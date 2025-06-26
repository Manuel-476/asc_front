using AscFrontEnd.DTOs.Fornecedor;
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
using AscFrontEnd.DTOs.StaticsDto;
using System.Text.Json;
using AscFrontEnd.DTOs.Deposito;
using AscFrontEnd.Application.Validacao;
using System.Globalization;
using AscFrontEnd.Application;


namespace AscFrontEnd
{
    public partial class Form1 : Form
    {
        List<FornecedorFilialDTO> filiais;
        DataTable dtFilial;
        Requisicoes _requisicoes;

        HttpClient client;
        public Form1()
        {
            InitializeComponent();
            filiais = new List<FornecedorFilialDTO> ();
           
            _requisicoes = new Requisicoes ();

            // Configuração do HttpClient
           client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:7200/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async void cadastrarBtn_Click(object sender, EventArgs e)
        {
            List<FornecedorPhoneDTO> phone = new List<FornecedorPhoneDTO>() { new FornecedorPhoneDTO() { telefone = telefonetxt.Text} };
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
                fornecedorFiliais = filias
            };



            // Conversão do objeto Film para JSON
            string json = JsonSerializer.Serialize(fornecedor);

            // Envio dos dados para a API
            HttpResponseMessage response = await client.PostAsync("api/Fornecedor", new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Dados enviados com sucesso.");

            }
            else
            {
                Console.WriteLine($"Erro ao enviar dados: {response.StatusCode}");
            }
        }

        private void adicionarBtn_Click(object sender, EventArgs e)
        {

        }

        private async void salvarBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nifText.Text.ToString()))
            {
                if (!ValidacaoForms.IsValidNif(nifText.Text.ToString()))
                {
                    MessageBox.Show("O NIF introduzido nao e valido", "Impossivel Concluir a acao", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }
            }

            if (!ValidacaoForms.IsValidEmail(emailText.Text.ToString()))
            {
                MessageBox.Show("O Email introduzido nao e valido", "Impossivel Concluir a acao", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (!string.IsNullOrEmpty(telefonetxt.Text.ToString()) && !ValidacaoForms.IsValidPhone(telefonetxt.Text.ToString()))
            {
                MessageBox.Show("O Telefone introduzido nao e valido", "Impossivel Concluir a acao", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            List<FornecedorPhoneDTO> phone = new List<FornecedorPhoneDTO>() { new FornecedorPhoneDTO() { telefone = !string.IsNullOrEmpty(telefonetxt.Text.ToString()) ?  telefonetxt.Text:string.Empty } };
            List<FornecedorFilialDTO> filias = new List<FornecedorFilialDTO> { new FornecedorFilialDTO() { email = emailText.Text,codigo=codigotxt.Text,localizacao=FiliallocalTxt.Text,nif=nifText.Text,fornFilialPhones=null,foto="string"} };

            var desconto = !string.IsNullOrEmpty(descontoTxt.Text.ToString()) ? float.Parse(descontoTxt.Text.ToString().Replace(".", "").Replace(",", "."), CultureInfo.InvariantCulture) : 0f;

            var fornecedor = new FornecedorDTO()
            {
                nome_fantasia = nomeFantasiatxt.Text,
                razao_social = razaoSocialtxt.Text,
                localizacao = localizacaotxt.Text,
                email = emailText.Text,
                espaco_fiscal = espacoFiscalCombo.Text,
                pessoa = pessoaCombo.Text,
                nif = nifText.Text,
                desconto = desconto,
                phones = phone.Any() && phone != null? phone:null,
                foto = "string",
                fornecedorFiliais = filias.Any() && filias != null?filiais:null,
                empresaid = StaticProperty.empresaId
            };

            // Conversão do objeto Film para JSON
            string json = JsonSerializer.Serialize(fornecedor);

            // Envio dos dados para a API
            HttpResponseMessage response = await client.PostAsync($"api/Fornecedor/{StaticProperty.funcionarioId}", new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Fornecedor Salvo Com Sucesso", "Feito Com Sucesso", MessageBoxButtons.OK);
                // Actualizar dados nas propriedades estaticas

                // Fornecedor
                await _requisicoes.GetFornecedores();
                // Depositos
                await _requisicoes.GetBanco();

                await _requisicoes.GetCaixa();

                pessoaCombo.Items.Clear();
                espacoFiscalCombo.Items.Clear();

                WindowsConfig.LimparFormulario(this);

                tabelaFilial.DataSource = null;

                Form1_Load(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Ocorreu um erro ao tentar Salvar", "Erro", MessageBoxButtons.RetryCancel);
            }
        }

        private void fecharBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FornecedorTable fornecedorTable = new FornecedorTable();
            fornecedorTable.ShowDialog();
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.White;
            button1.ForeColor = Color.Black;
                
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
            button1.ForeColor = Color.White;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(64,64,64);
            button2.ForeColor = Color.White;
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.BackColor = Color.White;
            button2.ForeColor = Color.Black;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtFilial = new DataTable();
            pessoaCombo.Items.Add("Singular");
            pessoaCombo.Items.Add("Colectiva");

            espacoFiscalCombo.Items.Add("Nacional");
            espacoFiscalCombo.Items.Add("Internacional");

            dtFilial.Columns.Add("id", typeof(int));
            dtFilial.Columns.Add("Codigo", typeof(string));
            dtFilial.Columns.Add("Email", typeof(string));
            dtFilial.Columns.Add("Telefone", typeof(string));
            dtFilial.Columns.Add("Localizacao", typeof(string));

            tabelaFilial.DataSource = dtFilial;
        }

        private void addFilialBtn_Click(object sender, EventArgs e)
        {
            if (filiais.Any() && filiais.Where(x => x.codigo == codigotxt.Text).Any())
            {
                MessageBox.Show("Já adicionaste uma Filial com este código", "O código já existe", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            int idFilais = tabelaFilial.Rows.Count;
            int id = 1;

            dtFilial.Rows.Clear();

            var telefone = new List<FornFilialPhoneDTO>();
               telefone.Add(new FornFilialPhoneDTO() { telefone =  filialTel.Text });

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
    }
    
}
