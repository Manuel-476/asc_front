﻿using AscFrontEnd.DTOs.StaticsDto;
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

namespace AscFrontEnd
{
    public partial class DecrementarStock : Form
    {
        ArtigoDTO _artigo;
        int _qtd;
        public DecrementarStock(ArtigoDTO artigo, int qtd)
        {
            InitializeComponent();
            _artigo = artigo;
            _qtd = qtd;
        }

        private void DecrementarStock_Load(object sender, EventArgs e)
        {
            artigoLabel.Text = $"Artigo: {_artigo.codigo}";
            qtdLabel.Text = $"Qtd Stock: {_qtd}";
        }

        private async void salvarBtn_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri("https://sua-api.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(_artigo.id);

                // Envio dos dados para a API
                HttpResponseMessage response = await client.PutAsync($"https://localhost:7200/api/Armazem/Stock/Qtd/Artigo/Decremento/{_artigo.id}/{_qtd}", new StringContent(json, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var responseLocationStore = await client.GetAsync($"https://localhost:7200/api/Armazem/LocationStore");

                    var contentLocationStore = await responseLocationStore.Content.ReadAsStringAsync();
                    StaticProperty.locationStores = JsonConvert.DeserializeObject<List<LocationStoreDTO>>(contentLocationStore);


                    var responseLocationArtigo = await client.GetAsync($"https://localhost:7200/api/Armazem/LocationArtigo");

                    var contentLocationArtigo = await responseLocationArtigo.Content.ReadAsStringAsync();
                    StaticProperty.locationArtigos = JsonConvert.DeserializeObject<List<LocationArtigoDTO>>(contentLocationArtigo);


                    MessageBox.Show($"Quantidade Reduzida com sucesso",
                                     "Feito com sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Actualizar tabela

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao Activar Serie: {ex.Message}", "Ocorreu um erro", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }
        }
    }
}