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
using AscFrontEnd.DTOs.Cliente;
using AscFrontEnd.DTOs.Compra;
using AscFrontEnd.DTOs.Fornecedor;
using AscFrontEnd.DTOs.StaticsDto;
using AscFrontEnd.DTOs.Stock;
using AscFrontEnd.DTOs.Venda;
using ERP_Buyer.Application.DTOs.Documentos;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
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
        List<ArmazemHistoricoDTO> _historicoStock;
        List<ClienteDTO> _clientes;
        List<FornecedorDTO> _fornecedores;
        List<ArtigoDTO> _dados;

        List<string> _documentos;
        List<int> _entidadeIds;
        List<int> _artigoIds;
        List<int> _armazemIds;

        ArtigoListagem dialogArtigo;
        ArmazemListagem dialogArmazem;
        ClienteListagem dialogEntidadeCl;
        FornecedorListagem dialogEntidadeForn;

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
            _dados = new List<ArtigoDTO>();
            _clientes = new List<ClienteDTO>();
            _fornecedores = new List<FornecedorDTO>();
            _historicoStock = new List<ArmazemHistoricoDTO>();

            dialogArtigo = new ArtigoListagem(true, null);
            dialogArmazem = new ArmazemListagem(true, null);
            dialogEntidadeCl = new ClienteListagem(true, null);
            dialogEntidadeForn = new FornecedorListagem(true, null);

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

        private async void RelatorioFiltros_Load(object sender, EventArgs e)
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

            _dados = await new Requisicoes().GetArtigos();
            timerRelatorio.Start();
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

        private void btnArmazem_Click(object sender, EventArgs e)
        {
            dialogArmazem = new ArmazemListagem(true, _armazemIds);
            dialogArmazem.ShowDialog();

            armazemList.Text = "";

            _armazemIds = dialogArmazem.GetArmazemIdList();

            foreach (var item in _armazemIds)
            {
                armazemList.Text += $"{StaticProperty.armazens.Where(x => x.id == item).First().descricao}\n";
            }
        }

        private void btnArtigo_Click(object sender, EventArgs e)
        {
            dialogArtigo = new ArtigoListagem(true, _artigoIds);

            dialogArtigo.ShowDialog();

            _artigoIds = dialogArtigo.GetArtigoIdList();

            artigoList.Text = "";

            foreach (var item in _artigoIds)
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
                string url = $"api/Relatorio/Venda/{dateStart:yyyy-MM-dd}/{dateEnd:yyyy-MM-dd}/{StaticProperty.empresaId}{queryString}";

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
                string queryString = $"?fornecedorId={string.Join("&fornecedorId=", _entidadeIds)}" +
                   $"&documento={string.Join("&documento=", _documentos)}" +
                   $"&artigoId={string.Join("&artigoId=", _artigoIds)}";

                // Monte a URL completa
                string url = $"api/Relatorio/Compra/{dateStart:yyyy-MM-dd}/{dateEnd:yyyy-MM-dd}/{StaticProperty.empresaId}{queryString}";

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
            if (_consulta == Consulta.stock)
            {
                string queryString = $"?armazemId={string.Join("&armazemId=", _armazemIds)}" +
                  $"&artigoId={string.Join("&artigoId=", _artigoIds)}";

                // Monte a URL completa
                string url = $"api/Relatorio/Armazem/{dateStart:yyyy-MM-dd}/{dateEnd:yyyy-MM-dd}/{StaticProperty.empresaId}{queryString}";

                // Faça a requisição GET
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                // Verifique se a requisição foi bem-sucedida
                if (response.IsSuccessStatusCode)
                {
                    // Leia o conteúdo da resposta
                    var resultado = await response.Content.ReadAsStringAsync();

                    _historicoStock = JsonConvert.DeserializeObject<List<ArmazemHistoricoDTO>>(resultado);

                    printPreview.Document = printArmazem;

                    if (printPreview.ShowDialog() == DialogResult.OK)
                    {
                        printArmazem.Print();
                    }

                }
            }
        }

        private void printVenda_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            try
            {
                float desconto = 0f;
                float totalLiquido = 0f;
                float totalIva = 0f;
                float total = 0f;
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


                // Verificar se e.Graphics é válido
                if (e.Graphics == null)
                {
                    throw new Exception("O objeto e.Graphics é nulo.");
                }

                e.Graphics.DrawImage(Image.FromFile(imagePathEmpresa), new Rectangle(40, 50, 100, 100));
                // Desenhar a string
                e.Graphics.DrawString(empresaNome, fontCabecalhoNegrito, cor, new PointF(50, 135), formatToLeft);
                e.Graphics.DrawString(empresaCabecalho, fontCabecalho, cor, ponto, formatToLeft);

                e.Graphics.DrawString($"De {dataInicioCombo.Text.ToString()} á {dataFinalCombo.Text.ToString()}", fontNormalNegrito, cor, new PointF(50, 200), formatToLeft);

                e.Graphics.DrawString($"Artigo", fontNormalNegrito, cor, new Rectangle(50, 280, 110, 300));
                e.Graphics.DrawString("Descricao", fontNormalNegrito, cor, new Rectangle(110, 280, 200, 300));
                e.Graphics.DrawString($"Qtd", fontNormalNegrito, cor, new Rectangle(200, 280, 240, 300));
                e.Graphics.DrawString($"Preco Uni.", fontNormalNegrito, cor, new Rectangle(240, 280, 310, 300));
                e.Graphics.DrawString($"Entidade", fontNormalNegrito, cor, new Rectangle(310, 280, 370, 300));
                e.Graphics.DrawString($"Documento", fontNormalNegrito, cor, new Rectangle(370, 280, 450, 300));
                e.Graphics.DrawString($"Valor Bruto", fontNormalNegrito, cor, new Rectangle(450, 280, 510, 300));
                e.Graphics.DrawString($"Valor Liq.", fontNormalNegrito, cor, new Rectangle(520, 280, 580, 300));
                e.Graphics.DrawString($"Desconto", fontNormalNegrito, cor, new Rectangle(590, 280, 650, 300));
                e.Graphics.DrawString($"Iva", fontNormalNegrito, cor, new Rectangle(655, 280, 700, 300));
                e.Graphics.DrawString($"Data", fontNormalNegrito, cor, new Rectangle(700, 280, 750, 300));
                e.Graphics.DrawLine(caneta, 50, 295, 750, 295);
                int i = 15;
                foreach (var venda in _vendas)
                {
                    foreach (var va in venda.artigoVendas)
                    {
                        totalIva += (va.preco * float.Parse(va.qtd.ToString()) * (va.iva / 100));
                        total += va.preco * float.Parse(va.qtd.ToString());
                        desconto += (va.preco * float.Parse(va.qtd.ToString()) * (va.desconto / 100));
                        var valorIva = (va.preco * float.Parse(va.qtd.ToString()) * (va.iva / 100));
                        var descontoLinha = (va.preco * float.Parse(va.qtd.ToString()) * (va.desconto / 100));

                        if (_artigoIds.Any())
                        {
                            if (_artigoIds.Contains(va.artigoId))
                            {
                                e.Graphics.DrawString($"{_dados.Where(art => art.id == va.artigoId).First().codigo}", fontNormal, cor, new Rectangle(50, 290 + i, 110, 305 + i));
                                e.Graphics.DrawString($"{_dados.Where(art => art.id == va.artigoId).First().descricao}", fontNormal, cor, new Rectangle(110, 290 + i, 200, 305 + i));
                                e.Graphics.DrawString($"{va.qtd}", fontNormal, cor, new Rectangle(200, 290 + i, 250, 305 + i));
                                e.Graphics.DrawString($"{va.preco.ToString("F2")}", fontNormal, cor, new Rectangle(250, 290 + i, 310, 305 + i));
                                e.Graphics.DrawString($"{StaticProperty.clientes.Where(cl => cl.id == venda.clienteId).First().nome_fantasia}", fontNormal, cor, new Rectangle(310, 290 + i, 370, 305 + i));
                                e.Graphics.DrawString($"{venda.documento} {venda.serie}/{venda.numeroDocumento}", fontNormal, cor, new Rectangle(370, 290 + i, 450, 305 + i));
                                e.Graphics.DrawString($"{(va.preco * va.qtd).ToString("F2")}", fontNormal, cor, new Rectangle(450, 290 + i, 510, 425 + i));
                                e.Graphics.DrawString($"{((va.preco * va.qtd) - descontoLinha).ToString("F2")}", fontNormal, cor, new Rectangle(520, 290 + i, 580, 305 + i));
                                e.Graphics.DrawString($"{va.desconto.ToString("F2")}", fontNormal, cor, new Rectangle(590, 290 + i, 650, 425 + i));
                                e.Graphics.DrawString($"{valorIva.ToString("F2")} %", fontNormal, cor, new Rectangle(655, 290 + i, 700, 305 + i));
                                e.Graphics.DrawString($"{(venda.data.ToString("dd-MM-yyyy"))}", fontNormal, cor, new Rectangle(700, 290 + i, 750, 305 + i));
                            }
                        }
                        else
                        {
                            e.Graphics.DrawString($"{_dados.Where(art => art.id == va.artigoId).First().codigo}", fontNormal, cor, new Rectangle(50, 290 + i, 110, 305 + i));
                            e.Graphics.DrawString($"{_dados.Where(art => art.id == va.artigoId).First().descricao}", fontNormal, cor, new Rectangle(110, 290 + i, 200, 305 + i));
                            e.Graphics.DrawString($"{va.qtd}", fontNormal, cor, new Rectangle(200, 290 + i, 250, 305 + i));
                            e.Graphics.DrawString($"{va.preco.ToString("F2")}", fontNormal, cor, new Rectangle(250, 290 + i, 310, 305 + i));
                            e.Graphics.DrawString($"{StaticProperty.clientes.Where(cl => cl.id == venda.clienteId).First().nome_fantasia}", fontNormal, cor, new Rectangle(310, 290 + i, 370, 305 + i));
                            e.Graphics.DrawString($"{venda.documento} {venda.serie}/{venda.numeroDocumento}", fontNormal, cor, new Rectangle(370, 290 + i, 450, 305 + i));
                            e.Graphics.DrawString($"{(va.preco * va.qtd).ToString("F2")}", fontNormal, cor, new Rectangle(450, 290 + i, 510, 425 + i));
                            e.Graphics.DrawString($"{((va.preco * va.qtd) - descontoLinha).ToString("F2")}", fontNormal, cor, new Rectangle(520, 290 + i, 580, 305 + i));
                            e.Graphics.DrawString($"{va.desconto.ToString("F2")}", fontNormal, cor, new Rectangle(590, 290 + i, 650, 425 + i));
                            e.Graphics.DrawString($"{valorIva.ToString("F2")} %", fontNormal, cor, new Rectangle(655, 290 + i, 700, 305 + i));
                            e.Graphics.DrawString($"{(venda.data.ToString("dd-MM-yyyy"))}", fontNormal, cor, new Rectangle(700, 290 + i, 750, 305 + i));

                        }

                        i = i + 15;
                    }
                }

                totalLiquido += total - desconto;

                string mercadoria = $"Total liquido:";
                string iva = $"{totalIva.ToString("F2")}";
                string totalIvaValor = $"Total Iva:";
                string totalFinal = $"TOTAL";


                e.Graphics.DrawRectangle(caneta, new Rectangle(540, 530 + i, 210, 90));

                e.Graphics.DrawString(mercadoria, fontCabecalho, cor, new PointF(550, 545 + i), formatToLeft);
                e.Graphics.DrawString(totalLiquido.ToString("F2"), fontCabecalho, cor, new PointF(680, 545 + i), formatToLeft);
                e.Graphics.DrawString(iva, fontCabecalho, cor, new PointF(550, 555 + i), formatToLeft);
                e.Graphics.DrawString(totalIva.ToString("F2"), fontCabecalho, cor, new PointF(680, 555 + i), formatToLeft);
                e.Graphics.DrawString(totalIvaValor, fontCabecalho, cor, new PointF(550, 565 + i), formatToLeft);
                e.Graphics.DrawString((total * (totalIva / 100)).ToString("F2"), fontCabecalho, cor, new PointF(680, 565 + i), formatToLeft);
                e.Graphics.DrawString("Desconto", fontCabecalho, cor, new PointF(550, 585 + i), formatToLeft);
                e.Graphics.DrawString($"{desconto.ToString("F2")}", fontCabecalho, cor, new PointF(680, 585 + i), formatToLeft);

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
                Console.WriteLine($"Erro: {ex.Message}");
                throw new Exception("Erro ao desenhar a string: " + ex.Message);
            }
        }

        private void printCompra_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                float desconto = 0f;
                float totalLiquido = 0f;
                float totalIva = 0f;
                float total = 0f;
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


                // Verificar se e.Graphics é válido
                if (e.Graphics == null)
                {
                    throw new Exception("O objeto e.Graphics é nulo.");
                }

                e.Graphics.DrawImage(Image.FromFile(imagePathEmpresa), new Rectangle(40, 50, 100, 100));
                // Desenhar a string
                e.Graphics.DrawString(empresaNome, fontCabecalhoNegrito, cor, new PointF(50, 135), formatToLeft);
                e.Graphics.DrawString(empresaCabecalho, fontCabecalho, cor, ponto, formatToLeft);

                e.Graphics.DrawString($"De {dataInicioCombo.Text.ToString()} á {dataFinalCombo.Text.ToString()}", fontNormalNegrito, cor, new PointF(50, 200), formatToLeft);

                e.Graphics.DrawString($"Artigo", fontNormalNegrito, cor, new Rectangle(50, 280, 110, 300));
                e.Graphics.DrawString("Descricao", fontNormalNegrito, cor, new Rectangle(110, 280, 200, 300));
                e.Graphics.DrawString($"Qtd", fontNormalNegrito, cor, new Rectangle(200, 280, 240, 300));
                e.Graphics.DrawString($"Preco Uni.", fontNormalNegrito, cor, new Rectangle(240, 280, 310, 300));
                e.Graphics.DrawString($"Entidade", fontNormalNegrito, cor, new Rectangle(310, 280, 370, 300));
                e.Graphics.DrawString($"Documento", fontNormalNegrito, cor, new Rectangle(370, 280, 450, 300));
                e.Graphics.DrawString($"Valor Bruto", fontNormalNegrito, cor, new Rectangle(450, 280, 510, 300));
                e.Graphics.DrawString($"Valor Liq.", fontNormalNegrito, cor, new Rectangle(520, 280, 580, 300));
                e.Graphics.DrawString($"Desconto", fontNormalNegrito, cor, new Rectangle(590, 280, 650, 300));
                e.Graphics.DrawString($"Iva", fontNormalNegrito, cor, new Rectangle(655, 280, 700, 300));
                e.Graphics.DrawString($"Data", fontNormalNegrito, cor, new Rectangle(700, 280, 750, 300));
                e.Graphics.DrawLine(caneta, 50, 295, 750, 295);
                int i = 15;
                foreach (var compra in _compras)
                {
                    foreach (var cmp in compra.artigoCompras)
                    {
                        totalIva += (cmp.preco * float.Parse(cmp.qtd.ToString()) * (cmp.iva / 100));
                        total += cmp.preco * float.Parse(cmp.qtd.ToString());
                        desconto += (cmp.preco * float.Parse(cmp.qtd.ToString()) * (cmp.desconto / 100));
                        var valorIva = (cmp.preco * float.Parse(cmp.qtd.ToString()) * (cmp.iva / 100));
                        var descontoLinha = (cmp.preco * float.Parse(cmp.qtd.ToString()) * (cmp.desconto / 100));

                        if (_artigoIds.Any())
                        {
                            if (_artigoIds.Contains(cmp.artigoId))
                            {
                                e.Graphics.DrawString($"{_dados.Where(art => art.id == cmp.artigoId).First().codigo}", fontNormal, cor, new Rectangle(50, 290 + i, 110, 305 + i));
                                e.Graphics.DrawString($"{_dados.Where(art => art.id == cmp.artigoId).First().descricao}", fontNormal, cor, new Rectangle(110, 290 + i, 200, 305 + i));
                                e.Graphics.DrawString($"{cmp.qtd}", fontNormal, cor, new Rectangle(200, 290 + i, 250, 305 + i));
                                e.Graphics.DrawString($"{cmp.preco.ToString("F2")}", fontNormal, cor, new Rectangle(250, 290 + i, 310, 305 + i));
                                e.Graphics.DrawString($"{StaticProperty.fornecedores.Where(f => f.id == compra.fornecedorId).First().nome_fantasia}", fontNormal, cor, new Rectangle(310, 290 + i, 370, 305 + i));
                                e.Graphics.DrawString($"{compra.documento} {compra.serie}/{compra.numeroDocumento}", fontNormal, cor, new Rectangle(370, 290 + i, 450, 305 + i));
                                e.Graphics.DrawString($"{(cmp.preco * cmp.qtd).ToString("F2")}", fontNormal, cor, new Rectangle(450, 290 + i, 510, 425 + i));
                                e.Graphics.DrawString($"{((cmp.preco * cmp.qtd) - descontoLinha).ToString("F2")}", fontNormal, cor, new Rectangle(520, 290 + i, 580, 305 + i));
                                e.Graphics.DrawString($"{cmp.desconto.ToString("F2")}", fontNormal, cor, new Rectangle(590, 290 + i, 650, 425 + i));
                                e.Graphics.DrawString($"{valorIva.ToString("F2")} %", fontNormal, cor, new Rectangle(655, 290 + i, 700, 305 + i));
                                e.Graphics.DrawString($"{(compra.data.ToString("dd-MM-yyyy"))}", fontNormal, cor, new Rectangle(700, 290 + i, 750, 305 + i));
                            }
                        }
                        else
                        {
                            e.Graphics.DrawString($"{_dados.Where(art => art.id == cmp.artigoId).First().codigo}", fontNormal, cor, new Rectangle(50, 290 + i, 110, 305 + i));
                            e.Graphics.DrawString($"{_dados.Where(art => art.id == cmp.artigoId).First().descricao}", fontNormal, cor, new Rectangle(110, 290 + i, 200, 305 + i));
                            e.Graphics.DrawString($"{cmp.qtd}", fontNormal, cor, new Rectangle(200, 290 + i, 250, 305 + i));
                            e.Graphics.DrawString($"{cmp.preco.ToString("F2")}", fontNormal, cor, new Rectangle(250, 290 + i, 310, 305 + i));
                            e.Graphics.DrawString($"{StaticProperty.fornecedores.Where(f => f.id == compra.fornecedorId).First().nome_fantasia}", fontNormal, cor, new Rectangle(310, 290 + i, 370, 305 + i));
                            e.Graphics.DrawString($"{compra.documento} {compra.serie}/{compra.numeroDocumento}", fontNormal, cor, new Rectangle(370, 290 + i, 450, 305 + i));
                            e.Graphics.DrawString($"{(cmp.preco * cmp.qtd).ToString("F2")}", fontNormal, cor, new Rectangle(450, 290 + i, 510, 425 + i));
                            e.Graphics.DrawString($"{((cmp.preco * cmp.qtd) - descontoLinha).ToString("F2")}", fontNormal, cor, new Rectangle(520, 290 + i, 580, 305 + i));
                            e.Graphics.DrawString($"{cmp.desconto.ToString("F2")}", fontNormal, cor, new Rectangle(590, 290 + i, 650, 425 + i));
                            e.Graphics.DrawString($"{valorIva.ToString("F2")} %", fontNormal, cor, new Rectangle(655, 290 + i, 700, 305 + i));
                            e.Graphics.DrawString($"{(compra.data.ToString("dd-MM-yyyy"))}", fontNormal, cor, new Rectangle(700, 290 + i, 750, 305 + i));

                        }

                        i = i + 15;
                    }
                }

                totalLiquido += total - desconto;

                string mercadoria = $"Total liquido:";
                string iva = $"{totalIva.ToString("F2")}";
                string totalIvaValor = $"Total Iva:";
                string totalFinal = $"TOTAL";


                e.Graphics.DrawRectangle(caneta, new Rectangle(540, 530 + i, 210, 90));

                e.Graphics.DrawString(mercadoria, fontCabecalho, cor, new PointF(550, 545 + i), formatToLeft);
                e.Graphics.DrawString(totalLiquido.ToString("F2"), fontCabecalho, cor, new PointF(680, 545 + i), formatToLeft);
                e.Graphics.DrawString(iva, fontCabecalho, cor, new PointF(550, 555 + i), formatToLeft);
                e.Graphics.DrawString(totalIva.ToString("F2"), fontCabecalho, cor, new PointF(680, 555 + i), formatToLeft);
                e.Graphics.DrawString(totalIvaValor, fontCabecalho, cor, new PointF(550, 565 + i), formatToLeft);
                e.Graphics.DrawString((total * (totalIva / 100)).ToString("F2"), fontCabecalho, cor, new PointF(680, 565 + i), formatToLeft);
                e.Graphics.DrawString("Desconto", fontCabecalho, cor, new PointF(550, 585 + i), formatToLeft);
                e.Graphics.DrawString($"{desconto.ToString("F2")}", fontCabecalho, cor, new PointF(680, 585 + i), formatToLeft);

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
                Console.WriteLine($"Erro: {ex.Message}");
                throw new Exception("Erro ao desenhar a string: " + ex.Message);
            }
        }

        private void printArmazem_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                float desconto = 0f;
                float totalLiquido = 0f;
                float totalIva = 0f;
                float total = 0f;

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


                // Verificar se e.Graphics é válido
                if (e.Graphics == null)
                {
                    throw new Exception("O objeto e.Graphics é nulo.");
                }

                e.Graphics.DrawImage(Image.FromFile(imagePathEmpresa), new Rectangle(40, 50, 100, 100));
                // Desenhar a string
                e.Graphics.DrawString(empresaNome, fontCabecalhoNegrito, cor, new PointF(50, 135), formatToLeft);
                e.Graphics.DrawString(empresaCabecalho, fontCabecalho, cor, ponto, formatToLeft);

                e.Graphics.DrawString($"De {dataInicioCombo.Text.ToString()} á {dataFinalCombo.Text.ToString()}", fontNormalNegrito, cor, new PointF(50, 200), formatToLeft);

                e.Graphics.DrawString($"Armazem", fontNormalNegrito, cor, new Rectangle(50, 280, 200, 300));
                e.Graphics.DrawString("Localizacao", fontNormalNegrito, cor, new Rectangle(200, 280, 300, 300));
                e.Graphics.DrawString($"Artigo", fontNormalNegrito, cor, new Rectangle(350, 280, 450, 300));
                e.Graphics.DrawString($"Qtd.", fontNormalNegrito, cor, new Rectangle(500, 280, 590, 300));
                e.Graphics.DrawString($"data", fontNormalNegrito, cor, new Rectangle(600, 280, 700, 300));

                e.Graphics.DrawLine(caneta, 50, 295, 750, 295);
                int i = 15;
                foreach (var hs in _historicoStock)
                {

                    e.Graphics.DrawString($"{StaticProperty.armazens.Where(arm => arm.id == hs.armazemId).First().codigo}", fontNormal, cor, new Rectangle(50, 290 + i, 200, 305 + i));
                    e.Graphics.DrawString($"{StaticProperty.locationStores.Where(loc => loc.id == hs.localizacaoId).First().codigo}", fontNormal, cor, new Rectangle(200, 290 + i, 300, 305 + i));
                    e.Graphics.DrawString($"{StaticProperty.artigos.Where(loc => loc.id == hs.artigoId).First().codigo}", fontNormal, cor, new Rectangle(350, 290 + i, 450, 305 + i));
                    e.Graphics.DrawString($"{hs.qtd.ToString("F2")}", fontNormal, cor, new Rectangle(500, 290 + i, 590, 305 + i));
                    e.Graphics.DrawString($"{hs.created_at.ToString("dd-MM-yyyy")}", fontNormal, cor, new Rectangle(600, 290 + i, 700, 305 + i));

                    i = i + 15;

                }

                totalLiquido += total - desconto;

                string mercadoria = $"Total liquido:";
                string iva = $"{totalIva.ToString("F2")}";
                string totalIvaValor = $"Total Iva:";
                string totalFinal = $"TOTAL";


                //e.Graphics.DrawRectangle(caneta, new Rectangle(540, 530 + i, 210, 90));

                //e.Graphics.DrawString(mercadoria, fontCabecalho, cor, new PointF(550, 545 + i), formatToLeft);
                //e.Graphics.DrawString(totalLiquido.ToString("F2"), fontCabecalho, cor, new PointF(680, 545 + i), formatToLeft);
                //e.Graphics.DrawString(iva, fontCabecalho, cor, new PointF(550, 555 + i), formatToLeft);
                //e.Graphics.DrawString(totalIva.ToString("F2"), fontCabecalho, cor, new PointF(680, 555 + i), formatToLeft);
                //e.Graphics.DrawString(totalIvaValor, fontCabecalho, cor, new PointF(550, 565 + i), formatToLeft);
                //e.Graphics.DrawString((total * (totalIva / 100)).ToString("F2"), fontCabecalho, cor, new PointF(680, 565 + i), formatToLeft);
                //e.Graphics.DrawString("Desconto", fontCabecalho, cor, new PointF(550, 585 + i), formatToLeft);
                //e.Graphics.DrawString($"{desconto.ToString("F2")}", fontCabecalho, cor, new PointF(680, 585 + i), formatToLeft);

                //e.Graphics.DrawLine(canetaFina, 550, 583 + i, 740, 583 + i);
                //e.Graphics.DrawString(totalFinal, fontNormalNegrito, cor, new PointF(550, 600 + i), formatToLeft);
                //e.Graphics.DrawString(total.ToString("F2"), fontNormalNegrito, cor, new PointF(680, 600 + i), formatToLeft);

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

        private void timerRelatorio_Tick(object sender, EventArgs e)
        {
            _artigoIds = dialogArtigo.GetArtigoIdList();

            artigoList.Text = "";

            if (_artigoIds != null && _artigoIds.Any())
            {
                foreach (var item in _artigoIds)
                {
                    artigoList.Text += $"{StaticProperty.artigos.Where(x => x.id == item).First().descricao}\n";
                }
            }
            //==============================================

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



            _armazemIds = dialogArmazem.GetArmazemIdList();
            armazemList.Text = "";
            if (_armazemIds != null && _armazemIds.Any())
            {

                foreach (var item in _armazemIds)
                {
                    armazemList.Text += $"{StaticProperty.armazens.Where(x => x.id == item).First().descricao}\n";
                }
            }
        }
        private void RelatorioFiltros_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerRelatorio.Stop();
            timerRelatorio.Dispose();
        }
    }
}
