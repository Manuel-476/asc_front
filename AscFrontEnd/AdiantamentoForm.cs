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

namespace AscFrontEnd
{
    public partial class AdiantamentoForm : Form
    {
        string nomeEntidadeStr = string.Empty;
        AdiantamentoFornDTO adiantamentoFornecedor;
        AdiantamentoClienteDTO adiantamentoCliente;
        

        public AdiantamentoForm()
        {
            InitializeComponent();
        }

        private void AdiantamentoForm_Load(object sender, EventArgs e)
        {
            radioCliente.Checked = true;
        }

        private void radioCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (radioCliente.Checked) 
            {
                botaoFornecedor.Enabled = false;
                botaoCliente.Enabled = true;
            }
        }

        private void botaoFornecedor_MouseMove(object sender, MouseEventArgs e)
        {
            botaoFornecedor.BackColor = Color.White;
            botaoFornecedor.ForeColor = Color.FromArgb(64,64,64);
        }

        private void botaoFornecedor_MouseLeave(object sender, EventArgs e)
        {
            botaoFornecedor.BackColor = Color.Transparent;
            botaoFornecedor.ForeColor = Color.White;
        }

        private void botaoCliente_MouseMove(object sender, MouseEventArgs e)
        {
            botaoCliente.BackColor = Color.White;
            botaoCliente.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void botaoCliente_MouseLeave(object sender, EventArgs e)
        {
            botaoCliente.BackColor = Color.Transparent;
            botaoCliente.ForeColor = Color.White;
        }

        private void botaoFornecedor_Click(object sender, EventArgs e)
        {
            FornecedorListagem form = new FornecedorListagem();
            form.ShowDialog();
        }

        private void botaoCliente_Click(object sender, EventArgs e)
        {
            ClienteListagem form = new ClienteListagem();
            form.ShowDialog();
        }

        private void radioFornecedor_CheckedChanged(object sender, EventArgs e)
        {
            if (radioFornecedor.Checked)
            {
                botaoFornecedor.Enabled = true;
                botaoCliente.Enabled = false;
            }
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

            
            if (radioFornecedor.Checked) 
            {
                documento = "ADF";

                codigoDocumento = await Documento.GetCodigoDocumentoAsync(documento);

                adiantamentoFornecedor = new AdiantamentoFornDTO() { fornecedorId = StaticProperty.entityId,
                                                                     state = DTOs.Enums.Enums.DocState.ativo,
                                                                     documento = codigoDocumento};

                json = System.Text.Json.JsonSerializer.Serialize(adiantamentoFornecedor);

                response = await client.PostAsync($"https://localhost:7200/api/ContaCorrente/Adiantamento/Fornecedor", new StringContent(json, Encoding.UTF8, "application/json"));

            }

            if (radioCliente.Checked)
            {
                documento = "ADC";

                codigoDocumento = await Documento.GetCodigoDocumentoAsync(documento);

                adiantamentoCliente = new AdiantamentoClienteDTO()
                {
                    clienteId = StaticProperty.entityId,
                    state = DTOs.Enums.Enums.DocState.ativo,
                    documento = codigoDocumento
                };

                json = System.Text.Json.JsonSerializer.Serialize(adiantamentoCliente);

                response = await client.PostAsync($"https://localhost:7200/api/ContaCorrente/Adiantamento/Cliente", new StringContent(json, Encoding.UTF8, "application/json"));

            }

            // Envio dos dados para a API
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Adiantamento Com Sucesso", "Feito Com Sucesso", MessageBoxButtons.OK);

                var responseAdForn = await client.GetAsync($"https://localhost:7200/api/ContaCorrente/Adiantamento/Fornecedor");

                if (responseAdForn.IsSuccessStatusCode)
                {
                    var contentAdForn = await responseAdForn.Content.ReadAsStringAsync();
                    StaticProperty.adiantamentoForns = JsonConvert.DeserializeObject<List<AdiantamentoFornDTO>>(contentAdForn);
                }

                var responseAdCliente = await client.GetAsync($"https://localhost:7200/api/ContaCorrente/Adiantamento/Fornecedor");

                if (responseAdCliente.IsSuccessStatusCode)
                {
                    var contentAdCliente = await responseAdForn.Content.ReadAsStringAsync();
                    StaticProperty.adiantamentoClientes = JsonConvert.DeserializeObject<List<AdiantamentoClienteDTO>>(contentAdCliente);
                }
            }
        }

        private void valorTxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
