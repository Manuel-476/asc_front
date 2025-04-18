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
using AscFrontEnd.Application;
using AscFrontEnd.DTOs.Cliente;
using AscFrontEnd.DTOs.Compra;
using AscFrontEnd.DTOs.Deposito;
using AscFrontEnd.DTOs.Fornecedor;
using AscFrontEnd.DTOs.StaticsDto;
using AscFrontEnd.DTOs.Stock;
using AscFrontEnd.DTOs.Venda;
using Newtonsoft.Json;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd
{
    public partial class RelatorioBancoCaixaForm : Form
    {
        Consulta _consulta;
        List<string> _documentos;
        List<int> _entidadeIds;
        List<int> _bancoIds;
        List<int> _caixaIds;

        List<ParcelasFormaPagamentoDTO> _parcelas;

        ClienteListagem dialogEntidadeCl;
        FornecedorListagem dialogEntidadeForn;
        BancoListagemForm _bancoForm;
        CaixaListagemForm _caixaForm;

        private readonly HttpClient _httpClient;
        public RelatorioBancoCaixaForm()
        {
            InitializeComponent();

            _documentos = new List<string>();
            _entidadeIds = new List<int>();
            _bancoIds = new List<int>();
            _caixaIds = new List<int>();
            _parcelas = new List<ParcelasFormaPagamentoDTO>();


            dialogEntidadeCl = new ClienteListagem(true, null);
            dialogEntidadeForn = new FornecedorListagem(true, null);
            _bancoForm = new BancoListagemForm(true, null);
            _caixaForm = new CaixaListagemForm(true, null);

            _httpClient = new HttpClient();

            // Defina a URL base da sua API
            _httpClient.BaseAddress = new Uri("https://localhost:7200");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
        }

        private void RelatorioBancoCaixaForm_Load(object sender, EventArgs e)
        {
            timer1.Start();

            comboEntidade.Items.Add("Cliente");
            comboEntidade.Items.Add("Fornecedor");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_consulta == Consulta.venda)
            {
                _entidadeIds = dialogEntidadeCl.GetClienteIdList();

                entidadeList.Text = "";

                if (_entidadeIds != null && _entidadeIds.Any())
                {


                    foreach (var item in _entidadeIds)
                    {
                        entidadeList.Text += $"{StaticProperty.clientes.Where(x => x.id == item).First().nome_fantasia}\n";
                    };
                }
            }
            else
            {
                _entidadeIds = dialogEntidadeForn.GetFornecedorIdList();

                if (_entidadeIds != null && _entidadeIds.Any())
                {
                    entidadeList.Text = "";

                    foreach (var item in _entidadeIds)
                    {
                        entidadeList.Text += $"{StaticProperty.fornecedores.Where(x => x.id == item).First().nome_fantasia}\n";
                    };
                }
            }

            _bancoIds = _bancoForm.GetDepositoIdList();

            if (_bancoIds != null && _bancoIds.Any())
            {
                bancoList.Text = "";

                foreach (var item in _bancoIds)
                {
                    bancoList.Text += $"{StaticProperty.bancos.Where(x => x.id == item).First().codigo}\n";
                };
            }

            _caixaIds = _caixaForm.GetDepositoIdList();

            if (_caixaIds != null && _caixaIds.Any())
            {
                caixaList.Text = "";

                foreach (var item in _caixaIds)
                {
                    caixaList.Text += $"{StaticProperty.caixas.Where(x => x.id == item).First().codigo}\n";
                };
            }
        }

        private void btnEntidade_Click(object sender, EventArgs e)
        {
            if (_consulta == Consulta.venda)
            {
                dialogEntidadeCl = new ClienteListagem(true, _entidadeIds);

                dialogEntidadeCl.ShowDialog();

                _entidadeIds = dialogEntidadeCl.GetClienteIdList();

                foreach (var item in _entidadeIds)
                {
                    entidadeList.Text += $"{StaticProperty.clientes.Where(x => x.id == item).First().nome_fantasia}\n";
                };
            }
            else
            {
                dialogEntidadeForn = new FornecedorListagem(true, _entidadeIds);
                dialogEntidadeForn.ShowDialog();

                _entidadeIds = dialogEntidadeForn.GetFornecedorIdList();

                foreach (var item in _entidadeIds)
                {
                    entidadeList.Text += $"{StaticProperty.fornecedores.Where(x => x.id == item).First().nome_fantasia}\n";
                };
            }
        }

        private void RelatorioBancoCaixaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            timer1.Dispose();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void documentoCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var doc = documentoCombo.SelectedItem.ToString();

            if (!_documentos.Contains(doc))
            {
                _documentos.Add(doc);
            }
            else
            {
                _documentos.Remove(doc);
            }

            documentoList.Text = "";

            foreach (var item in _documentos)
            {
                documentoList.Text += $"{item}\n";
            }
        }

        private void comboEntidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboEntidade.SelectedItem.ToString() == "Cliente")
            {
                _consulta = Consulta.venda;
            }
            else if (comboEntidade.SelectedItem.ToString() == "Fornecedor")
            {
                _consulta = Consulta.compra;
            }

            documentoCombo.Items.Clear();

            if (_consulta == Consulta.venda)
            {
                documentoCombo.Items.Add("FR");
                documentoCombo.Items.Add("FT");
                documentoCombo.Items.Add("GR");
                documentoCombo.Items.Add("OR");

            }
            else if (_consulta == Consulta.compra)
            {
                documentoCombo.Items.Add("VFR");
                documentoCombo.Items.Add("VFT");
                documentoCombo.Items.Add("VGR");
            }
        }

        private void btnDeposito_Click(object sender, EventArgs e)
        {
            new BancoListagemForm(true, _bancoIds).ShowDialog();
        }

        private void btnArmazem_Click(object sender, EventArgs e)
        {
            new CaixaListagemForm(true, _caixaIds).ShowDialog();
        }

        private async void btnImprimir_Click(object sender, EventArgs e)
        {
            DateTime dateStart = dataInicioCombo.Value; // Pegue do DateTimePicker
            DateTime dateEnd = dataFinalCombo.Value;
            string queryString = string.Empty;
            string url = string.Empty;

            if (_consulta == Consulta.venda)
            {
                 queryString = $"?clienteId={string.Join("&clienteId=", _entidadeIds)}" +
                   $"&documento={string.Join("&documento=", _documentos)}" +
                   $"&bancoId={string.Join("&bancoId=", _bancoIds)}" +
                   $"&caixaId={string.Join("&caixaId=", _caixaIds)}";

                // Monte a URL completa
                url = $"api/Relatorio/Bancos/Caixas/Venda/{dateStart:yyyy-MM-dd}/{dateEnd:yyyy-MM-dd}/{StaticProperty.empresaId}{queryString}";

                // Faça a requisição GET
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                // Verifique se a requisição foi bem-sucedida
                if (response.IsSuccessStatusCode)
                {
                    // Leia o conteúdo da resposta
                    var resultado = await response.Content.ReadAsStringAsync();

                    _parcelas = JsonConvert.DeserializeObject<List<ParcelasFormaPagamentoDTO>>(resultado);

                    printPreview.Document = printBancoCaixa;

                    if (printPreview.ShowDialog() == DialogResult.OK)
                    {
                        printBancoCaixa.Print();
                    }
                }
            }
            else if (_consulta == Consulta.compra)
            {


                 queryString = $"?fornecedorId={string.Join("&fornecedorId=", _entidadeIds)}" +
                   $"&documento={string.Join("&documento=", _documentos)}" +
                   $"&bancoId={string.Join("&bancoId=", _bancoIds)}" +
                   $"&caixaId={string.Join("&caixaId=", _caixaIds)}";

                // Monte a URL completa
                url = $"api/Relatorio/Bancos/Caixas/Compra/{dateStart:yyyy-MM-dd}/{dateEnd:yyyy-MM-dd}/{StaticProperty.empresaId}{queryString}";

                // Faça a requisição GET
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                // Verifique se a requisição foi bem-sucedida
                if (response.IsSuccessStatusCode)
                {
                    // Leia o conteúdo da resposta
                    var resultado = await response.Content.ReadAsStringAsync();

                    _parcelas = JsonConvert.DeserializeObject<List<ParcelasFormaPagamentoDTO>>(resultado);

                    printPreview.Document = printBancoCaixaCompra;

                    if (printPreview.ShowDialog() == DialogResult.OK)
                    {
                        printBancoCaixaCompra.Print();
                    }
                }
            }
        }

        private void printBancoCaixa_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                List<ParcelasFormaPagamentoDTO> result = new List<ParcelasFormaPagamentoDTO>();

                foreach (var item in _parcelas)
                {
                    result.Add(item);
                }

                var deposito = CalcularTotaisPorBancoECaixa(result);


                float total = 0f;

                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string projectPath = Path.GetFullPath(Path.Combine(basePath, @"..\.."));
                string imagePathEmpresa = Path.Combine(projectPath, "Files", "Smart_Entity.png");
                string imagePathAsc = Path.Combine(projectPath, "Files", "asc.png");
                string docFinanceiro = string.Empty;

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

                Pen caneta = new Pen(Color.Black, 2); // Define a cor e a largura da linha
                Pen canetaFina = new Pen(Color.Black, 1);


                // Verificar se e.Graphics é válido
                if (e.Graphics == null)
                {
                    throw new Exception("O objeto e.Graphics é nulo.");
                }

                e.Graphics.DrawImage(Image.FromFile(imagePathEmpresa), new Rectangle(40, 50, 100, 100));
                // Desenhar a string
                e.Graphics.DrawString(empresaNome, fontCabecalhoNegrito, cor, new PointF(50, 135), formatToLeft);
                e.Graphics.DrawString(empresaCabecalho, fontCabecalho, cor, ponto, formatToLeft);

                e.Graphics.DrawString($"Relatorio de Deposito Financeiro em Venda \n\nDe {dataInicioCombo.Text.ToString()} á {dataFinalCombo.Text.ToString()}", fontNormalNegrito, cor, new PointF(50, 200), formatToLeft);

                e.Graphics.DrawString($"Documento", fontNormalNegrito, cor, new Rectangle(50, 280, 150, 300));
                e.Graphics.DrawString("Cliente", fontNormalNegrito, cor, new Rectangle(150, 280, 250, 300));
                e.Graphics.DrawString($"Doc. Financeiro", fontNormalNegrito, cor, new Rectangle(250, 280, 400, 300));
                e.Graphics.DrawString($"Banco", fontNormalNegrito, cor, new Rectangle(400, 280, 500, 300));
                e.Graphics.DrawString($"Caixa", fontNormalNegrito, cor, new Rectangle(500, 280, 600, 300));
                e.Graphics.DrawString($"Valor", fontNormalNegrito, cor, new Rectangle(600, 280, 700, 300));
                e.Graphics.DrawString($"Data", fontNormalNegrito, cor, new Rectangle(700, 280, 780, 300));
                e.Graphics.DrawLine(caneta, 50, 295, 750, 295);
                int i = 15;
                foreach (var p in _parcelas)
                {
                    
                    var cliente = string.Empty;

                    var venda = StaticProperty.venda.Where(x => $"{x.documento} {x.serie}/{x.numeroDocumento}".ToUpper().Equals(p.documento.ToUpper())).Any() ?
                                StaticProperty.venda.Where(x => $"{x.documento} {x.serie}/{x.numeroDocumento}".ToUpper().Equals(p.documento)).First() : new VendaDTO();

                    cliente = StaticProperty.clientes.Where(x => x.id == venda.clienteId).Any() ? StaticProperty.clientes.Where(x => x.id == venda.clienteId).First().nome_fantasia : string.Empty;

                    var bancoCodigo = StaticProperty.bancos.Where(x => x.id == p.bancoId).Any() ? StaticProperty.bancos.Where(x => x.id == p.bancoId).First().codigo : "-";
                    var caixaCodigo = StaticProperty.caixas.Where(x => x.id == p.caixaId).Any() ? StaticProperty.caixas.Where(x => x.id == p.caixaId).First().codigo : "-";

                    //Nao mostrar os dados dos documentos de compra
                    if(p.documento.Contains("VFR ") || p.documento.Contains("VFT ") || p.documento.Contains("VGR ") || venda.state == DocState.anulado || venda.state == DocState.estornado)
                    {
                        //Fazer desaparecer os dados de deposito que nao seram usado no calculo final
                        result.Remove(p);

                        deposito = CalcularTotaisPorBancoECaixa(result);

                        continue;

                    }

                        total += p.valor;

                    if (venda.documento == "FT")
                    {
                        if (StaticProperty.fts.Where(x => x.documento == $"{venda.documento} {venda.serie}/{venda.numeroDocumento}").Any())
                        {
                            docFinanceiro = StaticProperty.fts.Where(x => x.documento == $"{venda.documento} {venda.serie}/{venda.numeroDocumento}").Any() ?
                                            StaticProperty.recibos.Where(x => x.ftId == StaticProperty.fts.Where(f => f.documento == $"{venda.documento} {venda.serie}/{venda.numeroDocumento}").First().id).Any() ?
                                            StaticProperty.recibos.Where(x => x.ftId == StaticProperty.fts.Where(f => f.documento == $"{venda.documento} {venda.serie}/{venda.numeroDocumento}").First().id).First().documento : "-" : "-";

                            e.Graphics.DrawString($"{p.documento}", fontNormal, cor, new Rectangle(50, 290 + i, 150, 305 + i));
                            e.Graphics.DrawString($"{cliente}", fontNormal, cor, new Rectangle(150, 290 + i, 250, 305 + i));
                            e.Graphics.DrawString($"{docFinanceiro}", fontNormal, cor, new Rectangle(250, 290 + i, 400, 305 + i));
                            e.Graphics.DrawString($"{bancoCodigo}", fontNormal, cor, new Rectangle(400, 290 + i, 500, 305 + i));
                            e.Graphics.DrawString($"{caixaCodigo}", fontNormal, cor, new Rectangle(500, 290 + i, 600, 305 + i));
                            e.Graphics.DrawString($"{p.valor:F2}", fontNormal, cor, new Rectangle(600, 290 + i, 700, 305 + i));
                            e.Graphics.DrawString($"{p.data:dd-MM-yyyy}", fontNormal, cor, new Rectangle(700, 290 + i, 780, 425 + i));
                        }
                    }
                    else
                    {
                        e.Graphics.DrawString($"{p.documento}", fontNormal, cor, new Rectangle(50, 290 + i, 150, 305 + i));
                        e.Graphics.DrawString($"{cliente}", fontNormal, cor, new Rectangle(150, 290 + i, 250, 305 + i));
                        e.Graphics.DrawString($"{docFinanceiro}", fontNormal, cor, new Rectangle(250, 290 + i, 400, 305 + i));
                        e.Graphics.DrawString($"{bancoCodigo}", fontNormal, cor, new Rectangle(400, 290 + i, 500, 305 + i));
                        e.Graphics.DrawString($"{caixaCodigo}", fontNormal, cor, new Rectangle(500, 290 + i, 600, 305 + i));
                        e.Graphics.DrawString($"{p.valor:F2}", fontNormal, cor, new Rectangle(600, 290 + i, 700, 305 + i));
                        e.Graphics.DrawString($"{p.data:dd-MM-yyyy}", fontNormal, cor, new Rectangle(700, 290 + i, 780, 425 + i));
                    }

                    i = i + 15;
                }





                string totalFinal = $"TOTAL";



                var ini = i;
                foreach (var dep in deposito)
                {
                    if (!string.IsNullOrEmpty(dep.Tipo))
                    {
                        e.Graphics.DrawString(dep.Tipo, fontCabecalho, cor, new PointF(550, 555 + i), formatToLeft);
                        e.Graphics.DrawString(dep.ValorTotal.ToString("F2"), fontCabecalho, cor, new PointF(680, 555 + i), formatToLeft);

                        i = i + 15;
                    }
                }

                e.Graphics.DrawRectangle(caneta, new Rectangle(540, 530 + ini, 210, 90 + i));

                e.Graphics.DrawLine(canetaFina, 550, 583 + i, 740, 583 + i);
                e.Graphics.DrawString(totalFinal, fontNormalNegrito, cor, new PointF(550, 600 + i), formatToLeft);
                e.Graphics.DrawString(total.ToString("F2"), fontNormalNegrito, cor, new PointF(680, 600 + i), formatToLeft);

                // Desenhando a imagem no documento
                e.Graphics.DrawImage(Image.FromFile(imagePathAsc), new Rectangle(10, 900, 200, 90));


                Console.WriteLine("Texto desenhado com sucesso.");

                // Liberar recursos
                fontNormal.Dispose();
                cor.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Ocorreu um Erro", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
        }


        private void printBancoCaixaCompra_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
 
                float total = 0f;


                List<ParcelasFormaPagamentoDTO> result = new List<ParcelasFormaPagamentoDTO>();

                foreach (var item in _parcelas)
                {
                    result.Add(item);
                }

                var deposito = CalcularTotaisPorBancoECaixa(result);
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string projectPath = Path.GetFullPath(Path.Combine(basePath, @"..\.."));
                string imagePathEmpresa = Path.Combine(projectPath, "Files", "Smart_Entity.png");
                string imagePathAsc = Path.Combine(projectPath, "Files", "asc.png");
                string docFinanceiro = string.Empty;

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

                Pen caneta = new Pen(Color.Black, 2); // Define a cor e a largura da linha
                Pen canetaFina = new Pen(Color.Black, 1);


                // Verificar se e.Graphics é válido
                if (e.Graphics == null)
                {
                    throw new Exception("O objeto e.Graphics é nulo.");
                }

                e.Graphics.DrawImage(Image.FromFile(imagePathEmpresa), new Rectangle(40, 50, 100, 100));
                // Desenhar a string
                e.Graphics.DrawString(empresaNome, fontCabecalhoNegrito, cor, new PointF(50, 135), formatToLeft);
                e.Graphics.DrawString(empresaCabecalho, fontCabecalho, cor, ponto, formatToLeft);

                e.Graphics.DrawString($"Relatorio de Deposito Financeiro em Compra \n\nDe {dataInicioCombo.Text.ToString()} á {dataFinalCombo.Text.ToString()}", fontNormalNegrito, cor, new PointF(50, 200), formatToLeft);

                e.Graphics.DrawString($"Documento", fontNormalNegrito, cor, new Rectangle(50, 280, 150, 300));
                e.Graphics.DrawString("Cliente", fontNormalNegrito, cor, new Rectangle(150, 280, 250, 300));
                e.Graphics.DrawString($"Doc. Financeiro", fontNormalNegrito, cor, new Rectangle(250, 280, 400, 300));
                e.Graphics.DrawString($"Banco", fontNormalNegrito, cor, new Rectangle(400, 280, 500, 300));
                e.Graphics.DrawString($"Caixa", fontNormalNegrito, cor, new Rectangle(500, 280, 600, 300));
                e.Graphics.DrawString($"Valor", fontNormalNegrito, cor, new Rectangle(600, 280, 700, 300));
                e.Graphics.DrawString($"Data", fontNormalNegrito, cor, new Rectangle(700, 280, 780, 300));
                e.Graphics.DrawLine(caneta, 50, 295, 750, 295);
                int i = 15;
                foreach (var p in _parcelas)
                {
                    
                    var cliente = string.Empty;

                    var compra = StaticProperty.compra.Where(x => $"{x.documento} {x.serie}/{x.numeroDocumento}".ToUpper().Equals(p.documento.ToUpper())).Any() ?
                                StaticProperty.compra.Where(x => $"{x.documento} {x.serie}/{x.numeroDocumento}".ToUpper().Equals(p.documento)).First() : new CompraDTO();

                    cliente = StaticProperty.fornecedores.Where(x => x.id == compra.fornecedorId).Any() ? StaticProperty.fornecedores.Where(x => x.id == compra.fornecedorId).First().nome_fantasia : string.Empty;

                    // Nao mostrar os documntos de venda 
                    if ((!p.documento.Contains("VFR ") && !p.documento.Contains("VFT ") && !p.documento.Contains("VGR ")) || compra.state == DocState.anulado || compra.state == DocState.estornado)
                    { 
                        //Fazer desaparecer os dados de deposito que nao seram usado no calculo final
                       result.Remove(p);

                        deposito = CalcularTotaisPorBancoECaixa(result);

                        continue;
                    }

                    total += p.valor;

                    var bancoCodigo = StaticProperty.bancos.Where(x => x.id == p.bancoId).Any() ? StaticProperty.bancos.Where(x => x.id == p.bancoId).First().codigo : "-";
                    var caixaCodigo = StaticProperty.caixas.Where(x => x.id == p.caixaId).Any() ? StaticProperty.caixas.Where(x => x.id == p.caixaId).First().codigo : "-";

                    if (compra.documento == "VFT")
                    {
                        if (StaticProperty.vfts.Where(x => x.documento == $"{compra.documento} {compra.serie}/{compra.numeroDocumento}").Any())
                        {
                            docFinanceiro = StaticProperty.vfts.Where(x => x.documento == $"{compra.documento} {compra.serie}/{compra.numeroDocumento}").Any() ?
                                            StaticProperty.nps.Where(x => x.vftId == StaticProperty.vfts.Where(f => f.documento == $"{compra.documento} {compra.serie}/{compra.numeroDocumento}").First().id).Any() ?
                                            StaticProperty.nps.Where(x => x.vftId == StaticProperty.vfts.Where(f => f.documento == $"{compra.documento} {compra.serie}/{compra.numeroDocumento}").First().id).First().documento : "-" : "-";

                            e.Graphics.DrawString($"{p.documento}", fontNormal, cor, new Rectangle(50, 290 + i, 150, 305 + i));
                            e.Graphics.DrawString($"{cliente}", fontNormal, cor, new Rectangle(150, 290 + i, 250, 305 + i));
                            e.Graphics.DrawString($"{docFinanceiro}", fontNormal, cor, new Rectangle(250, 290 + i, 400, 305 + i));
                            e.Graphics.DrawString($"{bancoCodigo}", fontNormal, cor, new Rectangle(400, 290 + i, 500, 305 + i));
                            e.Graphics.DrawString($"{caixaCodigo}", fontNormal, cor, new Rectangle(500, 290 + i, 600, 305 + i));
                            e.Graphics.DrawString($"{p.valor:F2}", fontNormal, cor, new Rectangle(600, 290 + i, 700, 305 + i));
                            e.Graphics.DrawString($"{p.data:dd-MM-yyyy}", fontNormal, cor, new Rectangle(700, 290 + i, 780, 425 + i));
                        }
                    }
                    else
                    {
                        e.Graphics.DrawString($"{p.documento}", fontNormal, cor, new Rectangle(50, 290 + i, 150, 305 + i));
                        e.Graphics.DrawString($"{cliente}", fontNormal, cor, new Rectangle(150, 290 + i, 250, 305 + i));
                        e.Graphics.DrawString($"{docFinanceiro}", fontNormal, cor, new Rectangle(250, 290 + i, 400, 305 + i));
                        e.Graphics.DrawString($"{bancoCodigo}", fontNormal, cor, new Rectangle(400, 290 + i, 500, 305 + i));
                        e.Graphics.DrawString($"{caixaCodigo}", fontNormal, cor, new Rectangle(500, 290 + i, 600, 305 + i));
                        e.Graphics.DrawString($"{p.valor:F2}", fontNormal, cor, new Rectangle(600, 290 + i, 700, 305 + i));
                        e.Graphics.DrawString($"{p.data:dd-MM-yyyy}", fontNormal, cor, new Rectangle(700, 290 + i, 780, 425 + i));
                    }

                    i = i + 15;
                }

                string totalFinal = $"TOTAL";

                var ini = i;
                foreach (var dep in deposito)
                {
                    if (!string.IsNullOrEmpty(dep.Tipo))
                    {
                        e.Graphics.DrawString(dep.Tipo, fontCabecalho, cor, new PointF(550, 555 + i), formatToLeft);
                        e.Graphics.DrawString(dep.ValorTotal.ToString("F2"), fontCabecalho, cor, new PointF(680, 555 + i), formatToLeft);

                        i = i + 15;
                    }
                }

                e.Graphics.DrawRectangle(caneta, new Rectangle(540, 530 + ini, 210, 90 + i));

                e.Graphics.DrawLine(canetaFina, 550, 583 + i, 740, 583 + i);
                e.Graphics.DrawString(totalFinal, fontNormalNegrito, cor, new PointF(550, 600 + i), formatToLeft);
                e.Graphics.DrawString(total.ToString("F2"), fontNormalNegrito, cor, new PointF(680, 600 + i), formatToLeft);

                // Desenhando a imagem no documento
                e.Graphics.DrawImage(Image.FromFile(imagePathAsc), new Rectangle(10, 900, 200, 90));


                Console.WriteLine("Texto desenhado com sucesso.");

                // Liberar recursos
                fontNormal.Dispose();
                cor.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Ocorreu um Erro", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
        }


        public class TotalPorBancoECaixa
        {
            public string Tipo { get; set; } // "Banco" ou "Caixa"
            public int? Id { get; set; } // bancoId ou caixaId
            public float ValorTotal { get; set; }
        }

        public static List<TotalPorBancoECaixa> CalcularTotaisPorBancoECaixa(List<ParcelasFormaPagamentoDTO> parcelas)
        {
            // Agrupar por bancoId
            var totaisPorBanco = parcelas
                .Where(p => p.bancoId.HasValue)
                .GroupBy(p => p.bancoId)
                .Select(g => new TotalPorBancoECaixa
                {
                    Tipo = StaticProperty.bancos.Where(x => x.id == g.First().bancoId).Any() ? StaticProperty.bancos.Where(x => x.id == g.First().bancoId).First().codigo : "",
                    Id = g.Key,
                    ValorTotal = g.Sum(p => p.valor)
                });

            // Agrupar por caixaId
            var totaisPorCaixa = parcelas
                .Where(p => p.caixaId.HasValue)
                .GroupBy(p => p.caixaId)
                .Select(g => new TotalPorBancoECaixa
                {
                    Tipo = StaticProperty.caixas.Where(x => x.id == g.First().caixaId).Any() ? StaticProperty.caixas.Where(x => x.id == g.First().caixaId).First().codigo : "",
                    Id = g.Key,
                    ValorTotal = g.Sum(p => p.valor)
                });

            // Combinar os resultados
            return totaisPorBanco
                .Union(totaisPorCaixa)
                .OrderBy(t => t.Tipo)
                .ThenBy(t => t.Id)
                .ToList();
        }
    }
 }

