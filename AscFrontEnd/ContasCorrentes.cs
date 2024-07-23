using AscFrontEnd.DTOs.StaticsDto;
using AscFrontEnd.DTOs.Stock;
using ERP_Buyer.Application.DTOs.Documentos;
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

namespace AscFrontEnd
{
    public partial class ContasCorrentes : Form
    {
        List<VftDTO> dados;
        DataTable entidadeTable;
        public ContasCorrentes()
        {
            InitializeComponent();
            dados = new List<VftDTO>();
            entidadeTable = new DataTable();
        }

        private async void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.DeepSkyBlue;
            label5.ForeColor = Color.DeepSkyBlue;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromArgb(0, 120, 215);
            label5.ForeColor = Color.FromArgb(0, 120, 215);

        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.DeepSkyBlue;
            label6.ForeColor = Color.DeepSkyBlue;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.FromArgb(0, 120, 215);
            label6.ForeColor = Color.FromArgb(0, 120, 215);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private async void ContasCorrentes_Load(object sender, EventArgs e)
        {
            var client = new HttpClient();

            var response = await client.GetAsync($"https://localhost:7200/api/Compra/VftByRelations");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                dados = JsonConvert.DeserializeObject<List<VftDTO>>(content);
                dados.GroupBy(vft => vft.fornecedorId);

                entidadeTable.Columns.Add("id", typeof(int));
                entidadeTable.Columns.Add("Entidade", typeof(string));
                entidadeTable.Columns.Add("Por Pagar", typeof(float));
                entidadeTable.Columns.Add("Estado", typeof(float));

                // Adicionando linhas ao DataTable
                foreach (var vft in dados)
                {
                    string status = vft.status == 0 ? "Não Regulada" : "Regulada";

                    float result = vft.vftArtigo.Sum(vt => vt.preco);

                    entidadeTable.Rows.Add(vft.id, vft.fornecedorId, result, status);

                    correnteTable.DataSource = entidadeTable;
                }

            }
        }

        private void correnteTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
