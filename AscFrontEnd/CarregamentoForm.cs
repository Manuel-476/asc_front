﻿using AscFrontEnd.DTOs;
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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AscFrontEnd
{
    public partial class CarregamentoForm : Form
    {
        public CarregamentoForm()
        {
            InitializeComponent();
        }

        private async void CarregamentoForm_Load(object sender, EventArgs e)
        {
            var client = new HttpClient();
            try
            {
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
                    var contentVfr = await responseVft.Content.ReadAsStringAsync();
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

                // Venda
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

                // Cliente
                var responseCliente = await client.GetAsync($"https://localhost:7200/api/Cliente/ClientesByRelations");

                if (responseCliente.IsSuccessStatusCode)
                {
                    var contentCliente = await responseCliente.Content.ReadAsStringAsync();
                    StaticProperty.clientes = JsonConvert.DeserializeObject<List<ClienteDTO>>(contentCliente);
                }

                // Fornecedor
                var responseFornecedor = await client.GetAsync($"https://localhost:7200/api/Fornecedor/FornecedoresByRelation");

                if (responseFornecedor.IsSuccessStatusCode)
                {
                    var contentFornecedor = await responseFornecedor.Content.ReadAsStringAsync();
                    StaticProperty.fornecedores = JsonConvert.DeserializeObject<List<FornecedorDTO>>(contentFornecedor);
                }

                // Artigo
                var responseArtigo = await client.GetAsync($"https://localhost:7200/api/Artigo");

                if (responseArtigo.IsSuccessStatusCode)
                {
                    var contentArtigo = await responseArtigo.Content.ReadAsStringAsync();
                    StaticProperty.artigos = JsonConvert.DeserializeObject<List<ArtigoDTO>>(contentArtigo);
                }

                // Amazem
                var responseArmazem = await client.GetAsync($"https://localhost:7200/api/Armazem/ArmazensByRelations");

                if (responseArmazem.IsSuccessStatusCode)
                {
                    var contentArmazem = await responseArmazem.Content.ReadAsStringAsync();
                    StaticProperty.armazens = JsonConvert.DeserializeObject<List<ArmazemDTO>>(contentArmazem);
                }

                // Nota Pagamento
                  var responseNp = await client.GetAsync($"https://localhost:7200/api/ContaCorrente/Nps");

                  if (responseNp.IsSuccessStatusCode)
                  {
                      var contentNp = await responseNp.Content.ReadAsStringAsync();
                      StaticProperty.nps = JsonConvert.DeserializeObject<List<NpDTO>>(contentNp);
                  }

                // Recibo
                var responseRe = await client.GetAsync($"https://localhost:7200/api/ContaCorrente/Res");

                if (responseRe.IsSuccessStatusCode)
                {
                    var contentRe = await responseRe.Content.ReadAsStringAsync();
                    StaticProperty.recibos = JsonConvert.DeserializeObject<List<ReciboDTO>>(contentRe);
                }


                // Conta Corrente
                var responseCCf = await client.GetAsync($"https://localhost:7200/api/ContaCorrente/divida/Fornecedor");

                if (responseCCf.IsSuccessStatusCode)
                {
                    var contentCCf = await responseCCf.Content.ReadAsStringAsync();
                    StaticProperty.contaCorrenteFornecedor = JsonConvert.DeserializeObject<object>(contentCCf);
                }

                var responseCCc = await client.GetAsync($"https://localhost:7200/api/ContaCorrente/divida/Cliente");

                if (responseCCc.IsSuccessStatusCode)
                {
                    var contentCCc = await responseCCc.Content.ReadAsStringAsync();
                    StaticProperty.contaCorrenteCliente = JsonConvert.DeserializeObject<object>(contentCCc);
                }

                // Serie
                var responseSerie = await client.GetAsync($"https://localhost:7200/api/Serie");

                if (responseSerie.IsSuccessStatusCode)
                {
                    var contentSerie = await responseSerie.Content.ReadAsStringAsync();
                    StaticProperty.series = JsonConvert.DeserializeObject<List<SerieDTO>>(contentSerie);
                }

                // Actividade
                var responseAct = await client.GetAsync($"https://localhost:7200/api/Actividade/WithRelations");

                if (responseAct.IsSuccessStatusCode)
                {
                    var contentAct = await responseAct.Content.ReadAsStringAsync();
                    StaticProperty.actividades = JsonConvert.DeserializeObject<List<ActividadeDTO>>(contentAct);
                }

                // Depositos
                var responseBanco = await client.GetAsync($"https://localhost:7200/api/Deposito/Banco");

                if (responseBanco.IsSuccessStatusCode)
                {
                    var contentBanco = await responseBanco.Content.ReadAsStringAsync();
                    StaticProperty.bancos = JsonConvert.DeserializeObject<List<BancoDTO>>(contentBanco);
                }

                var responseCaixa = await client.GetAsync($"https://localhost:7200/api/Deposito/Caixa");

                if (responseCaixa.IsSuccessStatusCode)
                {
                    var contentCaixa = await responseBanco.Content.ReadAsStringAsync();
                    StaticProperty.caixas = JsonConvert.DeserializeObject<List<CaixaDTO>>(contentCaixa);
                }

                // Funcionario
                var responseFuncionario = await client.GetAsync($"https://localhost:7200/api/Funcionario/WithRelations");

                if (responseFuncionario.IsSuccessStatusCode)
                {
                    var contentFuncionario = await responseFuncionario.Content.ReadAsStringAsync();

                    StaticProperty.funcionarios = JsonConvert.DeserializeObject<List<FuncionarioDTO>>(contentFuncionario);
                }

                // Familia
                var responseFamilia= await client.GetAsync($"https://localhost:7200/api/Artigo/Familia");

                if (responseFamilia.IsSuccessStatusCode)
                {
                    var contentFamilia = await responseFamilia.Content.ReadAsStringAsync();

                    StaticProperty.familias = JsonConvert.DeserializeObject<List<FamiliaArtigoDTO>>(contentFamilia);
                }

                // Sub-Familia
                var responseSubFamilia = await client.GetAsync($"https://localhost:7200/api/Artigo/SubFamilia");

                if (responseSubFamilia.IsSuccessStatusCode)
                {
                    var contentSubFamilia = await responseSubFamilia.Content.ReadAsStringAsync();

                    StaticProperty.subFamilias = JsonConvert.DeserializeObject<List<SubFamiliaDTO>>(contentSubFamilia);
                }

                // Marca
                var responseMarca = await client.GetAsync($"https://localhost:7200/api/Artigo/Marca");

                if (responseMarca.IsSuccessStatusCode)
                {
                    var contentMarca = await responseMarca.Content.ReadAsStringAsync();

                    StaticProperty.marcas = JsonConvert.DeserializeObject<List<MarcaDTO>>(contentMarca);
                }

                // Modelo
                var responseModelo = await client.GetAsync($"https://localhost:7200/api/Artigo/Modelo");

                if (responseModelo.IsSuccessStatusCode)
                {
                    var contentModelo = await responseModelo.Content.ReadAsStringAsync();

                    StaticProperty.modelos = JsonConvert.DeserializeObject<List<ModeloDTO>>(contentModelo);
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
                this.Hide();
                MenuPrincipal menuForm = new MenuPrincipal();
                menuForm.ShowDialog();
             
            }
        }
    }
}