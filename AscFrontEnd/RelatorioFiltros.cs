using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AscFrontEnd.Application;
using AscFrontEnd.DTOs.Compra;
using AscFrontEnd.DTOs.StaticsDto;
using AscFrontEnd.DTOs.Venda;
using ERP_Buyer.Application.DTOs.Documentos;
using Newtonsoft.Json;
using static AscFrontEnd.DTOs.Enums.Enums;
using static AscFrontEnd.Venda;

namespace AscFrontEnd
{
    public partial class RelatorioFiltros : Form
    {
        OpcaoBinaria _financeira;
        Consulta _consulta;

        private readonly HttpClient _httpClient;
        List<VendaDTO> _vendas;
        List<CompraDTO> _compras;

        List<string> _documentos;
        List<int> _entidadeIds;
        List<int> _artigoIds;
        List<int> _armazemIds;
        
        public RelatorioFiltros(OpcaoBinaria financeira, Consulta consulta)
        {
            InitializeComponent();

            _financeira = financeira;
            _consulta = consulta;

            _documentos = new List<string>();
            _entidadeIds = new List<int>();
            _artigoIds = new List<int>();
            _armazemIds = new List<int>();
            _compras = new List<CompraDTO>();
            _vendas = new List<VendaDTO>();

            _httpClient = new HttpClient();
            // Defina a URL base da sua API
            _httpClient.BaseAddress = new Uri("https://localhost:7200");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void RelatorioFiltros_Load(object sender, EventArgs e)
        {
            if (_financeira == OpcaoBinaria.Sim)
            {
                btnArmazem.Visible = false;
               // btnArtigo.Visible = false;
            }
            else 
            {
                btnEntidade.Visible = false;
                documentoCombo.Enabled = false;
            }


            if (_consulta == Consulta.venda)
            {
                documentoCombo.Items.Add("FR");
                documentoCombo.Items.Add("FT");
                documentoCombo.Items.Add("PP");
                documentoCombo.Items.Add("ECL");
                documentoCombo.Items.Add("NC");
                documentoCombo.Items.Add("GT");
                documentoCombo.Items.Add("GR");
            }
            else if (_consulta == Consulta.compra)
            {
                documentoCombo.Items.Add("VFR");
                documentoCombo.Items.Add("VFT");
                documentoCombo.Items.Add("PCO");
                documentoCombo.Items.Add("COT");
                documentoCombo.Items.Add("ECF");
                documentoCombo.Items.Add("VNC");
                documentoCombo.Items.Add("VGT");
                documentoCombo.Items.Add("VGR");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void btnEntidade_Click(object sender, EventArgs e)
        {
            if (_consulta == Consulta.venda)
            {
                var dialog = new ClienteListagem(true);
                dialog.ShowDialog();

                _entidadeIds = dialog.GetClienteIdList();

                foreach (var item in dialog.GetClienteIdList())
                {
                    entidadeList.Text += $"{StaticProperty.clientes.Where(x => x.id == item).First().nome_fantasia}\n";
                };
            }
            else 
            {
                var dialog = new FornecedorListagem(true);
                dialog.ShowDialog();

                _entidadeIds = dialog.GetFornecedorIdList();

                foreach (var item in dialog.GetFornecedorIdList())
                {
                    entidadeList.Text += $"{StaticProperty.fornecedores.Where(x => x.id == item).First().nome_fantasia}\n";
                };
            }
        }

        private void btnArmazem_Click(object sender, EventArgs e)
        {
           var dialog = new ArmazemListagem(true);
           dialog.ShowDialog();

            armazemList.Text = "";

            _armazemIds = dialog.GetArmazemIdList();

           foreach (var item in dialog.GetArmazemIdList())
           {
                armazemList.Text += $"{StaticProperty.armazens.Where(x => x.id == item).First().descricao}\n";
           }
        }

        private void btnArtigo_Click(object sender, EventArgs e)
        {
            var dialog = new ArtigoListagem(true);

            dialog.ShowDialog();

            _artigoIds = dialog.GetArtigoIdList();

            artigoList.Text = "";

            foreach (var item in dialog.GetArtigoIdList())
            {
                artigoList.Text += $"{StaticProperty.artigos.Where(x => x.id == item).First().descricao}\n";    
            }
        }

        private async void btnImprimir_Click(object sender, EventArgs e)
        {

                DateTime dateStart = dataInicioCombo.Value; // Pegue do DateTimePicker
                DateTime dateEnd = dataFinalCombo.Value; // Pegue do DateTimePicker

                // Construa a query string


            if (_consulta == Consulta.venda)
            {
                string queryString = $"?clienteId={string.Join("&clienteId=", _entidadeIds)}" +
                   $"&documento={string.Join("&documento=", _documentos)}" +
                   $"&artigoId={string.Join("&artigoId=", _artigoIds)}";

                // Monte a URL completa
                string url = $"api/Relatorio/Venda/{dateStart:yyyy-MM-dd}/{dateEnd:yyyy-MM-dd}{queryString}";

                // Faça a requisição GET
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                // Verifique se a requisição foi bem-sucedida
                if (response.IsSuccessStatusCode)
                {
                    // Leia o conteúdo da resposta
                    var resultado = await response.Content.ReadAsStringAsync();

                    _vendas = JsonConvert.DeserializeObject<List<VendaDTO>>(resultado);

                    printPreview.Document = printVenda;

                    if (printPreview.ShowDialog() == DialogResult.OK)
                    {
                        printVenda.Print();
                    }
                }
            }
            if (_consulta == Consulta.compra)
            {
                string queryString = $"?clienteId={string.Join("&fornecedorId=", _entidadeIds)}" +
                   $"&documento={string.Join("&documento=", _documentos)}" +
                   $"&artigoId={string.Join("&artigoId=", _artigoIds)}";

                // Monte a URL completa
                string url = $"api/Relatorio/Compra/{dateStart:yyyy-MM-dd}/{dateEnd:yyyy-MM-dd}{queryString}";

                // Faça a requisição GET
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                // Verifique se a requisição foi bem-sucedida
                if (response.IsSuccessStatusCode)
                {
                    // Leia o conteúdo da resposta
                    var resultado = await response.Content.ReadAsStringAsync();

                    _compras = JsonConvert.DeserializeObject<List<CompraDTO>>(resultado);

                    printPreview.Document = printCompra;

                    if (printPreview.ShowDialog() == DialogResult.OK)
                    {
                        printCompra.Print();
                    }

                }
            }
        }

        private void printVenda_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            try
            {
                float totalLiquido = 0f;
                float totalIva = 0f;
                float ivaValorTotal = 0f;
                float total = 0f;
                float incidencia = 0f;
                float taxa = 0f;
                float valorImposto = 0f;
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


                e.Graphics.DrawString($"{dataInicioCombo.Text.ToString()}  {dataFinalCombo.Text.ToString()}", fontNormalNegrito, cor, new PointF(50, 180), formatToLeft);
                e.Graphics.DrawLine(canetaFina, 50, 295, 250, 295);
                e.Graphics.DrawString("Contribuente", fontNormalNegrito, cor, new Rectangle(50, 300, 200, 310));
                e.Graphics.DrawString("Desc. Cli", fontNormalNegrito, cor, new Rectangle(200, 300, 350, 310));
                e.Graphics.DrawString("Data Emissão", fontNormalNegrito, cor, new Rectangle(350, 300, 500, 310));
                e.Graphics.DrawString("Data Vencimento", fontNormalNegrito, cor, new Rectangle(500, 300, 650, 310));
                e.Graphics.DrawLine(caneta, 50, 315, 750, 315);

                e.Graphics.DrawString($"{clienteResult.nif}", fontNormal, cor, new Rectangle(50, 330, 200, 340));
                e.Graphics.DrawString("0,00", fontNormal, cor, new Rectangle(200, 330, 350, 340));
                e.Graphics.DrawString($"{DateTime.Now.Date.ToString("dd-mm-yyyy")}", fontNormal, cor, new Rectangle(350, 330, 450, 340));

                if (documento.Text.Equals("FR"))
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
                foreach (VendaArtigo va in vendaArtigos)
                {
                    totalIva += va.iva;
                    total += va.preco * float.Parse(va.qtd.ToString());

                    e.Graphics.DrawString($"{va.codigo}", fontNormal, cor, new Rectangle(50, 410 + i, 200, 425 + i));
                    e.Graphics.DrawString($"{dados.Where(art => art.codigo == va.codigo).First().descricao}", fontNormal, cor, new Rectangle(200, 410 + i, 350, 425 + i));
                    e.Graphics.DrawString($"{va.qtd}", fontNormal, cor, new Rectangle(350, 410 + i, 450, 425 + i));
                    e.Graphics.DrawString($"{va.preco.ToString("F2")}", fontNormal, cor, new Rectangle(450, 410 + i, 550, 425 + i));
                    e.Graphics.DrawString($"{(dados.Where(art => art.codigo == va.codigo).First().regimeIva == OpcaoBinaria.Sim ? va.iva : 0).ToString("F2")} %", fontNormal, cor, new Rectangle(550, 410 + i, 650, 425 + i));
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
                e.Graphics.DrawString($"{CalculosVendaCompra.TotalDescontoVenda(vendaArtigos).ToString("F2")}", fontCabecalho, cor, new PointF(680, 595 + i), formatToLeft);

                e.Graphics.DrawLine(canetaFina, 550, 583 + i, 740, 583 + i);
                e.Graphics.DrawString(totalFinal, fontNormalNegrito, cor, new PointF(550, 600 + i), formatToLeft);
                e.Graphics.DrawString(total.ToString("F2"), fontNormalNegrito, cor, new PointF(680, 600 + i), formatToLeft);

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


                if (documento.Text.Equals("FP") || documento.Text.Equals("GR"))
                {
                    e.Graphics.DrawString($"Este documento não serve como factura ", fontCabecalho, new SolidBrush(Color.Red), new PointF(280, 720 + i), formatToCenter);
                }
                else if (documento.Text.Equals("FT") || documento.Text.Equals("FR"))
                {
                    e.Graphics.DrawString($"Os bens/serviços foram colocados á disposição do adquirente na data e local do documento", fontCabecalho, new SolidBrush(Color.Black), new PointF(280, 720 + i), formatToCenter);
                }
                else if (documento.Text.Equals("GT"))
                {
                    e.Graphics.DrawString("Entreguei", fontCabecalho, cor, new PointF(100, 720 + i), formatToLeft);
                    e.Graphics.DrawLine(caneta, 50, 780 + i, 200, 780 + i);

                    e.Graphics.DrawString("Recebi", fontCabecalho, cor, new PointF(660, 720 + i), formatToLeft);
                    e.Graphics.DrawLine(caneta, 600, 780 + i, 750, 780 + i);
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
}
