using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AscFrontEnd.Application;
using AscFrontEnd.Application.Validacao;
using AscFrontEnd.DTOs.Artigo;
using AscFrontEnd.DTOs.Deposito;
using AscFrontEnd.DTOs.StaticsDto;
using Newtonsoft.Json;

namespace AscFrontEnd
{
    public partial class IvaForm : Form
    {
        HttpClient httpClient;
        string json = string.Empty;
        public IvaForm()
        {
            InitializeComponent();

            valorIvaTxt.KeyPress += ValidacaoForms.TratarKeyPress; // Ajustado
            valorIvaTxt.TextChanged += ValidacaoForms.TratarTextChanged;

            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            httpClient.BaseAddress = new Uri("http://localhost:7200/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async void button1_Click(object sender, EventArgs e)
        {
          

            try
            {
                if (!string.IsNullOrWhiteSpace(valorIvaTxt.Text.ToString()))
                {
                    var iva = new IvaDTO()
                    {
                        valorIva = !string.IsNullOrEmpty(valorIvaTxt.Text.ToString()) ? float.Parse(valorIvaTxt.Text.ToString().Replace(".", "").Replace(",", "."), CultureInfo.InvariantCulture) : 0f,
                        state = DTOs.Enums.Enums.Status.activo,
                        empresaId = StaticProperty.empresaId,
                        created_at = DateTime.Now,
                    };
                    json = System.Text.Json.JsonSerializer.Serialize(iva);

                    var resposta = await httpClient.PostAsync("api/Iva", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (resposta.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Salvo Com Sucesso", "Novo Valor do Iva", MessageBoxButtons.OK, MessageBoxIcon.Information);

                         StaticProperty.ivas = await new Requisicoes().GetIvas();

                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um Erro", "Erro ao Salvar valor do iva", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    }

                    WindowsConfig.LimparFormulario(this);
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Ocorreu um Erro", $"Alguma coisa correu mal: {ex.Message}", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void IvaForm_Load(object sender, EventArgs e)
        {

        }
    }
}
