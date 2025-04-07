using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using AscFrontEnd.DTOs.Configuration;
using AscFrontEnd.DTOs.StaticsDto;
using DocumentFormat.OpenXml.Bibliography;

namespace AscFrontEnd
{
    public partial class ConfigStock : Form
    {
        HttpClient _client;
        public ConfigStock()
        {
            InitializeComponent();
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7200");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
        }

        private void ConfigStock_Load(object sender, EventArgs e)
        {
            var qtdMinim = StaticProperty.stockMinims.Where(x => x.empresaId == StaticProperty.empresaId).FirstOrDefault() == null
                ? 0 : StaticProperty.stockMinims.Where(x => x.empresaId == StaticProperty.empresaId).FirstOrDefault().qtdMinim;

            descricaoLabel.Text = "Ao definir um stock minimo o sistema\npassará a alertar sempre que a quantidade de um artigo\nem stock for igual ou inferior a valor definido";
            stockMinimLabel.Text = $"Stock Minimo Actual: {qtdMinim}";
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                var qtdMinim = float.Parse(stockMinimTxt.Text.ToString());

                var setStockMinim = new StockMinimDTO() { id = 0, qtdMinim = qtdMinim, empresaId = StaticProperty.empresaId };

                string json = JsonSerializer.Serialize(setStockMinim);

                var response = await _client.PostAsync($"api/Configuration/Definir/StockMinimo", new StringContent(json, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Definido Com Sucesso", "Feito Com sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }
                else
                {
                    MessageBox.Show("Alguma coisa correu mal!", "Ocorreu um erro", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                    return;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Erro {ex.Message}", "Ocorreu um erro", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
