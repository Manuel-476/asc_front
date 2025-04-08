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
using AscFrontEnd.DTOs.Fornecedor;
using AscFrontEnd.DTOs;
using ERP_Buyer.Application.DTOs.Documentos;
using Newtonsoft.Json;
using AscFrontEnd.DTOs.Venda;
using EAscFrontEnd;
using ERP_Seller.Application.DTOs.Documentos;

namespace AscFrontEnd
{
    public partial class CompraListagem : Form
    {
        string fornecedorNome = string.Empty;
        int id;
        string documento;
        List<DocumentoCompra> documentoCompras;
        public CompraListagem()
        {
            InitializeComponent();
            documentoCompras = new List<DocumentoCompra>();
        }

        private void radioFp_CheckedChanged(object sender, EventArgs e)
        {
            if (radioPco.Checked)
            {
                CleanDataGridView();

                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Fornecedor", typeof(string));
                dt.Columns.Add("Documento", typeof(string));
                dt.Columns.Add("Estado", typeof(string));
                dt.Columns.Add("Data", typeof(string));


                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.pcos.Where(f => f.status != DocState.anulado && f.empresaId == StaticProperty.empresaId))
                {
                    fornecedorNome = StaticProperty.fornecedores.Where(f => f.id == item.fornecedorId).First().nome_fantasia;

                    var estado = item.status == DocState.estornado ? "Estornado" : "activo";

                    dt.Rows.Add(item.id, fornecedorNome, item.documento, estado, item.data);

                }
                    dataGridView1.DataSource = dt;
            }
        }

