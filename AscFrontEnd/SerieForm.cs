﻿using AscFrontEnd.DTOs.Serie;
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
using AscFrontEnd.DTOs.Fornecedor;
using Newtonsoft.Json;
using AscFrontEnd.DTOs.StaticsDto;

namespace AscFrontEnd.Files
{
    public partial class SerieForm : Form
    {
        public SerieForm()
        {
            InitializeComponent();
        }

        private async void CrairSerieBtn_Click(object sender, EventArgs e)
        {
            var serie = new SerieDTO()
            {
                EmpresaId = 0,
                serie = textSerie.Text,
                status = DTOs.Enums.Enums.OpcaoBinaria.Sim,
            };

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://sua-api.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Conversão do objeto Film para JSON
            string json = System.Text.Json.JsonSerializer.Serialize(serie);

            // Envio dos dados para a API
            var response = await client.PostAsync("https://localhost:7200/api/Serie", new StringContent(json, Encoding.UTF8, "application/json"));
           
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Serie Salva", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Serie
                var responseSerie = await client.GetAsync($"https://localhost:7200/api/Serie");

                if (responseSerie.IsSuccessStatusCode)
                {
                    var contentSerie = await responseSerie.Content.ReadAsStringAsync();
                    StaticProperty.series = JsonConvert.DeserializeObject<List<SerieDTO>>(contentSerie);
                }
            }
            else 
            {
                MessageBox.Show("Erro ao salvar a serie", "Erro inesperado", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void SerieForm_Load(object sender, EventArgs e)
        {

        }
    }
}