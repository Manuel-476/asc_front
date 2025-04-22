using AscFrontEnd.DTOs.Cliente;
using AscFrontEnd.DTOs.Serie;
using AscFrontEnd.DTOs.StaticsDto;
using DocumentFormat.OpenXml.Office2010.Excel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AscFrontEnd.DTOs.Enums.Enums;
using static System.Windows.Forms.AxHost;

namespace AscFrontEnd
{
    public partial class ListaSeries : Form
    {
        public int id;
        public ListaSeries()
        {
            InitializeComponent();
        }

        private void ListaSeries_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void activarPicture_MouseMove(object sender, MouseEventArgs e)
        {
            activarPicture.BackColor =  System.Drawing.Color.FromArgb(0, 120, 215);

        }

        private void activarPicture_MouseLeave(object sender, EventArgs e)
        {
            activarPicture.BackColor = System.Drawing.Color.Transparent;
        }

        private void ListaSeries_Load(object sender, EventArgs e)
        {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Serie", typeof(string));
                dt.Columns.Add("Estado", typeof(string));

            // Adicionando linhas ao DataTable
            foreach (var item in StaticProperty.series)
                {
                string status = item.status == OpcaoBinaria.Nao ?"Nao activo"  : "Activo";
                    dt.Rows.Add(item.id, item.serie, status);

                    dataGridView1.DataSource = dt;
                }
            }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private async void activarPicture_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            try 
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
                client.BaseAddress = new Uri("https://localhost:7200/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(id);

                // Envio dos dados para a API
                HttpResponseMessage responseSerie = await client.PutAsync($"api/Serie/Change/State/{id}/{StaticProperty.empresaId}", new StringContent(json, Encoding.UTF8, "application/json"));

                if (responseSerie.IsSuccessStatusCode)
                {
                    var resposta = await client.GetAsync("api/Serie");
                    var contentSerie = await resposta.Content.ReadAsStringAsync();

                   StaticProperty.series = JsonConvert.DeserializeObject<List<SerieDTO>>(contentSerie);

                   MessageBox.Show($"A serie {StaticProperty.series.Where(s=>s.id == id).First().serie} foi activada com sucesso",
                                    "Feito com sucesso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                 }
     
                // Actualizar tabela
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Serie", typeof(string));
                dt.Columns.Add("Estado", typeof(string));
                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.series)
                {
                    string status = item.status == OpcaoBinaria.Nao ? "Nao activo" : "Activo";
                    dt.Rows.Add(item.id, item.serie, status);

                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Erro ao Activar Serie: {ex.Message}","Ocorreu um erro",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
                return;
            }
        }
    }
}