        private void radioCot_CheckedChanged(object sender, EventArgs e)
        {
            if (radioCot.Checked)
            {
                CleanDataGridView();

                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Fornecedor", typeof(string));
                dt.Columns.Add("Documento", typeof(string));
                dt.Columns.Add("Estado", typeof(string));
                dt.Columns.Add("Data", typeof(string));


                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.cots.Where(f => f.status != DocState.anulado && f.empresaId == StaticProperty.empresaId))
                {
                    fornecedorNome = StaticProperty.fornecedores.Where(f => f.id == item.fornecedorId).First().nome_fantasia;

                    var estado = item.status == DocState.estornado ? "Estornado" : "activo";

                    dt.Rows.Add(item.id, fornecedorNome, item.documento, estado, item.data);

                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void CompraListagem_Load(object sender, EventArgs e)
        {
            radioGeral.Checked = true;
            estornarPicture.Enabled = false;

            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("Fornecedor", typeof(string));
            dt.Columns.Add("Documento", typeof(string));
            dt.Columns.Add("Estado", typeof(string));
            dt.Columns.Add("Data", typeof(string));


            // Adicionando linhas ao DataTable
            this.SetCompras();
            foreach (var item in documentoCompras.OrderByDescending(x => x.data))
            {
                if (StaticProperty.fornecedores.Where(f => f.id == item.fornecedorId).Any())
                {
                    fornecedorNome = StaticProperty.fornecedores.Where(f => f.id == item.fornecedorId).First().nome_fantasia;
                }
                var estado = string.Empty;
                if (item.status == DocState.anulado) { estado = "Anulado"; }
                else if (item.status == DocState.estornado) { estado = "Estornado"; }
                else { estado = "activo"; }

                dt.Rows.Add(item.id, fornecedorNome, item.documento, estado, item.data);

            }
            dataGridView1.DataSource = dt;
        }

        private void radioVft_CheckedChanged(object sender, EventArgs e)
        {
            if (radioVft.Checked)
            {
                CleanDataGridView();

                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Fornecedor", typeof(string));
                dt.Columns.Add("Documento", typeof(string));
                dt.Columns.Add("Estado", typeof(string));
                dt.Columns.Add("Data", typeof(string));


                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.vfts.Where(f => f.status != DocState.anulado && f.empresaId == StaticProperty.empresaId))
                {
                    fornecedorNome = StaticProperty.fornecedores.Where(f => f.id == item.fornecedorId).First().nome_fantasia;

                    var estado = item.status == DocState.estornado ? "Estornado" : "activo";

                    dt.Rows.Add(item.id, fornecedorNome, item.documento, estado, item.data);

                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void radioVfr_CheckedChanged(object sender, EventArgs e)
        {
            if (radioVfr.Checked)
            {
                CleanDataGridView();

                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Fornecedor", typeof(string));
                dt.Columns.Add("Documento", typeof(string));
                dt.Columns.Add("Estado", typeof(string));
                dt.Columns.Add("Data", typeof(string));


                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.vfrs.Where(f => f.status != DocState.anulado && f.status != DocState.estornado && f.empresaId == StaticProperty.empresaId).ToList())
                {
                    fornecedorNome = StaticProperty.fornecedores.Where(f => f.id == item.fornecedorId).First().nome_fantasia;

                    var estado = item.status == DocState.estornado ? "Estornado" : "activo";

                    dt.Rows.Add(item.id, fornecedorNome, item.documento, estado, item.data);

                    dataGridView1.DataSource = dt;
                }

            }
        }

        private void radioVgt_CheckedChanged(object sender, EventArgs e)
        {
            if (radioVgt.Checked)
            {
                CleanDataGridView();

                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Fornecedor", typeof(string));
                dt.Columns.Add("Documento", typeof(string));
                dt.Columns.Add("Estado", typeof(string));
                dt.Columns.Add("Data", typeof(string));


                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.vgts.Where(f => f.status != DocState.anulado && f.empresaId == StaticProperty.empresaId))
                {
                    fornecedorNome = StaticProperty.fornecedores.Where(f => f.id == item.fornecedorId).First().nome_fantasia;

                    var estado = item.status == DocState.estornado ? "Estornado" : "activo";

                    dt.Rows.Add(item.id, fornecedorNome, item.documento, estado, item.data);

                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void radioVgr_CheckedChanged(object sender, EventArgs e)
        {
            if (radioVgr.Checked)
            {
                CleanDataGridView();

                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Fornecedor", typeof(string));
                dt.Columns.Add("Documento", typeof(string));
                dt.Columns.Add("Estado", typeof(string));
                dt.Columns.Add("Data", typeof(string));


                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.vgrs.Where(f => f.status != DocState.anulado && f.empresaId == StaticProperty.empresaId))
                {
                    fornecedorNome = StaticProperty.fornecedores.Where(f => f.id == item.fornecedorId).First().nome_fantasia;

                    var estado = item.status == DocState.estornado ? "Estornado" : "activo";

                    dt.Rows.Add(item.id, fornecedorNome, item.documento, estado, item.data);

                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void radioVnc_CheckedChanged(object sender, EventArgs e)
        {
            if (radioVnc.Checked)
            {
                CleanDataGridView();

                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Fornecedor", typeof(string));
                dt.Columns.Add("Documento", typeof(string));
                dt.Columns.Add("Estado", typeof(string));
                dt.Columns.Add("Data", typeof(string));


                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.vncs.Where(x => x.empresaId == StaticProperty.empresaId))
                {
                    fornecedorNome = StaticProperty.fornecedores.Where(f => f.id == item.fornecedorId).First().nome_fantasia;

                    var estado = item.status == DocState.estornado ? "Estornado" : "activo";

                    dt.Rows.Add(item.id, fornecedorNome, item.documento, estado, item.data);

                    dataGridView1.DataSource = dt;
                }
            }
        }
        private void radioAnulado_CheckedChanged(object sender, EventArgs e)
        {
            if (radioAnulado.Checked)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Fornecedor", typeof(string));
                dt.Columns.Add("Documento", typeof(string));
                dt.Columns.Add("Data", typeof(string));


                // Adicionando linhas ao DataTable
                foreach (var item in documentoCompras.Where(f => f.status == DocState.anulado).OrderByDescending(x => x.data))
                {
                    if (StaticProperty.fornecedores.Where(f => f.id == item.fornecedorId).First() != null)
                    {
                        fornecedorNome = StaticProperty.fornecedores.Where(f => f.id == item.fornecedorId).First().nome_fantasia;
                    }

                    dt.Rows.Add(item.id, fornecedorNome, item.documento, item.data);

                }
                dataGridView1.DataSource = dt;
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
                    foreach (var item in StaticProperty.vgts.Where(f => f.fornecedorId == item2.id && f.status != DocState.anulado).ToList())
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
            else if (radioEcf.Checked)
            {
                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.ecfs.Where(f => f.documento.Contains(textBox1.Text) || f.data.ToString().Contains(textBox1.Text) && f.status != DocState.anulado))
                {
                    fornecedorNome = StaticProperty.fornecedores.Where(cl => cl.id == item.fornecedorId).First().nome_fantasia;
                    dt.Rows.Add(item.id, fornecedorNome, item.documento, item.data);

                    dataGridView1.DataSource = dt;
                }
                foreach (var item2 in StaticProperty.fornecedores.Where(f => f.nome_fantasia.Contains(textBox1.Text) || f.razao_social.Contains(textBox1.Text) && f.status == Status.activo))
                {
                    foreach (var item in StaticProperty.ecfs.Where(f => f.fornecedorId == item2.id).ToList())
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

            var client = new HttpClient();
            try
            {

                client.BaseAddress = new Uri("https://localhost:7200/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (radioVfr.Checked)
                {
                    string documento = StaticProperty.vfrs.Where(cl => cl.id == id).First().documento;

                    // Conversão do objeto Film para JSON
                    string json = System.Text.Json.JsonSerializer.Serialize(DocState.estornado);

                    // Envio dos dados para a API
                    HttpResponseMessage responseFr = await client.PutAsync($"api/Compra/Vfr/Change/State/{id}/{DocState.estornado}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (responseFr.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"O documento {documento} foi estornado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (radioVft.Checked)
                {
                    string documento = StaticProperty.vfts.Where(cl => cl.id == id).First().documento;


                    // Conversão do objeto Film para JSON
                    string json = System.Text.Json.JsonSerializer.Serialize(DocState.estornado);

                    // Envio dos dados para a API
                    HttpResponseMessage responseFt = await client.PutAsync($"api/Compra/Vft/Change/State/{id}/{DocState.estornado}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (responseFt.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"O documento {documento} foi estornado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (radioVgr.Checked)
                {
                    string documento = StaticProperty.vfts.Where(cl => cl.id == id).First().documento;


                    // Conversão do objeto Film para JSON
                    string json = System.Text.Json.JsonSerializer.Serialize(DocState.estornado);

                    // Envio dos dados para a API
                    HttpResponseMessage responseFt = await client.PutAsync($"api/Compra/Vgr/Change/State/{id}/{DocState.estornado}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (responseFt.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"O documento {documento} foi estornado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                this.RefreshDocs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro mo processo de estorno: {ex.Message}", "Ocorreu um erro", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }

        }

        private async void anularPicture_Click(object sender, EventArgs e)
        {
            string documento = string.Empty;
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7200/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                if (radioVfr.Checked)
                {

                    documento = StaticProperty.vfrs.Where(cl => cl.id == id).First().documento;

                    // Conversão do objeto Film para JSON
                    string json = System.Text.Json.JsonSerializer.Serialize(DocState.anulado);

                    // Envio dos dados para a API
                    HttpResponseMessage responseVfr = await client.PutAsync($"api/Compra/Vfr/Change/State/{id}/{DocState.anulado}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (responseVfr.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"O documento {documento} foi anulado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.RefreshDocs();
                    }

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
                else if (radioVft.Checked)
                {
                    documento = StaticProperty.vfts.Where(cl => cl.id == id).First().documento;

                    // Conversão do objeto Film para JSON
                    string json = System.Text.Json.JsonSerializer.Serialize(DocState.anulado);

                    // Envio dos dados para a API
                    HttpResponseMessage responseFt = await client.PutAsync($"api/Compra/Vft/Change/State/{id}/{DocState.anulado}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (responseFt.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"O documento {documento} foi anulado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.RefreshDocs();
                    }

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
                else if (radioPco.Checked)
                {
                    documento = StaticProperty.pcos.Where(cl => cl.id == id).First().documento;

                    // Conversão do objeto Film para JSON
                    string json = System.Text.Json.JsonSerializer.Serialize(DocState.anulado);

                    // Envio dos dados para a API
                    HttpResponseMessage responseFp = await client.PutAsync($"api/Compra/Pco/Change/State/{id}/{DocState.anulado}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (responseFp
                        .IsSuccessStatusCode)
                    {
                        MessageBox.Show($"O documento {documento} foi anulado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.RefreshDocs();
                    }

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
                else if (radioCot.Checked)
                {
                    documento = StaticProperty.cots.Where(cl => cl.id == id).First().documento;

                    // Conversão do objeto Film para JSON
                    string json = System.Text.Json.JsonSerializer.Serialize(DocState.anulado);

                    // Envio dos dados para a API
                    HttpResponseMessage responseFp = await client.PutAsync($"api/Compra/Cot/Change/State/{id}/{DocState.anulado}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (responseFp
                        .IsSuccessStatusCode)
                    {
                        MessageBox.Show($"O documento {documento} foi anulado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.RefreshDocs();
                    }

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
                else if (radioVgt.Checked)
                {
                    documento = StaticProperty.vgts.Where(cl => cl.id == id).First().documento;

                    // Conversão do objeto Film para JSON
                    string json = System.Text.Json.JsonSerializer.Serialize(DocState.anulado);

                    // Envio dos dados para a API
                    HttpResponseMessage responseGt = await client.PutAsync($"api/Compra/Vgt/Change/State/{id}/{DocState.anulado}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (responseGt.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"O documento {documento} foi anulado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.RefreshDocs();
                    }

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
                this.RefreshDocs();
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
                if (radioVfr.Checked || radioVft.Checked || radioVgr.Checked)
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
            if (radioVgr.Checked) { documento = "VGR"; }
            if (radioAnulado.Checked || radioGeral.Checked)
            {
                var doc = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                var indexSpace = doc.IndexOf(" ");
                documento = doc.Substring(0, indexSpace);
            }

            DocumentosDetalhesForm ddf = new DocumentosDetalhesForm(documento, id, Entidade.fornecedor
                );
            ddf.ShowDialog();
        }

        private void radioEcf_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("Cliente", typeof(string));
            dt.Columns.Add("Documento", typeof(string));
            dt.Columns.Add("Estado", typeof(string));
            dt.Columns.Add("Data", typeof(string));

            if (radioEcf.Checked)
            {
                CleanDataGridView();

                foreach (var item in StaticProperty.ecfs.Where(x => x.empresaId == StaticProperty.empresaId))
                {
                    if (StaticProperty.artigos.Where(x => x.id == item.ecfArtigo.First().artigoId).First().empresaId == StaticProperty.empresaId)
                    {
                        fornecedorNome = StaticProperty.fornecedores.Where(cl => cl.id == item.fornecedorId).First().nome_fantasia;

                        var estado = item.status == DocState.estornado ? "Estornado" : "activo";

                        dt.Rows.Add(item.id, fornecedorNome, item.documento, estado, item.data);

                    }
                }
                dataGridView1.DataSource = dt;
            }
        }

        public void SetCompras()
        {
            documentoCompras.Clear();
            foreach (var item in StaticProperty.pcos.Where(x => x.empresaId == StaticProperty.empresaId))
            {
                documentoCompras.Add(new DocumentoCompra()
                {
                    id = item.id,
                    fornecedorId = item.fornecedorId,
                    documento = item.documento,
                    data = item.data,
                    status = item.status
                });
            }
            foreach (var item in StaticProperty.cots.Where(x => x.empresaId == StaticProperty.empresaId))
            {
                documentoCompras.Add(new DocumentoCompra()
                {
                    id = item.id,
                    fornecedorId = item.fornecedorId,
                    documento = item.documento,
                    data = item.data,
                    status = item.status
                });
            }
            foreach (var item in StaticProperty.vfts.Where(x => x.empresaId == StaticProperty.empresaId))
            {
                documentoCompras.Add(new DocumentoCompra()
                {
                    id = item.id,
                    fornecedorId = item.fornecedorId,
                    documento = item.documento,
                    data = item.data,
                    status = item.status
                });
            }
            foreach (var item in StaticProperty.vfrs.Where(x => x.empresaId == StaticProperty.empresaId))
            {
                documentoCompras.Add(new DocumentoCompra()
                {
                    id = item.id,
                    fornecedorId = item.fornecedorId,
                    documento = item.documento,
                    data = item.data,
                    status = item.status
                });
            }

            foreach (var item in StaticProperty.ecfs.Where(x => x.empresaId == StaticProperty.empresaId))
            {
                documentoCompras.Add(new DocumentoCompra()
                {
                    id = item.id,
                    fornecedorId = item.fornecedorId,
                    documento = item.documento,
                    data = item.data,
                    status = item.status
                });
            }
            foreach (var item in StaticProperty.vncs.Where(x => x.empresaId == StaticProperty.empresaId))
            {
                documentoCompras.Add(new DocumentoCompra()
                {
                    id = item.id,
                    fornecedorId = item.fornecedorId,
                    documento = item.documento,
                    data = item.data,
                    status = item.status
                });
            }
            foreach (var item in StaticProperty.vnds.Where(x => x.empresaId == StaticProperty.empresaId))
            {
                documentoCompras.Add(new DocumentoCompra()
                {
                    id = item.id,
                    fornecedorId = item.fornecedorId,
                    documento = item.documento,
                    data = item.data,
                    status = item.status
                });
            }

            foreach (var item in StaticProperty.vgts.Where(x => x.empresaId == StaticProperty.empresaId))
            {
                documentoCompras.Add(new DocumentoCompra()
                {
                    id = item.id,
                    fornecedorId = item.fornecedorId,
                    documento = item.documento,
                    data = item.data,
                    status = item.status
                });
            }
            foreach (var item in StaticProperty.vgrs.Where(x => x.empresaId == StaticProperty.empresaId))
            {
                documentoCompras.Add(new DocumentoCompra()
                {
                    id = item.id,
                    fornecedorId = item.fornecedorId,
                    documento = item.documento,
                    data = item.data,
                    status = item.status
                });
            }
        }

        public void CleanDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
        }

        private async void RefreshDocs()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7200/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            try
            {
                var responseVft = await client.GetAsync($"api/Compra/VftByRelations");

                if (responseVft.IsSuccessStatusCode)
                {
                    var contentVft = await responseVft.Content.ReadAsStringAsync();
                    StaticProperty.vfts = JsonConvert.DeserializeObject<List<VftDTO>>(contentVft);
                }

                var responseVfr = await client.GetAsync($"api/Compra/VfrByRelations");

                if (responseVfr.IsSuccessStatusCode)
                {
                    var contentVfr = await responseVfr.Content.ReadAsStringAsync();
                    StaticProperty.vfrs = JsonConvert.DeserializeObject<List<VfrDTO>>(contentVfr);
                }

                var responseVgt = await client.GetAsync($"api/Compra/VgtByRelation");

                if (responseVgt.IsSuccessStatusCode)
                {
                    var contentVgt = await responseVgt.Content.ReadAsStringAsync();
                    StaticProperty.vgts = JsonConvert.DeserializeObject<List<VgtDTO>>(contentVgt);
                }

                var responsePco = await client.GetAsync($"api/Compra/PcoByRelation");

                if (responsePco.IsSuccessStatusCode)
                {
                    var contentPco = await responsePco.Content.ReadAsStringAsync();
                    StaticProperty.pcos = JsonConvert.DeserializeObject<List<PedidoCotacaoDTO>>(contentPco);
                }

                var responseCot = await client.GetAsync($"api/Compra/CotByRelation");

                if (responseCot.IsSuccessStatusCode)
                {
                    var contentCot = await responseCot.Content.ReadAsStringAsync();
                    StaticProperty.cots = JsonConvert.DeserializeObject<List<CotacaoDTO>>(contentCot);
                }

                var responseEcf = await client.GetAsync($"api/Compra/EcfByRelations");

                if (responseEcf.IsSuccessStatusCode)
                {
                    var contentEcf = await responseEcf.Content.ReadAsStringAsync();
                    StaticProperty.ecfs = JsonConvert.DeserializeObject<List<EncomendaFornecedorDTO>>(contentEcf);
                }

                var responseVnc = await client.GetAsync($"api/Compra/VncByRelations");

                if (responseVnc.IsSuccessStatusCode)
                {
                    var contentVnc = await responseVnc.Content.ReadAsStringAsync();
                    StaticProperty.vncs = JsonConvert.DeserializeObject<List<VncDTO>>(contentVnc);
                }

                var responseVnd = await client.GetAsync($"api/Compra/VndByRelation");

                if (responseVnd.IsSuccessStatusCode)
                {
                    var contentVnd = await responseVnd.Content.ReadAsStringAsync();
                    StaticProperty.vnds = JsonConvert.DeserializeObject<List<VndDTO>>(contentVnd);
                }

                radioFp_CheckedChanged(this, EventArgs.Empty);
                radioCot_CheckedChanged(this, EventArgs.Empty);
                radioVft_CheckedChanged(this, EventArgs.Empty);
                radioVfr_CheckedChanged(this, EventArgs.Empty);
                radioVgt_CheckedChanged(this, EventArgs.Empty);
                radioVnc_CheckedChanged(this, EventArgs.Empty);
                radioAnulado_CheckedChanged(this, EventArgs.Empty);
                radioEcf_CheckedChanged(this, EventArgs.Empty);
            }
            catch (Exception ex)
            { throw new Exception($"Erro na actualizacao dos dados: {ex.Message}"); }
        }

    }

    public class DocumentoCompra
    {
        public int id { get; set; }
        public string documento { get; set; }
        public int fornecedorId { get; set; }
        public DocState status { get; set; }
        public DateTime data { get; set; }
        public FornecedorDTO fornecedor { get; set; }
    }
}
