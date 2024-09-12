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

namespace AscFrontEnd
{
    public partial class TransferenciaArmazem : Form
    {
        private int id;
        private int artigoId;
        private StockDTO _stock;
        private ArmazemDTO armazens;
        public TransferenciaArmazem(StockDTO stock)
        {
            InitializeComponent();
            _stock = stock;
            armazens = new ArmazemDTO();
        }

        private void TransferenciaArmazem_Load(object sender, EventArgs e)
        {
            artigoLabel.Text = $"Artigo: {_stock.artigo}";
            qtdLabel.Text = $"Qtd Stock: {_stock.qtd}";

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
            int qtd = int.Parse(qtdText.Text);
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
                    var resposta = await client.GetAsync("https://localhost:7200/api/Armazem/LocationArtigo");
                    var contentTransf = await resposta.Content.ReadAsStringAsync();

                    StaticProperty.locationArtigos = JsonConvert.DeserializeObject<List<LocationArtigoDTO>>(contentTransf);

                    var result = await responseTransf.Content.ReadAsStringAsync();

                    MessageBox.Show(result,result, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

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
