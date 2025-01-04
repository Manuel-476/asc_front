using AscFrontEnd.Application;
using AscFrontEnd.DTOs;
using AscFrontEnd.DTOs.Cliente;
using AscFrontEnd.DTOs.Fornecedor;
using AscFrontEnd.DTOs.StaticsDto;
using AscFrontEnd.DTOs.Venda;
using AscFrontEnd.Files;
using EAscFrontEnd;
using ERP_Buyer.Application.DTOs.Documentos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AscFrontEnd.DTOs.Enums.Enums;
using static AscFrontEnd.Venda;

namespace AscFrontEnd
{
    public partial class Compra : Form
    {
        List<VfrArtigoDTO> artigos;
        List<VftArtigoDTO> vftArtigos;
        List<PedidoCotacaoArtigoDTO> pcoArtigos;
        List<CotacaoArtigoDTO> cotArtigos;
        List<EcfArtigoDTO> ecfArtigos;
        List<VgtArtigoDTO> vgtArtigos;
        List<VncArtigoDTO> vncArtigos;
        List<VndArtigoDTO> vndArtigos;
        List<CompraArtigo> compraArtigos;
        List<int> idCompra; 
        static int artigoId = 0;
        DataTable dtCompra;
        FornecedorDTO fornecedorResult;

        public class CompraArtigo 
        {
            public int id {  get; set; }
            public string codigo { get; set; }
            public float preco { get; set; }
            public int qtd { get; set; }
            public float iva { get; set; }
            public float desconto { get; set; }
        }
        public Compra()
        {
            InitializeComponent();
            artigos = new List<VfrArtigoDTO>();
            vftArtigos = new List<VftArtigoDTO>();
            pcoArtigos = new List<PedidoCotacaoArtigoDTO>();
            cotArtigos = new List<CotacaoArtigoDTO> ();
            ecfArtigos = new List<EcfArtigoDTO>();
            vgtArtigos = new List<VgtArtigoDTO>();
            vncArtigos = new List<VncArtigoDTO>();
            vndArtigos = new List<VndArtigoDTO>();
            compraArtigos = new List<CompraArtigo>();
            dtCompra = new DataTable();
            idCompra = new List<int>();
            fornecedorResult = new FornecedorDTO();

        }
        private async void Compra_Load(object sender, EventArgs e)
        {           
                dtCompra.Columns.Add("id", typeof(int));
                dtCompra.Columns.Add("Artigo", typeof(string));
                dtCompra.Columns.Add("Preco", typeof(float));
                dtCompra.Columns.Add("Qtd", typeof(int));
                dtCompra.Columns.Add("Iva", typeof(float));
                dtCompra.Columns.Add("Desconto", typeof(float));

            DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Artigo", typeof(string));
                dt.Columns.Add("Descricao", typeof(string));
                dt.Columns.Add("preco", typeof(float));

                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.artigos.Where(x => x.empresaId == StaticProperty.empresaId))
                {
                    dt.Rows.Add(item.id, item.codigo, item.descricao, item.preco_unitario);

                    tabelaArtigos.DataSource = dt;
                }

                documento.Items.Add("PCO");
                documento.Items.Add("COT");
                documento.Items.Add("ECF");
                documento.Items.Add("VFR");
                documento.Items.Add("VFT");
                documento.Items.Add("VGT");
                documento.Items.Add("VNC");
                documento.Items.Add("VND");

                eliminarBtn.Enabled = false;

            totalBruto.Text = $"Total: {CalculosVendaCompra.TotalCompra(compraArtigos).ToString("F2")}";
            ivaTotal.Text = $"Iva: {CalculosVendaCompra.TotalIvaCompra(compraArtigos).ToString("F2")}";
            descontoTotal.Text = $"Desconto: {CalculosVendaCompra.TotalDescontoCompra(compraArtigos).ToString("F2")}";
            precoLiquido.Text = $"Preço: {compraArtigos.Sum(x => x.preco * x.qtd).ToString("F2")}";

            timerRefresh.Start();
        }

