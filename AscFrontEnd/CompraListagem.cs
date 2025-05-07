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
using AscFrontEnd.Application;
using static AscFrontEnd.Venda;
using static AscFrontEnd.Compra;
using AscFrontEnd.DTOs.Compra;
using AscFrontEnd.DTOs.Cliente;
using System.IO;
using Color = System.Drawing.Color;

namespace AscFrontEnd
{
    public partial class CompraListagem : Form
    {
        string fornecedorNome = string.Empty;
        int id;
        string documento;
        string codigoDocumentoOrigem = string.Empty;
        string codigoDocumento = string.Empty;
     

        List<DocumentoCompra> documentoCompras;
        List<CompraArtigo> compraArtigos;
        VncDTO vnc;
        FornecedorDTO fornecedorResult;
        public CompraListagem()
        {
            InitializeComponent();

            documentoCompras = new List<DocumentoCompra>();
            compraArtigos = new List<CompraArtigo>();
            fornecedorResult = new FornecedorDTO();
            vnc = new VncDTO();
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
                foreach (var item in StaticProperty.cots.Where(f => f.status != DocState.anulado && f.empresaId == StaticProperty.empresaId).ToList())
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
                else { estado = item.documento.Contains("ECF ") ? "Pendente" : "activo"; }

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
            List<VncArtigoDTO> vncArtigos = new List<VncArtigoDTO>();
            var client = new HttpClient();
            string documento = string.Empty;

            if (MessageBox.Show($"Documento: {codigoDocumento}\nTem certeza que pretende estornar este documento?", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
            {
                return;
            }
            try
            {

                client.BaseAddress = new Uri("https://localhost:7200/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var formAnulacao = new MotivoAnulacao(OpcaoBinaria.Sim);

                if (formAnulacao.ShowDialog() == DialogResult.OK)
                {
                    if (documento.Equals("VFR"))
                    {
                        var vfr = StaticProperty.vfrs.Where(cl => cl.id == id).First() ?? new VfrDTO();

                        documento = vfr.documento;

                        codigoDocumentoOrigem = documento;

                        fornecedorResult = StaticProperty.fornecedores.Where(cl => cl.id == vfr.fornecedorId).First() ?? new FornecedorDTO();

                        // Conversão do objeto Film para JSON
                         var jsonVfr = System.Text.Json.JsonSerializer.Serialize(DocState.estornado);

                        // Envio dos dados para a API
                        HttpResponseMessage responseFr = await client.PutAsync($"api/Compra/Vfr/Change/State/{id}/{DocState.estornado}", new StringContent(jsonVfr, Encoding.UTF8, "application/json"));

                        if (responseFr.IsSuccessStatusCode)
                        {
                            foreach (var item in vfr.vfrArtigo)
                            {
                                compraArtigos.Add(new CompraArtigo()
                                {
                                    codigo = StaticProperty.artigos.Where(x => x.id == item.artigoId).Any() ?
                                             StaticProperty.artigos.Where(x => x.id == item.artigoId).First().codigo : string.Empty,
                                    iva = item.iva,
                                    preco = item.preco,
                                    qtd = item.qtd
                                });

                                vncArtigos.Add(new VncArtigoDTO()
                                {
                                    artigoId = item.artigoId,
                                    iva = item.iva,
                                    preco = item.preco,
                                    qtd = item.qtd
                                });
                            }

                            MessageBox.Show($"O documento {documento} foi estornado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    if (documento.Equals("VFT"))
                    {
                        var vft = StaticProperty.vfts.Where(cl => cl.id == id).First() ?? new VftDTO();

                        documento = vft.documento;

                        codigoDocumentoOrigem = documento;

                        fornecedorResult = StaticProperty.fornecedores.Where(cl => cl.id == vft.fornecedorId).First() ?? new FornecedorDTO();

                        // Conversão do objeto Film para JSON
                         var jsonVft = System.Text.Json.JsonSerializer.Serialize(DocState.estornado);

                        // Envio dos dados para a API
                        HttpResponseMessage responseFt = await client.PutAsync($"api/Compra/Vft/Change/State/{id}/{DocState.estornado}", new StringContent(jsonVft, Encoding.UTF8, "application/json"));

                        if (responseFt.IsSuccessStatusCode)
                        {
                            foreach (var item in vft.vftArtigo)
                            {
                                compraArtigos.Add(new CompraArtigo()
                                {
                                    codigo = StaticProperty.artigos.Where(x => x.id == item.artigoId).Any()?
                                             StaticProperty.artigos.Where(x => x.id == item.artigoId).First().codigo : string.Empty,
                                    iva = item.iva,
                                    preco = item.preco,
                                    qtd = item.qtd
                                });

                                vncArtigos.Add(new VncArtigoDTO()
                                {
                                    artigoId = item.artigoId,
                                    iva = item.iva,
                                    preco = item.preco,
                                    qtd = item.qtd
                                });
                            }

                            MessageBox.Show($"O documento {documento} foi estornado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    if (documento.Equals("VGR"))
                    {
                        var vgr = StaticProperty.vgrs.Where(cl => cl.id == id).First() ?? new VgrDTO();

                        documento = vgr.documento;

                        codigoDocumentoOrigem = documento;

                        fornecedorResult = StaticProperty.fornecedores.Where(cl => cl.id == vgr.fornecedorId).First() ?? new FornecedorDTO();

                        // Conversão do objeto Film para JSON
                        var jsonVgr = System.Text.Json.JsonSerializer.Serialize(DocState.estornado);

                        // Envio dos dados para a API
                        HttpResponseMessage responseVgr = await client.PutAsync($"api/Compra/Vgr/Change/State/{id}/{DocState.estornado}", new StringContent(jsonVgr, Encoding.UTF8, "application/json"));

                        if (responseVgr.IsSuccessStatusCode)
                        {
                            foreach (var item in vgr.vgrArtigo)
                            {
                                compraArtigos.Add(new CompraArtigo()
                                {
                                    codigo = StaticProperty.artigos.Where(x => x.id == item.artigoId).Any() ?
                                             StaticProperty.artigos.Where(x => x.id == item.artigoId).First().codigo : string.Empty,
                                    iva = item.iva,
                                    preco = item.preco,
                                    qtd = item.qtd
                                });

                                vncArtigos.Add(new VncArtigoDTO()
                                {
                                    artigoId = item.artigoId,
                                    iva = item.iva,
                                    preco = item.preco,
                                    qtd = item.qtd
                                });
                            }

                            MessageBox.Show($"O documento {documento} foi estornado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    var result = await Documento.GetCodigoDocumentoAsync("VNC");

                    codigoDocumento = result.Trim('"');

                    vnc.documento = codigoDocumento;
                    vnc.fornecedorId = fornecedorResult.id;
                    vnc.data = DateTime.UtcNow.Date;
                    vnc.motivo = StaticProperty.motivoAnulacao;
                    vnc.status = DocState.ativo;
                    vnc.documentoOrigem = codigoDocumentoOrigem;
                    vnc.vncArtigo = vncArtigos;
                    vnc.created = DateTime.Now.Date;

                    var json = System.Text.Json.JsonSerializer.Serialize(vnc);

                    HttpResponseMessage responseVnc = await client.PostAsync($"api/Compra/Vnc/{StaticProperty.funcionarioId}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (responseVnc.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"O documento {codigoDocumentoOrigem} foi estornado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    preVisualizacaoDialog.Document = Imprimir;

                    if (preVisualizacaoDialog.ShowDialog() == DialogResult.OK)
                    {
                        Imprimir.Print();
                    }

                    compraArtigos.Clear();
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
            string documentoDoc = string.Empty;
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7200/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (MessageBox.Show($"Documento: {codigoDocumento}\nTem certeza que pretende anular este documento?", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
            {
                return;
            }

            try
            {
                if (documento.Equals("VFR"))
                {

                    documentoDoc = StaticProperty.vfrs.Where(cl => cl.id == id).First().documento;

                    // Conversão do objeto Film para JSON
                    string json = System.Text.Json.JsonSerializer.Serialize(DocState.anulado);

                    // Envio dos dados para a API
                    HttpResponseMessage responseVfr = await client.PutAsync($"api/Compra/Vfr/Change/State/{id}/{DocState.anulado}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (responseVfr.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"O documento {documentoDoc} foi anulado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                else if (documento.Equals("VFT"))
                {
                    documentoDoc = StaticProperty.vfts.Where(cl => cl.id == id).First().documento;

                    // Conversão do objeto Film para JSON
                    string json = System.Text.Json.JsonSerializer.Serialize(DocState.anulado);

                    // Envio dos dados para a API
                    HttpResponseMessage responseFt = await client.PutAsync($"api/Compra/Vft/Change/State/{id}/{DocState.anulado}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (responseFt.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"O documento {documentoDoc} foi anulado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                else if (documento.Equals("PCO"))
                {
                    documentoDoc = StaticProperty.pcos.Where(cl => cl.id == id).First().documento;

                    // Conversão do objeto Film para JSON
                    string json = System.Text.Json.JsonSerializer.Serialize(DocState.anulado);

                    // Envio dos dados para a API
                    HttpResponseMessage responseFp = await client.PutAsync($"api/Compra/Pco/Change/State/{id}/{DocState.anulado}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (responseFp
                        .IsSuccessStatusCode)
                    {
                        MessageBox.Show($"O documento {documentoDoc} foi anulado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                else if (documento.Equals("COT"))
                {
                    documentoDoc = StaticProperty.cots.Where(cl => cl.id == id).First().documento;

                    // Conversão do objeto Film para JSON
                    string json = System.Text.Json.JsonSerializer.Serialize(DocState.anulado);

                    // Envio dos dados para a API
                    HttpResponseMessage responseFp = await client.PutAsync($"api/Compra/Cot/Change/State/{id}/{DocState.anulado}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (responseFp
                        .IsSuccessStatusCode)
                    {
                        MessageBox.Show($"O documento {documentoDoc} foi anulado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                else if (documento.Equals("VGT"))
                {
                    documentoDoc = StaticProperty.vgts.Where(cl => cl.id == id).First().documento;

                    // Conversão do objeto Film para JSON
                    string json = System.Text.Json.JsonSerializer.Serialize(DocState.anulado);

                    // Envio dos dados para a API
                    HttpResponseMessage responseGt = await client.PutAsync($"api/Compra/Vgt/Change/State/{id}/{DocState.anulado}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (responseGt.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"O documento {documentoDoc} foi anulado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                var doc = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                var indexSpace = doc.IndexOf(" ");
                documento = doc.Substring(0, indexSpace);
                codigoDocumento = doc;

                if (documento.Equals("VFR") || documento.Equals("VFT") || documento.Equals("VGR"))
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

        private void Imprimir_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                float totalLiquido = 0f;
                float totalIva = 0f;
                float descontoFornecedor = CalculosVendaCompra.TotalDescontoCompra(compraArtigos, fornecedorResult.desconto);


                float total = 0f;
                float incidencia = 0f;
               
                List<float> listaIvas = new List<float>();

                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string projectPath = Path.GetFullPath(Path.Combine(basePath, @"..\.."));
                string imagePathEmpresa = Path.Combine(projectPath, "Files", "Smart_Entity.png");
                string imagePathAsc = Path.Combine(projectPath, "Files", "asc.png");
                // Testar com valores fixos para desenhar uma string
                Font fontNormal = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Pixel);
                Font fontNormalNegrito = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Pixel);
                Font fontCabecalho = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Pixel);
                Font fontCabecalhoNegrito = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Pixel);
                Brush cor = new SolidBrush(System.Drawing.Color.Black);

                PointF ponto = new PointF(50, 150);
                PointF pontoRight = new PointF(550, 150);

                StringFormat formatToRight = new StringFormat();
                formatToRight.Alignment = StringAlignment.Far;

                StringFormat formatToLeft = new StringFormat();
                formatToLeft.Alignment = StringAlignment.Near;

                StringFormat formatToCenter = new StringFormat();
                formatToCenter.Alignment = StringAlignment.Near;

                var empresa = StaticProperty.empresa;

                var tel = fornecedorResult.phones.Any() ? fornecedorResult.phones.First().telefone : "000000000";

                string empresaNome = $"{fornecedorResult.nome_fantasia.ToUpper()}\n";
                string empresaCabecalho = $"{fornecedorResult.localizacao}\n" +
                                          $"Contribuente: {fornecedorResult.nif}\n" +
                                          $"Email: {fornecedorResult.email ?? ""}\n" +
                                          $"Tel: {tel}";

                string clienteCabecalho = $"{StaticProperty.empresa.nome_fantasia}\n".ToUpper();
                string clienteOutros = $"Cliente Nº {StaticProperty.empresa.id}\n" +
                                       $"Endereco: {StaticProperty.empresa.endereco}\n" +
                                       $"Contribuente: {StaticProperty.empresa.nif}\n" +
                                       $"Email: {StaticProperty.empresa.email}\n" +
                                       $"Tel:{StaticProperty.empresa.telefone} ";

                Pen caneta = new Pen(Color.Black, 2); // Define a cor e a largura da linha
                Pen canetaFina = new Pen(Color.Black, 1);
                float linhaInicioX = 550; // Ponto X de início da linha
                float linhaInicioY = 136; // Ajuste conforme necessário para a posição vertical da linha
                float linhaFimX = 750; // Ponto X de fim da linha


                // Verificar se e.Graphics é válido
                if (e.Graphics == null)
                {
                    throw new Exception("O objeto e.Graphics é nulo.");
                }

                e.Graphics.DrawImage(Image.FromFile(imagePathEmpresa), new Rectangle(40, 50, 100, 100));
                // Desenhar a string
                e.Graphics.DrawString(empresaNome, fontCabecalhoNegrito, cor, new PointF(50, 135), formatToLeft);
                e.Graphics.DrawString(empresaCabecalho, fontCabecalho, cor, ponto, formatToLeft);

                e.Graphics.DrawString("Original", fontNormal, cor, new PointF(750, 120), formatToRight);
                e.Graphics.DrawLine(caneta, linhaInicioX, linhaInicioY, linhaFimX, linhaInicioY);
                e.Graphics.DrawString(clienteCabecalho, fontNormalNegrito, cor, new PointF(550, 138), formatToLeft);
                e.Graphics.DrawString(clienteOutros, fontCabecalho, cor, pontoRight, formatToLeft);


                e.Graphics.DrawString("Anulação", fontNormalNegrito, cor, new PointF(550, 215), formatToLeft);
                e.Graphics.DrawString("Motivo:", fontNormalNegrito, cor, new PointF(550, 230), formatToLeft);
                e.Graphics.DrawString($"{StaticProperty.motivoAnulacao.ToString()}", fontNormal, cor, new PointF(600, 230), formatToLeft);
                e.Graphics.DrawString("Documento de Origem:", fontNormalNegrito, cor, new PointF(550, 245), formatToLeft);
                e.Graphics.DrawString($"{codigoDocumentoOrigem.ToString()}", fontNormal, cor, new PointF(690, 247), formatToLeft);

                e.Graphics.DrawString($"V/Nota de Credito  {codigoDocumento}", fontNormalNegrito, cor, new PointF(50, 280), formatToLeft);
                e.Graphics.DrawLine(canetaFina, 50, 295, 250, 295);
                e.Graphics.DrawString("Contribuente", fontNormalNegrito, cor, new Rectangle(50, 300, 200, 310));
                e.Graphics.DrawString("Desc. Cli", fontNormalNegrito, cor, new Rectangle(200, 300, 350, 310));
                e.Graphics.DrawString("Data Emissão", fontNormalNegrito, cor, new Rectangle(350, 300, 500, 310));
                e.Graphics.DrawString("Data Vencimento", fontNormalNegrito, cor, new Rectangle(500, 300, 650, 310));
                e.Graphics.DrawLine(caneta, 50, 315, 750, 315);

                e.Graphics.DrawString($"{fornecedorResult.nif}", fontNormal, cor, new Rectangle(50, 330, 200, 340));
                e.Graphics.DrawString($"{descontoFornecedor:F2}", fontNormal, cor, new Rectangle(200, 330, 350, 340));
                e.Graphics.DrawString($"{DateTime.Now.Date.ToString("dd-MM-yyyy")}", fontNormal, cor, new Rectangle(350, 330, 450, 340));

                e.Graphics.DrawString($"{DateTime.Now.Date.ToString("dd-MM-yyyy")}", fontNormal, cor, new Rectangle(500, 330, 650, 340));

                e.Graphics.DrawString($"Artigo", fontNormalNegrito, cor, new Rectangle(50, 400, 200, 420));
                e.Graphics.DrawString("Descricao", fontNormalNegrito, cor, new Rectangle(200, 400, 350, 420));
                e.Graphics.DrawString($"Qtd", fontNormalNegrito, cor, new Rectangle(350, 400, 450, 420));
                e.Graphics.DrawString($"Preco", fontNormalNegrito, cor, new Rectangle(450, 400, 550, 420));
                e.Graphics.DrawString("Iva %", fontNormalNegrito, cor, new Rectangle(550, 400, 650, 420));
                e.Graphics.DrawString($"Valor", fontNormalNegrito, cor, new Rectangle(650, 400, 750, 420));
                e.Graphics.DrawLine(caneta, 50, 415, 750, 415);
                int i = 15;
                foreach (CompraArtigo va in compraArtigos)
                {
                    totalIva += va.iva;
                    total += va.preco * float.Parse(va.qtd.ToString());

                    var descricao = StaticProperty.artigos.Where(art => art.codigo == va.codigo).Any() ? StaticProperty.artigos.Where(art => art.codigo == va.codigo).First().descricao : string.Empty;
                    var regimeIva = StaticProperty.artigos.Where(art => art.codigo == va.codigo).Any() ?
                                    (StaticProperty.artigos.Where(art => art.codigo == va.codigo).First().regimeIva == OpcaoBinaria.Sim ? va.iva : 0) : 0;

                    e.Graphics.DrawString($"{va.codigo}", fontNormal, cor, new Rectangle(50, 410 + i, 200, 425 + i));
                    e.Graphics.DrawString($"{descricao}", fontNormal, cor, new Rectangle(200, 410 + i, 350, 425 + i));
                    e.Graphics.DrawString($"{va.qtd}", fontNormal, cor, new Rectangle(350, 410 + i, 450, 425 + i));
                    e.Graphics.DrawString($"{va.preco.ToString("F2")}", fontNormal, cor, new Rectangle(450, 410 + i, 550, 425 + i));
                    e.Graphics.DrawString($"{regimeIva.ToString("F2")} %", fontNormal, cor, new Rectangle(550, 410 + i, 650, 425 + i));
                    e.Graphics.DrawString($"{(va.preco * float.Parse(va.qtd.ToString())).ToString("F2")}", fontNormal, cor, new Rectangle(650, 410 + i, 750, 425 + i));
                    i = i + 15;
                }

                totalLiquido += total - (total * (totalIva / 100));

                string mercadoria = $"Mercadoria/Serviço:";
                string iva = $"Iva:{totalIva.ToString("F2")}";
                string totalIvaValor = $"Total Iva:";
                string totalFinal = $"TOTAL";


                e.Graphics.DrawRectangle(caneta, new Rectangle(540, 530 + i, 210, 70 + i));

                e.Graphics.DrawString(mercadoria, fontCabecalho, cor, new PointF(550, 545 + i), formatToLeft);
                e.Graphics.DrawString(totalLiquido.ToString("F2"), fontCabecalho, cor, new PointF(680, 545 + i), formatToLeft);
                e.Graphics.DrawString(iva, fontCabecalho, cor, new PointF(550, 555 + i), formatToLeft);
                e.Graphics.DrawString(totalIva.ToString("F2"), fontCabecalho, cor, new PointF(680, 555 + i), formatToLeft);
                e.Graphics.DrawString(totalIvaValor, fontCabecalho, cor, new PointF(550, 565 + i), formatToLeft);
                e.Graphics.DrawString((total * (totalIva / 100)).ToString("F2"), fontCabecalho, cor, new PointF(680, 565 + i), formatToLeft);
                e.Graphics.DrawString("Desconto", fontCabecalho, cor, new PointF(550, 595 + i), formatToLeft);
                e.Graphics.DrawString($"{descontoFornecedor:F2}", fontCabecalho, cor, new PointF(680, 595 + i), formatToLeft);

                e.Graphics.DrawLine(canetaFina, 550, 583 + i, 740, 583 + i);
                e.Graphics.DrawString(totalFinal, fontNormalNegrito, cor, new PointF(550, 620 + i), formatToLeft);
                e.Graphics.DrawString(total.ToString("F2"), fontNormalNegrito, cor, new PointF(680, 620 + i), formatToLeft);

                string conta = $"Conta nº";
                string iban = $"IBAN ";
                string banco = $"Banco Angolano de Investimento";

                e.Graphics.DrawString($"Precessado pelo programa válido nº{"41/AGT/2020"} Asc - Smart Entity", fontCabecalho, cor, new PointF(250, 515 + i), formatToCenter);
                e.Graphics.DrawString($"Resumo Imposto", fontCabecalho, cor, new PointF(50, 515 + i), formatToCenter);

                e.Graphics.DrawLine(caneta, 50, 530 + i, 530, 530 + i);
                e.Graphics.DrawString("Descrição", new Font("Arial", 10, GraphicsUnit.Pixel), cor, new PointF(50, 540 + i), formatToLeft);
                e.Graphics.DrawString("Taxa %", fontCabecalhoNegrito, cor, new PointF(130, 540 + i), formatToLeft);
                e.Graphics.DrawString("Incidência", fontCabecalho, cor, new PointF(200, 540 + i), formatToLeft);
                e.Graphics.DrawString($"Valor imposto", fontCabecalho, cor, new PointF(300, 540 + i), formatToLeft);
                e.Graphics.DrawString("Motivo Isenção", fontCabecalho, cor, new PointF(400, 540 + i), formatToLeft);


                // Pegar os dados dos artigo com iva aplicado
                foreach (var item in compraArtigos)
                {
                    if (StaticProperty.artigos.Where(x => x.codigo == item.codigo).First().regimeIva == OpcaoBinaria.Sim)
                    {
                        if (!listaIvas.Contains(item.iva))
                        {
                            listaIvas.Add(item.iva);
                        }
                    }
                }
                e.Graphics.DrawLine(caneta, 50, 555 + i, 530, 555 + i);
                if (listaIvas.Any())
                {
                    foreach (float ivas in listaIvas)
                    {
                        e.Graphics.DrawString("Iva", fontCabecalhoNegrito, cor, new PointF(50, 560 + i), formatToLeft);
                        e.Graphics.DrawString(ivas.ToString("F2"), new Font("Arial", 10, FontStyle.Underline, GraphicsUnit.Pixel), cor, new PointF(130, 560 + i), formatToLeft);
                        e.Graphics.DrawString(compraArtigos.Where(x => x.iva == ivas).Sum(x => x.preco * x.qtd).ToString("F4"), fontCabecalho, cor, new PointF(200, 560 + i), formatToLeft);
                        e.Graphics.DrawString(compraArtigos.Where(x => x.iva == ivas).Sum(x => ((x.preco * x.qtd) * (x.iva / 100))).ToString("F4"), fontCabecalho, cor, new PointF(300, 560 + i), formatToLeft);
                        e.Graphics.DrawString("", fontCabecalho, cor, new PointF(430, 560 + i), formatToLeft);
                        i = i + 10;
                    }
                }
                // Artigos com iva isento
                foreach (var motivo in StaticProperty.motivosIsencao)
                {
                    foreach (var item in compraArtigos)
                    {
                        if (StaticProperty.artigos.Where(x => x.codigo == item.codigo && x.codigoIva == motivo.codigo).Any())
                        {
                            if (StaticProperty.artigos.Where(x => x.codigo == item.codigo && x.codigoIva == motivo.codigo).First().regimeIva == OpcaoBinaria.Nao)
                            {
                                incidencia += item.preco * item.qtd;
                            }
                        }
                    }
                    if (incidencia > 0)
                    {

                        e.Graphics.DrawString("Isento", fontCabecalhoNegrito, cor, new PointF(50, 560 + i), formatToLeft);
                        e.Graphics.DrawString("0,00", new Font("Arial", 10, FontStyle.Underline, GraphicsUnit.Pixel), cor, new PointF(130, 560 + i), formatToLeft);
                        e.Graphics.DrawString(incidencia.ToString("F4"), fontCabecalho, cor, new PointF(200, 560 + i), formatToLeft);
                        e.Graphics.DrawString("0,00", fontCabecalho, cor, new PointF(300, 560 + i), formatToLeft);
                        e.Graphics.DrawString($"{motivo.mencao}", fontCabecalho, cor, new PointF(400, 560 + i), formatToLeft);
                        i = i + 10;
                        incidencia = 0;
                    }

                }

                // Desenhando a imagem no documento
                e.Graphics.DrawImage(Image.FromFile(imagePathAsc), new Rectangle(10, 900, 200, 90));


                Console.WriteLine("Texto desenhado com sucesso.");

                // Liberar recursos
                fontNormal.Dispose();
                cor.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                throw new Exception("Erro ao desenhar a string: " + ex.Message);
            }
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
