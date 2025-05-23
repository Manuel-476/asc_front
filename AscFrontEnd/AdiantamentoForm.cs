using AscFrontEnd.DTOs.StaticsDto;
using AscFrontEnd.DTOs.Stock;
using Newtonsoft.Json;
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
using AscFrontEnd.DTOs.ContasCorrentes;
using AscFrontEnd.Application;
using AscFrontEnd.Application.Validacao;
using System.Globalization;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd
{
    public partial class AdiantamentoForm : Form
    {
        string _nomeEntidadeStr = string.Empty;
        AdiantamentoFornDTO _adiantamentoFornecedor;
        AdiantamentoClienteDTO _adiantamentoCliente;
        DataTable _adiantamentoDataTable;
        Requisicoes _requisicoes;

        public AdiantamentoForm()
        {
            InitializeComponent();
            _requisicoes = new Requisicoes();
            valorTxt.KeyPress += ValidacaoForms.TratarKeyPress; // Ajustado
            valorTxt.TextChanged += ValidacaoForms.TratarTextChanged;
        }

        private void AdiantamentoForm_Load(object sender, EventArgs e)
        {
            radioCliente.Checked = true;

            timer1.Start();
        }

        private void radioCliente_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void botaoFornecedor_MouseMove(object sender, MouseEventArgs e)
        {
            botaoEntidade.BackColor = Color.White;
            botaoEntidade.ForeColor = Color.FromArgb(64,64,64);
        }

        private void botaoFornecedor_MouseLeave(object sender, EventArgs e)
        {
            botaoEntidade.BackColor = Color.Transparent;
            botaoEntidade.ForeColor = Color.White;
        }

        private void botaoCliente_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void botaoCliente_MouseLeave(object sender, EventArgs e)
        {

        }

        private void botaoFornecedor_Click(object sender, EventArgs e)
        {
            if (radioFornecedor.Checked)
            {
                FornecedorListagem form = new FornecedorListagem();
                form.ShowDialog();
            }
            else if (radioCliente.Checked) 
            {
                ClienteListagem form = new ClienteListagem();
                form.ShowDialog();
            }
        }

        private void botaoCliente_Click(object sender, EventArgs e)
        {

        }

        private void radioFornecedor_CheckedChanged(object sender, EventArgs e)
        {

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            HttpResponseMessage response = null;
            string json;
            string codigoDocumento;
            string documento;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            client.BaseAddress = new Uri("https://sua-api.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if(StaticProperty.entityId <= 0) 
            {
                MessageBox.Show("Selecione alguma entidade","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Information);

                return;
            }

            if (!OutrasValidacoes.SerieExist()) 
            {
                return;
            }
            var valor = !string.IsNullOrEmpty(valorTxt.Text.ToString()) ? float.Parse(valorTxt.Text.ToString().Replace(".", "").Replace(",", "."), CultureInfo.InvariantCulture) : 0f;
            if (radioFornecedor.Checked) 
            {
                documento = "ADF";

                codigoDocumento = await Documento.GetCodigoDocumentoAsync(documento);

                _adiantamentoFornecedor = new AdiantamentoFornDTO() { fornecedorId = StaticProperty.entityId,
                                                                     state = DTOs.Enums.Enums.DocState.ativo,
                                                                     documento = codigoDocumento,
                                                                     valorAdiantado = valor
                };

                json = System.Text.Json.JsonSerializer.Serialize(_adiantamentoFornecedor);

                response = await client.PostAsync($"https://localhost:7200/api/ContaCorrente/Adiantamento/Fornecedor", new StringContent(json, Encoding.UTF8, "application/json"));

            }

            if (radioCliente.Checked)
            {
                documento = "ADC";

                codigoDocumento = await Documento.GetCodigoDocumentoAsync(documento);

                _adiantamentoCliente = new AdiantamentoClienteDTO()
                {
                    clienteId = StaticProperty.entityId,
                    state = DTOs.Enums.Enums.DocState.ativo,
                    documento = codigoDocumento.Replace("\"",""),
                    valorAdiantado = valor
                };

                json = System.Text.Json.JsonSerializer.Serialize(_adiantamentoCliente);

                response = await client.PostAsync($"https://localhost:7200/api/ContaCorrente/Adiantamento/Cliente", new StringContent(json, Encoding.UTF8, "application/json"));
            }

            // Envio dos dados para a API
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Adiantamento Com Sucesso", "Feito Com Sucesso", MessageBoxButtons.OK);

                await _requisicoes.GetAdFornecedor();
                await _requisicoes.GetAdCliente();
            }
            else 
            {
                MessageBox.Show("Nao foi possivel fazer o adiantamento", "Ocorreu um erro", MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
            }

            await _requisicoes.GetAdFornecedor();
            await _requisicoes.GetAdCliente();

            WindowsConfig.LimparFormulario(this);

            adiantamentosTable.DataSource = null;

            AdiantamentoForm_Load(this, EventArgs.Empty);
        }

        private void valorTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _adiantamentoDataTable = new DataTable();

            _adiantamentoDataTable.Columns.Add("Id",typeof(int));
            _adiantamentoDataTable.Columns.Add("Documento", typeof(string));
            _adiantamentoDataTable.Columns.Add("Valor", typeof(string));
            _adiantamentoDataTable.Columns.Add("Data", typeof(DateTime));

            if (StaticProperty.entityId > 0) 
            { 
              if (radioFornecedor.Checked) 
              {
                    nomeEntidade.Text = StaticProperty.fornecedores.Where(x => x.id == StaticProperty.entityId).First().nome_fantasia;

                    foreach (var item in StaticProperty.adiantamentoForns.Where(x => x.fornecedorId == StaticProperty.entityId && x.resolvido == OpcaoBinaria.Nao)) 
                    {
                        _adiantamentoDataTable.Rows.Add(new object[] {item.id,item.documento,item.valorAdiantado.ToString("F2"),item.created_at});
                    }
              }
              else if (radioCliente.Checked)
              {
                    nomeEntidade.Text = StaticProperty.clientes.Where(x => x.id == StaticProperty.entityId).First().nome_fantasia;

                    foreach (var item in StaticProperty.adiantamentoClientes.Where(x => x.clienteId == StaticProperty.entityId && x.resolvido == OpcaoBinaria.Nao))
                    {
                        _adiantamentoDataTable.Rows.Add(new object[] { item.id, item.documento, item.valorAdiantado.ToString("F2"), item.created_at });
                    }
                }

                adiantamentosTable.DataSource = _adiantamentoDataTable;
            }

        }

        private void btnRegular_Click(object sender, EventArgs e)
        {  

            if (radioCliente.Checked) 
            {
                new RegularAdiantamentoForm(Entidade.cliente,StaticProperty.entityId).ShowDialog();
            }
            else if (radioFornecedor.Checked) 
            {
                new RegularAdiantamentoForm(Entidade.fornecedor,StaticProperty.entityId).ShowDialog();
            }

        }

        private async void AdiantamentoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StaticProperty.entityId = 0;

            await new Requisicoes().SystemRefresh();
        }
    }
}
