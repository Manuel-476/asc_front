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
using System.IO;
using static AscFrontEnd.Venda;
using AscFrontEnd.Application;
using DocumentFormat.OpenXml.Office.ActiveX;

namespace AscFrontEnd
{
    public partial class VendaListagem : Form
    {
        string clienteNome = string.Empty;
        public int id;
        string documento;
        string codigoDocumentoOrigem = string.Empty;
        string codigoDocumento = string.Empty;
        string json = string.Empty;

        List<DocumentoVenda> documentoVendas;
        List<VendaArtigo> vendaArtigos;
        List<ArtigoDTO> dados;
        NcDTO nc;
        HttpClient client;

        ClienteDTO clienteResult;
        public VendaListagem()
        {
            InitializeComponent();

            documentoVendas = new List<DocumentoVenda>();
            vendaArtigos = new List<VendaArtigo>();
            clienteResult = new ClienteDTO();
            dados = StaticProperty.artigos;
            nc = new NcDTO();

            client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            client.BaseAddress = new Uri("http://localhost:7200/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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

            radioGeral.Checked = true;

            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("Cliente", typeof(string));
            dt.Columns.Add("Documento", typeof(string));
            dt.Columns.Add("Estado", typeof(string));
            dt.Columns.Add("Data", typeof(string));

            this.SetVendas();
            this.ActivarBotaoAprovar();
            // Adicionando linhas ao DataTable
            if (documentoVendas != null)
            {
                foreach (var item in documentoVendas.OrderByDescending(f => f.data))
                {
                    clienteNome = StaticProperty.clientes != null? StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia : string.Empty;

                    var estado = string.Empty;
                    if (item.status == DocState.anulado) { estado = "Anulado"; }
                    else if (item.status == DocState.estornado) { estado = "Estornado"; }
                    else if (item.status == DocState.resolvido) { estado = "activo"; }
                    else { estado = item.documento.Contains("ECL ") ? "Pendente" : "activo"; }

                    dt.Rows.Add(item.id, clienteNome, item.documento, estado, item.data);
                }
            }
            dataGridView1.DataSource = dt;


        }

        private void radioFt_CheckedChanged(object sender, EventArgs e)
        {
            if (radioFt.Checked)
            {
                ActivarBotaoAprovar();

                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Cliente", typeof(string));
                dt.Columns.Add("Documento", typeof(string));
                dt.Columns.Add("Estado", typeof(string));               
                dt.Columns.Add("Data", typeof(string));

                if ( StaticProperty.fts == null || !StaticProperty.fts.Any())
                {
                    this.CleanDataGridView();
                }
                else
                {
                    if (StaticProperty.fts != null)
                    {
                        // Adicionando linhas ao DataTable
                        foreach (var item in StaticProperty.fts.Where(v => v.status != DocState.anulado && v.empresaId == StaticProperty.empresaId))
                        {
                            if (StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First() != null)
                            {
                                clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;
                            }
                            var estado = item.status == DocState.estornado ? "Estornado" : "activo";

                            dt.Rows.Add(item.id, clienteNome, item.documento, estado, item.data);

                        }
                    }
                        dataGridView1.DataSource = dt;
                }
            }
        }

        private void radioFr_CheckedChanged(object sender, EventArgs e)
        {
            if (radioFr.Checked)
            {
                ActivarBotaoAprovar();

                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Cliente", typeof(string));
                dt.Columns.Add("Documento", typeof(string));
                dt.Columns.Add("Estado", typeof(string));
                dt.Columns.Add("Data", typeof(string));

                if (StaticProperty.frs == null || !StaticProperty.frs.Any())
                {
                    this.CleanDataGridView();
                }
                else
                {
                    if (StaticProperty.frs != null)
                    {
                        // Adicionando linhas ao DataTable
                        foreach (var item in StaticProperty.frs.Where(v => v.status != DocState.anulado && v.empresaId == StaticProperty.empresaId))
                        {
                            if (StaticProperty.artigos.Where(x => x.id == item.frArtigo.First().artigoId).First().empresaId == StaticProperty.empresaId)
                            {
                                clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;

                                var estado = item.status == DocState.estornado ? "Estornado" : "activo";

                                dt.Rows.Add(item.id, clienteNome, item.documento, estado, item.data);
                            }
                        }
                            dataGridView1.DataSource = dt;
                    }
                }
            }
        }

        private void radioGt_CheckedChanged(object sender, EventArgs e)
        {
            if (radioGt.Checked)
            {
                ActivarBotaoAprovar();

                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Cliente", typeof(string));
                dt.Columns.Add("Documento", typeof(string));
                dt.Columns.Add("Estado", typeof(string));
                dt.Columns.Add("Data", typeof(string));

                if (StaticProperty.gts == null ||  !StaticProperty.gts.Any()  )
                {
                    this.CleanDataGridView();
                }
                else
                {
                    if(StaticProperty.gts != null) {
                        // Adicionando linhas ao DataTable
                        foreach (var item in StaticProperty.gts.Where(v => v.status != DocState.anulado && v.empresaId == StaticProperty.empresaId))
                        {
                            if (StaticProperty.artigos.Where(x => x.id == item.gtArtigo.First().artigoId).First().empresaId == StaticProperty.empresaId)
                            {
                                clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;

                                var estado = item.status == DocState.estornado ? "Estornado" : "activo";

                                dt.Rows.Add(item.id, clienteNome, item.documento, estado, item.data);


                            }
                        }
                    }
                        dataGridView1.DataSource = dt;
                }
            }
        }

        private void radioNv_CheckedChanged(object sender, EventArgs e)
        {
            if (radioNc.Checked)
            {
                ActivarBotaoAprovar();

                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Cliente", typeof(string));
                dt.Columns.Add("Documento", typeof(string));
                dt.Columns.Add("Estado", typeof(string));
                dt.Columns.Add("Data", typeof(string));

                if (StaticProperty.ncs == null || !StaticProperty.ncs.Any())
                {
                    this.CleanDataGridView();
                }
                else
                {
                    if (StaticProperty.ncs != null)
                    {
                        // Adicionando linhas ao DataTable
                        foreach (var item in StaticProperty.ncs.Where(v => v.status != DocState.anulado && v.empresaId == StaticProperty.empresaId))
                        {
                            if (StaticProperty.artigos.Where(x => x.id == item.ncArtigo.First().artigoId).First().empresaId == StaticProperty.empresaId)
                            {
                                clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;

                                var estado = item.status == DocState.estornado ? "Estornado" : "activo";

                                dt.Rows.Add(item.id, clienteNome, item.documento, estado, item.data);

                            }
                        }
                            dataGridView1.DataSource = dt;
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var doc = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                var estado = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

                documento = Documento.GetCodigoDocumento(doc); 
                codigoDocumento = doc;

                if (documento.Equals("FR") || documento.Equals("FT") || documento.Equals("GR"))
                {
                    if (estado != "Estornado")
                    {
                        estornarPicture.Enabled = true;
                    }
                    else 
                    {
                        estornarPicture.Enabled = false;
                    }
                }
                else
                {
                    estornarPicture.Enabled = false;
                    
                }

                if (radioAnulado.Checked)
                { 
                    anularPicture.Enabled = false; 
                }
                else 
                { 
                    anularPicture.Enabled = true; 
                }



                ActivarBotaoAprovar();

                id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

                if (documento.Equals("OR")) 
                {
                    if (StaticProperty.ors != null)
                    {
                        if (StaticProperty.ors.Where(x => x.id == id).Any())
                        {
                            if (StaticProperty.ors.Where(x => x.id == id).First().aprovado == OpcaoBinaria.Sim)
                            {
                                estornarPicture.Enabled = true;
                            }
                        }
                    }
                }
            }
            catch
            {
                return;
            }

        }

        private async void estornarPicture_Click(object sender, EventArgs e)
        {

            List<NcArtigoDTO> ncArtigos = new List<NcArtigoDTO>();
            try
            {
                var formAnulacao = new MotivoAnulacao(OpcaoBinaria.Sim);

                if (MessageBox.Show($"Documento: {codigoDocumento}\nTem certeza que pretende estornar este documento?", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                {
                    return;
                }

                if (formAnulacao.ShowDialog() == DialogResult.OK)
                {

                    if (documento.Equals("FR"))
                    {
                        if (StaticProperty.frs != null)
                        {
                            var fr = StaticProperty.frs.Where(cl => cl.id == id).First();
                            codigoDocumentoOrigem = fr.documento;

                            clienteResult = StaticProperty.clientes.Where(cl => cl.id == fr.clienteId).First();

                            foreach (var item in fr.frArtigo)
                            {
                                vendaArtigos.Add(new Venda.VendaArtigo()
                                {
                                    codigo = StaticProperty.artigos.Where(x => x.id == item.artigoId).First().codigo,
                                    iva = item.iva,
                                    preco = item.preco,
                                    qtd = item.qtd
                                });

                                ncArtigos.Add(new NcArtigoDTO()
                                {
                                    artigoId = item.artigoId,
                                    iva = item.iva,
                                    preco = item.preco,
                                    qtd = item.qtd
                                });
                            }

                            // Conversão do objeto Film para JSON
                            json = System.Text.Json.JsonSerializer.Serialize(DocState.estornado);

                            // Envio dos dados para a API
                            HttpResponseMessage responseFr = await client.PutAsync($"api/Venda/Fr/Change/State/{id}/{DocState.estornado}", new StringContent(json, Encoding.UTF8, "application/json"));

                            if (responseFr.IsSuccessStatusCode)
                            {
                                MessageBox.Show($"O documento {codigoDocumentoOrigem} foi estornado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else if (documento.Equals("FT"))
                    {
                        if (StaticProperty.fts != null)
                        {
                            var ft = StaticProperty.fts.Where(cl => cl.id == id).First();

                            codigoDocumentoOrigem = ft.documento;

                            clienteResult = StaticProperty.clientes.Where(cl => cl.id == ft.clienteId).First();

                            foreach (var item in ft.ftArtigo)
                            {
                                vendaArtigos.Add(new Venda.VendaArtigo()
                                {
                                    codigo = StaticProperty.artigos.Where(x => x.id == item.artigoId).First().codigo,
                                    iva = item.iva,
                                    preco = item.preco,
                                    qtd = item.qtd
                                });
                                ncArtigos.Add(new NcArtigoDTO()
                                {
                                    artigoId = item.artigoId,
                                    iva = item.iva,
                                    preco = item.preco,
                                    qtd = item.qtd
                                });
                            }

                            // Conversão do objeto Film para JSON
                            string json = System.Text.Json.JsonSerializer.Serialize(DocState.estornado);

                            // Envio dos dados para a API
                            HttpResponseMessage responseF = await client.PutAsync($"api/Venda/Ft/Change/State/{id}/{DocState.estornado}", new StringContent(json, Encoding.UTF8, "application/json"));

                            if (responseF.IsSuccessStatusCode)
                            {
                                MessageBox.Show($"O documento {codigoDocumentoOrigem} foi estornado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else if (documento.Equals("GR"))
                    {
                        if (StaticProperty.grs != null)
                        {
                            var gr = StaticProperty.grs.Where(cl => cl.id == id).First();

                            codigoDocumentoOrigem = gr.documento;

                            clienteResult = StaticProperty.clientes.Where(cl => cl.id == gr.clienteId).First();

                            foreach (var item in gr.grArtigo)
                            {
                                vendaArtigos.Add(new Venda.VendaArtigo()
                                {
                                    codigo = StaticProperty.artigos.Where(x => x.id == item.artigoId).First().codigo,
                                    iva = item.iva,
                                    preco = item.preco,
                                    qtd = item.qtd
                                });
                            }

                            // Conversão do objeto Film para JSON
                            string json = System.Text.Json.JsonSerializer.Serialize(DocState.estornado);

                            // Envio dos dados para a API
                            HttpResponseMessage responseF = await client.PutAsync($"api/Venda/Gr/Change/State/{id}/{DocState.estornado}", new StringContent(json, Encoding.UTF8, "application/json"));

                            if (responseF.IsSuccessStatusCode)
                            {
                                MessageBox.Show($"O documento {codigoDocumentoOrigem} foi estornado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }

                    else if (documento.Equals("OR"))
                    {
                        if (StaticProperty.ors != null)
                        {
                            var or = StaticProperty.ors.Where(cl => cl.id == id).First();

                            codigoDocumentoOrigem = or.documento;

                            clienteResult = StaticProperty.clientes.Where(cl => cl.id == or.clienteId).First();

                            foreach (var item in or.orArtigos)
                            {
                                vendaArtigos.Add(new Venda.VendaArtigo()
                                {
                                    codigo = StaticProperty.artigos.Where(x => x.id == item.artigoId).First().codigo,
                                    iva = item.iva,
                                    preco = item.preco,
                                    qtd = item.qtd
                                });
                            }

                            // Conversão do objeto Film para JSON
                            string json = System.Text.Json.JsonSerializer.Serialize(DocState.estornado);

                            // Envio dos dados para a API
                            HttpResponseMessage responseF = await client.PutAsync($"api/Venda/Or/Change/State/Doc/{id}/{DocState.estornado}", new StringContent(json, Encoding.UTF8, "application/json"));

                            if (responseF.IsSuccessStatusCode)
                            {
                                MessageBox.Show($"O documento {codigoDocumentoOrigem} foi estornado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    codigoDocumento = await Documento.GetCodigoDocumentoAsync("NC");

                    nc.documento = codigoDocumento;
                    nc.clienteId = clienteResult.id;
                    nc.data = DateTime.UtcNow.Date;
                    nc.motivo = StaticProperty.motivoAnulacao;
                    nc.status = DocState.ativo;
                    nc.documentoOrigem = codigoDocumentoOrigem;
                    nc.ncArtigo = ncArtigos;
                    nc.created_at = DateTime.Now;
                    nc.empresaId = StaticProperty.empresaId;

                    await this.RefreshDocs();

                    // Conversão do objeto Film para JSON
                    json = System.Text.Json.JsonSerializer.Serialize(nc);

                    // Envio dos dados para a API
                    HttpResponseMessage responseNc = await client.PostAsync($"api/Venda/Nc/{StaticProperty.funcionarioId}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (responseNc.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"O documento {codigoDocumentoOrigem} foi estornado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else 
                    {
                        MessageBox.Show($"Não foi possível estornar o documento {codigoDocumentoOrigem}\nVerifique a data do sistema se esta definido correctamente ou se o servidor esta respondendo", "Erro a estornar documento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    preVisualizacaoDialog.Document = Imprimir;

                    if (preVisualizacaoDialog.ShowDialog() == DialogResult.OK)
                    {
                        Imprimir.Print();
                    }

                    vendaArtigos.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro mo processo de estorno: {ex.Message}", "Ocorreu um erro", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            await RefreshDocs();
        }

        private void radioFp_CheckedChanged(object sender, EventArgs e)
        {
            if (radioFp.Checked)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Cliente", typeof(string));
                dt.Columns.Add("Documento", typeof(string));
                dt.Columns.Add("Data", typeof(string));

                if (StaticProperty.fps == null || !StaticProperty.fps.Any())
                {
                    this.CleanDataGridView();
                }
                else
                {
                    if (StaticProperty.fps != null)
                    {
                        foreach (var item in StaticProperty.fps.Where(x => x.empresaId == StaticProperty.empresaId))
                        {
                            if (StaticProperty.artigos.Where(x => x.id == item.fpArtigo.First().artigoId).First().empresaId == StaticProperty.empresaId)
                            {
                                clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;
                                dt.Rows.Add(item.id, clienteNome, item.documento, item.data);


                            }
                        }

                        dataGridView1.DataSource = dt;

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
                    }
                }
            }
        }

        private async void anularPicture_Click(object sender, EventArgs e)
        {
            string documentoDoc = string.Empty;

            if (MessageBox.Show($"Documento: {codigoDocumento}\nTem certeza que pretende anular este documento?", "Atenção", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) != DialogResult.OK) 
            {
                return;
            }

            try
            {
                if (documento.Equals("FR"))
                {

                    documentoDoc = StaticProperty.frs.Where(cl => cl.id == id).First().documento;

                    // Conversão do objeto Film para JSON
                    json = System.Text.Json.JsonSerializer.Serialize(DocState.anulado);

                    // Envio dos dados para a API
                    HttpResponseMessage responseFr = await client.PutAsync($"api/Venda/Fr/Change/State/{id}/{DocState.anulado}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (responseFr.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"O documento {documentoDoc} foi anulado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else if (documento.Equals("FT"))
                {
                    documentoDoc = StaticProperty.fts.Where(cl => cl.id == id).First().documento;

                    // Conversão do objeto Film para JSON
                    json = System.Text.Json.JsonSerializer.Serialize(DocState.anulado);

                    // Envio dos dados para a API
                    HttpResponseMessage responseFt = await client.PutAsync($"api/Venda/Ft/Change/State/{id}/{DocState.anulado}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (responseFt.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"O documento {documentoDoc} foi anulado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else if (documento.Equals("PP"))
                {
                    documentoDoc = StaticProperty.fps.Where(cl => cl.id == id).First().documento;

                    // Conversão do objeto Film para JSON
                    string json = System.Text.Json.JsonSerializer.Serialize(DocState.anulado);

                    // Envio dos dados para a API
                    HttpResponseMessage responseFp = await client.PutAsync($"api/Venda/Fp/Change/State/{id}/{DocState.anulado}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (responseFp
                        .IsSuccessStatusCode)
                    {
                        MessageBox.Show($"O documento {documentoDoc} foi anulado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                }
                else if (documento.Equals("GT"))
                {
                    documentoDoc = StaticProperty.gts.Where(cl => cl.id == id).First().documento;

                    // Conversão do objeto Film para JSON
                    string json = System.Text.Json.JsonSerializer.Serialize(DocState.anulado);

                    // Envio dos dados para a API
                    HttpResponseMessage responseGt = await client.PutAsync($"api/Venda/Gt/Change/State/{id}/{DocState.anulado}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (responseGt.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"O documento {documentoDoc} foi anulado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }

                else if (documento.Equals("GR"))
                {
                    documentoDoc = StaticProperty.grs.Where(cl => cl.id == id).First().documento;

                    // Conversão do objeto Film para JSON
                    string json = System.Text.Json.JsonSerializer.Serialize(DocState.anulado);

                    // Envio dos dados para a API
                    HttpResponseMessage responseGt = await client.PutAsync($"api/Venda/Gr/Change/State/{id}/{DocState.anulado}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (responseGt.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"O documento {documentoDoc} foi anulado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }

                else if (documento.Equals("OR"))
                {
                    documentoDoc = StaticProperty.ors.Where(cl => cl.id == id).First().documento;

                    // Conversão do objeto Film para JSON
                    string json = System.Text.Json.JsonSerializer.Serialize(DocState.anulado);

                    // Envio dos dados para a API
                    HttpResponseMessage responseOr = await client.PutAsync($"api/Venda/Or/Change/State/Doc/{id}/{DocState.anulado}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (responseOr.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"O documento {documentoDoc} foi anulado com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                await this.RefreshDocs();
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
            else if (radioEcl.Checked)
            {
                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.ecls.Where(f => f.documento.Contains(textBox1.Text) || f.data.ToString().Contains(textBox1.Text) && f.status != DocState.anulado))
                {
                    clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;
                    dt.Rows.Add(item.id, clienteNome, item.documento, item.data);

                    dataGridView1.DataSource = dt;
                }
                foreach (var item2 in StaticProperty.clientes.Where(f => f.nome_fantasia.Contains(textBox1.Text) || f.razao_social.Contains(textBox1.Text)))
                {
                    foreach (var item in StaticProperty.ecls.Where(f => f.clienteId == item2.id && f.status != DocState.anulado).ToList())
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
            if (radioGr.Checked) { documento = "GR"; }
            if (radioOrcamento.Checked) { documento = "OR"; }
            if (radioAnulado.Checked || radioGeral.Checked)
            {
                var doc = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                var indexSpace = doc.IndexOf(" ");
                documento = doc.Substring(0, indexSpace);
            }

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
                dt.Columns.Add("Estado", typeof(string));
                dt.Columns.Add("Data", typeof(string));

                if (!documentoVendas.Any() || documentoVendas == null)
                {
                    this.CleanDataGridView();
                }
                else
                {
                    // Adicionando linhas ao DataTable
                    foreach (var item in documentoVendas.Where(f => f.status == DocState.anulado).OrderByDescending(x => x.data))
                    {
                        if (StaticProperty.clientes.Where(f => f.id == item.clienteId).First() != null)
                        {
                            clienteNome = StaticProperty.clientes.Where(f => f.id == item.clienteId).First().nome_fantasia;
                        }

                        var estado = string.Empty;
                        if (item.status == DocState.anulado) { estado = "Anulado"; }
                        else if (item.status == DocState.estornado) { estado = "Estornado"; }
                        else { estado = "activo"; }

                        dt.Rows.Add(item.id, clienteNome, item.documento, estado, item.data);


                    }
                    dataGridView1.DataSource = dt;
                }
            }

        }

        private void radioEcl_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("Cliente", typeof(string));
            dt.Columns.Add("Documento", typeof(string));
            dt.Columns.Add("Estado", typeof(string));
            dt.Columns.Add("Data", typeof(string));

            if (radioEcl.Checked)
            
                if (StaticProperty.ecls.Any() && StaticProperty.ecls != null)
                {
                    this.CleanDataGridView();
                }
                else
                {
                    foreach (var item in StaticProperty.ecls.Where(x => x.empresaId == StaticProperty.empresaId))
                    {
                        if (StaticProperty.artigos.Where(x => x.id == item.eclArtigo.First().artigoId).First().empresaId == StaticProperty.empresaId)
                        {
                            clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;

                            var estado = item.status == DocState.estornado ? "Estornado" : "activo";

                            dt.Rows.Add(item.id, clienteNome, item.documento, estado, item.data);
                        }
                    }
                    dataGridView1.DataSource = dt;
                }
            }
        

        private void ImprimirPagina_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                float totalLiquido = 0f;
                float totalIva = 0f;
                float total = 0f;
                float incidencia = 0f;

                List<float> listaIvas = new List<float>();

                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string projectPath = Path.GetFullPath(Path.Combine(basePath, @"..\.."));
                string imagePathEmpresa = StaticProperty.empresaLogo;
                string imagePathAsc = Path.Combine(projectPath, "Files", "asc.png");
                // Testar com valores fixos para desenhar uma string
                Font fontNormal = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Pixel);
                Font fontNormalNegrito = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Pixel);
                Font fontCabecalho = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Pixel);
                Font fontCabecalhoNegrito = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Pixel);
                Brush cor = new SolidBrush(Color.Black);

                PointF ponto = new PointF(50, 150);
                PointF pontoRight = new PointF(550, 150);

                StringFormat formatToRight = new StringFormat();
                formatToRight.Alignment = StringAlignment.Far;

                StringFormat formatToLeft = new StringFormat();
                formatToLeft.Alignment = StringAlignment.Near;

                StringFormat formatToCenter = new StringFormat();
                formatToCenter.Alignment = StringAlignment.Near;

                var empresa = StaticProperty.empresa;

                string empresaNome = $"{empresa.nome_fantasia}";
                string empresaCabecalho = $"Endereço: {empresa.endereco}\nNif: {empresa.nif}\n" +
                                          $"Email: {empresa.email}\nContactos: {empresa.telefone}";

                var tel = clienteResult.phones.Any() ? clienteResult.phones.First().telefone : "9";
                var nifCl = clienteResult.nif ?? "999999999";
                var localCl = clienteResult.localizacao ?? "";


                string clienteCabecalho = $"Exmo (s) Senhor (a)\n";
                string clienteOutros = $"{clienteResult.nome_fantasia.ToUpper()}\nEndereço: {localCl}\nNif: {nifCl}\n" +
                                          $"Email: {clienteResult.email}\nTel: {tel}";

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

                e.Graphics.DrawString($"Nota de Credito  {codigoDocumento}", fontNormalNegrito, cor, new PointF(50, 280), formatToLeft);
                e.Graphics.DrawLine(canetaFina, 50, 295, 250, 295);
                e.Graphics.DrawString("Contribuente", fontNormalNegrito, cor, new Rectangle(50, 300, 200, 310));
                e.Graphics.DrawString("Desc. Cli", fontNormalNegrito, cor, new Rectangle(200, 300, 350, 310));
                e.Graphics.DrawString("Data Emissão", fontNormalNegrito, cor, new Rectangle(350, 300, 500, 310));
                e.Graphics.DrawString("Data Vencimento", fontNormalNegrito, cor, new Rectangle(500, 300, 650, 310));
                e.Graphics.DrawLine(caneta, 50, 315, 750, 315);

                e.Graphics.DrawString($"{clienteResult.nif}", fontNormal, cor, new Rectangle(50, 330, 200, 340));
                e.Graphics.DrawString("0,00", fontNormal, cor, new Rectangle(200, 330, 350, 340));
                e.Graphics.DrawString($"{DateTime.Now.Date.ToString("dd-mm-yyyy")}", fontNormal, cor, new Rectangle(350, 330, 450, 340));

                e.Graphics.DrawString($"{DateTime.Now.Date}", fontNormal, cor, new Rectangle(500, 330, 650, 340));

                e.Graphics.DrawString($"Artigo", fontNormalNegrito, cor, new Rectangle(50, 400, 200, 420));
                e.Graphics.DrawString("Descricao", fontNormalNegrito, cor, new Rectangle(200, 400, 350, 420));
                e.Graphics.DrawString($"Quantidade", fontNormalNegrito, cor, new Rectangle(350, 400, 450, 420));
                e.Graphics.DrawString($"P/Unitario", fontNormalNegrito, cor, new Rectangle(450, 400, 550, 420));
                e.Graphics.DrawString("Iva %", fontNormalNegrito, cor, new Rectangle(550, 400, 650, 420));
                e.Graphics.DrawString($"Desconto", fontNormalNegrito, cor, new Rectangle(600, 400, 700, 420));
                e.Graphics.DrawString($"Total", fontNormalNegrito, cor, new Rectangle(700, 400, 750, 420));
                e.Graphics.DrawLine(caneta, 50, 415, 750, 415);
          
                int i = 15;
                foreach (VendaArtigo va in vendaArtigos)
                {
                    totalIva += va.iva;
                    total += va.preco * float.Parse(va.qtd.ToString());

                    e.Graphics.DrawString($"{va.codigo}", fontNormal, cor, new Rectangle(50, 410 + i, 200, 425 + i));
                    e.Graphics.DrawString($"{dados.Where(art => art.codigo == va.codigo).First().descricao}", fontNormal, cor, new Rectangle(200, 410 + i, 300, 425 + i));
                    e.Graphics.DrawString($"{va.qtd:F2}", fontNormal, cor, new Rectangle(300, 410 + i, 400, 425 + i));
                    e.Graphics.DrawString($"{va.preco.ToString("F2")}", fontNormal, cor, new Rectangle(400, 410 + i, 500, 425 + i));
                    e.Graphics.DrawString($"{(dados.Where(art => art.codigo == va.codigo).First().regimeIva == OpcaoBinaria.Sim ? va.iva : 0).ToString("F2")} %", fontNormal, cor, new Rectangle(500, 410 + i, 600, 425 + i));
                    e.Graphics.DrawString($"{(((va.preco - (va.preco * (clienteResult.desconto / 100))) * (va.desconto / 100)) * va.qtd).ToString("F2")}", fontNormal, cor, new Rectangle(600, 410 + i, 700, 425 + i));
                    e.Graphics.DrawString($"{(va.preco * float.Parse(va.qtd.ToString())).ToString("F2")}", fontNormal, cor, new Rectangle(700, 410 + i, 750, 425 + i));
                    i = i + 15;
                }


                totalLiquido = CalculosVendaCompra.TotalVenda(vendaArtigos, clienteResult.desconto);

                string mercadoria = $"Total Ilíquido";
                string totalIvaValor = $"Total Imposto:";
                string totalFinal = $"Total á pagar";
                var desconto = CalculosVendaCompra.TotalDescontoVenda(vendaArtigos, clienteResult.desconto) + CalculosVendaCompra.TotalDescontoCliente(vendaArtigos, clienteResult.desconto);
                e.Graphics.DrawString($"{StaticProperty.hash} - Processado por programa\r válido nº 31.1/AGT20 Asc - Smart Entity", fontCabecalho, cor, new PointF(250, 515 + i), formatToCenter);


                if (documento != "GR" && documento != "GT")
                {
                    e.Graphics.DrawRectangle(caneta, new Rectangle(540, 530 + i, 210, 70 + i));

                    e.Graphics.DrawString(mercadoria, fontCabecalho, cor, new PointF(550, 545 + i), formatToLeft);
                    e.Graphics.DrawString(totalLiquido.ToString("F2"), fontCabecalho, cor, new PointF(680, 545 + i), formatToLeft);
                    e.Graphics.DrawString(totalIvaValor, fontCabecalho, cor, new PointF(550, 555 + i), formatToLeft);
                    e.Graphics.DrawString((total * (totalIva / 100)).ToString("F2"), fontCabecalho, cor, new PointF(680, 555 + i), formatToLeft);
                    e.Graphics.DrawString("Desconto", fontCabecalho, cor, new PointF(550, 565 + i), formatToLeft);
                    e.Graphics.DrawString($"{desconto:F2}", fontCabecalho, cor, new PointF(680, 565 + i), formatToLeft);

                    e.Graphics.DrawLine(canetaFina, 550, 580 + i, 740, 580 + i);
                    e.Graphics.DrawString(totalFinal, fontNormalNegrito, cor, new PointF(550, 605 + i), formatToLeft);
                    e.Graphics.DrawString(total.ToString("F2"), fontNormalNegrito, cor, new PointF(680, 605 + i), formatToLeft);

                    string conta = $"Conta nº";
                    string iban = $"IBAN ";
                    string banco = $"Banco Angolano de Investimento";


                    e.Graphics.DrawString($"Resumo Imposto", fontCabecalho, cor, new PointF(50, 515 + i), formatToCenter);

                    e.Graphics.DrawLine(caneta, 50, 530 + i, 530, 530 + i);
                    e.Graphics.DrawString("Descrição", new Font("Arial", 10, GraphicsUnit.Pixel), cor, new PointF(50, 540 + i), formatToLeft);
                    e.Graphics.DrawString("Taxa %", fontCabecalhoNegrito, cor, new PointF(130, 540 + i), formatToLeft);
                    e.Graphics.DrawString("Incidência", fontCabecalho, cor, new PointF(200, 540 + i), formatToLeft);
                    e.Graphics.DrawString($"Valor imposto", fontCabecalho, cor, new PointF(300, 540 + i), formatToLeft);
                    e.Graphics.DrawString("Motivo Isenção", fontCabecalho, cor, new PointF(400, 540 + i), formatToLeft);


                    // Pegar os dados dos artigo com iva aplicado
                    foreach (var item in vendaArtigos)
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
                            e.Graphics.DrawString(vendaArtigos.Where(x => x.iva == ivas).Sum(x => x.preco * x.qtd).ToString("F2"), fontCabecalho, cor, new PointF(200, 560 + i), formatToLeft);
                            e.Graphics.DrawString(vendaArtigos.Where(x => x.iva == ivas).Sum(x => ((x.preco * x.qtd) * (x.iva / 100))).ToString("F2"), fontCabecalho, cor, new PointF(300, 560 + i), formatToLeft);
                            e.Graphics.DrawString("", fontCabecalho, cor, new PointF(430, 560 + i), formatToLeft);
                            i = i + 10;
                        }
                    }
                    // Artigos com iva isento
                    foreach (var motivo in StaticProperty.motivosIsencao)
                    {
                        foreach (var item in vendaArtigos)
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
                            e.Graphics.DrawString(incidencia.ToString("F2"), fontCabecalho, cor, new PointF(200, 560 + i), formatToLeft);
                            e.Graphics.DrawString("0,00", fontCabecalho, cor, new PointF(300, 560 + i), formatToLeft);
                            e.Graphics.DrawString($"{motivo.mencao}", fontCabecalho, cor, new PointF(400, 560 + i), formatToLeft);
                            i = i + 10;
                            incidencia = 0;
                        }

                    }
                }
                if (!documento.Equals("NC") && !documento.Equals("ND") && !documento.Equals("GT") && !documento.Equals("GR"))
                {
                    e.Graphics.DrawString($"Retenção           0,00 ", fontCabecalho, new SolidBrush(Color.Red), new PointF(50, 680 + i), formatToCenter);

                }
                if (documento.Equals("FP") || documento.Equals("GR") || documento.Equals("OR"))
                {
                    e.Graphics.DrawString($"Este documento não serve como factura ", fontCabecalho, new SolidBrush(Color.Red), new PointF(280, 720 + i), formatToCenter);
                }
                else if (documento.Equals("FT") || documento.Equals("FR"))
                {
                    e.Graphics.DrawString($"Os bens/serviços foram colocados á disposição do adquirente na data e local do documento", fontCabecalho, new SolidBrush(Color.Black), new PointF(210, 720 + i), formatToCenter);
                }

                if (documento.Equals("GT") || documento.Equals("GR"))
                {
                    e.Graphics.DrawString("Entreguei", fontCabecalho, cor, new PointF(100, 720 + i), formatToLeft);
                    e.Graphics.DrawLine(caneta, 50, 780 + i, 200, 780 + i);

                    e.Graphics.DrawString("Recebi", fontCabecalho, cor, new PointF(660, 720 + i), formatToLeft);
                    e.Graphics.DrawLine(caneta, 600, 780 + i, 750, 780 + i);
                }

                if (documento.Equals("NC"))
                {
                    e.Graphics.DrawString("O Cliente", fontCabecalho, cor, new PointF(100, 720 + i), formatToLeft);
                    e.Graphics.DrawLine(caneta, 50, 780 + i, 200, 780 + i);

                }

                if (documento.Equals("GT") || documento.Equals("ECL"))
                {
                    e.Graphics.DrawString("Local de Carga:", fontCabecalhoNegrito, cor, new PointF(50, 820 + i), formatToLeft);

                    e.Graphics.DrawString($"Viana", fontCabecalho, cor, new PointF(150, 820 + i), formatToLeft);

                    e.Graphics.DrawString("Local de Descarga:", fontCabecalhoNegrito, cor, new PointF(50, 835 + i), formatToLeft);

                    e.Graphics.DrawString($"Desconhecido", fontCabecalho, cor, new PointF(150, 835 + i), formatToLeft);
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

        private void radioGeral_CheckedChanged(object sender, EventArgs e)
        {
            if (radioGeral.Checked)
            {
                this.SetVendas();

                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Fornecedor", typeof(string));
                dt.Columns.Add("Documento", typeof(string));
                dt.Columns.Add("Estado", typeof(string));
                dt.Columns.Add("Data", typeof(string));


                if (!documentoVendas.Any() || documentoVendas == null)
                {
                    this.CleanDataGridView();
                }
                else
                {
                    // Adicionando linhas ao DataTable
                    foreach (var item in documentoVendas.OrderByDescending(x => x.data))
                    {
                        if (StaticProperty.clientes.Where(f => f.id == item.clienteId).First() != null)
                        {
                            clienteNome = StaticProperty.clientes.Where(f => f.id == item.clienteId).First().nome_fantasia;
                        }

                        var estado = string.Empty;
                        if (item.status == DocState.anulado) { estado = "Anulado"; }
                        else if (item.status == DocState.estornado) { estado = "Estornado"; }
                        else { estado = "activo"; }

                        dt.Rows.Add(item.id, clienteNome, item.documento, estado, item.data);


                    }
                    dataGridView1.DataSource = dt;
                }
            }

        }

        private void radioGr_CheckedChanged(object sender, EventArgs e)
        {
            if (radioGr.Checked)
            {

                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Cliente", typeof(string));
                dt.Columns.Add("Documento", typeof(string));
                dt.Columns.Add("Estado", typeof(string));
                dt.Columns.Add("Data", typeof(string));

                if (!StaticProperty.fts.Any() || StaticProperty.fts == null)
                {
                    this.CleanDataGridView();
                }
                else
                {
                    // Adicionando linhas ao DataTable
                    foreach (var item in StaticProperty.grs.Where(v => v.status != DocState.anulado && v.empresaId == StaticProperty.empresaId))
                    {
                        if (StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First() != null)
                        {
                            clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;
                        }

                        var estado = item.status == DocState.estornado ? "Estornado" : "activo";

                        dt.Rows.Add(item.id, clienteNome, item.documento, estado, item.data);

                    }

                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void radioOrcamento_CheckedChanged(object sender, EventArgs e)
        {
            if (radioOrcamento.Checked)
            {

                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Cliente", typeof(string));
                dt.Columns.Add("Documento", typeof(string));
                dt.Columns.Add("Estado", typeof(string));
                dt.Columns.Add("Data", typeof(string));

                if (!StaticProperty.ors.Any() || StaticProperty.fts == null)
                {
                    this.CleanDataGridView();
                }
                else
                {
                    // Adicionando linhas ao DataTable
                    foreach (var item in StaticProperty.ors.Where(v => v.status != DocState.anulado && v.empresaId == StaticProperty.empresaId))
                    {
                        if (StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First() != null)
                        {
                            clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia;
                        }
                        var estado = item.status == DocState.estornado ? "Estornado" : "activo";

                        dt.Rows.Add(item.id, clienteNome, item.documento, estado, item.data);

                    }

                    dataGridView1.DataSource = dt;
                }
            }
        }

        private async Task RefreshDocs()
        {
            try
            {
                var responseFr = await client.GetAsync($"api/Venda/FrByRelations");

                if (responseFr.IsSuccessStatusCode)
                {
                    var contentFr = await responseFr.Content.ReadAsStringAsync();
                    StaticProperty.frs = JsonConvert.DeserializeObject<List<FrDTO>>(contentFr);
                }

                var responseFt = await client.GetAsync($"api/Venda/FtByRelations");

                if (responseFt.IsSuccessStatusCode)
                {
                    var contentFt = await responseFt.Content.ReadAsStringAsync();
                    StaticProperty.fts = JsonConvert.DeserializeObject<List<FtDTO>>(contentFt);
                }

                var responseEcl = await client.GetAsync($"api/Venda/EclByRelations");

                if (responseEcl.IsSuccessStatusCode)
                {
                    var contentEcl = await responseEcl.Content.ReadAsStringAsync();
                    StaticProperty.ecls = JsonConvert.DeserializeObject<List<EncomendaClienteDTO>>(contentEcl);
                }

                var responseFp = await client.GetAsync($"api/Venda/FpByRelations");

                if (responseFp.IsSuccessStatusCode)
                {
                    var contentFp = await responseFp.Content.ReadAsStringAsync();
                    StaticProperty.fps = JsonConvert.DeserializeObject<List<FaturaProformaDTO>>(contentFp);
                }

                var responseNc = await client.GetAsync($"api/Venda/NcByRelations");

                if (responseNc.IsSuccessStatusCode)
                {
                    var contentNc = await responseNc.Content.ReadAsStringAsync();
                    StaticProperty.ncs = JsonConvert.DeserializeObject<List<NcDTO>>(contentNc);
                }

                var responseNd = await client.GetAsync($"api/Venda/NdByRelations");

                if (responseNd.IsSuccessStatusCode)
                {
                    var contentNd = await responseNd.Content.ReadAsStringAsync();
                    StaticProperty.nds = JsonConvert.DeserializeObject<List<NdDTO>>(contentNd);
                }

                var responseGt = await client.GetAsync($"api/Venda/GtByRelations");

                if (responseGt.IsSuccessStatusCode)
                {
                    var contentGt = await responseGt.Content.ReadAsStringAsync();
                    StaticProperty.gts = JsonConvert.DeserializeObject<List<GtDTO>>(contentGt);
                }

                var responseGr = await client.GetAsync($"api/Venda/GrByRelations");

                if (responseGr.IsSuccessStatusCode)
                {
                    var contentGr = await responseGr.Content.ReadAsStringAsync();
                    StaticProperty.grs = JsonConvert.DeserializeObject<List<GrDTO>>(contentGr);
                }

                var responseOr = await client.GetAsync($"api/Venda/OrByRelations");

                if (responseOr.IsSuccessStatusCode)
                {
                    var contentOr = await responseOr.Content.ReadAsStringAsync();
                    StaticProperty.ors = JsonConvert.DeserializeObject<List<OrDTO>>(contentOr);
                }

                this.SetVendas();

                
                radioFt_CheckedChanged(this, EventArgs.Empty);
                radioFr_CheckedChanged(this, EventArgs.Empty);
                radioGt_CheckedChanged(this, EventArgs.Empty);
               // radioGt_CheckedChanged(this, EventArgs.Empty);
                radioNv_CheckedChanged(this, EventArgs.Empty);
                radioFp_CheckedChanged(this, EventArgs.Empty);
                radioEcl_CheckedChanged(this, EventArgs.Empty);
                radioAnulado_CheckedChanged(this, EventArgs.Empty);
                radioOrcamento_CheckedChanged(this, EventArgs.Empty);
                radioGr_CheckedChanged(this, EventArgs.Empty);
                radioGeral_CheckedChanged(this, EventArgs.Empty);


            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao carregar os dados: {ex.Message}");
            }
        }

        public void SetVendas()
        {
            documentoVendas.Clear();

            foreach (var item in StaticProperty.fps.Where(x => x.empresaId == StaticProperty.empresaId))
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
            foreach (var item in StaticProperty.fts.Where(x => x.empresaId == StaticProperty.empresaId))
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
            foreach (var item in StaticProperty.frs.Where(x => x.empresaId == StaticProperty.empresaId))
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

            foreach (var item in StaticProperty.ecls.Where(x => x.empresaId == StaticProperty.empresaId))
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
            foreach (var item in StaticProperty.ncs.Where(x => x.empresaId == StaticProperty.empresaId))
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
            foreach (var item in StaticProperty.nds.Where(x => x.empresaId == StaticProperty.empresaId))
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
            foreach (var item in StaticProperty.ors.Where(x => x.empresaId == StaticProperty.empresaId))
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
            foreach (var item in StaticProperty.gts.Where(x => x.empresaId == StaticProperty.empresaId))
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
            foreach (var item in StaticProperty.grs.Where(x => x.empresaId == StaticProperty.empresaId))
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

        public void CleanDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
        }

        public void ActivarBotaoAprovar()
        {
            if (radioOrcamento.Checked)
            {
                pictureAprovar.Enabled = true;
            }
            else
            {
                pictureAprovar.Enabled = false;
            }
        }

        private async void pictureBox1_Click(object sender, EventArgs e)
        {
            if (radioOrcamento.Checked)
            {
                if (radioOrcamento.Checked)
                {
                    documento = StaticProperty.ors.Where(cl => cl.id == id).First().documento;

                    // Conversão do objeto Film para JSON
                    string json = System.Text.Json.JsonSerializer.Serialize(DocState.anulado);

                    // Envio dos dados para a API
                    HttpResponseMessage responseOr = await client.PutAsync($"api/Venda/Or/Change/State/{id}/{OpcaoBinaria.Sim}", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (responseOr.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"O documento {documento} foi aprovao com sucesso", "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);              
                    }

                    await this.RefreshDocs();
                }
            }
        }

        private void pictureAprovar_MouseMove(object sender, MouseEventArgs e)
        {
            pictureAprovar.BackColor = Color.DeepSkyBlue;
        }

        private void pictureAprovar_MouseLeave(object sender, EventArgs e)
        {
            pictureAprovar.BackColor = Color.FromArgb(0, 120, 215);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            VendaListagem_Load(this, EventArgs.Empty);
        }

        private void btnActualizar_MouseMove(object sender, MouseEventArgs e)
        {
            btnActualizar.BackColor = Color.White;
            btnActualizar.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void btnActualizar_MouseLeave(object sender, EventArgs e)
        {
            btnActualizar.BackColor = Color.FromArgb(64, 64, 64);
            btnActualizar.ForeColor = Color.White;
        }

        private void excelBtn_MouseMove(object sender, MouseEventArgs e)
        {
            excelBtn.BackColor = Color.White;
            excelBtn.ForeColor = Color.FromArgb(64, 64, 64);
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
