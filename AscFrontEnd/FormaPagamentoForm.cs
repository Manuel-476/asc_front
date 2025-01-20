using AscFrontEnd.DTOs.Deposito;
using AscFrontEnd.DTOs.StaticsDto;
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
    public partial class FormaPagamentoForm : Form
    {
        HttpClient httpClient;
        public FormaPagamentoForm()
        {
            InitializeComponent();
           
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            httpClient.BaseAddress = new Uri("https://sua-api.com/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string json = string.Empty;
            try
            {
                if (string.IsNullOrWhiteSpace(codigoTxt.Text.ToString()) || string.IsNullOrWhiteSpace(descricaoTxt.Text.ToString()))
                {
                    MessageBox.Show("Todos os campos precisam ser premchido os campos","Impossivel concluir a acao",MessageBoxButtons.OK,MessageBoxIcon.Information);

                    return;
                }
                var formaPagamento = new FormaPagamentoDTO()
                {
                    codigo = codigoTxt.Text.ToString(),
                    descricao = descricaoTxt.Text.ToString(),
                    empresaId = StaticProperty.empresaId
                };

                json = System.Text.Json.JsonSerializer.Serialize(formaPagamento);



                var resposta = await httpClient.PostAsync("https://localhost:7200/api/Deposito/FormaPagamento", new StringContent(json, Encoding.UTF8, "application/json"));

                if (resposta.IsSuccessStatusCode)
                {
                    MessageBox.Show("Salvo Com Sucesso", "Nova Forma de pagamento", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var responseFormaPagamento = await httpClient.GetAsync($"https://localhost:7200/api/Deposito/FormaPagamento");

                    if (responseFormaPagamento.IsSuccessStatusCode)
                    {
                        var contentFormaPagamento = await responseFormaPagamento.Content.ReadAsStringAsync();
                        StaticProperty.formasPagamento =  JsonConvert.DeserializeObject<List<FormaPagamentoDTO>>(contentFormaPagamento);

                        
                    }
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

        private  void FormaPagamentoForm_Load(object sender, EventArgs e)
        {
           
        }
    }
}
