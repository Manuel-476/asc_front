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

        private void button3_Click(object sender, EventArgs e)
        {
            adiantamentoCliente = new AdiantamentoClienteDTO();
            

            if (radioFornecedor.Checked) 
            {
                adiantamentoFornecedor = new AdiantamentoFornDTO() { fornecedorId = StaticProperty.entityId,
                                                                     state = DTOs.Enums.Enums.DocState.ativo,
                                                                     documento = };
            }
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            client.BaseAddress = new Uri("https://sua-api.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Conversão do objeto Film para JSON
            string json = System.Text.Json.JsonSerializer.Serialize(armazem);

            // Envio dos dados para a API
            HttpResponseMessage response = await client.PostAsync($"https://localhost:7200/api/Armazem/{StaticProperty.funcionarioId}", new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Armazem Com Sucesso", "Feito Com Sucesso", MessageBoxButtons.OK);
                //Actualizar propriedade estatica armazem
                // Amazem
                var responseArmazem = await client.GetAsync($"https://localhost:7200/api/Armazem/ArmazensByRelations");

                if (responseArmazem.IsSuccessStatusCode)
                {
                    var contentArmazem = await responseArmazem.Content.ReadAsStringAsync();
                    StaticProperty.armazens = JsonConvert.DeserializeObject<List<ArmazemDTO>>(contentArmazem);
                }
            }
        }

        private void valorTxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
