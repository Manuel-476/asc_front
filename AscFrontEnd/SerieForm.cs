using AscFrontEnd.DTOs.Serie;
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
using AscFrontEnd.Application;

namespace AscFrontEnd.Files
{
    public partial class SerieForm : Form
    {
        Requisicoes _requisicoes;
        public SerieForm()
        {
            InitializeComponent();

            _requisicoes = new Requisicoes();
        }

        private async void CrairSerieBtn_Click(object sender, EventArgs e)
        {
            var serie = new SerieDTO()
            {
                EmpresaId = StaticProperty.empresaId,
                serie = textSerie.Text,
                status = DTOs.Enums.Enums.OpcaoBinaria.Sim,
            };

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
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
                await _requisicoes.GetSerie();
            }
            else 
            {
                MessageBox.Show("Erro ao salvar a serie", "Erro inesperado", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            WindowsConfig.LimparFormulario(this);

        }

        private void SerieForm_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ListaSeries listaSeries = new ListaSeries();
            listaSeries.ShowDialog();
        }
    }
}
