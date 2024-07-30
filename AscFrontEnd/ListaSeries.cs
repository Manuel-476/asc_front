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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            activarPicture.BackColor =  Color.FromArgb(0, 120, 215);

        }

        private void activarPicture_MouseLeave(object sender, EventArgs e)
        {
            activarPicture.BackColor = Color.Transparent;
        }

        private void ListaSeries_Load(object sender, EventArgs e)
        {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Serie", typeof(string));

                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.series)
                {
                    dt.Rows.Add(item.id, item.id, item.serie);

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
                var responseSerie = await client.GetAsync($"https://localhost:7200/api/Serie/Change/State/{id}");

                if (responseSerie.IsSuccessStatusCode)
                {
                   var contentSerie = await responseSerie.Content.ReadAsStringAsync();
                   StaticProperty.series = JsonConvert.DeserializeObject<List<SerieDTO>>(contentSerie);
                 }
            }
            catch (Exception ex) 
            {
                throw new Exception($"Erro ao Activar Serie: {ex.Message}");
            }
        }
    }
}
