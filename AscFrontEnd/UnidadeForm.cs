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
using AscFrontEnd.DTOs.Deposito;
using AscFrontEnd.DTOs.StaticsDto;
using Newtonsoft.Json;
using AscFrontEnd.DTOs.Artigo;
using AscFrontEnd.Application;
using AscFrontEnd.Application.Validacao;

namespace AscFrontEnd
{
    public partial class UnidadeForm : Form
    {
        HttpClient httpClient;
        string json = string.Empty;
        public UnidadeForm()
        {
            InitializeComponent();

            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            httpClient.BaseAddress = new Uri("http://localhost:7200/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            if (OutrasValidacoes.UnidadeCodigoExiste(codigoTxt.Text.ToString()))
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(codigoTxt.Text.ToString()) || !string.IsNullOrWhiteSpace(descricaoTxt.Text.ToString()))
            {
                var unidade = new UnidadeDTO()
                {
                    codigo = codigoTxt.Text.ToString(),
                    descricao = descricaoTxt.Text.ToString(),
                    empresaId = StaticProperty.empresaId,
                    state = DTOs.Enums.Enums.Status.activo,
                    created_at = DateTime.Now,
                };
                json = System.Text.Json.JsonSerializer.Serialize(unidade);



                var resposta = await httpClient.PostAsync("api/Unidade", new StringContent(json, Encoding.UTF8, "application/json"));

                if (resposta.IsSuccessStatusCode)
                {
                    MessageBox.Show("Salvo Com Sucesso", "Nova Forma de pagamento", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    StaticProperty.unidades = await new Requisicoes().GetUnidades();
                }
                else
                {
                    MessageBox.Show("Ocorreu um Erro", "Erro ao Salvar Forma de Pagamento", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }

                WindowsConfig.LimparFormulario(this);
            }
        }

        private void UnidadeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
