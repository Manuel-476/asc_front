using AscFrontEnd.DTOs;
using AscFrontEnd.DTOs.Actividades;
using AscFrontEnd.DTOs.Cliente;
using AscFrontEnd.DTOs.ContasCorrentes;
using AscFrontEnd.DTOs.Deposito;
using AscFrontEnd.DTOs.Fornecedor;
using AscFrontEnd.DTOs.Serie;
using AscFrontEnd.DTOs.StaticsDto;
using AscFrontEnd.DTOs.Stock;
using AscFrontEnd.DTOs.Venda;
using EAscFrontEnd;
using ERP_Buyer.Application.DTOs.Documentos;
using ERP_Seller.Application.DTOs.Documentos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AscFrontEnd
{
    public partial class CarregamentoForm : Form
    {
        int processValue = 0;
        public CarregamentoForm()
        {
            InitializeComponent();
        }

        private async void CarregamentoForm_Load(object sender, EventArgs e)
        {
            timer1.Start();

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            try
            {
                // Compra
                var responseVft = await client.GetAsync($"https://localhost:7200/api/Compra/VftByRelations");

                if (responseVft.IsSuccessStatusCode)
                {
                    var contentVft = await responseVft.Content.ReadAsStringAsync();
                    StaticProperty.vfts = JsonConvert.DeserializeObject<List<VftDTO>>(contentVft);

                    processValue += 3;
                }

                var responseVfr = await client.GetAsync($"https://localhost:7200/api/Compra/VfrByRelations");

                if (responseVfr.IsSuccessStatusCode)
                {
                    var contentVfr = await responseVfr.Content.ReadAsStringAsync();
                    StaticProperty.vfrs = JsonConvert.DeserializeObject<List<VfrDTO>>(contentVfr);

                    processValue += 3;
                }

                var responseVgt = await client.GetAsync($"https://localhost:7200/api/Compra/VgtByRelation");

                if (responseVgt.IsSuccessStatusCode)
                {
                    var contentVgt = await responseVgt.Content.ReadAsStringAsync();
                    StaticProperty.vgts = JsonConvert.DeserializeObject<List<VgtDTO>>(contentVgt);
                    processValue += 4;
                }

                var responsePco = await client.GetAsync($"https://localhost:7200/api/Compra/PcoByRelation");

                if (responsePco.IsSuccessStatusCode)
                {
                    var contentPco = await responsePco.Content.ReadAsStringAsync();
                    StaticProperty.pcos = JsonConvert.DeserializeObject<List<PedidoCotacaoDTO>>(contentPco);

                    processValue += 5;
                }

                var responseCot = await client.GetAsync($"https://localhost:7200/api/Compra/CotByRelation");

                if (responseCot.IsSuccessStatusCode)
                {
                    var contentCot = await responseCot.Content.ReadAsStringAsync();
                    StaticProperty.cots = JsonConvert.DeserializeObject<List<CotacaoDTO>>(contentCot);

                    processValue += 3;
                }

                var responseEcf = await client.GetAsync($"https://localhost:7200/api/Compra/EcfByRelations");

                if (responseEcf.IsSuccessStatusCode)
                {
                    var contentEcf = await responseEcf.Content.ReadAsStringAsync();
                    StaticProperty.ecfs = JsonConvert.DeserializeObject<List<EncomendaFornecedorDTO>>(contentEcf);
                    processValue += 2;
                }

                var responseVnc = await client.GetAsync($"https://localhost:7200/api/Compra/VncByRelations");

                if (responseVnc.IsSuccessStatusCode)
                {
                    var contentVnc = await responseVnc.Content.ReadAsStringAsync();
                    StaticProperty.vncs = JsonConvert.DeserializeObject<List<VncDTO>>(contentVnc);

                    processValue += 1;
                }

                var responseVnd = await client.GetAsync($"https://localhost:7200/api/Compra/VndByRelation");

                if (responseVnd.IsSuccessStatusCode)
                {
                    var contentVnd = await responseVnd.Content.ReadAsStringAsync();
                    StaticProperty.vnds = JsonConvert.DeserializeObject<List<VndDTO>>(contentVnd);

                    processValue += 4;
                }

                // Venda
                var responseFr = await client.GetAsync($"https://localhost:7200/api/Venda/FrByRelations");

                if (responseFr.IsSuccessStatusCode)
                {
                    var contentFr = await responseFr.Content.ReadAsStringAsync();
                    StaticProperty.frs = JsonConvert.DeserializeObject<List<FrDTO>>(contentFr);

                    processValue += 2;
                }

                var responseFt = await client.GetAsync($"https://localhost:7200/api/Venda/FtByRelations");

                if (responseFt.IsSuccessStatusCode)
                {
                    var contentFt = await responseFt.Content.ReadAsStringAsync();
                    StaticProperty.fts = JsonConvert.DeserializeObject<List<FtDTO>>(contentFt);
                    processValue += 2;
                }

                var responseEcl = await client.GetAsync($"https://localhost:7200/api/Venda/EclByRelations");

                if (responseEcl.IsSuccessStatusCode)
                {
                    var contentEcl = await responseEcl.Content.ReadAsStringAsync();
                    StaticProperty.ecls = JsonConvert.DeserializeObject<List<EncomendaClienteDTO>>(contentEcl);

                    processValue += 1;
                }

                var responseFp = await client.GetAsync($"https://localhost:7200/api/Venda/FpByRelations");

                if (responseFp.IsSuccessStatusCode)
                {
                    var contentFp = await responseFp.Content.ReadAsStringAsync();
                    StaticProperty.fps = JsonConvert.DeserializeObject<List<FaturaProformaDTO>>(contentFp);

                    processValue += 5;
                }

                var responseNc = await client.GetAsync($"https://localhost:7200/api/Venda/NcByRelations");

                if (responseNc.IsSuccessStatusCode)
                {
                    var contentNc = await responseNc.Content.ReadAsStringAsync();
                    StaticProperty.ncs = JsonConvert.DeserializeObject<List<NcDTO>>(contentNc);

                    processValue += 5;
                }

                var responseNd = await client.GetAsync($"https://localhost:7200/api/Venda/NdByRelations");

                if (responseNd.IsSuccessStatusCode)
                {
                    var contentNd = await responseNd.Content.ReadAsStringAsync();
                    StaticProperty.nds = JsonConvert.DeserializeObject<List<NdDTO>>(contentNd);
                    processValue += 7;
                }

                var responseGt = await client.GetAsync($"https://localhost:7200/api/Venda/GtByRelations");

                if (responseGt.IsSuccessStatusCode)
                {
                    var contentGt = await responseNd.Content.ReadAsStringAsync();
                    StaticProperty.gts = JsonConvert.DeserializeObject<List<GtDTO>>(contentGt);

                    processValue += 3;
                }

                // Cliente
                var responseCliente = await client.GetAsync($"https://localhost:7200/api/Cliente/ClientesByRelation");

                if (responseCliente.IsSuccessStatusCode)
                {
                    var contentCliente = await responseCliente.Content.ReadAsStringAsync();
                    StaticProperty.clientes = JsonConvert.DeserializeObject<List<ClienteDTO>>(contentCliente);

                    processValue += 3;
                }

                // Fornecedor
                var responseFornecedor = await client.GetAsync($"https://localhost:7200/api/Fornecedor/FornecedoresByRelation");

                if (responseFornecedor.IsSuccessStatusCode)
                {
                    var contentFornecedor = await responseFornecedor.Content.ReadAsStringAsync();
                    StaticProperty.fornecedores = JsonConvert.DeserializeObject<List<FornecedorDTO>>(contentFornecedor);

                    processValue += 3;
                }

                // Artigo
                var responseArtigo = await client.GetAsync($"https://localhost:7200/api/Artigo");

                if (responseArtigo.IsSuccessStatusCode)
                {
                    var contentArtigo = await responseArtigo.Content.ReadAsStringAsync();
                    StaticProperty.artigos = JsonConvert.DeserializeObject<List<ArtigoDTO>>(contentArtigo);

                    processValue += 3;
                }

                // Amazem
                var responseArmazem = await client.GetAsync($"https://localhost:7200/api/Armazem/ArmazensByRelations");

                if (responseArmazem.IsSuccessStatusCode)
                {
                    var contentArmazem = await responseArmazem.Content.ReadAsStringAsync();
                    StaticProperty.armazens = JsonConvert.DeserializeObject<List<ArmazemDTO>>(contentArmazem);

                    processValue += 1;
                }

                var responseLocationStore = await client.GetAsync($"https://localhost:7200/api/Armazem/LocationStore");

                if (responseLocationStore.IsSuccessStatusCode)
                {
                    var contentLocationStore = await responseLocationStore.Content.ReadAsStringAsync();
                    StaticProperty.locationStores = JsonConvert.DeserializeObject<List<LocationStoreDTO>>(contentLocationStore);

                    processValue += 1;
                }

                var responseLocationArtigo = await client.GetAsync($"https://localhost:7200/api/Armazem/LocationArtigo");
                
                if (responseLocationArtigo.IsSuccessStatusCode)
                {
                    var contentLocationArtigo = await responseLocationArtigo.Content.ReadAsStringAsync();
                    StaticProperty.locationArtigos = JsonConvert.DeserializeObject<List<LocationArtigoDTO>>(contentLocationArtigo);

                    processValue += 1;
                }

                var responseHistorico  = await client.GetAsync($"https://localhost:7200/api/Stock/Historico");

                if (responseHistorico.IsSuccessStatusCode)
                {
                    var contentHistorico = await responseHistorico.Content.ReadAsStringAsync();

                    StaticProperty.historico = JsonConvert.DeserializeObject<List<ArmazemHistoricoDTO>>(contentHistorico);

                    processValue += 1;
                }

                // Nota Pagamento
                var responseNp = await client.GetAsync($"https://localhost:7200/api/ContaCorrente/Nps");

                  if (responseNp.IsSuccessStatusCode)
                  {
                      var contentNp = await responseNp.Content.ReadAsStringAsync();
                      StaticProperty.nps = JsonConvert.DeserializeObject<List<NpDTO>>(contentNp);
                    processValue += 3;
                }

                // Recibo
                var responseRe = await client.GetAsync($"https://localhost:7200/api/ContaCorrente/Res");

                if (responseRe.IsSuccessStatusCode)
                {
                    var contentRe = await responseRe.Content.ReadAsStringAsync();
                    StaticProperty.recibos = JsonConvert.DeserializeObject<List<ReciboDTO>>(contentRe);

                    processValue += 5;
                }


                // Conta Corrente
                var responseCCf = await client.GetAsync($"https://localhost:7200/api/ContaCorrente/divida/Fornecedor");

                if (responseCCf.IsSuccessStatusCode)
                {
                    var contentCCf = await responseCCf.Content.ReadAsStringAsync();
                    StaticProperty.contaCorrenteFornecedor = JsonConvert.DeserializeObject<object>(contentCCf);

                    processValue += 5;
                }

                var responseCCc = await client.GetAsync($"https://localhost:7200/api/ContaCorrente/divida/Cliente");

                if (responseCCc.IsSuccessStatusCode)
                {
                    var contentCCc = await responseCCc.Content.ReadAsStringAsync();
                    StaticProperty.contaCorrenteCliente = JsonConvert.DeserializeObject<object>(contentCCc);

                    processValue += 5;
                }

                // Serie
                var responseSerie = await client.GetAsync($"https://localhost:7200/api/Serie");

                if (responseSerie.IsSuccessStatusCode)
                {
                    var contentSerie = await responseSerie.Content.ReadAsStringAsync();
                    StaticProperty.series = JsonConvert.DeserializeObject<List<SerieDTO>>(contentSerie);
                    processValue += 3;
                }

                // Actividade
                var responseAct = await client.GetAsync($"https://localhost:7200/api/Actividade/WithRelations");

                if (responseAct.IsSuccessStatusCode)
                {
                    var contentAct = await responseAct.Content.ReadAsStringAsync();
                    StaticProperty.actividades = JsonConvert.DeserializeObject<List<ActividadeDTO>>(contentAct);

                    processValue += 5;
                }

                // Depositos
                var responseBanco = await client.GetAsync($"https://localhost:7200/api/Deposito/Banco");

                if (responseBanco.IsSuccessStatusCode)
                {
                    var contentBanco = await responseBanco.Content.ReadAsStringAsync();
                    StaticProperty.bancos = JsonConvert.DeserializeObject<List<BancoDTO>>(contentBanco);

                    processValue += 4;
                }

                var responseCaixa = await client.GetAsync($"https://localhost:7200/api/Deposito/Caixa");

                if (responseCaixa.IsSuccessStatusCode)
                {
                    var contentCaixa = await responseBanco.Content.ReadAsStringAsync();
                    StaticProperty.caixas = JsonConvert.DeserializeObject<List<CaixaDTO>>(contentCaixa);

                    processValue += 6;
                }

                // Funcionario
                var responseFuncionario = await client.GetAsync($"https://localhost:7200/api/Funcionario/WithRelations");

                if (responseFuncionario.IsSuccessStatusCode)
                {
                    var contentFuncionario = await responseFuncionario.Content.ReadAsStringAsync();

                    StaticProperty.funcionarios = JsonConvert.DeserializeObject<List<FuncionarioDTO>>(contentFuncionario);

                    processValue += 1;
                }

                // Familia
                var responseFamilia= await client.GetAsync($"https://localhost:7200/api/Artigo/Familia");

                if (responseFamilia.IsSuccessStatusCode)
                {
                    var contentFamilia = await responseFamilia.Content.ReadAsStringAsync();

                    StaticProperty.familias = JsonConvert.DeserializeObject<List<FamiliaArtigoDTO>>(contentFamilia);
                    processValue += 1;
                }

                // Sub-Familia
                var responseSubFamilia = await client.GetAsync($"https://localhost:7200/api/Artigo/SubFamilia");

                if (responseSubFamilia.IsSuccessStatusCode)
                {
                    var contentSubFamilia = await responseSubFamilia.Content.ReadAsStringAsync();

                    StaticProperty.subFamilias = JsonConvert.DeserializeObject<List<SubFamiliaDTO>>(contentSubFamilia);
                    processValue += 2;
                }

                // Marca
                var responseMarca = await client.GetAsync($"https://localhost:7200/api/Artigo/Marca");

                if (responseMarca.IsSuccessStatusCode)
                {
                    var contentMarca = await responseMarca.Content.ReadAsStringAsync();

                    StaticProperty.marcas = JsonConvert.DeserializeObject<List<MarcaDTO>>(contentMarca);

                    processValue += 1;
                }

                // Modelo
                var responseModelo = await client.GetAsync($"https://localhost:7200/api/Artigo/Modelo");

                if (responseModelo.IsSuccessStatusCode)
                {
                    var contentModelo = await responseModelo.Content.ReadAsStringAsync();

                    StaticProperty.modelos = JsonConvert.DeserializeObject<List<ModeloDTO>>(contentModelo);

                    processValue += 3;
                }
            }
            catch (Exception ex)
            {          
                if (MessageBox.Show( $"{ex.Message}", "Erro na Abertura do Sistema", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning)==DialogResult.Abort)
                {
                    Application.Exit();
                }
            }
            finally 
            {

             
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (processValue < 100)
            {
                progressBar1.Value = processValue;

            }
            else 
            {
                timer1.Stop();

                this.Hide();

                MenuPrincipal menuForm = new MenuPrincipal();
                menuForm.ShowDialog();
            }
        }
    }
}
