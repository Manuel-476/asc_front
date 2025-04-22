
using AscFrontEnd.DTOs.Cliente;
using AscFrontEnd.DTOs.Venda;
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
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using EAscFrontEnd;
using System.IO;
using ERP_Seller.Application.DTOs.Documentos;
using AscFrontEnd.DTOs.StaticsDto;
using System.Drawing.Printing;
using DocumentFormat.OpenXml.Drawing.Wordprocessing;
using static AscFrontEnd.DTOs.Enums.Enums;
using AscFrontEnd.Application;
using AscFrontEnd.Files;
using AscFrontEnd.Application.Validacao;
using System.Globalization;
using AscFrontEnd.DTOs.Fornecedor;


namespace AscFrontEnd
{
    public partial class Venda : Form
    {
        List<FrArtigoDTO> artigos;
        List<FtArtigoDTO> ftArtigos;
        List<FaturaProformaArtigoDTO> fpArtigos;
        List<EclArtigoDTO> eclArtigos;
        List<GtArtigoDTO> gtArtigos;
        List<GrArtigoDTO> grArtigos;
        List<NcArtigoDTO> ncArtigos;
        List<NdArtigoDTO> ndArtigos;
        List<OrArtigoDTO> orArtigos;
        List<ArtigoDTO> dados;
        ClienteDTO clienteResult;


        string descricaoDocumento = string.Empty;
        string motivosIsencao = string.Empty;

        string localEntrega = string.Empty;

        List<VendaArtigo> vendaArtigos;
        List<int> idVenda;
        DataTable dtVenda;

        MotivoAnulacao formAnulacao;

        HttpClient client;

        static  int artigoId = 0;
        static float precoArtigo = 0;

        public class VendaArtigo
        {
            public int id { get; set; }
            public string codigo { get; set; }
            public float preco { get; set; }
            public float qtd { get; set; }
            public float iva { get; set; }
            public float desconto { get; set; }
        }

