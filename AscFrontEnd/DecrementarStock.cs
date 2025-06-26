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
using System.Globalization;
using AscFrontEnd.Application;

namespace AscFrontEnd
{
    public partial class DecrementarStock : Form
    {
        ArtigoDTO _artigo;
        Requisicoes _requisicoes;
        int _qtd;
        public DecrementarStock(ArtigoDTO artigo, int qtd)
        {
            InitializeComponent();
            _artigo = artigo;
            _qtd = qtd;
            _requisicoes = new Requisicoes();
        }

        private void DecrementarStock_Load(object sender, EventArgs e)
        {
            artigoLabel.Text = $"Artigo: {_artigo.codigo}";
            qtdLabel.Text = $"Qtd Stock: {_qtd:F2}";
        }

        private async void salvarBtn_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            try
            {
                client.BaseAddress = new Uri("http://localhost:7200/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(_artigo.id);

                var qtd = !string.IsNullOrEmpty(qtdText.Text.ToString()) ? float.Parse(qtdText.Text.ToString().Replace(".", "").Replace(",", "."), CultureInfo.InvariantCulture) : 0f;

                // Envio dos dados para a API
                HttpResponseMessage response = await client.PutAsync($"api/Armazem/Stock/Qtd/Artigo/Decremento/{_artigo.id}/{qtd}/{StaticProperty.funcionarioId}/{StaticProperty.empresaId}", new StringContent(json, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    await _requisicoes.GetLocalizacoes();

                    await _requisicoes.GetLocalizacaoArtigo();


                    MessageBox.Show($"Quantidade Reduzida com sucesso",
                                     "Feito com sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Ocorreu um erro", "Impossivel concluir!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                WindowsConfig.LimparFormulario(this);

                DecrementarStock_Load(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao Decrementar: {ex.Message}", "Ocorreu um erro", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