        private async void salvarBtn_Click(object sender, EventArgs e)
        {
            FaturaDetalhes form;

            HttpResponseMessage response = null;
            var clientGet = new HttpClient();
            clientGet.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            client.BaseAddress = new Uri("https://sua-api.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (StaticProperty.series == null)
            {
                MessageBox.Show("Nenhuma Serie Foi Criada", "Precisa de uma Serie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            float totalPreco = compraArtigos.Sum(x=> x.preco * x.qtd);

            if (documento.Text == "VFR")
            {

                artigos.Clear();
                foreach (var compraArtigo in compraArtigos)
                {
                    artigos.Add(new VfrArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = compraArtigo.preco,
                        qtd = compraArtigo.qtd,
                        iva = compraArtigo.iva,
                        desconto = compraArtigo.desconto,
                    });
                }

                VfrDTO vfrs = new VfrDTO()
                {
                    documento = codigoDocumentotxt.Text,
                    data = DateTime.Now,
                    fornecedorId = StaticProperty.entityId,
                    vfrArtigo = artigos,
                    status = DTOs.Enums.Enums.DocState.ativo,
                    created_at = DateTime.Now,
                };

                form = new FaturaDetalhes(totalPreco, vfrs);
                form.ShowDialog();
                if (form.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
              
            }

            if (documento.Text == "VFT")
            {

                vftArtigos.Clear();

                foreach (var compraArtigo in compraArtigos)
                {
                    vftArtigos.Add(new VftArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = compraArtigo.preco,
                        qtd = compraArtigo.qtd,
                        iva = compraArtigo.iva,
                        desconto=compraArtigo.desconto,
                    });
                }

                VftDTO vfts = new VftDTO()
                {
                    documento = codigoDocumentotxt.Text,
                    data = DateTime.Now,
                    fornecedorId = StaticProperty.entityId,
                    vftArtigo = vftArtigos,
                    status = DTOs.Enums.Enums.DocState.ativo,
                };

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(vfts);

                // Envio dos dados para a API
                response = await client.PostAsync($"https://localhost:7200/api/Compra/Vft/{StaticProperty.funcionarioId}", new StringContent(json, Encoding.UTF8, "application/json"));
            }

            if (documento.Text == "VGT")
            {
                vgtArtigos.Clear();

                foreach (var compraArtigo in compraArtigos)
                {
                    vgtArtigos.Add(new VgtArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = compraArtigo.preco,
                        qtd = compraArtigo.qtd,
                        iva = compraArtigo.iva,
                        desconto = compraArtigo.desconto,
                    });
                }

                VgtDTO vgts = new VgtDTO()
                {
                    documento = codigoDocumentotxt.Text,
                    data = DateTime.Now,
                    fornecedorId = StaticProperty.entityId,
                    vgtArtigo = vgtArtigos,
                    status = DTOs.Enums.Enums.DocState.ativo,
                };

                string json = System.Text.Json.JsonSerializer.Serialize(vgts);

                // Envio dos dados para a API
                response = await client.PostAsync($"https://localhost:7200/api/Compra/Vgt/{StaticProperty.funcionarioId}", new StringContent(json, Encoding.UTF8, "application/json"));
            }

            if (documento.Text == "ECF")
            {

                ecfArtigos.Clear();

                foreach (var compraArtigo in compraArtigos)
                {
                    ecfArtigos.Add(new EcfArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = compraArtigo.preco,
                        qtd = compraArtigo.qtd,
                        iva = compraArtigo.iva,
                        desconto=compraArtigo.desconto,
                    });
                }

                EncomendaFornecedorDTO ecfs = new EncomendaFornecedorDTO()
                {
                    documento = codigoDocumentotxt.Text,
                    data = DateTime.Now,
                    fornecedorId = StaticProperty.entityId,
                    ecfArtigo = ecfArtigos,
                    status = DTOs.Enums.Enums.DocState.ativo,
                };

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(ecfs);

                // Envio dos dados para a API
                response = await client.PostAsync($"https://localhost:7200/api/Compra/Ecf", new StringContent(json, Encoding.UTF8, "application/json"));
            }

            if (documento.Text == "VNC")
            {
                vncArtigos.Clear();
                foreach (var compraArtigo in compraArtigos)
                {
                    vncArtigos.Add(new VncArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = compraArtigo.preco,
                        qtd = compraArtigo.qtd,
                        iva = compraArtigo.iva,
                        desconto = compraArtigo.desconto,
                    });
                }

                VncDTO vncs = new VncDTO()
                {
                    documento = codigoDocumentotxt.Text,
                    data = DateTime.Now,
                    fornecedorId = StaticProperty.entityId,
                    vncArtigo = vncArtigos,
                    status = DTOs.Enums.Enums.DocState.ativo,
                };

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(vncs);

                // Envio dos dados para a API
                response = await client.PostAsync($"https://localhost:7200/api/Compra/Vnc/{StaticProperty.funcionarioId}", new StringContent(json, Encoding.UTF8, "application/json"));
            }

