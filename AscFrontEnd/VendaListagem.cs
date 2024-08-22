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
using AscFrontEnd.DTOs.Fornecedor;
using AscFrontEnd.DTOs.Cliente;
using AscFrontEnd.DTOs.Venda;
using EAscFrontEnd;
using ERP_Seller.Application.DTOs.Documentos;
using Newtonsoft.Json;

namespace AscFrontEnd
{
    public partial class VendaListagem : Form
    {
        string clienteNome = string.Empty;
        public int id;
        string documento;
        List<DocumentoVenda> documentoVendas;
        public VendaListagem()
        {
            InitializeComponent();
            documentoVendas = new List<DocumentoVenda>();
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
            dt.Columns.Add("Data", typeof(string));


            // Adicionando linhas ao DataTable
            foreach (var item in StaticProperty.fps)
            {
                if (StaticProperty.artigos.Where(x => x.id == item.fpArtigo.First().artigoId).First().empresaId == StaticProperty.empresaId)
                {
                    clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;
                    dt.Rows.Add(item.id, clienteNome, item.documento, item.data);

                    dataGridView1.DataSource = dt;
                }
            }
            foreach (var item in StaticProperty.fps)
            {
                documentoVendas.Add(new DocumentoVenda()
                {
                    id = item.id,
                    clienteId = item.clienteId,
                    documento = item.documento,
                    data = item.data,
                    status = item.status
                });
            }
            foreach (var item in StaticProperty.fts)
            {
                documentoVendas.Add(new DocumentoVenda()
                {
                    id = item.id,
                    clienteId = item.clienteId,
                    documento = item.documento,
                    data = item.data,
                    status = item.status
                });
            }
            foreach (var item in StaticProperty.frs)
            {
                documentoVendas.Add(new DocumentoVenda()
                {
                    id = item.id,
                    clienteId = item.clienteId,
                    documento = item.documento,
                    data = item.data,
                    status = item.status
                });
            }

            foreach (var item in StaticProperty.ecls)
            {
                documentoVendas.Add(new DocumentoVenda()
                {
                    id = item.id,
                    clienteId = item.clienteId,
                    documento = item.documento,
                    data = item.data,
                    status = item.status
                });
            }
            foreach (var item in StaticProperty.ncs)
            {
                documentoVendas.Add(new DocumentoVenda()
                {
                    id = item.id,
                    clienteId = item.clienteId,
                    documento = item.documento,
                    data = item.data,
                    status = item.status
                });
            }
            foreach (var item in StaticProperty.nds)
            {
                documentoVendas.Add(new DocumentoVenda()
                {
                    id = item.id,
                    clienteId = item.clienteId,
                    documento = item.documento,
                    data = item.data,
                    status = item.status
                });
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
                dt.Columns.Add("Data", typeof(string));


                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.fts.Where(v => v.status != DocState.estornado && v.status != DocState.anulado && v.cliente.empresaid == StaticProperty.empresaId))
                {
                    if (StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First() != null)
                    {
                        clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;
                    }
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
                dt.Columns.Add("Data", typeof(string));


                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.frs.Where(v => v.status != DocState.anulado && v.status != DocState.estornado))
                {
                    if (StaticProperty.artigos.Where(x => x.id == item.frArtigo.First().artigoId).First().empresaId == StaticProperty.empresaId)
                    {
                        clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;
                        dt.Rows.Add(item.id, clienteNome, item.documento, item.data);

                        dataGridView1.DataSource = dt;
                    }
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
                dt.Columns.Add("Data", typeof(string));


                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.gts.Where(v => v.status != DocState.anulado))
                {
                    if (StaticProperty.artigos.Where(x => x.id == item.gtArtigo.First().artigoId).First().empresaId == StaticProperty.empresaId)
                    {
                        clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;
                        dt.Rows.Add(item.id, clienteNome, item.documento, item.data);

                        dataGridView1.DataSource = dt;
                    }
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
                dt.Columns.Add("Data", typeof(string));


                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.ncs.Where(v => v.status != DocState.anulado))
                {
                    if (StaticProperty.artigos.Where(x => x.id == item.ncArtigo.First().artigoId).First().empresaId == StaticProperty.empresaId)
                    {
                        clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;
                        dt.Rows.Add(item.id, clienteNome, item.documento, item.data);

                        dataGridView1.DataSource = dt;
                    }
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
                if (radioAnulado.Checked) {anularPicture.Enabled = false;}
                else { anularPicture.Enabled = true; }
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
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um erro mo processo de estorno: {ex.Message}", "Ocorreu um erro", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
            }
        }

        private void radioFp_CheckedChanged(object sender, EventArgs e)
        {
            if (radioFp.Checked)
            {
               

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
                        this.RefreshDocs();
                    }
                    DataTable dt = new DataTable();
                    dt.Columns.Add("id", typeof(int));
                    dt.Columns.Add("Cliente", typeof(string));
                    dt.Columns.Add("Documento", typeof(string));
                    dt.Columns.Add("Data", typeof(string));


                    // Adicionando linhas ao DataTable
                    foreach (var item in StaticProperty.frs.Where(v => v.status != DocState.anulado && v.status != DocState.estornado))
                    {
                        if (StaticProperty.artigos.Where(x => x.id == item.frArtigo.First().artigoId).First().empresaId == StaticProperty.empresaId)
                        {
                            clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;
                            dt.Rows.Add(item.id, clienteNome, item.documento, item.data);

                            dataGridView1.DataSource = dt;
                        }
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
                        this.RefreshDocs();
                    }

                    DataTable dt = new DataTable();
                    dt.Columns.Add("id", typeof(int));
                    dt.Columns.Add("Cliente", typeof(string));
                    dt.Columns.Add("Documento", typeof(string));
                    dt.Columns.Add("Data", typeof(string));


                    // Adicionando linhas ao DataTable
                    foreach (var item in StaticProperty.fts.Where(v => v.status != DocState.estornado && v.status != DocState.anulado && v.cliente.empresaid == StaticProperty.empresaId))
                    {
                        clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;
                        dt.Rows.Add(item.id, clienteNome, item.documento, item.data);

                        dataGridView1.DataSource = dt;
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
                        this.RefreshDocs();
                    }

                    DataTable dt = new DataTable();
                    dt.Columns.Add("id", typeof(int));
                    dt.Columns.Add("Cliente", typeof(string));
                    dt.Columns.Add("Documento", typeof(string));
                    dt.Columns.Add("Data", typeof(float));


                    // Adicionando linhas ao DataTable
                    foreach (var item in StaticProperty.fps.Where(v => v.status != DocState.anulado))
                    {
                        if (StaticProperty.artigos.Where(x => x.id == item.fpArtigo.First().artigoId).First().empresaId == StaticProperty.empresaId)
                        {
                            clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;
                            dt.Rows.Add(item.id, clienteNome, item.documento, item.data);

                            dataGridView1.DataSource = dt;
                        }
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
                        this.RefreshDocs();
                    }

                    DataTable dt = new DataTable();
                    dt.Columns.Add("id", typeof(int));
                    dt.Columns.Add("Cliente", typeof(string));
                    dt.Columns.Add("Documento", typeof(string));
                    dt.Columns.Add("Data", typeof(string));


                    // Adicionando linhas ao DataTable
                    foreach (var item in StaticProperty.gts.Where(v => v.status != DocState.anulado))
                    {
                        if (StaticProperty.artigos.Where(x => x.id == item.gtArtigo.First().artigoId).First().empresaId == StaticProperty.empresaId)
                        {
                            clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;
                            dt.Rows.Add(item.id, clienteNome, item.documento, item.data);

                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro no processo de anulacao de documento: {ex.Message}", "Ocorreu um erro", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("Cliente", typeof(string));
            dt.Columns.Add("Documento", typeof(string));
            dt.Columns.Add("Data", typeof(string));
            if (radioFt.Checked)
            {
                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.fts.Where(f => f.documento.Contains(textBox1.Text) || f.data.ToString().Contains(textBox1.Text) && f.status != DocState.anulado))
                {
                    clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;
                    dt.Rows.Add(item.id, clienteNome, item.documento, item.data);

                    dataGridView1.DataSource = dt;
                }
                foreach (var item2 in StaticProperty.clientes.Where(f => f.nome_fantasia.Contains(textBox1.Text) || f.razao_social.Contains(textBox1.Text)))
                {
                    foreach (var item in StaticProperty.fts.Where(f => f.clienteId == item2.id && f.status != DocState.anulado).ToList())
                    {
                        clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;
                        dt.Rows.Add(item.id, clienteNome, item.documento, item.data);

                        dataGridView1.DataSource = dt;
                    }
                }
            }
            else if (radioFr.Checked)
            {
                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.frs.Where(f => f.documento.Contains(textBox1.Text) || f.data.ToString().Contains(textBox1.Text) && f.status != DocState.anulado && f.status != DocState.estornado))
                {
                    clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;
                    dt.Rows.Add(item.id, clienteNome, item.documento, item.data);

                    dataGridView1.DataSource = dt;
                }
                foreach (var item2 in StaticProperty.clientes.Where(f => f.nome_fantasia.Contains(textBox1.Text) || f.razao_social.Contains(textBox1.Text)))
                {
                    foreach (var item in StaticProperty.frs.Where(f => f.clienteId == item2.id && f.status != DocState.anulado && f.status != DocState.estornado).ToList())
                    {
                        clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;
                        dt.Rows.Add(item.id, clienteNome, item.documento, item.data);

                        dataGridView1.DataSource = dt;
                    }
                }
            }
            else if (radioFp.Checked)
            {
                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.fps.Where(f => f.documento.Contains(textBox1.Text) || f.data.ToString().Contains(textBox1.Text) && f.status != DocState.anulado))
                {
                    clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;
                    dt.Rows.Add(item.id, clienteNome, item.documento, item.data);

                    dataGridView1.DataSource = dt;
                }
                foreach (var item2 in StaticProperty.clientes.Where(f => f.nome_fantasia.Contains(textBox1.Text) || f.razao_social.Contains(textBox1.Text)))
                {
                    foreach (var item in StaticProperty.fps.Where(f => f.clienteId == item2.id && f.status != DocState.anulado).ToList())
                    {
                        clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;
                        dt.Rows.Add(item.id, clienteNome, item.documento, item.data);

                        dataGridView1.DataSource = dt;
                    }
                }
            }
            else if (radioGt.Checked)
            {
                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.gts.Where(f => f.documento.Contains(textBox1.Text) || f.data.ToString().Contains(textBox1.Text) && f.status != DocState.anulado))
                {
                    clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;
                    dt.Rows.Add(item.id, clienteNome, item.documento, item.data);

                    dataGridView1.DataSource = dt;
                }
                foreach (var item2 in StaticProperty.clientes.Where(f => f.nome_fantasia.Contains(textBox1.Text) || f.razao_social.Contains(textBox1.Text)))
                {
                    foreach (var item in StaticProperty.gts.Where(f => f.clienteId == item2.id && f.status != DocState.anulado).ToList())
                    {
                        clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;
                        dt.Rows.Add(item.id, clienteNome, item.documento, item.data);

                        dataGridView1.DataSource = dt;
                    }
                }
            }
            else if (radioNc.Checked)
            {
                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.ncs.Where(f => f.documento.Contains(textBox1.Text) || f.data.ToString().Contains(textBox1.Text) && f.status != DocState.anulado))
                {
                    clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;
                    dt.Rows.Add(item.id, clienteNome, item.documento, item.data);

                    dataGridView1.DataSource = dt;
                }
                foreach (var item2 in StaticProperty.clientes.Where(f => f.nome_fantasia.Contains(textBox1.Text) || f.razao_social.Contains(textBox1.Text)))
                {
                    foreach (var item in StaticProperty.ncs.Where(f => f.clienteId == item2.id && f.status != DocState.anulado).ToList())
                    {
                        clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;
                        dt.Rows.Add(item.id, clienteNome, item.documento, item.data);

                        dataGridView1.DataSource = dt;
                    }
                }
            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            if (radioFp.Checked) { documento = "FP"; }
            if (radioFr.Checked) { documento = "FR"; }
            if (radioFt.Checked) { documento = "FT"; }
            if (radioGt.Checked) { documento = "GT"; }
            if (radioNc.Checked) { documento = "NC"; }
            if (radioEcl.Checked) { documento = "ECL"; }

            DocumentosDetalhesForm ddf = new DocumentosDetalhesForm(documento, id, Entidade.cliente);
            ddf.ShowDialog();
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
                foreach (var item in documentoVendas.Where(f => f.status == DocState.anulado).OrderByDescending(x => x.data))
                {
                    if (StaticProperty.clientes.Where(f => f.id == item.clienteId).First() != null)
                    {
                        clienteNome = StaticProperty.clientes.Where(f => f.id == item.clienteId).First().nome_fantasia;
                    }

                    dt.Rows.Add(item.id, clienteNome, item.documento, item.data);

                    dataGridView1.DataSource = dt;
                }
            }

        }
        private async void RefreshDocs()
        {
            var client = new HttpClient();
            try
            {
                var responseFr = await client.GetAsync($"https://localhost:7200/api/Venda/FrByRelations");

                if (responseFr.IsSuccessStatusCode)
                {
                    var contentFr = await responseFr.Content.ReadAsStringAsync();
                    StaticProperty.frs = JsonConvert.DeserializeObject<List<FrDTO>>(contentFr);
                }

                var responseFt = await client.GetAsync($"https://localhost:7200/api/Venda/FtByRelations");

                if (responseFt.IsSuccessStatusCode)
                {
                    var contentFt = await responseFt.Content.ReadAsStringAsync();
                    StaticProperty.fts = JsonConvert.DeserializeObject<List<FtDTO>>(contentFt);
                }

                var responseEcl = await client.GetAsync($"https://localhost:7200/api/Venda/EclByRelations");

                if (responseEcl.IsSuccessStatusCode)
                {
                    var contentEcl = await responseEcl.Content.ReadAsStringAsync();
                    StaticProperty.ecls = JsonConvert.DeserializeObject<List<EncomendaClienteDTO>>(contentEcl);
                }

                var responseFp = await client.GetAsync($"https://localhost:7200/api/Venda/FpByRelations");

                if (responseFp.IsSuccessStatusCode)
                {
                    var contentFp = await responseFp.Content.ReadAsStringAsync();
                    StaticProperty.fps = JsonConvert.DeserializeObject<List<FaturaProformaDTO>>(contentFp);
                }

                var responseNc = await client.GetAsync($"https://localhost:7200/api/Venda/NcByRelations");

                if (responseNc.IsSuccessStatusCode)
                {
                    var contentNc = await responseNc.Content.ReadAsStringAsync();
                    StaticProperty.ncs = JsonConvert.DeserializeObject<List<NcDTO>>(contentNc);
                }

                var responseNd = await client.GetAsync($"https://localhost:7200/api/Venda/NdByRelations");

                if (responseNd.IsSuccessStatusCode)
                {
                    var contentNd = await responseNd.Content.ReadAsStringAsync();
                    StaticProperty.nds = JsonConvert.DeserializeObject<List<NdDTO>>(contentNd);
                }

                var responseGt = await client.GetAsync($"https://localhost:7200/api/Venda/GtByRelations");

                if (responseGt.IsSuccessStatusCode)
                {
                    var contentGt = await responseNd.Content.ReadAsStringAsync();
                    StaticProperty.gts = JsonConvert.DeserializeObject<List<GtDTO>>(contentGt);
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao carregar os dados: {ex.Message}");
            }
        }
    } 
    public class DocumentoVenda
    {
        public int id { get; set; }
        public string documento { get; set; }
        public int clienteId { get; set; }
        public DocState status { get; set; }
        public DateTime data { get; set; }
        public ClienteDTO cliente { get; set; }
    }
}