        public Venda()
        {
            InitializeComponent();

            client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            client.BaseAddress = new Uri("https://localhost:7200/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            artigos = new List<FrArtigoDTO>();
            ftArtigos = new List<FtArtigoDTO>();
            fpArtigos = new List<FaturaProformaArtigoDTO>();
            eclArtigos = new List<EclArtigoDTO>();
            gtArtigos = new List<GtArtigoDTO>();
            grArtigos = new List<GrArtigoDTO>();
            ncArtigos = new List<NcArtigoDTO>();
            ndArtigos = new List<NdArtigoDTO>();
            orArtigos = new List<OrArtigoDTO>();
            dados = new List<ArtigoDTO>();
            vendaArtigos = new List<VendaArtigo>();
            dtVenda = new DataTable();
            idVenda = new List<int>();
            dtVenda = new DataTable();
            clienteResult = new ClienteDTO();

            Qtd.KeyPress += ValidacaoForms.TratarKeyPress; // Ajustado
            Qtd.TextChanged += ValidacaoForms.TratarTextChanged;

            descontoTxt.KeyPress += ValidacaoForms.TratarKeyPress; // Ajustado
            descontoTxt.TextChanged += ValidacaoForms.TratarTextChanged;
        }

        private  void Venda_Load(object sender, EventArgs e)
        {
                dados = StaticProperty.artigos;
                clientetxt.Text = "cliente: " + ClienteDTO.clienteId;

                dtVenda.Columns.Add("id", typeof(int));
                dtVenda.Columns.Add("Artigo", typeof(string));
                dtVenda.Columns.Add("Preco", typeof(string));
                dtVenda.Columns.Add("Qtd", typeof(string));
                dtVenda.Columns.Add("Iva", typeof(float));
                dtVenda.Columns.Add("Desconto", typeof(string));

            DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Artigo", typeof(string));
                dt.Columns.Add("Descricao", typeof(string));
                dt.Columns.Add("preco", typeof(string));


            // Adicionando linhas ao DataTable
            if (StaticProperty.artigos.Where(x => x.empresaId == StaticProperty.empresaId) != null)
            {
                foreach (var item in StaticProperty.artigos.Where(x => x.empresaId == StaticProperty.empresaId))
                {
                    dt.Rows.Add(item.id, item.codigo, item.descricao, item.preco_unitario.ToString("F2"));
                }
                tabelaArtigos.DataSource = dt;
            }

            // Carregar documentos
            documento.Items.Add("PP");
            documento.Items.Add("ECL");
            documento.Items.Add("FR");
            documento.Items.Add("FT");
            documento.Items.Add("GT");
            documento.Items.Add("GR");
            documento.Items.Add("NC");
            documento.Items.Add("ND");
            documento.Items.Add("OR");

            Qtd.Text = "0";
            descontoTxt.Text = "0";

            descricaoLabel.Text = string.Empty;

            eliminarBtn.Enabled = false;

            totalAgragado(vendaArtigos);

            timerRefresh.Start();
        }

        private void clienteBtn_Click(object sender, EventArgs e)
        {
            ClienteListagem clienteListagem = new ClienteListagem();
            clienteListagem.ShowDialog();
        }

        private void tabelaArtigos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Obtém o valor da célula clicada
                    string id = tabelaArtigos.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string preco = tabelaArtigos.Rows[e.RowIndex].Cells[3].Value.ToString();

                    artigoId = int.Parse(id);
                    precoArtigo = float.Parse(preco);

                    //if(StaticProperty.artigos.Where(x => x.id == artigoId).First().regimeIva == OpcaoBinaria.Sim) 
                    //{
                    //    var codigo = StaticProperty.artigos.Where(x => x.id == artigoId).First().codigoIva;
                    //    motivosIsencao = StaticProperty.motivosIsencao.Where(x => x.codigo == codigo.ToString()).First().mencao;
                    //}
                    //else 
                    //{ 
                    //    motivosIsencao = ""; 
                    //}

                }
            }
            catch { return; }
        }

        private async void salvarBtn_Click(object sender, EventArgs e)
        {
            FaturaDetalhes form;
            HttpResponseMessage response = null;
            var client = new HttpClient();
            var clientGet = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            clientGet.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);

            // Configuração do HttpClient
            client.BaseAddress = new Uri("https://localhost:7200/");
            clientGet.BaseAddress = new Uri("https://localhost:7200/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if(!vendaArtigos.Any() || vendaArtigos == null) 
            {
                MessageBox.Show("Nenhum artigo foi selecionado", "Impossivel concluir a ação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            float totalPreco = vendaArtigos.Sum(x => x.preco * x.qtd);
            
            if (documento.Text == "FR")
            {
                //actualizar a lista de artigos
                artigos.Clear();
                foreach (var vendaArtigo in vendaArtigos)
                {
                    artigos.Add(new FrArtigoDTO()
                    {
                        artigoId = StaticProperty.artigos.Where(x => x.codigo == vendaArtigo.codigo).Any() ? StaticProperty.artigos.Where(x => x.codigo == vendaArtigo.codigo).First().id:0,
                        preco = vendaArtigo.preco,
                        qtd = vendaArtigo.qtd,
                        iva = vendaArtigo.iva,
                        desconto = vendaArtigo.desconto,

                    });
                }

                FrDTO frs = new FrDTO()
                {
                    documento = codigoDocumento.Text,
                    clienteId = StaticProperty.entityId,
                    frArtigo = artigos,
                    status = DTOs.Enums.Enums.DocState.ativo,
                    fullHash = string.Empty,
                    shortHash = string.Empty,
                    empresaId = StaticProperty.empresaId,
                    data = DateTime.Parse(dataDocumento.Value.ToString("yyyy-MM-dd")),
                    created_at = DateTime.Now,
                };

                form = new FaturaDetalhes(totalPreco,frs);
                if (form.ShowDialog() != DialogResult.OK) 
                {
                    return;
                }
                
                
              
            }

            if (documento.Text == "FT")
            {
                FtDTO fts = new FtDTO()
                {
                    documento = codigoDocumento.Text,
                    data = DateTime.Parse(dataDocumento.Value.ToString("yyyy-MM-dd")),
                    clienteId = StaticProperty.entityId,
                    ftArtigo = ftArtigos,
                    status = DTOs.Enums.Enums.DocState.ativo,
                    empresaId = StaticProperty.empresaId,
                    created_at = DateTime.Now,
                };
                //Actualizar lista de artigos
                ftArtigos.Clear();
                foreach (var vendaArtigo in vendaArtigos)
                {
                    ftArtigos.Add(new FtArtigoDTO()
                    {
                        artigoId = StaticProperty.artigos.Where(x => x.codigo == vendaArtigo.codigo).Any() ? StaticProperty.artigos.Where(x => x.codigo == vendaArtigo.codigo).First().id : 0,
                        preco = vendaArtigo.preco,
                        qtd = vendaArtigo.qtd,
                        iva = vendaArtigo.iva,
                        desconto = vendaArtigo.desconto,
                    });
                }

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(fts);

                // Envio dos dados para a API
                response = await client.PostAsync($"api/Venda/Ft/{StaticProperty.funcionarioId}", new StringContent(json, Encoding.UTF8, "application/json"));

            }

            if (documento.Text == "PP")
            {
                // Actualizar a lista de artigos
                fpArtigos.Clear();
                foreach (var vendaArtigo in vendaArtigos)
                {
                    fpArtigos.Add(new FaturaProformaArtigoDTO()
                    {
                        artigoId = StaticProperty.artigos.Where(x => x.codigo == vendaArtigo.codigo).Any() ? StaticProperty.artigos.Where(x => x.codigo == vendaArtigo.codigo).First().id : 0,
                        preco = vendaArtigo.preco,
                        iva = vendaArtigo.iva,
                        qtd = vendaArtigo.qtd,
                        desconto = vendaArtigo.desconto,
                    });
                }

                FaturaProformaDTO fps = new FaturaProformaDTO()
                {
                    documento = codigoDocumento.Text,
                    data = DateTime.Parse(dataDocumento.Text),
                    clienteId = StaticProperty.entityId,
                    fpArtigo = fpArtigos,
                    empresaId = StaticProperty.empresaId,
                    status = DTOs.Enums.Enums.DocState.ativo,
                    created_at = DateTime.Now,
                };

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(fps);

                // Envio dos dados para a API
                response = await client.PostAsync($"api/Venda/Fp/{StaticProperty.funcionarioId}", new StringContent(json, Encoding.UTF8, "application/json"));
            }

            if (documento.Text == "GT")
            {
                //Actualizar lista de artigo
                gtArtigos.Clear();
                foreach (var vendaArtigo in vendaArtigos)
                {
                    gtArtigos.Add(new GtArtigoDTO()
                    {
                        artigoId = StaticProperty.artigos.Where(x => x.codigo == vendaArtigo.codigo).Any() ? StaticProperty.artigos.Where(x => x.codigo == vendaArtigo.codigo).First().id : 0,
                        preco = vendaArtigo.preco,
                        qtd = vendaArtigo.qtd,
                        iva = vendaArtigo.iva,
                        desconto = vendaArtigo.desconto,
                    });
                }

                GtDTO gts = new GtDTO()
                {
                    documento = codigoDocumento.Text,
                    data = DateTime.Parse(dataDocumento.Text),
                    clienteId = StaticProperty.entityId,
                    gtArtigo = gtArtigos,
                    empresaId = StaticProperty.empresaId,
                    status =  DTOs.Enums.Enums.DocState.ativo,
                    created_at = DateTime.Now,
                };

                string json = System.Text.Json.JsonSerializer.Serialize(gts);

                // Envio dos dados para a API
                response = await client.PostAsync($"api/Venda/Gt/{StaticProperty.funcionarioId}", new StringContent(json, Encoding.UTF8, "application/json"));
            }

            if (documento.Text == "GR")
            {
                GrDTO grs = new GrDTO()
                {
                    documento = codigoDocumento.Text,
                    data = DateTime.Parse(dataDocumento.Value.ToString("yyyy-MM-dd")),
                    clienteId = StaticProperty.entityId,
                    grArtigo = grArtigos,
                    status = DTOs.Enums.Enums.DocState.ativo,
                    empresaId = StaticProperty.empresaId,
                    created_at = DateTime.Now,
                };
                //Actualizar lista de artigos
                grArtigos.Clear();
                foreach (var vendaArtigo in vendaArtigos)
                {
                    grArtigos.Add(new GrArtigoDTO()
                    {
                        artigoId = StaticProperty.artigos.Where(x => x.codigo == vendaArtigo.codigo).Any() ? StaticProperty.artigos.Where(x => x.codigo == vendaArtigo.codigo).First().id : 0,
                        preco = vendaArtigo.preco,
                        qtd = vendaArtigo.qtd,
                        iva = vendaArtigo.iva,
                       desconto = vendaArtigo.desconto 
                    });
                }

                form = new FaturaDetalhes(totalPreco, grs);
                if (form.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                // Conversão do objeto Film para JSON
                /*   string json = System.Text.Json.JsonSerializer.Serialize(grs);

                   // Envio dos dados para a API
                   response = await client.PostAsync($"api/Venda/Gr/{StaticProperty.funcionarioId}", new StringContent(json, Encoding.UTF8, "application/json"));
    */
            }

            if (documento.Text == "ECL")
            {
                eclArtigos.Clear();
                foreach (var vendaArtigo in vendaArtigos)
                {
                    eclArtigos.Add(new EclArtigoDTO()
                    {
                        artigoId = StaticProperty.artigos.Where(x => x.codigo == vendaArtigo.codigo).Any() ? StaticProperty.artigos.Where(x => x.codigo == vendaArtigo.codigo).First().id : 0,
                        preco = vendaArtigo.preco,
                        qtd = vendaArtigo.qtd,
                        iva = vendaArtigo.iva,
                        desconto= vendaArtigo.desconto,
                    });
                }

                localEntrega = string.IsNullOrEmpty(localEntregatxt.Text.ToString()) ? string.Empty : localEntregatxt.Text.ToString();
                EncomendaClienteDTO ecls = new EncomendaClienteDTO()
                {
                    documento = codigoDocumento.Text,
                    data = DateTime.Parse(dataDocumento.Text),
                    clienteId = StaticProperty.entityId,
                    eclArtigo = eclArtigos,
                    local_entrega = localEntrega,
                    empresaId = StaticProperty.empresaId,
                    status = DTOs.Enums.Enums.DocState.ativo,
                    created = DateTime.Now,
                };

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(ecls);

                // Envio dos dados para a API
                response = await client.PostAsync($"api/Venda/Ecl/{StaticProperty.funcionarioId}", new StringContent(json, Encoding.UTF8, "application/json")); 
            }

            if (documento.Text == "NC")
            {
                ncArtigos.Clear();

                foreach (var vendaArtigo in vendaArtigos)
                {
                    ncArtigos.Add(new NcArtigoDTO()
                    {
                        artigoId = StaticProperty.artigos.Where(x => x.codigo == vendaArtigo.codigo).Any() ? StaticProperty.artigos.Where(x => x.codigo == vendaArtigo.codigo).First().id : 0,
                        preco = vendaArtigo.preco,
                        qtd = vendaArtigo.qtd,
                        iva = vendaArtigo.iva,
                        desconto = vendaArtigo.desconto,
                    });
                }

                formAnulacao = new MotivoAnulacao(Entidade.cliente,OpcaoBinaria.Nao);
                formAnulacao.ShowDialog();
                if (formAnulacao.DialogResult == DialogResult.OK)
                {
                   NcDTO ncs = new NcDTO()
                   {
                      documento = codigoDocumento.Text,
                      data = DateTime.Parse(dataDocumento.Text),
                      clienteId = StaticProperty.entityId,
                      documentoOrigem = StaticProperty.documentoOrigem,
                      motivo = StaticProperty.motivoAnulacao,
                      ncArtigo = ncArtigos,
                       empresaId = StaticProperty.empresaId,
                       status = DTOs.Enums.Enums.DocState.ativo,
                      created_at = DateTime.Now,
                   };

                    // Conversão do objeto Film para JSON
                    string json = System.Text.Json.JsonSerializer.Serialize(ncs);

                    // Envio dos dados para a API
                    response = await client.PostAsync($"api/Venda/Nc/{StaticProperty.funcionarioId}", new StringContent(json, Encoding.UTF8, "application/json"));
                    StaticProperty.documentoOrigem = string.Empty;
                }
                else 
                {
                    return;
                }
            }

            if (documento.Text == "ND")
            {
                ndArtigos.Clear();
                foreach (var vendaArtigo in vendaArtigos)
                {
                    ndArtigos.Add(new NdArtigoDTO()
                    {
                        artigoId = StaticProperty.artigos.Where(x => x.codigo == vendaArtigo.codigo).Any() ? StaticProperty.artigos.Where(x => x.codigo == vendaArtigo.codigo).First().id : 0,
                        preco = vendaArtigo.preco,
                        qtd = vendaArtigo.qtd,
                        iva = vendaArtigo.iva,
                        desconto = vendaArtigo.desconto,
                    });
                }
                NdDTO nds = new NdDTO()
                {
                    documento = codigoDocumento.Text,
                    data = DateTime.Parse(dataDocumento.Text),
                    clienteId = StaticProperty.entityId,
                    ndArtigo = ndArtigos,
                    empresaId = StaticProperty.empresaId,
                    status = DTOs.Enums.Enums.DocState.ativo,
                    created_at = DateTime.Now, 
                };

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(nds);

                // Envio dos dados para a API
                response = await client.PostAsync($"api/Venda/Nd/{StaticProperty.funcionarioId}", new StringContent(json, Encoding.UTF8, "application/json"));
            }

            var responseGet = await clientGet.GetAsync($"api/Cliente/{StaticProperty.entityId}");

            if (responseGet.IsSuccessStatusCode)
            {
                var content = await responseGet.Content.ReadAsStringAsync();
                clienteResult = JsonConvert.DeserializeObject<ClienteDTO>(content);
            }

            if (documento.Text == "OR")
            {
                OrDTO ors = new OrDTO()
                {
                    documento = codigoDocumento.Text,
                    data = DateTime.Parse(dataDocumento.Value.ToString("yyyy-MM-dd")),
                    clienteId = StaticProperty.entityId,
                    orArtigos = orArtigos,
                    status = DTOs.Enums.Enums.DocState.ativo,
                    empresaId = StaticProperty.empresaId,
                    created_at = DateTime.Now,
                };
                //Actualizar lista de artigos
                orArtigos.Clear();

                foreach (var vendaArtigo in vendaArtigos)
                {
                    orArtigos.Add(new OrArtigoDTO()
                    {
                        artigoId = StaticProperty.artigos.Where(x => x.codigo == vendaArtigo.codigo).Any() ? StaticProperty.artigos.Where(x => x.codigo == vendaArtigo.codigo).First().id : 0,
                        preco = vendaArtigo.preco,
                        qtd = vendaArtigo.qtd,
                        iva = vendaArtigo.iva,
                        desconto = vendaArtigo.desconto,
                    });
                }

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(ors);

                // Envio dos dados para a API
                response = await client.PostAsync($"api/Venda/Or/{StaticProperty.funcionarioId}", new StringContent(json, Encoding.UTF8, "application/json"));
            }

            if (documento.Text != "FR" && documento.Text != "GR") {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    if(result == "-1") 
                    {
                        MessageBox.Show("A data deste documento é inferior a data da ultimo documento\n", "Não é possível concluir a acão!", MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                        return;
                    }
                    else if (result == "-2")
                    {
                        MessageBox.Show("A data do sistema não segue a sequencia dos documentos anterior\n Verfique a se a data do sistema está correcto e reinicie o programa", "Não é possível concluir a acão!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                        return;
                    }

                 

                    // Venda
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
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao tentar Salvar", "Erro", MessageBoxButtons.RetryCancel);
                    return;
                }
            }


            preVisualizacaoDialog.Document = Imprimir;

            if (preVisualizacaoDialog.ShowDialog() == DialogResult.OK)
            {
                Imprimir.Print();
            }

            MessageBox.Show("Venda Com Sucesso", "Feito Com Sucesso", MessageBoxButtons.OK);

            vendaArtigos.Clear();

            documento.Items.Clear();
            
            totalAgragado(vendaArtigos);

            WindowsConfig.LimparFormulario(this);

            dtVenda = new DataTable();

            Venda_Load(this,EventArgs.Empty);

            this.Refresh();
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            var response = await client.GetAsync($"https://localhost:7200/api/Artigo/Search/{textBox1.Text}");


            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var dados = JsonConvert.DeserializeObject<List<ArtigoDTO>>(content);

                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Artigo", typeof(string));
                dt.Columns.Add("Descricao", typeof(string));
                dt.Columns.Add("preco", typeof(string));


                // Adicionando linhas ao DataTable
                foreach (var item in dados.Where(x => x.empresaId == StaticProperty.empresaId))
                {
                    dt.Rows.Add(item.id, item.codigo, item.descricao, item.preco_unitario.ToString("F2"));

                    tabelaArtigos.DataSource = dt;
                }
            }
        }

        private async void documento_SelectedIndexChanged(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);

            if(!StaticProperty.series.Where(x => x.status == OpcaoBinaria.Sim).Any())
            {
                if(MessageBox.Show("Nenhuma serie foi criada\nDeseja criar uma serie?","Imposivel concluir a acao",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK) 
                {
                    new SerieForm().ShowDialog();
                }
                else 
                {
                    return;
                }
            }
            var response = await client.GetAsync($"https://localhost:7200/api/serie/codigoDocumento/{documento.Text}/{StaticProperty.empresaId}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                string dados = content.ToString();

                codigoDocumento.Text = dados;
            }
            if (documento.Text == "FR") { descricaoDocumento = "Factura Recibo"; }
            else if (documento.Text == "FT") { descricaoDocumento = "Factura"; }
            else if(documento.Text == "ECL") { descricaoDocumento = "Encomenda a Cliente"; }
            else if (documento.Text == "GT") { descricaoDocumento = "Guia de Transporte"; }
            else if (documento.Text == "GR") { descricaoDocumento = "Guia de Remessa"; }
            else if (documento.Text == "PP") { descricaoDocumento = "Factura Proforma"; }
            else if (documento.Text == "NC") { descricaoDocumento = "Nota Credito"; }
            else if (documento.Text == "ND") { descricaoDocumento = "Nota Debito"; }
            else if (documento.Text == "OR") { descricaoDocumento = "Orçamento"; }

            descricaoLabel.Text = descricaoDocumento;

            if (documento.Text != "ECL" || documento.Text != "GT")
            {
                localEntregatxt.Enabled = false;
            }
            else
            {
                localEntregatxt.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string codigo;
            try
            {
                if (StaticProperty.entityId <=0) 
                {
                    if (MessageBox.Show("Precisas Selecionar o cliente, caso o contrario o cliente passará como desconhecido", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        StaticProperty.entityId = 1;
                    }
                    else
                    {
                        return;
                    }
                }
                if (artigoId <= 0) 
                {
                    MessageBox.Show("Nenhum Artigo Foi Selecionado", "Atencao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrWhiteSpace(documento.Text.ToString())) 
                {
                    MessageBox.Show("Selecione um documento de Venda", "Atencao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (float.Parse(Qtd.Text.ToString().Replace(".", "").Replace(",", "."), CultureInfo.InvariantCulture) <= 0 || string.IsNullOrEmpty(Qtd.Text.ToString()))
                {
                    MessageBox.Show("A quantidade nao pode ser igual a 0 ou vazia", "Atencao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                codigo = dados.Where(art => art.id == artigoId).First().codigo;

                if (vendaArtigos.Where(x => x.codigo == codigo).Any()) 
                {
                    return;
                }
                
                int idVendaArtigo = tabelaVenda.Rows.Count;

                List<VendaArtigo> refreshVendaArtigo = new List<VendaArtigo>();
                int i = 1;

                dtVenda.Rows.Clear();
                tabelaVenda.DataSource = dtVenda;

                

                foreach (var va in vendaArtigos)
                {
                    var vArtigo = new VendaArtigo
                    {
                        id = i,
                        codigo = va.codigo,
                        preco = va.preco,
                        qtd = va.qtd,
                        iva = va.iva,
                        desconto = va.desconto,
                    };
                    refreshVendaArtigo.Add(vArtigo);
                    i++;
                }

                vendaArtigos.Clear();

                vendaArtigos = refreshVendaArtigo;

                var qtd = !string.IsNullOrEmpty(Qtd.Text.ToString())? float.Parse(Qtd.Text.ToString().Replace(".", "").Replace(",", "."), CultureInfo.InvariantCulture):0f;
                var desconto = !string.IsNullOrEmpty(descontoTxt.Text.ToString())?float.Parse(descontoTxt.Text.ToString().Replace(".", "").Replace(",", "."), CultureInfo.InvariantCulture):0f;

                vendaArtigos.Add(new VendaArtigo()
                {
                    id = idVendaArtigo,
                    codigo = codigo,
                    preco = precoArtigo,
                    qtd = qtd,
                    iva = dados.Where(art => art.id == artigoId).First().iva,
                    desconto = desconto,

                });

                if (documento.Text == "FR")
                {
                    artigos.Add(new FrArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = precoArtigo,
                        qtd = qtd,
                        iva = dados.Where(art => art.id == artigoId).First().iva,
                        desconto = desconto
                    });


                    foreach (var fr in vendaArtigos)
                    {

                        dtVenda.Rows.Add(fr.id, fr.codigo, fr.preco.ToString("F2"), fr.qtd.ToString("F2"), fr.iva.ToString("F2"),fr.desconto.ToString("F2"));

                    }
                        tabelaVenda.DataSource = dtVenda;
                }

                if (documento.Text == "FT")
                {
                    ftArtigos.Add(new FtArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = precoArtigo,
                        qtd = qtd,
                        iva = dados.Where(art => art.id == artigoId).First().iva,
                        desconto = desconto
                    });

                    foreach (var ft in vendaArtigos)
                    {

                        dtVenda.Rows.Add(ft.id, ft.codigo, ft.preco.ToString("F2"), ft.qtd.ToString("F2"), ft.iva.ToString("F2"),ft.desconto.ToString("F2"));

                    }
                        tabelaVenda.DataSource = dtVenda;
                }

                if (documento.Text == "PP")
                {
                    fpArtigos.Add(new FaturaProformaArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = precoArtigo,
                        iva = dados.Where(art => art.id == artigoId).First().iva,
                        qtd = qtd,
                        desconto = desconto
                    });

                    foreach (var fp in vendaArtigos)
                    {

                        dtVenda.Rows.Add(fp.id, fp.codigo, fp.preco.ToString("F2"), fp.qtd.ToString("F2"), fp.iva.ToString("F2"), fp.desconto.ToString("F2"));

                    }
                        tabelaVenda.DataSource = dtVenda;
                }

                if (documento.Text == "ECL")
                {
                    eclArtigos.Add(new EclArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = precoArtigo,
                        qtd = qtd,
                        iva = dados.Where(art => art.id == artigoId).First().iva,
                        desconto = desconto
                    });

                    foreach (var ecl in vendaArtigos)
                    {

                        dtVenda.Rows.Add(ecl.id, ecl.codigo, ecl.preco.ToString("F2"), ecl.qtd.ToString("F2"), ecl.iva.ToString("F2"),ecl.desconto.ToString("F2"));

                    }
                        tabelaVenda.DataSource = dtVenda;
                }

                if (documento.Text == "GT")
                {
                    gtArtigos.Add(new GtArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = precoArtigo,
                        qtd = qtd,
                        iva = dados.Where(art => art.id == artigoId).First().iva,
                        desconto = desconto
                    });

                    foreach (var gt in vendaArtigos)
                    {

                        dtVenda.Rows.Add(gt.id, gt.codigo, gt.preco.ToString("F2"), gt.qtd.ToString("F2"), gt.iva.ToString("F2"),gt.desconto.ToString("F2"));

                    }
                        tabelaVenda.DataSource = dtVenda;
                }

                if (documento.Text == "GR")
                {
                    grArtigos.Add(new GrArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = precoArtigo,
                        qtd = qtd,
                        iva = dados.Where(art => art.id == artigoId).First().iva,
                        desconto = desconto
                    });

                    foreach (var gr in vendaArtigos)
                    {

                        dtVenda.Rows.Add(gr.id, gr.codigo, gr.preco.ToString("F2"), gr.qtd.ToString("F2"), gr.iva.ToString("F2"), gr.desconto.ToString("F2"));

                    }
                        tabelaVenda.DataSource = dtVenda;
                }

                if (documento.Text == "NC")
                {
                    ncArtigos.Add(new NcArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = precoArtigo,
                        qtd = qtd,
                        iva = dados.Where(art => art.id == artigoId).First().iva,
                        desconto = desconto
                    });

                    foreach (var nc in vendaArtigos)
                    {

                        dtVenda.Rows.Add(nc.id, nc.codigo, nc.preco.ToString("F2"), nc.qtd.ToString("F2"), nc.iva.ToString("F2"),nc.desconto.ToString("F2"));

                    }
                        tabelaVenda.DataSource = dtVenda;
                }

                if (documento.Text == "ND")
                {
                    ndArtigos.Add(new NdArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = precoArtigo,
                        qtd = qtd,
                        iva = dados.Where(art => art.id == artigoId).First().iva,
                        desconto = desconto
                    });

                    foreach (var nd in vendaArtigos)
                    {

                        dtVenda.Rows.Add(nd.id, nd.codigo, nd.preco.ToString("F2"), nd.qtd.ToString("F2"), nd.iva.ToString("F2"),nd.desconto.ToString("F2"));

                    }
                        tabelaVenda.DataSource = dtVenda;
                }

                if (documento.Text == "OR")
                {
                    orArtigos.Add(new OrArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = precoArtigo,
                        qtd = qtd,
                        iva = dados.Where(art => art.id == artigoId).First().iva,
                        desconto = desconto
                    });

                    foreach (var or in vendaArtigos)
                    {

                        dtVenda.Rows.Add(or.id, or.codigo, or.preco.ToString("F2"), or.qtd.ToString("F2"), or.iva.ToString("F2"));

                    }
                        tabelaVenda.DataSource = dtVenda;
                }

                artigoId = 0;

                totalAgragado(vendaArtigos);
            }
            catch { return; }
        }

        private  void excelBtn_Click(object sender, EventArgs e)
        {
            exportar exp = new exportar();

            exp.ShowDialog();

        }

        private void eliminarBtn_Click(object sender, EventArgs e)
        {
            var selectedRows = tabelaVenda.SelectedRows;
            try
            {
                foreach (DataGridViewRow row in selectedRows)
                {
                    if (row != null && row.Index >= 0) // Verifica se a linha está válida
                    {
                        int id = int.Parse(row.Cells[0].Value?.ToString()); // Substitua 0 pelo índice da coluna desejada
                                                                            // Ou faça algo mais útil com o valor
                        idVenda.Add(id);
                    }
                }

                foreach (int id in idVenda)
                {
                    var result = vendaArtigos.Where(c => c.id == id).First();

                    int index = vendaArtigos.IndexOf(result);

                    vendaArtigos.RemoveAt(index);
                }

                dtVenda.Rows.Clear();
                tabelaVenda.DataSource = dtVenda;


                foreach (var ca in vendaArtigos)
                {

                    dtVenda.Rows.Add(ca.id, ca.codigo.ToString(), ca.preco, ca.qtd, ca.iva);

                    tabelaVenda.DataSource = dtVenda;
                }
                idVenda.Clear();
            }
            catch { return; }
        }

        private void tabelaVenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            eliminarBtn.Enabled = true;
        }

        private void fecharBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void createPicture_Click(object sender, EventArgs e)
        {
           
        }

        private void clienteBtn_MouseLeave(object sender, EventArgs e)
        {
            clienteBtn.BackColor = Color.FromArgb(64,64,64);
            clienteBtn.ForeColor = Color.White;
        }

        private void clienteBtn_MouseMove(object sender, MouseEventArgs e)
        {
            clienteBtn.BackColor = Color.White;
            clienteBtn.ForeColor = Color.Black;
        }

        private void excelBtn_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void excelBtn_MouseLeave(object sender, EventArgs e)
        {

        }

        private async void timerRefresh_Tick(object sender, EventArgs e)
        {
            clientetxt.Text = $"Cliente: {StaticProperty.nome}";

            if (StaticProperty.entityId > 0)
            {
                var responseGet = await client.GetAsync($"api/Cliente/{StaticProperty.entityId}");

                if (responseGet.IsSuccessStatusCode)
                {
                    var content = await responseGet.Content.ReadAsStringAsync();

                    clienteResult = JsonConvert.DeserializeObject<ClienteDTO>(content);
                }
                else
                {
                    MessageBox.Show("Fornecedor nao encontrado", "Alguma coisa correu mal", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }
            }
        }

        private void Imprimir_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                float totalLiquido = 0f;
                float totalIva = 0f;
                float total = 0f;
                float incidencia = 0f;
                float descontoCliente = CalculosVendaCompra.TotalDescontoCliente(vendaArtigos, clienteResult.desconto);


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
                string empresaCabecalho = $"{empresa.endereco}\nContribuente: {empresa.nif}\n" +
                                          $"Email: {empresa.email}\nTel: {empresa.telefone}";

                var tel = clienteResult.phones.Any() ? clienteResult.phones.First().telefone : "000000000";

                string clienteCabecalho = $"{clienteResult.nome_fantasia.ToUpper()}\n";
                string clienteOutros = $"Cliente Nº {clienteResult.id}\nEndereco: {clienteResult.localizacao}\nContribuente: {clienteResult.nif}\n" +
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

                if (documento.Text.Equals("NC"))
                {
                    e.Graphics.DrawString("Anulação", fontNormalNegrito, cor, new PointF(550, 215), formatToLeft);
                    e.Graphics.DrawString("Motivo:", fontNormalNegrito, cor, new PointF(550, 230), formatToLeft);
                    e.Graphics.DrawString($"{StaticProperty.motivoAnulacao.ToString()}", fontNormal, cor, new PointF(600, 230), formatToLeft);
                    e.Graphics.DrawString("Documento de Origem:", fontNormalNegrito, cor, new PointF(550, 245), formatToLeft);
                    e.Graphics.DrawString($"{StaticProperty.documentoOrigem.ToString()}", fontNormal, cor, new PointF(690, 247), formatToLeft);
                }

                e.Graphics.DrawString($"{descricaoDocumento}  {codigoDocumento.Text}", fontNormalNegrito, cor, new PointF(50, 280), formatToLeft);
                e.Graphics.DrawLine(canetaFina, 50, 295, 250, 295);
                e.Graphics.DrawString("Contribuente", fontNormalNegrito, cor, new Rectangle(50, 300, 200, 310));
                e.Graphics.DrawString("Desc. Cli", fontNormalNegrito, cor, new Rectangle(200, 300, 350, 310));
                e.Graphics.DrawString("Data Emissão", fontNormalNegrito, cor, new Rectangle(350, 300, 500, 310));
                e.Graphics.DrawString("Data Vencimento", fontNormalNegrito, cor, new Rectangle(500, 300, 650, 310));
                e.Graphics.DrawLine(caneta, 50, 315, 750, 315);

                e.Graphics.DrawString($"{clienteResult.nif}", fontNormal, cor, new Rectangle(50, 330, 200, 340));
                e.Graphics.DrawString($"{descontoCliente:F2}", fontNormal, cor, new Rectangle(200, 330, 350, 340));
                e.Graphics.DrawString($"{DateTime.Now.Date.ToString("dd-MM-yyyy")}", fontNormal, cor, new Rectangle(350, 330, 450, 340));

                if (documento.Text.Equals("FR"))
                {
                    e.Graphics.DrawString($"{DateTime.Now.Date.ToString("dd-MM-yyyy")}", fontNormal, cor, new Rectangle(500, 330, 650, 340));
                }
                else
                {
                    e.Graphics.DrawString($"-", fontNormal, cor, new Rectangle(500, 330, 650, 340));
                }

                e.Graphics.DrawString($"Artigo", fontNormalNegrito, cor, new Rectangle(50, 400, 200, 420));
                e.Graphics.DrawString("Descricao", fontNormalNegrito, cor, new Rectangle(200, 400, 300, 420));
                e.Graphics.DrawString($"Qtd", fontNormalNegrito, cor, new Rectangle(300, 400, 400, 420));
                e.Graphics.DrawString($"Preco", fontNormalNegrito, cor, new Rectangle(400, 400, 500, 420));
                e.Graphics.DrawString("Iva %", fontNormalNegrito, cor, new Rectangle(500, 400, 600, 420));
                e.Graphics.DrawString($"Valor", fontNormalNegrito, cor, new Rectangle(600, 400, 700, 420));
                e.Graphics.DrawString($"Desconto", fontNormalNegrito, cor, new Rectangle(700, 400, 750, 420));
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
                    e.Graphics.DrawString($"{(dados.Where(art => art.codigo == va.codigo).First().regimeIva == OpcaoBinaria.Sim? va.iva:0).ToString("F2")} %", fontNormal, cor, new Rectangle(500, 410 + i, 600, 425 + i));
                    e.Graphics.DrawString($"{(va.preco * float.Parse(va.qtd.ToString())).ToString("F2")}", fontNormal, cor, new Rectangle(600, 410 + i, 700, 425 + i));
                    e.Graphics.DrawString($"{(((va.preco - (va.preco * (clienteResult.desconto / 100))) * (va.desconto / 100)) * va.qtd).ToString("F4")}", fontNormal, cor, new Rectangle(700, 410 + i, 750, 425 + i));
                    i = i + 15;
                }

                totalLiquido += total - (total * (totalIva / 100));

                string mercadoria = $"Mercadoria/Serviço:";
                string iva = $"Iva";
                string totalIvaValor = $"Total Iva:";
                string totalFinal = $"TOTAL";
                total = total - CalculosVendaCompra.TotalDescontoVenda(vendaArtigos, descontoCliente);

                e.Graphics.DrawRectangle(caneta, new Rectangle(540, 530 + i, 210, 70 + i));

                e.Graphics.DrawString(mercadoria, fontCabecalho, cor, new PointF(550, 545 + i), formatToLeft);
                e.Graphics.DrawString(totalLiquido.ToString("F2"), fontCabecalho, cor, new PointF(680, 545 + i), formatToLeft);
                e.Graphics.DrawString(iva, fontCabecalho, cor, new PointF(550, 555 + i), formatToLeft);
                e.Graphics.DrawString(totalIva.ToString("F2"), fontCabecalho, cor, new PointF(680, 555 + i), formatToLeft);
                e.Graphics.DrawString(totalIvaValor, fontCabecalho, cor, new PointF(550, 565 + i), formatToLeft);
                e.Graphics.DrawString((total * (totalIva / 100)).ToString("F2"), fontCabecalho, cor, new PointF(680, 565 + i), formatToLeft);
                e.Graphics.DrawString("Desconto", fontCabecalho, cor, new PointF(550, 595 + i), formatToLeft);
                e.Graphics.DrawString($"{CalculosVendaCompra.TotalDescontoVenda(vendaArtigos, clienteResult.desconto):F2}", fontCabecalho, cor, new PointF(680, 595 + i), formatToLeft);

                e.Graphics.DrawLine(canetaFina, 550, 583 + i, 740, 583 + i);
                e.Graphics.DrawString(totalFinal, fontNormalNegrito, cor, new PointF(550, 615 + i), formatToLeft);
                e.Graphics.DrawString(total.ToString("F2"), fontNormalNegrito, cor, new PointF(680, 615 + i), formatToLeft);

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
                        e.Graphics.DrawString(vendaArtigos.Where(x => x.iva == ivas).Sum(x => x.preco * x.qtd).ToString("F4"), fontCabecalho, cor, new PointF(200, 560 + i), formatToLeft);
                        e.Graphics.DrawString(vendaArtigos.Where(x => x.iva == ivas).Sum(x => ((x.preco * x.qtd) * (x.iva / 100))).ToString("F4"), fontCabecalho, cor, new PointF(300, 560 + i), formatToLeft);
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
                        e.Graphics.DrawString(incidencia.ToString("F4"), fontCabecalho, cor, new PointF(200, 560 + i), formatToLeft);
                        e.Graphics.DrawString("0,00", fontCabecalho, cor, new PointF(300, 560 + i), formatToLeft);
                        e.Graphics.DrawString($"{motivo.mencao}", fontCabecalho, cor, new PointF(400, 560 + i), formatToLeft);
                        i = i + 10;
                        incidencia = 0;
                    }

                }


                if (documento.Text.Equals("FP") || documento.Text.Equals("GR") || documento.Text.Equals("OR"))
                {
                    e.Graphics.DrawString($"Este documento não serve como factura ", fontCabecalho, new SolidBrush(Color.Red), new PointF(280, 720 + i), formatToCenter);
                }
                else if (documento.Text.Equals("FT") || documento.Text.Equals("FR"))
                {
                    e.Graphics.DrawString($"Os bens/serviços foram colocados á disposição do adquirente na data e local do documento", fontCabecalho, new SolidBrush(Color.Black), new PointF(280, 720 + i), formatToCenter);
                }

                if (documento.Text.Equals("GT") || documento.Text.Equals("GR")) 
                {
                    e.Graphics.DrawString("Entreguei", fontCabecalho, cor, new PointF(100, 720 + i), formatToLeft);
                    e.Graphics.DrawLine(caneta, 50, 780 + i, 200, 780 + i);

                    e.Graphics.DrawString("Recebi", fontCabecalho, cor, new PointF(660, 720 + i), formatToLeft);
                    e.Graphics.DrawLine(caneta, 600, 780 + i, 750, 780 + i);
                }

                if (documento.Text.Equals("GT") || documento.Text.Equals("ECL"))
                {
                    e.Graphics.DrawString("Local de Entrega:", fontCabecalhoNegrito, cor, new PointF(50, 820 + i), formatToLeft);

                    e.Graphics.DrawString($"{localEntrega}", fontCabecalho, cor, new PointF(150, 820 + i), formatToLeft);
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

        private void vendaBtn_MouseMove(object sender, MouseEventArgs e)
        {
            vendaBtn.BackColor = Color.White;
            vendaBtn.ForeColor = Color.FromArgb(64,64,64);
        }

        private void vendaBtn_MouseLeave(object sender, EventArgs e)
        {
            vendaBtn.BackColor = Color.Transparent;
            vendaBtn.ForeColor = Color.White;
        }

        private void vendaBtn_Click(object sender, EventArgs e)
        {
            VendaListagem vendaListagem = new VendaListagem();
            vendaListagem.ShowDialog();
        }

        private void Venda_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerRefresh.Stop();
            timerRefresh.Dispose();

            StaticProperty.nome = string.Empty;
            StaticProperty.entityId = 0;
        }

        private void tabelaArtigos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Qtd_TextChanged(object sender, EventArgs e)
        {
            /*TextBox textBox = (TextBox)sender;
            string texto = textBox.Text.Replace(".", "").Replace(",", ".");
            // Pode validar aqui se quiser, mas não altere o textBox.Text*/
        }
      
        private void Qtd_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string texto = textBox.Text.Replace(".", "").Replace(",", ".");

            if (float.TryParse(texto, System.Globalization.NumberStyles.Any,
                               System.Globalization.CultureInfo.InvariantCulture, out float valor))
            {
                string textoFormatado = valor.ToString("#,##0.##",
                    System.Globalization.CultureInfo.CreateSpecificCulture("pt-BR"));
                textBox.Text = textoFormatado;
            }
        }

        private void Qtd_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void descontoTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!ValidacaoForms.IsPositiveFloatDesconto(descontoTxt.ToString()))
            {
                return;
            }
        }


        private void descontoTxt_Leave(object sender, EventArgs e)
        {
 
        }

        private void descontoTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void totalAgragado(List<VendaArtigo> vendaArtigos) 
        {
            totalBruto.Text = $"Total: {CalculosVendaCompra.TotalVenda(vendaArtigos, clienteResult.desconto).ToString("F2")}";
            ivaTotal.Text = $"Iva: {CalculosVendaCompra.TotalIvaVenda(vendaArtigos).ToString("F2")}";
            descontoTotal.Text = $"Desconto: {CalculosVendaCompra.TotalDescontoVenda(vendaArtigos, clienteResult.desconto).ToString("F2")}";
            precoLiquido.Text = $"Preço: {vendaArtigos.Sum(x => x.preco * x.qtd).ToString("F2")}";
            descontoCliente.Text = $"Desc. Cliente: {CalculosVendaCompra.TotalDescontoCliente(vendaArtigos, clienteResult.desconto):F2}";
        }

        private void totalBruto_Click(object sender, EventArgs e)
        {

        }
    }


}
public class ArtigoIsencao
{
    public string motivoIsencao { get; set; }
    public float precoTotal { get; set; }
    public float qtd { get; set; }
}