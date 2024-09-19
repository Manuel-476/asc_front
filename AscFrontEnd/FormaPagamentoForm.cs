using AscFrontEnd.DTOs.Deposito;
using AscFrontEnd.DTOs.StaticsDto;
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
    public partial class FormaPagamentoForm : Form
    {
        HttpClient httpClient;
        public FormaPagamentoForm()
        {
            InitializeComponent();
            httpClient = new HttpClient();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string json = string.Empty;
            try
            {
                var formaPagamento = new FormaPagamentoDTO()
                {
                    codigo = codigoTxt.ToString(),
                    descricao = descricaoTxt.ToString(),
                    empresaId = StaticProperty.empresaId
                };

                json = System.Text.Json.JsonSerializer.Serialize(formaPagamento);

                httpClient.DefaultRequestHeaders.Authorization =  new AuthenticationHeaderValue("Bearer", StaticProperty.token);

                var resposta = await httpClient.PostAsync("api/Deposito/FormaPagamento", new StringContent(json, Encoding.UTF8, "application/json"));

                if (resposta.IsSuccessStatusCode)
                {
                    MessageBox.Show("Salvo Com Sucesso", "Nova Forma de pagamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ocorreu um Erro", "Erro ao Salvar Forma de Pagamento", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Erro ao Salvar Forma de Pagamento", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private async void FormaPagamentoForm_Load(object sender, EventArgs e)
        {
           
        }
    }
}
