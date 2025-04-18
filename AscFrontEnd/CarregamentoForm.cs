using AscFrontEnd.DTOs;
using AscFrontEnd.DTOs.Artigo;
using AscFrontEnd.DTOs.Actividades;
using AscFrontEnd.DTOs.Cliente;
using AscFrontEnd.DTOs.ContasCorrentes;
using AscFrontEnd.DTOs.Deposito;
using AscFrontEnd.DTOs.Fornecedor;
using AscFrontEnd.DTOs.Serie;
using AscFrontEnd.DTOs.StaticsDto;
using AscFrontEnd.DTOs.Stock;
using AscFrontEnd.DTOs.Venda;
using AscFrontEnd.DTOs.Empresa;
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
using AscFrontEnd.DTOs.Regiao;
using AscFrontEnd.DTOs.Funcionario;
using AscFrontEnd.DTOs.Configuration;
using AscFrontEnd.DTOs.Compra;

namespace AscFrontEnd
{
    public partial class CarregamentoForm : Form
    {
        int processValue = 0;
        UserDTO _user;

        public CarregamentoForm(UserDTO user)
        {
            _user = user;
            InitializeComponent();
        }


        private async void CarregamentoForm_Load(object sender, EventArgs e)
        {
            timer1.Start();

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7200");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            try
            {

                var responseStock = await client.GetAsync($"api/Configuration/StockMinimo/{StaticProperty.empresaId}");

                if (responseStock.IsSuccessStatusCode)
                {
                    var contentStock = await responseStock.Content.ReadAsStringAsync();

                    StaticProperty.stockMinims = JsonConvert.DeserializeObject<List<StockMinimDTO>>(contentStock);

                    processValue += 1;
                }
                // Compra
                var responseVft = await client.GetAsync($"api/Compra/VftByRelations");

                if (responseVft.IsSuccessStatusCode)
                {
                    var contentVft = await responseVft.Content.ReadAsStringAsync();
                    StaticProperty.vfts = JsonConvert.DeserializeObject<List<VftDTO>>(contentVft);

                    processValue += 3;
                }

                var responseVfr = await client.GetAsync($"api/Compra/VfrByRelations");

                if (responseVfr.IsSuccessStatusCode)
                {
                    var contentVfr = await responseVfr.Content.ReadAsStringAsync();
                    StaticProperty.vfrs = JsonConvert.DeserializeObject<List<VfrDTO>>(contentVfr);

                    processValue += 3;
                }

                var responseVgt = await client.GetAsync($"api/Compra/VgtByRelation");

                if (responseVgt.IsSuccessStatusCode)
                {
                    var contentVgt = await responseVgt.Content.ReadAsStringAsync();
                    StaticProperty.vgts = JsonConvert.DeserializeObject<List<VgtDTO>>(contentVgt);

                    processValue += 2;
                }

                var responseVgr = await client.GetAsync($"api/Compra/VgrByRelations");

                if (responseVgr.IsSuccessStatusCode)
                {
                    var contentVgr = await responseVgr.Content.ReadAsStringAsync();
                    StaticProperty.vgrs = JsonConvert.DeserializeObject<List<VgrDTO>>(contentVgr);

                    processValue += 2;
                }

                var responsePco = await client.GetAsync($"api/Compra/PcoByRelation");

                if (responsePco.IsSuccessStatusCode)
                {
                    var contentPco = await responsePco.Content.ReadAsStringAsync();
                    StaticProperty.pcos = JsonConvert.DeserializeObject<List<PedidoCotacaoDTO>>(contentPco);

                    processValue += 5;
                }

                var responseCot = await client.GetAsync($"api/Compra/CotByRelation");

                if (responseCot.IsSuccessStatusCode)
                {
                    var contentCot = await responseCot.Content.ReadAsStringAsync();
                    StaticProperty.cots = JsonConvert.DeserializeObject<List<CotacaoDTO>>(contentCot);

                    processValue += 3;
                }

                var responseEcf = await client.GetAsync($"api/Compra/EcfByRelations");

                if (responseEcf.IsSuccessStatusCode)
                {
                    var contentEcf = await responseEcf.Content.ReadAsStringAsync();
                    StaticProperty.ecfs = JsonConvert.DeserializeObject<List<EncomendaFornecedorDTO>>(contentEcf);
                    processValue += 2;
                }

                var responseVnc = await client.GetAsync($"api/Compra/VncByRelations");

                if (responseVnc.IsSuccessStatusCode)
                {
                    var contentVnc = await responseVnc.Content.ReadAsStringAsync();
                    StaticProperty.vncs = JsonConvert.DeserializeObject<List<VncDTO>>(contentVnc);

                    processValue += 1;
                }

                var responseVnd = await client.GetAsync($"api/Compra/VndByRelation");

                if (responseVnd.IsSuccessStatusCode)
                {
                    var contentVnd = await responseVnd.Content.ReadAsStringAsync();
                    StaticProperty.vnds = JsonConvert.DeserializeObject<List<VndDTO>>(contentVnd);

                    processValue += 2;
                }

                var responseCompra = await client.GetAsync($"api/Relatorio/Compras/{StaticProperty.empresaId}");

                if (responseCompra.IsSuccessStatusCode)
                {
                    var contentCompra = await responseCompra.Content.ReadAsStringAsync();

                    StaticProperty.compra = JsonConvert.DeserializeObject<List<CompraDTO>>(contentCompra);

                    processValue += 1;
                }
                // Venda
                var responseFr = await client.GetAsync($"api/Venda/FrByRelations");

                if (responseFr.IsSuccessStatusCode)
                {
                    var contentFr = await responseFr.Content.ReadAsStringAsync();
                    StaticProperty.frs = JsonConvert.DeserializeObject<List<FrDTO>>(contentFr);

                    processValue += 2;
                }

                var responseFt = await client.GetAsync($"api/Venda/FtByRelations");

                if (responseFt.IsSuccessStatusCode)
                {
                    var contentFt = await responseFt.Content.ReadAsStringAsync();
                    StaticProperty.fts = JsonConvert.DeserializeObject<List<FtDTO>>(contentFt);
                    processValue += 2;
                }

                var responseEcl = await client.GetAsync($"api/Venda/EclByRelations");

                if (responseEcl.IsSuccessStatusCode)
                {
                    var contentEcl = await responseEcl.Content.ReadAsStringAsync();
                    StaticProperty.ecls = JsonConvert.DeserializeObject<List<EncomendaClienteDTO>>(contentEcl);

                    processValue += 1;
                }

                var responseFp = await client.GetAsync($"api/Venda/FpByRelations");

                if (responseFp.IsSuccessStatusCode)
                {
                    var contentFp = await responseFp.Content.ReadAsStringAsync();
                    StaticProperty.fps = JsonConvert.DeserializeObject<List<FaturaProformaDTO>>(contentFp);

                    processValue += 5;
                }

                var responseNc = await client.GetAsync($"api/Venda/NcByRelations");

                if (responseNc.IsSuccessStatusCode)
                {
                    var contentNc = await responseNc.Content.ReadAsStringAsync();
                    StaticProperty.ncs = JsonConvert.DeserializeObject<List<NcDTO>>(contentNc);

                    processValue += 5;
                }

                var responseNd = await client.GetAsync($"api/Venda/NdByRelations");

                if (responseNd.IsSuccessStatusCode)
                {
                    var contentNd = await responseNd.Content.ReadAsStringAsync();
                    StaticProperty.nds = JsonConvert.DeserializeObject<List<NdDTO>>(contentNd);
                    processValue += 3;
                }

                var responseGt = await client.GetAsync($"api/Venda/GtByRelations");

                if (responseGt.IsSuccessStatusCode)
                {
                    var contentGt = await responseGt.Content.ReadAsStringAsync();
                    StaticProperty.gts = JsonConvert.DeserializeObject<List<GtDTO>>(contentGt);

                    processValue += 1;
                }

                var responseGr = await client.GetAsync($"api/Venda/GrByRelations");

                if (responseGr.IsSuccessStatusCode)
                {
                    var contentGr = await responseGr.Content.ReadAsStringAsync();
                    StaticProperty.grs = JsonConvert.DeserializeObject<List<GrDTO>>(contentGr);

                    processValue += 2;
                }

                var responseOr = await client.GetAsync($"api/Venda/OrByRelations");

                if (responseOr.IsSuccessStatusCode)
                {
                    var contentOr = await responseOr.Content.ReadAsStringAsync();
                    StaticProperty.ors = JsonConvert.DeserializeObject<List<OrDTO>>(contentOr);

                    processValue += 4;
                }

                var responseVenda = await client.GetAsync($"api/Relatorio/Vendas/{StaticProperty.empresaId}");

                if (responseVenda.IsSuccessStatusCode)
                {
                    var contentVenda = await responseVenda.Content.ReadAsStringAsync();

                    StaticProperty.venda = JsonConvert.DeserializeObject<List<VendaDTO>>(contentVenda);

                    processValue += 1;
                }

                // Cliente
                var responseCliente = await client.GetAsync($"api/Cliente/ClientesByRelation");

                if (responseCliente.IsSuccessStatusCode)
                {
                    var contentCliente = await responseCliente.Content.ReadAsStringAsync();
                    StaticProperty.clientes = JsonConvert.DeserializeObject<List<ClienteDTO>>(contentCliente);

                    processValue += 3;
                }

                // Fornecedor
                var responseFornecedor = await client.GetAsync($"api/Fornecedor/FornecedoresByRelation");

                if (responseFornecedor.IsSuccessStatusCode)
                {
                    var contentFornecedor = await responseFornecedor.Content.ReadAsStringAsync();
                    StaticProperty.fornecedores = JsonConvert.DeserializeObject<List<FornecedorDTO>>(contentFornecedor);

                    processValue += 3;
                }

                // Artigo
                var responseArtigo = await client.GetAsync($"api/Artigo");

                if (responseArtigo.IsSuccessStatusCode)
                {
                    var contentArtigo = await responseArtigo.Content.ReadAsStringAsync();
                    StaticProperty.artigos = JsonConvert.DeserializeObject<List<ArtigoDTO>>(contentArtigo);

                    processValue += 2;
                }

                var responseMotivos = await client.GetAsync($"api/Artigo/Iva/MotivosIsencao");

                if (responseMotivos.IsSuccessStatusCode)
                {
                    var contentMotivos = await responseMotivos.Content.ReadAsStringAsync();
                    StaticProperty.motivosIsencao = JsonConvert.DeserializeObject<List<MotivosIsencaoIvaDTO>>(contentMotivos);

                    processValue += 1;
                }

                // Amazem
                var responseArmazem = await client.GetAsync($"api/Armazem/ArmazensByRelations");

                if (responseArmazem.IsSuccessStatusCode)
                {
                    var contentArmazem = await responseArmazem.Content.ReadAsStringAsync();
                    StaticProperty.armazens = JsonConvert.DeserializeObject<List<ArmazemDTO>>(contentArmazem);

                    processValue += 1;
                }

                var responseLocationStore = await client.GetAsync($"api/Armazem/LocationStore");

                if (responseLocationStore.IsSuccessStatusCode)
                {
                    var contentLocationStore = await responseLocationStore.Content.ReadAsStringAsync();
                    StaticProperty.locationStores = JsonConvert.DeserializeObject<List<LocationStoreDTO>>(contentLocationStore);

                    processValue += 1;
                }

                var responseLocationArtigo = await client.GetAsync($"api/Armazem/LocationArtigo");
                
                if (responseLocationArtigo.IsSuccessStatusCode)
                {
                    var contentLocationArtigo = await responseLocationArtigo.Content.ReadAsStringAsync();
                    StaticProperty.locationArtigos = JsonConvert.DeserializeObject<List<LocationArtigoDTO>>(contentLocationArtigo);

                    processValue += 1;
                }

                var responseHistorico  = await client.GetAsync($"api/Stock/Historico");

                if (responseHistorico.IsSuccessStatusCode)
                {
                    var contentHistorico = await responseHistorico.Content.ReadAsStringAsync();

                    StaticProperty.historico = JsonConvert.DeserializeObject<List<ArmazemHistoricoDTO>>(contentHistorico);

                    processValue += 1;
                }

                // Nota Pagamento
                var responseNp = await client.GetAsync($"api/ContaCorrente/Nps");

                  if (responseNp.IsSuccessStatusCode)
                  {
                      var contentNp = await responseNp.Content.ReadAsStringAsync();
                      StaticProperty.nps = JsonConvert.DeserializeObject<List<NpDTO>>(contentNp);
                    processValue += 3;
                }

                // Recibo
                var responseRe = await client.GetAsync($"api/ContaCorrente/Res");

                if (responseRe.IsSuccessStatusCode)
                {
                    var contentRe = await responseRe.Content.ReadAsStringAsync();
                    StaticProperty.recibos = JsonConvert.DeserializeObject<List<ReciboDTO>>(contentRe);

                    processValue += 4;
                }


                // Conta Corrente
                var responseCCf = await client.GetAsync($"api/ContaCorrente/divida/Fornecedor");

                if (responseCCf.IsSuccessStatusCode)
                {
                    var contentCCf = await responseCCf.Content.ReadAsStringAsync();
                    StaticProperty.contaCorrenteFornecedor = JsonConvert.DeserializeObject<object>(contentCCf);

                    processValue += 5;
                }

                var responseCCc = await client.GetAsync($"api/ContaCorrente/divida/Cliente");

                if (responseCCc.IsSuccessStatusCode)
                {
                    var contentCCc = await responseCCc.Content.ReadAsStringAsync();
                    StaticProperty.contaCorrenteCliente = JsonConvert.DeserializeObject<object>(contentCCc);

                    processValue += 3;
                }

                var responseAdForn = await client.GetAsync($"api/ContaCorrente/Adiantamento/Fornecedor");

                if (responseAdForn.IsSuccessStatusCode)
                {
                    var contentAdForn = await responseAdForn.Content.ReadAsStringAsync();
                    StaticProperty.adiantamentoForns = JsonConvert.DeserializeObject<List<AdiantamentoFornDTO>>(contentAdForn);

                    processValue += 1;
                }

                var responseAdCliente = await client.GetAsync($"api/ContaCorrente/Adiantamento/Cliente");

                if (responseAdCliente.IsSuccessStatusCode)
                {
                    var contentAdCliente = await responseAdCliente.Content.ReadAsStringAsync();
                    StaticProperty.adiantamentoClientes = JsonConvert.DeserializeObject<List<AdiantamentoClienteDTO>>(contentAdCliente);

                    processValue += 1;
                }

                var responseRegAdForn = await client.GetAsync($"api/ContaCorrente/Regular/Adiantamento/Fornecedor/WithRelations");

                if (responseRegAdForn.IsSuccessStatusCode)
                {
                    var contentRegAdForn = await responseRegAdForn.Content.ReadAsStringAsync();
                    StaticProperty.regAdiantamentoForns = JsonConvert.DeserializeObject<List<RegAdiantamentoFornDTO>>(contentRegAdForn);

                    processValue += 1;
                }

                var responseRegAdCliente = await client.GetAsync($"api/ContaCorrente/Regular/Adiantamento/Cliente/WithRelations");

                if (responseRegAdCliente.IsSuccessStatusCode)
                {
                    var contentRegAdCliente = await responseRegAdCliente.Content.ReadAsStringAsync();
                    StaticProperty.regAdiantamentoClientes = JsonConvert.DeserializeObject <List<RegAdiantamentoClienteDTO>>(contentRegAdCliente);

                    processValue += 1;
                }

                // Serie
                var responseSerie = await client.GetAsync($"api/Serie");

                if (responseSerie.IsSuccessStatusCode)
                {
                    var contentSerie = await responseSerie.Content.ReadAsStringAsync();
                    StaticProperty.series = JsonConvert.DeserializeObject<List<SerieDTO>>(contentSerie);
                    processValue += 3;
                }

                // Actividade
                var responseAct = await client.GetAsync($"api/Actividade/WithRelations");

                if (responseAct.IsSuccessStatusCode)
                {
                    var contentAct = await responseAct.Content.ReadAsStringAsync();
                    StaticProperty.actividades = JsonConvert.DeserializeObject<List<ActividadeDTO>>(contentAct);

                    processValue += 3;
                }

                // Depositos
                var responseBanco = await client.GetAsync($"api/Deposito/Bancos");

                if (responseBanco.IsSuccessStatusCode)
                {
                    var contentBanco = await responseBanco.Content.ReadAsStringAsync();
                    StaticProperty.bancos = JsonConvert.DeserializeObject<List<BancoDTO>>(contentBanco);

                    processValue += 3;
                }

                var responseCaixa = await client.GetAsync($"api/Deposito/Caixa");

                if (responseCaixa.IsSuccessStatusCode)
                {
                    var contentCaixa = await responseCaixa.Content.ReadAsStringAsync();
                    StaticProperty.caixas = JsonConvert.DeserializeObject<List<CaixaDTO>>(contentCaixa);

                    processValue += 2;
                }

                var responseFormaPagamento = await client.GetAsync($"api/Deposito/FormaPagamento");

                if (responseFormaPagamento.IsSuccessStatusCode)
                {
                    var contentFormaPagamento = await responseFormaPagamento.Content.ReadAsStringAsync();
                    StaticProperty.formasPagamento = JsonConvert.DeserializeObject<List<FormaPagamentoDTO>>(contentFormaPagamento);

                    processValue += 2;
                }

                // Funcionario
                var responseFuncionario = await client.GetAsync($"api/Funcionario/WithRelations");

                if (responseFuncionario.IsSuccessStatusCode)
                {
                    var contentFuncionario = await responseFuncionario.Content.ReadAsStringAsync();

                    StaticProperty.funcionarios = JsonConvert.DeserializeObject<List<FuncionarioDTO>>(contentFuncionario);

                    processValue += 1;
                }

                // Permissoes
                var responsePermissions = await client.GetAsync($"api/Funcionario/Permissions");

                if (responsePermissions.IsSuccessStatusCode)
                {
                    var contentPermissions = await responsePermissions.Content.ReadAsStringAsync();

                    StaticProperty.permissions = JsonConvert.DeserializeObject<List<UserPermissionsDTO>>(contentPermissions);

                    processValue += 1;
                }

                // Familia
                var responseFamilia= await client.GetAsync($"api/Artigo/Familia");

                if (responseFamilia.IsSuccessStatusCode)
                {
                    var contentFamilia = await responseFamilia.Content.ReadAsStringAsync();

                    StaticProperty.familias = JsonConvert.DeserializeObject<List<FamiliaArtigoDTO>>(contentFamilia);
                    processValue += 1;
                }

                // Sub-Familia
                var responseSubFamilia = await client.GetAsync($"api/Artigo/SubFamilia");

                if (responseSubFamilia.IsSuccessStatusCode)
                {
                    var contentSubFamilia = await responseSubFamilia.Content.ReadAsStringAsync();

                    StaticProperty.subFamilias = JsonConvert.DeserializeObject<List<SubFamiliaDTO>>(contentSubFamilia);
                    processValue += 2;
                }

                // Marca
                var responseMarca = await client.GetAsync($"api/Artigo/Marca");

                if (responseMarca.IsSuccessStatusCode)
                {
                    var contentMarca = await responseMarca.Content.ReadAsStringAsync();

                    StaticProperty.marcas = JsonConvert.DeserializeObject<List<MarcaDTO>>(contentMarca);

                    processValue += 1;
                }

                // Modelo
                var responseModelo = await client.GetAsync($"api/Artigo/Modelo");

                if (responseModelo.IsSuccessStatusCode)
                {
                    var contentModelo = await responseModelo.Content.ReadAsStringAsync();

                    StaticProperty.modelos = JsonConvert.DeserializeObject<List<ModeloDTO>>(contentModelo);

                    processValue += 2;
                }

                // Empresa
                var responseEmpresa = await client.GetAsync($"api/Empresa/{StaticProperty.empresaId}");

                if (responseEmpresa.IsSuccessStatusCode)
                {
                    var contentEmpresa = await responseEmpresa.Content.ReadAsStringAsync();

                    StaticProperty.empresa = JsonConvert.DeserializeObject<EmpresaDTO>(contentEmpresa);

                    processValue += 1;
                }

                // Outros
                var responseIva = await client.GetAsync($"api/iva");

                if (responseIva.IsSuccessStatusCode)
                {
                    var contentIva = await responseIva.Content.ReadAsStringAsync();

                    StaticProperty.ivas = JsonConvert.DeserializeObject < List<IvaDTO>>(contentIva);

                    processValue += 1;
                }

                var responseUnidade = await client.GetAsync($"api/Unidade");

                if (responseUnidade.IsSuccessStatusCode)
                {
                    var contentUnidade = await responseUnidade.Content.ReadAsStringAsync();

                    StaticProperty.unidades = JsonConvert.DeserializeObject<List<UnidadeDTO>>(contentUnidade);

                    processValue += 1;
                }

                var responsePais = await client.GetAsync($"api/pais/WithRelations");

                if (responsePais.IsSuccessStatusCode)
                {
                    var contentPais = await responsePais.Content.ReadAsStringAsync();

                    StaticProperty.paises = JsonConvert.DeserializeObject<List<PaisDTO>>(contentPais);

                    processValue += 1;
                }

                var responseProvincia = await client.GetAsync($"api/pais/provincia");

                if (responseProvincia.IsSuccessStatusCode)
                {
                    var contentProvincia = await responseProvincia.Content.ReadAsStringAsync();

                    StaticProperty.provincias = JsonConvert.DeserializeObject<List<ProvinciaDTO>>(contentProvincia);

                    processValue += 1;
                }


            }
            catch (Exception ex)
            {          
                if (MessageBox.Show( $"{ex.Message}", "Erro na Abertura do Sistema", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning)==DialogResult.Abort)
                {
                    System.Windows.Forms.Application.Exit();
                }
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

                MenuPrincipal menuForm = new MenuPrincipal(_user);
                menuForm.ShowDialog();
            }
        }
    }
}
