using AscFrontEnd.DTOs.StaticsDto;
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
    public partial class VendaListagem : Form
    {
        string clienteNome = string.Empty;
        public int id;
        public VendaListagem()
        {
            InitializeComponent();
        }

        private void anularPicture_MouseMove(object sender, MouseEventArgs e)
        {
            anularPicture.BackColor = Color.Red;
        }

        private void anularPicture_MouseLeave(object sender, EventArgs e)
        {
            anularPicture.BackColor = Color.IndianRed;
        }

        private void estornarPicture_MouseMove(object sender, MouseEventArgs e)
        {
            estornarPicture.BackColor = Color.Red;
        }

        private void estornarPicture_MouseLeave(object sender, EventArgs e)
        {
            estornarPicture.BackColor = Color.IndianRed;
        }

        private void VendaListagem_Load(object sender, EventArgs e)
        {
         
            radioFp.Checked = true;

            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("Cliente", typeof(string));
            dt.Columns.Add("Documento", typeof(string));
            dt.Columns.Add("Data", typeof(float));


            // Adicionando linhas ao DataTable
            foreach (var item in StaticProperty.fps)
            {
                clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;
                dt.Rows.Add(item.id, clienteNome, item.documento, item.data);

                dataGridView1.DataSource = dt;
            }
        }

        private void radioFt_CheckedChanged(object sender, EventArgs e)
        {
            if (radioFt.Checked) 
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Cliente", typeof(string));
                dt.Columns.Add("Documento", typeof(string));
                dt.Columns.Add("Data", typeof(float));


                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.fts)
                {
                    clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;
                    dt.Rows.Add(item.id, clienteNome, item.documento, item.data);

                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void radioFr_CheckedChanged(object sender, EventArgs e)
        {
            if (radioFr.Checked) 
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Cliente", typeof(string));
                dt.Columns.Add("Documento", typeof(string));
                dt.Columns.Add("Data", typeof(float));


                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.frs)
                {
                    clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;
                    dt.Rows.Add(item.id, clienteNome, item.documento, item.data);

                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void radioGt_CheckedChanged(object sender, EventArgs e)
        {
            if (radioGt.Checked)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Cliente", typeof(string));
                dt.Columns.Add("Documento", typeof(string));
                dt.Columns.Add("Data", typeof(float));


                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.gts)
                {
                    clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;
                    dt.Rows.Add(item.id, clienteNome, item.documento, item.data);

                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void radioNv_CheckedChanged(object sender, EventArgs e)
        {
            if (radioNc.Checked)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Cliente", typeof(string));
                dt.Columns.Add("Documento", typeof(string));
                dt.Columns.Add("Data", typeof(float));


                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.ncs)
                {
                    clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;
                    dt.Rows.Add(item.id, clienteNome, item.documento, item.data);

                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try 
            {
                if (radioFr.Checked)
                {
                    estornarPicture.Enabled = true;
                }
                else 
                {
                    estornarPicture.Enabled = false;
                }
                id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            catch 
            {
                return;
            }
           
        }

        private async void estornarPicture_Click(object sender, EventArgs e)
        {
            if (radioFr.Checked)
            {
                var client = new HttpClient();
                try
                {
                    string documento = StaticProperty.frs.Where(cl => cl.id == id).First().documento;

                    client.BaseAddress = new Uri("https://sua-api.com/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Conversão do objeto Film para JSON
                    string json = System.Text.Json.JsonSerializer.Serialize(DocState.estornado);

                    // Envio dos dados para a API
                    HttpResponseMessage responseFr = await client.PutAsync($"https://localhost:7200/api/Venda/Fr/Change/State/{id}/{DocState.estornado}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (responseFr.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"O documento {documento} foi estornado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch(Exception ex) 
                {
                    MessageBox.Show($"Ocorreu um erro mo processo de estorno: {ex.Message}","Ocorreu um erro",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
                }
            }
        }

        private void radioFp_CheckedChanged(object sender, EventArgs e)
        {
            if (radioFp.Checked)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Cliente", typeof(string));
                dt.Columns.Add("Documento", typeof(string));
                dt.Columns.Add("Data", typeof(float));


                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.fps)
                {
                    clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;
                    dt.Rows.Add(item.id, clienteNome, item.documento, item.data);

                    dataGridView1.DataSource = dt;
                }
            }
        }

        private async void anularPicture_Click(object sender, EventArgs e)
        {
            string documento = string.Empty;
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://sua-api.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                if (radioFr.Checked)
                {        
               
                    documento = StaticProperty.frs.Where(cl => cl.id == id).First().documento;

                    // Conversão do objeto Film para JSON
                    string json = System.Text.Json.JsonSerializer.Serialize(DocState.anulado);

                    // Envio dos dados para a API
                    HttpResponseMessage responseFr = await client.PutAsync($"https://localhost:7200/api/Venda/Fr/Change/State/{id}/{DocState.anulado}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (responseFr.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"O documento {documento} foi anulado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                 }
                else if (radioFt.Checked) 
                {
                    documento = StaticProperty.fts.Where(cl => cl.id == id).First().documento;

                    // Conversão do objeto Film para JSON
                    string json = System.Text.Json.JsonSerializer.Serialize(DocState.anulado);

                    // Envio dos dados para a API
                    HttpResponseMessage responseFt = await client.PutAsync($"https://localhost:7200/api/Venda/Ft/Change/State/{id}/{DocState.anulado}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (responseFt.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"O documento {documento} foi anulado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (radioFp.Checked)
                {
                    documento = StaticProperty.fps.Where(cl => cl.id == id).First().documento;

                    // Conversão do objeto Film para JSON
                    string json = System.Text.Json.JsonSerializer.Serialize(DocState.anulado);

                    // Envio dos dados para a API
                    HttpResponseMessage responseFp = await client.PutAsync($"https://localhost:7200/api/Venda/Fp/Change/State/{id}/{DocState.anulado}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (responseFp
                        .IsSuccessStatusCode)
                    {
                        MessageBox.Show($"O documento {documento} foi anulado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (radioGt.Checked)
                {
                    documento = StaticProperty.gts.Where(cl => cl.id == id).First().documento;

                    // Conversão do objeto Film para JSON
                    string json = System.Text.Json.JsonSerializer.Serialize(DocState.anulado);

                    // Envio dos dados para a API
                    HttpResponseMessage responseGt = await client.PutAsync($"https://localhost:7200/api/Venda/Gt/Change/State/{id}/{DocState.anulado}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (responseGt.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"O documento {documento} foi anulado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro no processo de anulacao de documento: {ex.Message}", "Ocorreu um erro", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }
    }
}
