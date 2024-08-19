using AscFrontEnd.DTOs.StaticsDto;
using DocumentFormat.OpenXml.Office2010.Excel;
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
    public partial class CompraListagem : Form
    {
        string fornecedorNome;
        int id;
        string documento;
        public CompraListagem()
        {
            InitializeComponent();
        }

        private void radioFp_CheckedChanged(object sender, EventArgs e)
        {
            if (radioPco.Checked) 
            { 
               DataTable dt = new DataTable();
               dt.Columns.Add("id", typeof(int));
               dt.Columns.Add("Fornecedor", typeof(string));
               dt.Columns.Add("Documento", typeof(string));
               dt.Columns.Add("Data", typeof(string));


              // Adicionando linhas ao DataTable
              foreach (var item in StaticProperty.pcos.Where(f => f.status != DocState.anulado && f.fornecedor.empresaid == StaticProperty.empresaId))
              {
                fornecedorNome = StaticProperty.fornecedores.Where(f =>f.id == item.fornecedorId).First().nome_fantasia;
                dt.Rows.Add(item.id, fornecedorNome, item.documento, item.data);

                dataGridView1.DataSource = dt;
              }
            }
        }

        private void radioCot_CheckedChanged(object sender, EventArgs e)
        {
            if (radioCot.Checked)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Fornecedor", typeof(string));
                dt.Columns.Add("Documento", typeof(string));
                dt.Columns.Add("Data", typeof(string));


                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.cots.Where(f => f.status != DocState.anulado && f.fornecedor.empresaid == StaticProperty.empresaId))
                {
                    fornecedorNome = StaticProperty.fornecedores.Where(f => f.id == item.fornecedorId).First().nome_fantasia;
                    dt.Rows.Add(item.id, fornecedorNome, item.documento, item.data);

                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void CompraListagem_Load(object sender, EventArgs e)
        {
            radioPco.Enabled = true;
            estornarPicture.Enabled = false;

            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("Fornecedor", typeof(string));
            dt.Columns.Add("Documento", typeof(string));
            dt.Columns.Add("Data", typeof(string));


            // Adicionando linhas ao DataTable
            foreach (var item in StaticProperty.pcos.Where(f => f.status != DocState.anulado && f.fornecedor.empresaid == StaticProperty.empresaId))
            {
                fornecedorNome = StaticProperty.fornecedores.Where(f => f.id == item.fornecedorId).First().nome_fantasia;
                dt.Rows.Add(item.id, fornecedorNome, item.documento, item.data);

                dataGridView1.DataSource = dt;
            }
        }

        private void radioVft_CheckedChanged(object sender, EventArgs e)
        {
            if (radioVft.Checked)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Fornecedor", typeof(string));
                dt.Columns.Add("Documento", typeof(string));
                dt.Columns.Add("Data", typeof(string));


                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.vfts.Where(f => f.status != DocState.anulado && f.fornecedor.empresaid == StaticProperty.empresaId))
                {
                    fornecedorNome = StaticProperty.fornecedores.Where(f => f.id == item.fornecedorId).First().nome_fantasia;
                    dt.Rows.Add(item.id, fornecedorNome, item.documento, item.data);

                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void radioVfr_CheckedChanged(object sender, EventArgs e)
        {
            if (radioVfr.Checked)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Fornecedor", typeof(string));
                dt.Columns.Add("Documento", typeof(string));
                dt.Columns.Add("Data", typeof(string));


                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.vfrs.Where(f => f.status != DocState.anulado && f.status != DocState.estornado && f.fornecedor.empresaid == StaticProperty.empresaId).ToList())
                {
                    fornecedorNome = StaticProperty.fornecedores.Where(f => f.id == item.fornecedorId).First().nome_fantasia;
                    dt.Rows.Add(item.id, fornecedorNome, item.documento, item.data);

                    dataGridView1.DataSource = dt;
                }
                
            }
        }

        private void radioVgt_CheckedChanged(object sender, EventArgs e)
        {
            if (radioVgt.Checked)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Fornecedor", typeof(string));
                dt.Columns.Add("Documento", typeof(string));
                dt.Columns.Add("Data", typeof(string));


                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.vgts.Where(f => f.status != DocState.anulado && f.fornecedor.empresaid == StaticProperty.empresaId))
                {
                    fornecedorNome = StaticProperty.fornecedores.Where(f => f.id == item.fornecedorId).First().nome_fantasia;
                    dt.Rows.Add(item.id, fornecedorNome, item.documento, item.data);

                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void radioVnc_CheckedChanged(object sender, EventArgs e)
        {
            if (radioVnc.Checked)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Fornecedor", typeof(string));
                dt.Columns.Add("Documento", typeof(string));
                dt.Columns.Add("Data", typeof(string));


                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.vncs.Where(x => x.fornecedor.empresaid == StaticProperty.empresaId))
                {
                    fornecedorNome = StaticProperty.fornecedores.Where(f => f.id == item.fornecedorId).First().nome_fantasia;
                    dt.Rows.Add(item.id, fornecedorNome, item.documento, item.data);

                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("Fornecedor", typeof(string));
            dt.Columns.Add("Documento", typeof(string));
            dt.Columns.Add("Data", typeof(string));
            if (radioVft.Checked)
            {
                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.vfts.Where(f => f.documento.Contains(textBox1.Text) || f.data.ToString().Contains(textBox1.Text) && f.status != DocState.anulado && f.fornecedor.empresaid == StaticProperty.empresaId))
                {
                    fornecedorNome = StaticProperty.fornecedores.Where(cl => cl.id == item.fornecedorId).First().nome_fantasia;
                    dt.Rows.Add(item.id, fornecedorNome, item.documento, item.data);

                    dataGridView1.DataSource = dt;
                }
                foreach (var item2 in StaticProperty.fornecedores.Where(f => f.nome_fantasia.Contains(textBox1.Text) || f.razao_social.Contains(textBox1.Text)))
                {
                    foreach (var item in StaticProperty.vfts.Where(f => f.fornecedorId == item2.id).ToList())
                    {
                        fornecedorNome = StaticProperty.fornecedores.Where(cl => cl.id == item.fornecedorId).First().nome_fantasia;
                        dt.Rows.Add(item.id, fornecedorNome, item.documento, item.data);

                        dataGridView1.DataSource = dt;
                    }
                }
            }
            else if (radioVfr.Checked)
            {
                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.vfrs.Where(f => f.documento.Contains(textBox1.Text) || f.data.ToString().Contains(textBox1.Text) && f.status != DocState.anulado && f.status != DocState.estornado))
                {
                    fornecedorNome = StaticProperty.fornecedores.Where(cl => cl.id == item.fornecedorId).First().nome_fantasia;
                    dt.Rows.Add(item.id, fornecedorNome, item.documento, item.data);

                    dataGridView1.DataSource = dt;
                }
                foreach (var item2 in StaticProperty.fornecedores.Where(f => f.nome_fantasia.Contains(textBox1.Text) || f.razao_social.Contains(textBox1.Text)))
                {
                    foreach (var item in StaticProperty.vfrs.Where(f => f.fornecedorId == item2.id && f.status != DocState.anulado && f.status != DocState.estornado).ToList())
                    {
                        fornecedorNome = StaticProperty.fornecedores.Where(cl => cl.id == item.fornecedorId).First().nome_fantasia;
                        dt.Rows.Add(item.id, fornecedorNome, item.documento, item.data);

                        dataGridView1.DataSource = dt;
                    }
                }
            }
            else if (radioPco.Checked)
            {
                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.pcos.Where(f => f.documento.Contains(textBox1.Text) || f.data.ToString().Contains(textBox1.Text) && f.status != DocState.anulado))
                {
                    fornecedorNome = StaticProperty.fornecedores.Where(cl => cl.id == item.fornecedorId).First().nome_fantasia;
                    dt.Rows.Add(item.id, fornecedorNome, item.documento, item.data);

                    dataGridView1.DataSource = dt;
                }
                foreach (var item2 in StaticProperty.fornecedores.Where(f => f.nome_fantasia.Contains(textBox1.Text) || f.razao_social.Contains(textBox1.Text)))
                {
                    foreach (var item in StaticProperty.pcos.Where(f => f.fornecedorId == item2.id && f.status != DocState.anulado).ToList())
                    {
                        fornecedorNome = StaticProperty.fornecedores.Where(cl => cl.id == item.fornecedorId).First().nome_fantasia;
                        dt.Rows.Add(item.id, fornecedorNome, item.documento, item.data);

                        dataGridView1.DataSource = dt;
                    }
                }
            }
            else if (radioVgt.Checked)
            {
                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.vgts.Where(f => f.documento.Contains(textBox1.Text) || f.data.ToString().Contains(textBox1.Text) && f.status != DocState.anulado))
                {
                    fornecedorNome = StaticProperty.fornecedores.Where(cl => cl.id == item.fornecedorId).First().nome_fantasia;
                    dt.Rows.Add(item.id, fornecedorNome, item.documento, item.data);

                    dataGridView1.DataSource = dt;
                }
                foreach (var item2 in StaticProperty.fornecedores.Where(f => f.nome_fantasia.Contains(textBox1.Text) || f.razao_social.Contains(textBox1.Text)))
                {
                    foreach (var item in StaticProperty.vgts.Where(f => f.fornecedorId == item2.id && f.status != DocState.anulado ).ToList())
                    {
                        fornecedorNome = StaticProperty.fornecedores.Where(cl => cl.id == item.fornecedorId).First().nome_fantasia;
                        dt.Rows.Add(item.id, fornecedorNome, item.documento, item.data);

                        dataGridView1.DataSource = dt;
                    }
                }
            }
            else if (radioVnc.Checked)
            {
                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.vncs.Where(f => f.documento.Contains(textBox1.Text) || f.data.ToString().Contains(textBox1.Text) && f.status != DocState.anulado))
                {
                    fornecedorNome = StaticProperty.fornecedores.Where(cl => cl.id == item.fornecedorId).First().nome_fantasia;
                    dt.Rows.Add(item.id, fornecedorNome, item.documento, item.data);

                    dataGridView1.DataSource = dt;
                }
                foreach (var item2 in StaticProperty.fornecedores.Where(f => f.nome_fantasia.Contains(textBox1.Text) || f.razao_social.Contains(textBox1.Text) && f.status == Status.activo))
                {
                    foreach (var item in StaticProperty.vncs.Where(f => f.fornecedorId == item2.id).ToList())
                    {
                        fornecedorNome = StaticProperty.fornecedores.Where(cl => cl.id == item.fornecedorId).First().nome_fantasia;
                        dt.Rows.Add(item.id, fornecedorNome, item.documento, item.data);

                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }

        private async void estornarPicture_Click(object sender, EventArgs e)
        {
            if (radioVfr.Checked)
            {
                var client = new HttpClient();
                try
                {
                    string documento = StaticProperty.vfrs.Where(cl => cl.id == id).First().documento;

                    client.BaseAddress = new Uri("https://sua-api.com/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Conversão do objeto Film para JSON
                    string json = System.Text.Json.JsonSerializer.Serialize(DocState.estornado);

                    // Envio dos dados para a API
                    HttpResponseMessage responseFr = await client.PutAsync($"https://localhost:7200/api/Compra/Vfr/Change/State/{id}/{DocState.estornado}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (responseFr.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"O documento {documento} foi estornado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um erro mo processo de estorno: {ex.Message}", "Ocorreu um erro", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
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
                if (radioVfr.Checked)
                {

                    documento = StaticProperty.vfrs.Where(cl => cl.id == id).First().documento;

                    // Conversão do objeto Film para JSON
                    string json = System.Text.Json.JsonSerializer.Serialize(DocState.anulado);

                    // Envio dos dados para a API
                    HttpResponseMessage responseVfr = await client.PutAsync($"https://localhost:7200/api/Compra/Vfr/Change/State/{id}/{DocState.anulado}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (responseVfr.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"O documento {documento} foi anulado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else if (radioVft.Checked)
                {
                    documento = StaticProperty.vfts.Where(cl => cl.id == id).First().documento;

                    // Conversão do objeto Film para JSON
                    string json = System.Text.Json.JsonSerializer.Serialize(DocState.anulado);

                    // Envio dos dados para a API
                    HttpResponseMessage responseFt = await client.PutAsync($"https://localhost:7200/api/Compra/Vft/Change/State/{id}/{DocState.anulado}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (responseFt.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"O documento {documento} foi anulado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (radioPco.Checked)
                {
                    documento = StaticProperty.pcos.Where(cl => cl.id == id).First().documento;

                    // Conversão do objeto Film para JSON
                    string json = System.Text.Json.JsonSerializer.Serialize(DocState.anulado);

                    // Envio dos dados para a API
                    HttpResponseMessage responseFp = await client.PutAsync($"https://localhost:7200/api/Compra/Pco/Change/State/{id}/{DocState.anulado}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (responseFp
                        .IsSuccessStatusCode)
                    {
                        MessageBox.Show($"O documento {documento} foi anulado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (radioCot.Checked)
                {
                    documento = StaticProperty.cots.Where(cl => cl.id == id).First().documento;

                    // Conversão do objeto Film para JSON
                    string json = System.Text.Json.JsonSerializer.Serialize(DocState.anulado);

                    // Envio dos dados para a API
                    HttpResponseMessage responseFp = await client.PutAsync($"https://localhost:7200/api/Compra/Cot/Change/State/{id}/{DocState.anulado}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (responseFp
                        .IsSuccessStatusCode)
                    {
                        MessageBox.Show($"O documento {documento} foi anulado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (radioVgt.Checked)
                {
                    documento = StaticProperty.vgts.Where(cl => cl.id == id).First().documento;

                    // Conversão do objeto Film para JSON
                    string json = System.Text.Json.JsonSerializer.Serialize(DocState.anulado);

                    // Envio dos dados para a API
                    HttpResponseMessage responseGt = await client.PutAsync($"https://localhost:7200/api/Compra/Vgt/Change/State/{id}/{DocState.anulado}", new StringContent(json, Encoding.UTF8, "application/json"));

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (radioVfr.Checked)
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            if (radioPco.Checked) { documento = "PCO"; }
            if (radioVfr.Checked) { documento = "VFR"; }
            if (radioVft.Checked) { documento = "VFT"; }
            if (radioVgt.Checked) { documento = "VGT"; }
            if (radioVnc.Checked) { documento = "VNC"; }
            if (radioEcf.Checked) { documento = "ECF"; }

            DocumentosDetalhesForm ddf = new DocumentosDetalhesForm(documento, id, Entidade.fornecedor
                );
            ddf.ShowDialog();
        }
    }
}
