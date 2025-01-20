using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AscFrontEnd.DTOs;
using AscFrontEnd.DTOs.Actividades;
using AscFrontEnd.DTOs.Artigo;
using AscFrontEnd.DTOs.Cliente;
using AscFrontEnd.DTOs.ContasCorrentes;
using AscFrontEnd.DTOs.Deposito;
using AscFrontEnd.DTOs.Empresa;
using AscFrontEnd.DTOs.Fornecedor;
using AscFrontEnd.DTOs.Regiao;
using AscFrontEnd.DTOs.Serie;
using AscFrontEnd.DTOs.StaticsDto;
using AscFrontEnd.DTOs.Stock;
using AscFrontEnd.DTOs.Venda;
using DocumentFormat.OpenXml.Office2013.Drawing.Chart;
using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
using DocumentFormat.OpenXml.Office2016.Drawing.Command;
using EAscFrontEnd;
using ERP_Buyer.Application.DTOs.Documentos;
using ERP_Seller.Application.DTOs.Documentos;
using Newtonsoft.Json;

namespace AscFrontEnd.Application
{
    public class Requisicoes
    {
        HttpClient _httpClient;
        public Requisicoes()
        {
            _httpClient = new HttpClient();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            _httpClient.BaseAddress = new Uri("https://localhost:7200");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<VftDTO>> GetVft()
        {
            try
            {
                var responseVft = await _httpClient.GetAsync($"https://localhost:7200/api/Compra/VftByRelations");

                if (responseVft.IsSuccessStatusCode)
                {
                    var contentVft = await responseVft.Content.ReadAsStringAsync();

                    var vfts = JsonConvert.DeserializeObject<List<VftDTO>>(contentVft);

                    return vfts;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<VfrDTO>> GetVfr()
        {
            try
            {
                var responseVfr = await _httpClient.GetAsync($"https://localhost:7200/api/Compra/VfrByRelations");

                if (responseVfr.IsSuccessStatusCode)
                {
                    var contentVfr = await responseVfr.Content.ReadAsStringAsync();
                    var vfrs = JsonConvert.DeserializeObject<List<VfrDTO>>(contentVfr);

                    return vfrs;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<VgtDTO>> GetVgt()
        {
            try
            {
                var responseVgt = await _httpClient.GetAsync($"https://localhost:7200/api/Compra/VgtByRelation");

                if (responseVgt.IsSuccessStatusCode)
                {
                    var contentVgt = await responseVgt.Content.ReadAsStringAsync();
                    var vgts = JsonConvert.DeserializeObject<List<VgtDTO>>(contentVgt);

                    return vgts;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<PedidoCotacaoDTO>> GetPco()
        {
            try
            {
                var responsePco = await _httpClient.GetAsync($"https://localhost:7200/api/Compra/PcoByRelation");

                if (responsePco.IsSuccessStatusCode)
                {
                    var contentPco = await responsePco.Content.ReadAsStringAsync();

                    var pcos = JsonConvert.DeserializeObject<List<PedidoCotacaoDTO>>(contentPco);

                    return pcos;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<CotacaoDTO>> GetCot()
        {
            try
            {

                var responseCot = await _httpClient.GetAsync($"https://localhost:7200/api/Compra/CotByRelation");

                if (responseCot.IsSuccessStatusCode)
                {
                    var contentCot = await responseCot.Content.ReadAsStringAsync();

                    var cots = JsonConvert.DeserializeObject<List<CotacaoDTO>>(contentCot);

                    return cots;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<EncomendaFornecedorDTO>> GetEcf()
        {
            try
            {

                var responseEcf = await _httpClient.GetAsync($"api/Compra/EcfByRelations");

                if (responseEcf.IsSuccessStatusCode)
                {
                    var contentEcf = await responseEcf.Content.ReadAsStringAsync();

                    var ecfs = JsonConvert.DeserializeObject<List<EncomendaFornecedorDTO>>(contentEcf);

                    return ecfs;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<VncDTO>> GetVnc()
        {
            try
            {

                var responseVnc = await _httpClient.GetAsync($"api/Compra/VncByRelations");

                if (responseVnc.IsSuccessStatusCode)
                {
                    var contentVnc = await responseVnc.Content.ReadAsStringAsync();
                    var vncs = JsonConvert.DeserializeObject<List<VncDTO>>(contentVnc);

                    return vncs;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<VndDTO>> GetVnd()
        {
            try
            {

                var responseVnd = await _httpClient.GetAsync($"api/Compra/VndByRelation");

                if (responseVnd.IsSuccessStatusCode)
                {
                    var contentVnd = await responseVnd.Content.ReadAsStringAsync();
                    var vnds = JsonConvert.DeserializeObject<List<VndDTO>>(contentVnd);

                    return vnds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<FrDTO>> GetFr()
        {
            try
            {
                var responseFr = await _httpClient.GetAsync($"api/Venda/FrByRelations");

                if (responseFr.IsSuccessStatusCode)
                {
                    var contentFr = await responseFr.Content.ReadAsStringAsync();

                    var frs = JsonConvert.DeserializeObject<List<FrDTO>>(contentFr);

                    return frs;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<FtDTO>> GetFt()
        {
            try
            {
                var responseFt = await _httpClient.GetAsync($"api/Venda/FtByRelations");

                if (responseFt.IsSuccessStatusCode)
                {
                    var contentFt = await responseFt.Content.ReadAsStringAsync();
                    var fts = JsonConvert.DeserializeObject<List<FtDTO>>(contentFt);

                    return fts;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<EncomendaClienteDTO>> GetEcl()
        {
            try
            {
                var responseEcl = await _httpClient.GetAsync($"https://localhost:7200/api/Venda/EclByRelations");

                if (responseEcl.IsSuccessStatusCode)
                {
                    var contentEcl = await responseEcl.Content.ReadAsStringAsync();
                    var ecls = JsonConvert.DeserializeObject<List<EncomendaClienteDTO>>(contentEcl);

                    return ecls;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<FaturaProformaDTO>> GetFp()
        {
            try
            {
                var responseFp = await _httpClient.GetAsync($"api/Venda/FpByRelations");

                if (responseFp.IsSuccessStatusCode)
                {
                    var contentFp = await responseFp.Content.ReadAsStringAsync();

                    var fps = JsonConvert.DeserializeObject<List<FaturaProformaDTO>>(contentFp);

                    return fps;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<NcDTO>> GetNc()
        {
            try
            {
                var responseNc = await _httpClient.GetAsync($"api/Venda/NcByRelations");

                if (responseNc.IsSuccessStatusCode)
                {
                    var contentNc = await responseNc.Content.ReadAsStringAsync();
                    var ncs = JsonConvert.DeserializeObject<List<NcDTO>>(contentNc);

                    return ncs;
                }
                else 
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<NdDTO>> GetNd()
        {
            try
            {
                var responseNd = await _httpClient.GetAsync($"api/Venda/NdByRelations");

                if (responseNd.IsSuccessStatusCode)
                {
                    var contentNd = await responseNd.Content.ReadAsStringAsync();
                    var nds = JsonConvert.DeserializeObject<List<NdDTO>>(contentNd);
                    
                    return nds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<GtDTO>> GetGt()
        {
            try
            {
                var responseGt = await _httpClient.GetAsync($"api/Venda/GtByRelations");

                if (responseGt.IsSuccessStatusCode)
                {
                    var contentGt = await responseGt.Content.ReadAsStringAsync();
                    var gts = JsonConvert.DeserializeObject<List<GtDTO>>(contentGt);

                    return gts;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<ClienteDTO>> GetClientes()
        {
            try
            {
                var responseCliente = await _httpClient.GetAsync($"api/Cliente/ClientesByRelation");

                if (responseCliente.IsSuccessStatusCode)
                {
                    var contentCliente = await responseCliente.Content.ReadAsStringAsync();
                    var clientes = JsonConvert.DeserializeObject<List<ClienteDTO>>(contentCliente);

                    return clientes;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<FornecedorDTO>> GetFornecedores()
        {
            try
            {
                var responseFornecedor = await _httpClient.GetAsync($"api/Fornecedor/FornecedoresByRelation");

                if (responseFornecedor.IsSuccessStatusCode)
                {
                    var contentFornecedor = await responseFornecedor.Content.ReadAsStringAsync();
                    var fornecedores = JsonConvert.DeserializeObject<List<FornecedorDTO>>(contentFornecedor);

                    return fornecedores;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<ArtigoDTO>> GetArtigos()
        {
            try
            {
                var responseArtigo = await _httpClient.GetAsync($"api/Artigo");

                if (responseArtigo.IsSuccessStatusCode)
                {
                    var contentArtigo = await responseArtigo.Content.ReadAsStringAsync();
                    var artigos = JsonConvert.DeserializeObject<List<ArtigoDTO>>(contentArtigo);

                    return artigos;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<MotivosIsencaoIvaDTO>> GetMotivos()
        {
            try
            {
                var responseMotivos = await _httpClient.GetAsync($"api/Artigo/Iva/MotivosIsencao");

                if (responseMotivos.IsSuccessStatusCode)
                {
                    var contentMotivos = await responseMotivos.Content.ReadAsStringAsync();
                    var motivosIsencao = JsonConvert.DeserializeObject<List<MotivosIsencaoIvaDTO>>(contentMotivos);

                    return motivosIsencao;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<ArmazemDTO>> GetArmazens()
        {
            try
            {
                var responseArmazem = await _httpClient.GetAsync($"api/Armazem/ArmazensByRelations");

                if (responseArmazem.IsSuccessStatusCode)
                {
                    var contentArmazem = await responseArmazem.Content.ReadAsStringAsync();
                    var armazens = JsonConvert.DeserializeObject<List<ArmazemDTO>>(contentArmazem);

                    return armazens;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<LocationStoreDTO>> GetLocalizacoes()
        {
            try
            {
                var responseLocationStore = await _httpClient.GetAsync($"api/Armazem/LocationStore");

                if (responseLocationStore.IsSuccessStatusCode)
                {
                    var contentLocationStore = await responseLocationStore.Content.ReadAsStringAsync();
                    var locationStores = JsonConvert.DeserializeObject<List<LocationStoreDTO>>(contentLocationStore);

                    return locationStores;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }


        public async Task<List<LocationArtigoDTO>> GetLocalizacaoArtigo()
        {
            try
            {
                var responseLocationArtigo = await _httpClient.GetAsync($"api/Armazem/LocationArtigo");

                if (responseLocationArtigo.IsSuccessStatusCode)
                {
                    var contentLocationArtigo = await responseLocationArtigo.Content.ReadAsStringAsync();
                    var locationArtigos = JsonConvert.DeserializeObject<List<LocationArtigoDTO>>(contentLocationArtigo);

                    return locationArtigos;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<ArmazemHistoricoDTO>> GetArmazemHistorico()
        {
            try
            {
                var responseHistorico = await _httpClient.GetAsync($"api/Stock/Historico");

                if (responseHistorico.IsSuccessStatusCode)
                {
                    var contentHistorico = await responseHistorico.Content.ReadAsStringAsync();

                    var historico = JsonConvert.DeserializeObject<List<ArmazemHistoricoDTO>>(contentHistorico);

                    return historico;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<NpDTO>> GetNotaPagamento()
        {
            try
            {
                var responseNp = await _httpClient.GetAsync($"api/ContaCorrente/Nps");

                if (responseNp.IsSuccessStatusCode)
                {
                    var contentNp = await responseNp.Content.ReadAsStringAsync();
                    var nps = JsonConvert.DeserializeObject<List<NpDTO>>(contentNp);

                    return nps;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<ReciboDTO>> GetRecibo()
        {
            try
            {
                var responseRe = await _httpClient.GetAsync($"api/ContaCorrente/Res");

                if (responseRe.IsSuccessStatusCode)
                {
                    var contentRe = await responseRe.Content.ReadAsStringAsync();
                    var recibos = JsonConvert.DeserializeObject<List<ReciboDTO>>(contentRe);

                    return recibos;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<object> GetContaCorrenteForn()
        {
            try
            {
                var responseCCf = await _httpClient.GetAsync($"api/ContaCorrente/divida/Fornecedor");

                if (responseCCf.IsSuccessStatusCode)
                {
                    var contentCCf = await responseCCf.Content.ReadAsStringAsync();
                    var ccf = JsonConvert.DeserializeObject<object>(contentCCf);

                    return ccf;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<object> GetContaCorrenteCliente()
        {
            try
            {
                var responseCCc = await _httpClient.GetAsync($"api/ContaCorrente/divida/Cliente");

                if (responseCCc.IsSuccessStatusCode)
                {
                    var contentCCc = await responseCCc.Content.ReadAsStringAsync();
                    var contaCorrenteCliente = JsonConvert.DeserializeObject<object>(contentCCc);

                    return contaCorrenteCliente;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<AdiantamentoFornDTO>> GetAdFornecedor()
        {
            try
            {
                var responseAdForn = await _httpClient.GetAsync($"api/ContaCorrente/Adiantamento/Fornecedor");

                if (responseAdForn.IsSuccessStatusCode)
                {
                    var contentAdForn = await responseAdForn.Content.ReadAsStringAsync();

                    var adiantamentoForns = JsonConvert.DeserializeObject<List<AdiantamentoFornDTO>>(contentAdForn);

                    return adiantamentoForns;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<AdiantamentoClienteDTO>> GetAdCliente()
        {
            try
            {
                var responseAdCliente = await _httpClient.GetAsync($"api/ContaCorrente/Adiantamento/Cliente");

                if (responseAdCliente.IsSuccessStatusCode)
                {
                    var contentAdCliente = await responseAdCliente.Content.ReadAsStringAsync();
                    var adiantamentoClientes = JsonConvert.DeserializeObject<List<AdiantamentoClienteDTO>>(contentAdCliente);

                    return adiantamentoClientes;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<RegAdiantamentoFornDTO>> GetRegAdCliente()
        {
            try
            {
                var responseRegAdForn = await _httpClient.GetAsync($"api/ContaCorrente/Regular/Adiantamento/Fornecedor/WithRelations");

                if (responseRegAdForn.IsSuccessStatusCode)
                {
                    var contentRegAdForn = await responseRegAdForn.Content.ReadAsStringAsync();
                    var regAdiantamentoForns = JsonConvert.DeserializeObject<List<RegAdiantamentoFornDTO>>(contentRegAdForn);

                    return regAdiantamentoForns;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<RegAdiantamentoClienteDTO>> GetRegAdiantamantoCliente()
        {
            try
            {
                var responseRegAdCliente = await _httpClient.GetAsync($"api/ContaCorrente/Regular/Adiantamento/Cliente/WithRelations");

                if (responseRegAdCliente.IsSuccessStatusCode)
                {
                    var contentRegAdCliente = await responseRegAdCliente.Content.ReadAsStringAsync();
                    var regAdiantamentoClientes = JsonConvert.DeserializeObject<List<RegAdiantamentoClienteDTO>>(contentRegAdCliente);

                    return regAdiantamentoClientes;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<SerieDTO>> GetSerie()
        {
            try
            {
                var responseSerie = await _httpClient.GetAsync($"api/Serie");

                if (responseSerie.IsSuccessStatusCode)
                {
                    var contentSerie = await responseSerie.Content.ReadAsStringAsync();
                    var series = JsonConvert.DeserializeObject<List<SerieDTO>>(contentSerie);
                    
                    return series;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<ActividadeDTO>> GetActividade()
        {
            try
            {
                var responseAct = await _httpClient.GetAsync($"api/Actividade/WithRelations");

                if (responseAct.IsSuccessStatusCode)
                {
                    var contentAct = await responseAct.Content.ReadAsStringAsync();
                    var actividades = JsonConvert.DeserializeObject<List<ActividadeDTO>>(contentAct);

                    return actividades;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<BancoDTO>> GetBanco()
        {
            try
            {
                var responseBanco = await _httpClient.GetAsync($"api/Deposito/Bancos");

                if (responseBanco.IsSuccessStatusCode)
                {
                    var contentBanco = await responseBanco.Content.ReadAsStringAsync();
                    var bancos = JsonConvert.DeserializeObject<List<BancoDTO>>(contentBanco);

                    return bancos;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<CaixaDTO>> GetCaixa()
        {
            try
            {
                var responseCaixa = await _httpClient.GetAsync($"api/Deposito/Caixa");

                if (responseCaixa.IsSuccessStatusCode)
                {
                    var contentCaixa = await responseCaixa.Content.ReadAsStringAsync();
                    var caixas = JsonConvert.DeserializeObject<List<CaixaDTO>>(contentCaixa);

                    return caixas;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<FormaPagamentoDTO>> GetFormaPagamento()
        {
            try
            {
                var responseFormaPagamento = await _httpClient.GetAsync($"api/Deposito/FormaPagamento");

                if (responseFormaPagamento.IsSuccessStatusCode)
                {
                    var contentFormaPagamento = await responseFormaPagamento.Content.ReadAsStringAsync();
                    var formasPagamento = JsonConvert.DeserializeObject<List<FormaPagamentoDTO>>(contentFormaPagamento);

                    return formasPagamento;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<FuncionarioDTO>> GetFuncionarios()
        {
            try
            {
                var responseFuncionario = await _httpClient.GetAsync($"api/Funcionario/WithRelations");

                if (responseFuncionario.IsSuccessStatusCode)
                {
                    var contentFuncionario = await responseFuncionario.Content.ReadAsStringAsync();

                    var funcionarios = JsonConvert.DeserializeObject<List<FuncionarioDTO>>(contentFuncionario);

                    return funcionarios;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<FamiliaArtigoDTO>> GetFamilias()
        {
            try
            {
                var responseFamilia = await _httpClient.GetAsync($"api/Artigo/Familia");

                if (responseFamilia.IsSuccessStatusCode)
                {
                    var contentFamilia = await responseFamilia.Content.ReadAsStringAsync();

                    var familias = JsonConvert.DeserializeObject<List<FamiliaArtigoDTO>>(contentFamilia);
                    
                    return familias;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<SubFamiliaDTO>> GetSubFamilias()
        {
            try
            {
                var responseSubFamilia = await _httpClient.GetAsync($"api/Artigo/SubFamilia");

                if (responseSubFamilia.IsSuccessStatusCode)
                {
                    var contentSubFamilia = await responseSubFamilia.Content.ReadAsStringAsync();

                    var subFamilias = JsonConvert.DeserializeObject<List<SubFamiliaDTO>>(contentSubFamilia);

                    return subFamilias;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<MarcaDTO>> GetMarcas()
        {
            try
            {
                var responseMarca = await _httpClient.GetAsync($"api/Artigo/Marca");

                if (responseMarca.IsSuccessStatusCode)
                {
                    var contentMarca = await responseMarca.Content.ReadAsStringAsync();

                    var marcas = JsonConvert.DeserializeObject<List<MarcaDTO>>(contentMarca);

                    return marcas;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<ModeloDTO>> GetModelo()
        {
            try
            {
                var responseModelo = await _httpClient.GetAsync($"api/Artigo/Modelo");

                if (responseModelo.IsSuccessStatusCode)
                {
                    var contentModelo = await responseModelo.Content.ReadAsStringAsync();

                    var modelos = JsonConvert.DeserializeObject<List<ModeloDTO>>(contentModelo);

                    return modelos;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<EmpresaDTO> GetEmpresas()
        {
            try
            {
                var responseEmpresa = await _httpClient.GetAsync($"api/Empresa/{StaticProperty.empresaId}");

                if (responseEmpresa.IsSuccessStatusCode)
                {
                    var contentEmpresa = await responseEmpresa.Content.ReadAsStringAsync();

                    var empresa = JsonConvert.DeserializeObject<EmpresaDTO>(contentEmpresa);

                    return empresa;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<IvaDTO>> GetIvas()
        {
            try
            {
                var responseIva = await _httpClient.GetAsync($"api/iva");

                if (responseIva.IsSuccessStatusCode)
                {
                    var contentIva = await responseIva.Content.ReadAsStringAsync();

                    var ivas = JsonConvert.DeserializeObject<List<IvaDTO>>(contentIva);

                    return ivas;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<UnidadeDTO>> GetUnidades()
        {
            try
            {
                var responseUnidade = await _httpClient.GetAsync($"api/Unidade");

                if (responseUnidade.IsSuccessStatusCode)
                {
                    var contentUnidade = await responseUnidade.Content.ReadAsStringAsync();

                    var unidades = JsonConvert.DeserializeObject<List<UnidadeDTO>>(contentUnidade);

                    return unidades;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<PaisDTO>> GetPaises()
        {
            try
            {
                var responsePais = await _httpClient.GetAsync($"api/pais/WithRelations");

                if (responsePais.IsSuccessStatusCode)
                {
                    var contentPais = await responsePais.Content.ReadAsStringAsync();

                    var paises = JsonConvert.DeserializeObject<List<PaisDTO>>(contentPais);

                    return paises;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<ProvinciaDTO>> GetProvincias()
        {
            try
            {
                var responseProvincia = await _httpClient.GetAsync($"api/Provincia");

                if (responseProvincia.IsSuccessStatusCode)
                {
                    var contentProvincia = await responseProvincia.Content.ReadAsStringAsync();

                    var provincias = JsonConvert.DeserializeObject<List<ProvinciaDTO>>(contentProvincia);

                    return provincias;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}