            if (documento.Text == "VND")
            {
                VndDTO vncs = new VndDTO()
                {
                    documento = codigoDocumentotxt.Text,
                    data = DateTime.Now,
                    fornecedorId = StaticProperty.entityId,
                    vndArtigo = vndArtigos,
                    status = DTOs.Enums.Enums.DocState.ativo,
                };
                vndArtigos.Clear();
                foreach (var compraArtigo in compraArtigos)
                {
                    vndArtigos.Add(new VndArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = compraArtigo.preco,
                        qtd = compraArtigo.qtd,
                        iva = compraArtigo.iva,
                        desconto = compraArtigo.desconto,
                    });
                }

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(vncs);

                // Envio dos dados para a API
                response = await client.PostAsync($"https://localhost:7200/api/Compra/Vnd", new StringContent(json, Encoding.UTF8, "application/json"));
            }

            if (documento.Text == "PCO")
            {

                pcoArtigos.Clear();

                foreach (var compraArtigo in compraArtigos)
                {
                    pcoArtigos.Add(new PedidoCotacaoArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = compraArtigo.preco,
                        iva = compraArtigo.iva,
                        desconto = compraArtigo.desconto
                    });
                }

                PedidoCotacaoDTO pcos = new PedidoCotacaoDTO()
                {
                    documento = codigoDocumentotxt.Text,
                    data = DateTime.Now,
                    fornecedorId = StaticProperty.entityId,
                    pcArtigo = pcoArtigos,
                    status = DTOs.Enums.Enums.DocState.ativo,
                    
                };

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(pcos);

                // Envio dos dados para a API
                response = await client.PostAsync($"https://localhost:7200/api/Compra/Pco", new StringContent(json, Encoding.UTF8, "application/json"));
            }

            if (documento.Text == "COT")
            {
                cotArtigos.Clear();

                foreach (var compraArtigo in compraArtigos)
                {
                    cotArtigos.Add(new CotacaoArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = compraArtigo.preco,
                        qtd = compraArtigo.qtd,
                        iva = compraArtigo.iva,
                        desconto =compraArtigo.desconto
                    });
                }


                CotacaoDTO cots = new CotacaoDTO()
                {
                    documento = codigoDocumentotxt.Text,
                    data = DateTime.Now,
                    fornecedorId = StaticProperty.entityId,
                    cArtigo = cotArtigos,
                    status = DTOs.Enums.Enums.DocState.ativo,
                };

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(cots);

                // Envio dos dados para a API
                response = await client.PostAsync($"https://localhost:7200/api/Compra/Cot", new StringContent(json, Encoding.UTF8, "application/json"));

            }

            var responseGet = await clientGet.GetAsync($"https://localhost:7200/api/Fornecedor/{StaticProperty.entityId}");

            if (responseGet.IsSuccessStatusCode)
            {
                var content = await responseGet.Content.ReadAsStringAsync();
                fornecedorResult = JsonConvert.DeserializeObject<FornecedorDTO>(content);
            }

            preVisualizacaoDialog.Document = Imprimir;

            if (preVisualizacaoDialog.ShowDialog() == DialogResult.OK)
            {
                Imprimir.Print();
            }

            
            compraArtigos.Clear();
            if(documento.Text == "VFR") { return; }
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Compra Com Sucesso", "Feito Com Sucesso", MessageBoxButtons.OK);


                // Compra
                var responseVft = await client.GetAsync($"https://localhost:7200/api/Compra/VftByRelations");

                if (responseVft.IsSuccessStatusCode)
                {
                    var contentVft = await responseVft.Content.ReadAsStringAsync();
                    StaticProperty.vfts = JsonConvert.DeserializeObject<List<VftDTO>>(contentVft);
                }

                var responseVfr = await client.GetAsync($"https://localhost:7200/api/Compra/VfrByRelations");

                if (responseVfr.IsSuccessStatusCode)
                {
                    var contentVfr = await responseVfr.Content.ReadAsStringAsync();
                    StaticProperty.vfrs = JsonConvert.DeserializeObject<List<VfrDTO>>(contentVfr);
                }

                var responseVgt = await client.GetAsync($"https://localhost:7200/api/Compra/VgtByRelations");

                if (responseVgt.IsSuccessStatusCode)
                {
                    var contentVgt = await responseVgt.Content.ReadAsStringAsync();
                    StaticProperty.vgts = JsonConvert.DeserializeObject<List<VgtDTO>>(contentVgt);
                }

                var responsePco = await client.GetAsync($"https://localhost:7200/api/Compra/PcoByRelations");

                if (responsePco.IsSuccessStatusCode)
                {
                    var contentPco = await responsePco.Content.ReadAsStringAsync();
                    StaticProperty.pcos = JsonConvert.DeserializeObject<List<PedidoCotacaoDTO>>(contentPco);
                }

                var responseCot = await client.GetAsync($"https://localhost:7200/api/Compra/CotByRelations");

                if (responseCot.IsSuccessStatusCode)
                {
                    var contentCot = await responseCot.Content.ReadAsStringAsync();
                    StaticProperty.cots = JsonConvert.DeserializeObject<List<CotacaoDTO>>(contentCot);
                }

                var responseEcf = await client.GetAsync($"https://localhost:7200/api/Compra/EcfByRelations");

                if (responseEcf.IsSuccessStatusCode)
                {
                    var contentEcf = await responseEcf.Content.ReadAsStringAsync();
                    StaticProperty.ecfs = JsonConvert.DeserializeObject<List<EncomendaFornecedorDTO>>(contentEcf);
                }

                var responseVnc = await client.GetAsync($"https://localhost:7200/api/Compra/VncByRelations");

                if (responseVnc.IsSuccessStatusCode)
                {
                    var contentVnc = await responseVnc.Content.ReadAsStringAsync();
                    StaticProperty.vncs = JsonConvert.DeserializeObject<List<VncDTO>>(contentVnc);
                }

                var responseVnd = await client.GetAsync($"https://localhost:7200/api/Compra/VndByRelations");

                if (responseVnd.IsSuccessStatusCode)
                {
                    var contentVnd = await responseVnd.Content.ReadAsStringAsync();
                    StaticProperty.vnds = JsonConvert.DeserializeObject<List<VndDTO>>(contentVnd);
                }
            }
            else
            {
                MessageBox.Show("Ocorreu um erro ao tentar Salvar", "Erro", MessageBoxButtons.RetryCancel);
            }
        }

        private void clienteBtn_Click(object sender, EventArgs e)
        {
            timerRefresh.Start();
            FornecedorListagem fornecedorListagem = new FornecedorListagem();
            fornecedorListagem.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (StaticProperty.series == null)
            {
                MessageBox.Show("Nenhuma Serie Foi Criada", "Precisa de uma Serie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                if (StaticProperty.entityId <= 0)
                {
                    MessageBox.Show("Precisas Selecionar o Fornecedor", "Atencao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (artigoId <= 0)
                {
                    MessageBox.Show("Nenhum Artigo Foi Selecionado", "Atencao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrWhiteSpace(documento.Text.ToString()))
                {
                    MessageBox.Show("Selecione um documento de Compra", "Atencao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string codigo;
                int idCompraArtigo = tabelaCompra.Rows.Count;
                List<CompraArtigo> refreshCompraArtigo = new List<CompraArtigo>();
                int i = 1;

                dtCompra.Rows.Clear();
                tabelaCompra.DataSource = dtCompra;

                codigo = StaticProperty.artigos.Where(art => art.id == artigoId).First().codigo;

                foreach (var ca in compraArtigos) 
                {
                    var cArtigo = new CompraArtigo
                    {
                        id = i,
                        codigo = ca.codigo,
                        preco = ca.preco,
                        qtd = ca.qtd,
                        iva = ca.iva,
                        desconto = ca.desconto,
                    };
                    refreshCompraArtigo.Add(cArtigo);
                    i++;          
                }

                compraArtigos.Clear();

                compraArtigos = refreshCompraArtigo;

                compraArtigos.Add(new CompraArtigo()
                {
                    id = idCompraArtigo,
                    codigo = codigo,
                    preco = float.Parse(precotxt.Text),
                    qtd = int.Parse(Qtd.Text),
                    iva = StaticProperty.artigos.Where(art => art.id == artigoId).First().iva,
                    desconto = float.Parse(descontoTxt.Text.ToString())

                });

                if (documento.Text == "VFR")
                {
                    artigos.Add(new VfrArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = float.Parse(precotxt.Text),
                        qtd = int.Parse(Qtd.Text),
                        iva = StaticProperty.artigos.Where(art => art.id == artigoId).First().iva,
                        desconto = float.Parse(descontoTxt.Text.ToString())
                    });

                    foreach (var vfr in compraArtigos)
                    {

                        dtCompra.Rows.Add(vfr.id, vfr.codigo, vfr.preco, vfr.qtd, vfr.iva,vfr.desconto);

                        tabelaCompra.DataSource = dtCompra;
                    }
                }

                if (documento.Text == "VFT")
                {
                    vftArtigos.Add(new VftArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = float.Parse(precotxt.Text),
                        qtd = int.Parse(Qtd.Text),
                        iva = StaticProperty.artigos.Where(art => art.id == artigoId).First().iva,
                        desconto = float.Parse(descontoTxt.Text.ToString())

                    });

                    foreach (var vft in compraArtigos)
                    {
                        idCompraArtigo = tabelaCompra.Rows.Count;
                        dtCompra.Rows.Add(vft.id, vft.codigo, vft.preco, vft.qtd, vft.iva,vft.desconto);

                        tabelaCompra.DataSource = dtCompra;
                    }
                }

                if (documento.Text == "PCO")
                {
                    pcoArtigos.Add(new PedidoCotacaoArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = float.Parse(precotxt.Text),
                        iva = StaticProperty.artigos.Where(art => art.id == artigoId).First().iva,
                        desconto = float.Parse(descontoTxt.Text.ToString())
                    });


                    foreach (var pco in compraArtigos)
                    {

                        dtCompra.Rows.Add(pco.id, pco.codigo, pco.preco, 0, pco.iva);

                        tabelaCompra.DataSource = dtCompra;
                    }
                }

                if (documento.Text == "COT")
                {
                    cotArtigos.Add(new CotacaoArtigoDTO()
                    {

                        artigoId = artigoId,
                        preco = float.Parse(precotxt.Text),
                        qtd = int.Parse(Qtd.Text),
                        iva = StaticProperty.artigos.Where(art => art.id == artigoId).First().iva,
                        desconto = float.Parse(descontoTxt.Text.ToString())
                    });


                    foreach (var cot in compraArtigos)
                    {

                        dtCompra.Rows.Add(cot.id, cot.codigo, cot.preco, cot.qtd, cot.iva, cot.desconto);

                        tabelaCompra.DataSource = dtCompra;
                    }
                }

                if (documento.Text == "VND")
                {
                    vndArtigos.Add(new VndArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = float.Parse(precotxt.Text),
                        qtd = int.Parse(Qtd.Text),
                        iva = StaticProperty.artigos.Where(art => art.id == artigoId).First().iva,
                        desconto = float.Parse(descontoTxt.Text.ToString())
                    });

                    foreach (var vnd in compraArtigos)
                    {
                        dtCompra.Rows.Add(vnd.id, vnd.codigo, vnd.preco, vnd.qtd, vnd.iva,vnd.desconto);

                        tabelaCompra.DataSource = dtCompra;
                    }
                }

                if (documento.Text == "VNC")
                {
                    vncArtigos.Add(new VncArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = float.Parse(precotxt.Text),
                        qtd = int.Parse(Qtd.Text),
                        iva = StaticProperty.artigos.Where(art => art.id == artigoId).First().iva,
                        desconto = float.Parse(descontoTxt.Text.ToString())
                    });

                    foreach (var vnc in compraArtigos)
                    {
                        dtCompra.Rows.Add(vnc.id, vnc.codigo, vnc.preco, vnc.qtd, vnc.iva, vnc.desconto);

                        tabelaCompra.DataSource = dtCompra;
                    }
                }
                if (documento.Text == "VGT")
                {
                    vncArtigos.Add(new VncArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = float.Parse(precotxt.Text),
                        qtd = int.Parse(Qtd.Text),
                        iva = StaticProperty.artigos.Where(art => art.id == artigoId).First().iva,
                        desconto = float.Parse(descontoTxt.Text.ToString())
                    });

                    foreach (var vgt in compraArtigos)
                    {
                        dtCompra.Rows.Add(vgt.id, vgt.codigo, vgt.preco, vgt.qtd, vgt.iva, vgt.desconto);

                        tabelaCompra.DataSource = dtCompra;
                    }
                }

                totalBruto.Text = $"Total: {CalculosVendaCompra.TotalCompra(compraArtigos).ToString("F2")}";
                ivaTotal.Text = $"Iva: {CalculosVendaCompra.TotalIvaCompra(compraArtigos).ToString("F2")}";
                descontoTotal.Text = $"Desconto: {CalculosVendaCompra.TotalDescontoCompra(compraArtigos).ToString("F2")}";
                precoLiquido.Text = $"Preço: {compraArtigos.Sum(x => x.preco * x.qtd).ToString("F2")}";
            }
            catch { return; }
        }

        private void tabelaArtigos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Obtém o valor da célula clicada
                    string id = tabelaArtigos.Rows[e.RowIndex].Cells[0].Value.ToString();

                    artigoId = int.Parse(id);

                }
            }
            catch { return; }
        }

        private async void documento_SelectedIndexChanged(object sender, EventArgs e)
        {
            var client = new HttpClient();

            if (!StaticProperty.series.Where(x => x.status == OpcaoBinaria.Sim).Any())
            {
                if (MessageBox.Show("Nenhuma serie foi criada\nDeseja criar uma serie?", "Imposivel concluir a acao", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    new SerieForm().ShowDialog();
                }
                else
                {
                    return;
                }
            }

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            var response = await client.GetAsync($"https://localhost:7200/api/serie/codigoDocumento/{documento.Text}/{StaticProperty.empresaId}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                string dados = content.ToString();

                codigoDocumentotxt.Text = dados.ToString();
            }

        }

        private void eliminarBtn_Click(object sender, EventArgs e)
        {
            var selectedRows = tabelaCompra.SelectedRows;

            foreach (DataGridViewRow row in selectedRows)
            {
                if (row != null && row.Index >= 0) // Verifica se a linha está válida
                {
                    int id = int.Parse(row.Cells[0].Value?.ToString()); // Substitua 0 pelo índice da coluna desejada
                                                                        // Ou faça algo mais útil com o valor
                    idCompra.Add(id);
                }
            }

            foreach (int id in idCompra)
            {
                var result = compraArtigos.Where(c => c.id == id).First();

                int index = compraArtigos.IndexOf(result);

                compraArtigos.RemoveAt(index);
            }

            dtCompra.Rows.Clear();
            tabelaCompra.DataSource = dtCompra;


            foreach (var ca in compraArtigos)
            {

                dtCompra.Rows.Add(ca.id, ca.codigo.ToString(), ca.preco, ca.qtd, ca.iva,ca.desconto);

                tabelaCompra.DataSource = dtCompra;
            }
            idCompra.Clear();
        }

        private void tabelaCompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            eliminarBtn.Enabled = true;
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            var response= await client.GetAsync($"https://localhost:7200/api/Artigo/Search/{textBox1.Text}"); ;

            if (string.IsNullOrWhiteSpace(textBox1.Text.ToString()))
            {
                response = await client.GetAsync("https://localhost:7200/api/Artigo");
            }

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var dados = JsonConvert.DeserializeObject<List<ArtigoDTO>>(content);

                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("Artigo", typeof(string));
                dt.Columns.Add("Descricao", typeof(string));
                dt.Columns.Add("preco", typeof(float));


                // Adicionando linhas ao DataTable
                foreach (var item in dados)
                {
                    dt.Rows.Add(item.id, item.codigo, item.descricao, item.preco_unitario);

                    tabelaArtigos.DataSource = dt;
                }
            }
        }

        private void fecharBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void excelBtn_Click(object sender, EventArgs e)
        {
            timerRefresh.Stop();
            CompraListagem cl = new CompraListagem();
            cl.ShowDialog();
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

        private void excelBtn_MouseLeave(object sender, EventArgs e)
        {
            comprasBtn.BackColor = Color.FromArgb(64,64,64);
            comprasBtn.ForeColor = Color.White;
        }

        private void excelBtn_MouseMove(object sender, MouseEventArgs e)
        {
            comprasBtn.BackColor= Color.White; 
            comprasBtn.ForeColor= Color.Black;   
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            fornecedortxt.Text = $"Fornecedor: {StaticProperty.nome}";
        }

        private void Imprimir_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                float totalLiquido = 0f;
                float totalIva = 0f;
                float ivaValorTotal = 0f;
                float total = 0f;
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
               
                string empresaNome = $"{fornecedorResult.nome_fantasia.ToUpper()}\n";
                string empresaCabecalho = $"{fornecedorResult.localizacao}\n" +
                                          $"Contribuente: {fornecedorResult.nif}\n" +
                                          $"Email: {fornecedorResult.email}\n" +
                                          $"Tel: {fornecedorResult.phones.First().telefone}";

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

                e.Graphics.DrawString($"Factura  {codigoDocumentotxt.Text}", fontNormalNegrito, cor, new PointF(50, 280), formatToLeft);
                e.Graphics.DrawLine(canetaFina, 50, 295, 250, 295);
                e.Graphics.DrawString("Contribuente", fontNormalNegrito, cor, new Rectangle(50, 300, 200, 310));
                e.Graphics.DrawString("Desc. Cli", fontNormalNegrito, cor, new Rectangle(200, 300, 350, 310));
                e.Graphics.DrawString("Data Emissão", fontNormalNegrito, cor, new Rectangle(350, 300, 500, 310));
                e.Graphics.DrawString("Data Vencimento", fontNormalNegrito, cor, new Rectangle(500, 300, 650, 310));
                e.Graphics.DrawLine(caneta, 50, 315, 750, 315);

                
                e.Graphics.DrawString($"{StaticProperty.empresa.nif}", fontNormal, cor, new Rectangle(50, 330, 200, 340));
                e.Graphics.DrawString("0,00", fontNormal, cor, new Rectangle(200, 330, 350, 340));
                e.Graphics.DrawString($"{DateTime.Now.Date.ToString("dd-MM-yyyy")}", fontNormal, cor, new Rectangle(350, 330, 450, 340));

                if (documento.Text.Equals("VFR"))
                {
                    e.Graphics.DrawString($"{DateTime.Now.Date}", fontNormal, cor, new Rectangle(500, 330, 650, 340));

                }
                else
                {
                    e.Graphics.DrawString($"-", fontNormal, cor, new Rectangle(500, 330, 650, 340));
                }

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

                    e.Graphics.DrawString($"{va.codigo}", fontNormal, cor, new Rectangle(50, 410 + i, 200, 425 + i));
                    e.Graphics.DrawString($"{StaticProperty.artigos.Where(art => art.codigo == va.codigo).First().descricao}", fontNormal, cor, new Rectangle(200, 410 + i, 350, 425 + i));
                    e.Graphics.DrawString($"{va.qtd}", fontNormal, cor, new Rectangle(350, 410 + i, 450, 425 + i));
                    e.Graphics.DrawString($"{va.preco.ToString("F4")}", fontNormal, cor, new Rectangle(450, 410 + i, 550, 425 + i));
                    e.Graphics.DrawString($"{(va.iva).ToString("F4")} %", fontNormal, cor, new Rectangle(550, 410 + i, 650, 425 + i));
                    e.Graphics.DrawString($"{(va.preco * float.Parse(va.qtd.ToString())).ToString("F4")}", fontNormal, cor, new Rectangle(650, 410 + i, 750, 425 + i));
                    i = i + 15;
                }

                totalLiquido += total - (total * (totalIva / 100));

                string mercadoria = $"Mercadoria/Serviço:";
                string iva = $"Iva:{totalIva.ToString("F4")}";
                string totalIvaValor = $"Total Iva:";
                string totalFinal = $"TOTAL";


                e.Graphics.DrawRectangle(caneta, new Rectangle(540, 520 + i, 210, 70 + i));

                e.Graphics.DrawString(mercadoria, fontCabecalho, cor, new PointF(550, 530 + i), formatToLeft);
                e.Graphics.DrawString(totalLiquido.ToString("F4"), fontCabecalho, cor, new PointF(680, 530 + i), formatToLeft);
                e.Graphics.DrawString(iva, fontCabecalho, cor, new PointF(550, 540 + i), formatToLeft);
                e.Graphics.DrawString(totalIva.ToString("F4"), fontCabecalho, cor, new PointF(680, 540 + i), formatToLeft);
                e.Graphics.DrawString(totalIvaValor, fontCabecalho, cor, new PointF(550, 550 + i), formatToLeft);
                e.Graphics.DrawString((total * (totalIva / 100)).ToString("F4"), fontCabecalho, cor, new PointF(680, 550 + i), formatToLeft);
                e.Graphics.DrawString("Desconto", fontCabecalho, cor, new PointF(550, 575 + i), formatToLeft);
                e.Graphics.DrawString($"{CalculosVendaCompra.TotalDescontoCompra(compraArtigos).ToString("F2")}", fontCabecalho, cor, new PointF(680, 575 + i), formatToLeft);

                e.Graphics.DrawLine(canetaFina, 550, 565 + i, 740, 565 + i);
                e.Graphics.DrawString(totalFinal, fontNormalNegrito, cor, new PointF(550, 595 + i), formatToLeft);
                e.Graphics.DrawString(total.ToString("F4"), fontNormalNegrito, cor, new PointF(680, 595 + i), formatToLeft);



             /*   e.Graphics.DrawString("Dados Bancários", new Font("Arial", 10, FontStyle.Underline, GraphicsUnit.Pixel), cor, new PointF(50, 530 + i), formatToLeft);
                e.Graphics.DrawString(banco, fontCabecalhoNegrito, cor, new PointF(50, 540 + i), formatToLeft);
                e.Graphics.DrawString(conta, fontCabecalho, cor, new PointF(50, 550 + i), formatToLeft);
                e.Graphics.DrawString($"24347216720012", fontCabecalho, cor, new PointF(115, 550 + i), formatToLeft);
                e.Graphics.DrawString(iban, fontCabecalho, cor, new PointF(50, 560 + i), formatToLeft);
                e.Graphics.DrawString("0040.0000.0305.4378,1012.4", fontCabecalho, cor, new PointF(95, 560 + i), formatToLeft);*/

                e.Graphics.DrawString($"Processado pelo programa válido nº{"41/AGT/2020"} Asc - Smart Entity", fontCabecalho, cor, new PointF(280, 700 + i), formatToCenter);



                // Verificando se o arquivo existe

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

        private void Compra_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerRefresh.Stop();
            timerRefresh.Dispose();

            StaticProperty.nome = string.Empty;
            StaticProperty.entityId = 0;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }

