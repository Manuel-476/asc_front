using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AscFrontEnd.DTOs.StaticsDto;

namespace AscFrontEnd
{
    public partial class GerarSaftForm : Form
    {
        HttpClient _httpClient;
        public GerarSaftForm()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:7200");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void GerarSaftForm_Load(object sender, EventArgs e)
        {
            dateInicioPicker.Value = DateTime.Now;
            dateFinalPicker.Value = DateTime.Now;
        }

        private async void btnGerar_Click(object sender, EventArgs e)
        {
            if(await DownloadSaftFile(dateInicioPicker.Value, dateFinalPicker.Value, StaticProperty.empresaId)) 
            {
                MessageBox.Show("Saft gerado com sucesso","Feito com sucesso",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else 
            {
                MessageBox.Show("Erro ao gerar o Saft", "Ocorreu um erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            GerarSaftForm_Load(this, EventArgs.Empty);
        }
        public async Task<bool> DownloadSaftFile(DateTime dataInicio, DateTime dataFinal, int empresaId)
        {
            try
            {
                // Fazer a requisição para o endpoint
                var response = await _httpClient.GetAsync($"api/Agt/Saft/{dataInicio:yyyy-MM-dd}/{dataFinal:yyyy-MM-dd}/{empresaId}");
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Erro na requisição: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                    return false;
                }

                // Ler o conteúdo como bytes
                var saftBytes = await response.Content.ReadAsByteArrayAsync();
                if (saftBytes == null || saftBytes.Length == 0)
                {
                    Console.WriteLine("Nenhum dado recebido.");
                    return false;
                }

                // Definir o caminho para salvar o arquivo
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Files/SaftFiles");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var fileName = $"SAFT_AO_{empresaId}_{dataInicio:yyyyMMdd}_{dataFinal:yyyyMMdd}.xml";
                var filePath = Path.Combine(uploadsFolder, fileName);

                // Salvar o arquivo
                File.WriteAllBytes(filePath, saftBytes);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao baixar ou salvar o arquivo SAFT: {ex.Message}");
                return false;
            }
        }
    }
}
