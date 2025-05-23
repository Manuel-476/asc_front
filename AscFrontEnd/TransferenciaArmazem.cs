using AscFrontEnd.DTOs.Serie;
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
using static AscFrontEnd.DTOs.Enums.Enums;
using AscFrontEnd.Application.Validacao;
using System.Globalization;
using AscFrontEnd.Application;

namespace AscFrontEnd
{
    public partial class TransferenciaArmazem : Form
    {
        private int artigoId;
        private StockDTO _stock;
        private ArmazemDTO armazens;
        private Requisicoes _requisicoes;
        public TransferenciaArmazem(StockDTO stock)
        {
            InitializeComponent();
            _stock = stock;
            armazens = new ArmazemDTO();
            _requisicoes = new Requisicoes();

            qtdText.KeyPress += ValidacaoForms.TratarKeyPress; // Ajustado
            qtdText.TextChanged += ValidacaoForms.TratarTextChanged;
        }

        private void TransferenciaArmazem_Load(object sender, EventArgs e)
        {
            artigoLabel.Text = $"Artigo: {_stock.artigo}";
            qtdLabel.Text = $"Qtd Stock: {_stock.qtd:F2}";

            armazens = StaticProperty.armazens.Where(ar => ar.storeLocations.Where(sl => sl.locationArtigos.Where(la => la.artigoId == _stock.id).First().artigoId == _stock.id).First().id != 0).First();

            armazemLabel.Text = $"Armazem: {armazens.codigo}";
            descricaoLabel.Text = $"Descricao: {armazens.storeLocations.Where(sl => sl.locationArtigos.Where(la => la.artigoId == _stock.id).First().artigoId == _stock.id).First().descricao}";
            localizacaoLabel.Text = $"Localizacao: {armazens.storeLocations.First().codigo}";

            artigoId = StaticProperty.artigos.Where(art => art.codigo == _stock.artigo).First().id;

            foreach(var item in StaticProperty.armazens) 
            {
                armazemCombo.Items.Add(item.codigo);
            }       
        }

        private void armazemCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            int locationStoreId,locationId,armazemDestineId, locationStoreDestineId,locationDestineId;
            float qtd = !string.IsNullOrEmpty(qtdText.Text.ToString()) ? float.Parse(qtdText.Text.ToString().Replace(".", "").Replace(",", "."), CultureInfo.InvariantCulture) : 0f;
            int idLoc = armazens.storeLocations.Where(sl => sl.locationArtigos.Where(la => la.artigoId == _stock.id).First().artigoId == _stock.id).First().id;

            var client = new HttpClient();
            try
            {
                locationStoreId = StaticProperty.locationStores.Where(loc => loc.id == idLoc).First().id; 
                locationId = StaticProperty.locationArtigos.Where(art => art.artigoId == artigoId).First().id;
                locationDestineId = armazens.storeLocations.Where(loc => loc.id == idLoc).First().locationArtigos.Max(la => la.id); 
                locationStoreDestineId = StaticProperty.locationStores.Where(loc => loc.codigo == localizacaoCombo.Text).First().id;
                armazemDestineId = armazens.id;

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
                client.BaseAddress = new Uri("https://sua-api.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(locationId);

                // Envio dos dados para a API
                HttpResponseMessage responseTransf = await client.PutAsync($"https://localhost:7200/api/Armazem/Stock/Artigo/Transferencia/{artigoId}/{qtd}/{locationId}/{locationDestineId}/{locationStoreDestineId}/{armazemDestineId}", new StringContent(json, Encoding.UTF8, "application/json"));

                if (responseTransf.IsSuccessStatusCode)
                {
                    await _requisicoes.GetLocalizacaoArtigo();

                    var result = await responseTransf.Content.ReadAsStringAsync();

                    MessageBox.Show(result,result, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                WindowsConfig.LimparFormulario(this);

                TransferenciaArmazem_Load(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao Transferir Artigo: {ex.Message}", "Ocorreu um erro", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }
        }

        private void armazemCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            var location = StaticProperty.armazens.Where(ar => ar.codigo == armazemCombo.Text.ToString()).First().storeLocations.ToList();
            foreach (var item in location)
            {
                localizacaoCombo.Items.Add(item.codigo);
            }
        }
    }
}
