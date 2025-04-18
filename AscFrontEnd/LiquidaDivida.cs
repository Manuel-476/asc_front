using AscFrontEnd.DTOs.ContasCorrentes;
using AscFrontEnd.DTOs.Enums;
using AscFrontEnd.DTOs.StaticsDto;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
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
using Font = System.Drawing.Font;
using Color = System.Drawing.Color;
using ERP_Buyer.Application.DTOs.Documentos;
using EAscFrontEnd;
using AscFrontEnd.DTOs.Cliente;
using AscFrontEnd.DTOs.Fornecedor;
using AscFrontEnd.Application;
using AscFrontEnd.Application.Validacao;
using System.Globalization;

namespace AscFrontEnd
{
    public partial class LiquidaDivida : Form
    {
        int _docId;
        Entidade _entidade;
        string codigoDocumento;
        VftDTO vftResult;
        FtDTO ftResult;
        List<VendaArtigo> vendaArtigos;
        List<ArtigoDTO> dados;
        DataTable faturas;
        HttpClient client;
        float divida = 0, regulado = 0;

        string codigo = string.Empty;

        public LiquidaDivida(int docId, Entidade entidade)
        {
            InitializeComponent();
            _docId = docId;
            this._entidade = entidade;
            vftResult = new VftDTO();
            ftResult = new FtDTO();
            vendaArtigos = new List<VendaArtigo>();
            dados = new List<ArtigoDTO>();
            faturas = new DataTable();

            client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            client.BaseAddress = new Uri("https://localhost:7200/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            valorTxt.KeyPress += ValidacaoForms.TratarKeyPress; // Ajustado
            valorTxt.TextChanged += ValidacaoForms.TratarTextChanged;
        }

        private  void LiquidaDivida_Load(object sender, EventArgs e)
        {
            dados = StaticProperty.artigos;
            

            if (StaticProperty.series == null)
            {
                MessageBox.Show("Nenhuma Serie Foi Criada", "Precisa de uma Serie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            faturas.Columns.Add("id",typeof(int));
            faturas.Columns.Add("Documento", typeof(string));
            faturas.Columns.Add("Valor Total",typeof(float));
            

            if (_entidade == Entidade.fornecedor) 
            {
                this.codigo = "np";
               
                vftResult = StaticProperty.vfts.Where(vft => vft.id == _docId).First();
                var result = StaticProperty.vfts.Where(vft => vft.fornecedorId == vftResult.fornecedorId).ToList();

                foreach (var item in result)
                {
                    if (item.pago == Enums.OpcaoBinaria.Nao)
                    {
                        divida += item.vftArtigo.Sum(d => d.preco * d.qtd);
                        regulado += StaticProperty.nps.Where(np => np.vftId == item.id).Sum(np => np.quantia);

                        faturas.Rows.Add(item.id, item.documento, item.vftArtigo.Sum(d => d.preco * d.qtd));
                    }

                   
                }
                entidadeLabel.Text = StaticProperty.fornecedores.Where(f => f.id == vftResult.fornecedorId).First().nome_fantasia;
                dividaLabel.Text = $"Divida: {divida}";
                liquidado.Text = $"Liquidado: {regulado}";

            }
            if (_entidade == Entidade.cliente)
            {
                this.codigo = "rg";
                ftResult = StaticProperty.fts.Where(ft => ft.id == _docId).First();
                var result = StaticProperty.fts.Where(ft => ft.clienteId == ftResult.clienteId).ToList();

                foreach (var item in result)
                {
                    if (item.pago == Enums.OpcaoBinaria.Nao)
                    {
                        divida += item.ftArtigo.Sum(d => d.preco * d.qtd);
                        regulado += StaticProperty.recibos.Where(re => re.ftId == item.id).Sum(np => np.quantia);

                        faturas.Rows.Add(item.id, item.documento, item.ftArtigo.Sum(d => d.preco * d.qtd));
                    }

                    
                }

                entidadeLabel.Text = StaticProperty.clientes.Where(f => f.id == ftResult.clienteId).First().nome_fantasia;
                dividaLabel.Text = $"Divida: {divida}";
                liquidado.Text = $"Liquidado: {regulado}";
            }

            tabelaFaturas.DataSource = faturas;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            FaturaDetalhes form;

            string json = string.Empty;

            codigoDocumento = await Documento.GetCodigoDocumentoAsync(this.codigo);

            var valor = !string.IsNullOrEmpty(valorTxt.Text.ToString()) ? float.Parse(valorTxt.Text.ToString().Replace(".", "").Replace(",", "."), CultureInfo.InvariantCulture) : 0f;
           
            if (_entidade == Entidade.fornecedor)
            {

                var np = new NpDTO()
                {
                    documento = codigoDocumento,
                    created = DateTime.UtcNow.Date,
                    quantia = valor,
                    vftId = _docId,
                };

                // Envio dos dados para a API
                form = new FaturaDetalhes(valor, np);
                if (form.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
           /*     var responsta = await client.PutAsync($"", new StringContent(json, Encoding.UTF8, "application/json"));

                if (!responsta.IsSuccessStatusCode)
                {
                    MessageBox.Show("Ocorreu um erro ao mudar estado do documento", "Ocorreu um erro", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                    return;
                }*/
            }
            if (_entidade == Entidade.cliente)
            {
                var re = new ReciboDTO()
                {
                    documento = codigoDocumento,
                    created = DateTime.UtcNow.Date,
                    quantia = valor,
                    ftId = _docId
                };
                form = new FaturaDetalhes(valor, re);
                if (form.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

            }
            //var response = await client.PutAsync($"", new StringContent(json, Encoding.UTF8, "application/json"));

            //if (!response.IsSuccessStatusCode)
            //{
            //    MessageBox.Show("Ocorreu um erro ao mudar estado do documento", "Ocorreu um erro", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

            //    return;
            //}

            preVisualizacaoDialog.Document = Imprimir;

            if (preVisualizacaoDialog.ShowDialog() == DialogResult.OK)
            {
                Imprimir.Print();
            }

            this.LoadRefresh();
        }

        private void Imprimir_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {

                string clienteCabecalho;
                string clienteOutros;
                string empresaNome;
                string empresaCabecalho;

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

         
                if (_entidade == Entidade.cliente)
                {
                    var entidade = StaticProperty.clientes.Where(cl => cl.id == ftResult.clienteId).First();

                    empresaNome = $"{empresa.nome_fantasia}";
                    empresaCabecalho = $"{empresa.endereco}\nContribuente: {empresa.nif}\n" +
                                              $"Email: {empresa.email}\nTel: {empresa.telefone}";

                    clienteCabecalho = $"{entidade.nome_fantasia.ToUpper()}\n";
                    clienteOutros = $"Cliente Nº {entidade.id}\nEndereco: {entidade.localizacao}\nContribuente: {entidade.nif}\n" +
                                              $"Email: {entidade.email}\nTel: {entidade.phones.First().telefone}";
                }
                else 
                {
                    var entidade = StaticProperty.fornecedores.Where(cl => cl.id == vftResult.fornecedorId).First();

                    empresaNome = $"{entidade.nome_fantasia}";
                    empresaCabecalho = $"{entidade.localizacao}\nContribuente: {entidade.nif}\n" +
                                              $"Email: {entidade.email}\nTel: {entidade.phones.First().telefone}";

                    clienteCabecalho = $"{empresa.nome_fantasia.ToUpper()}\n";
                    clienteOutros = $"Cliente Nº {empresa.id}\nEndereco: {empresa.endereco}\nContribuente: {empresa.nif}\n" +
                                              $"Email: {empresa.email}\nTel: {empresa.telefone}";
                }


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

                e.Graphics.DrawString($"{(_entidade == Entidade.fornecedor ? "Nota Pagamento" : "Recibo")}  {codigoDocumento}", fontNormalNegrito, cor, new PointF(50, 280), formatToLeft);
                e.Graphics.DrawLine(canetaFina, 50, 295, 250, 295);
                e.Graphics.DrawString("Referência da Factura", fontNormalNegrito, cor, new Rectangle(50, 300, 200, 310));
                e.Graphics.DrawString("Data Emissão", fontNormalNegrito, cor, new Rectangle(200, 300, 200, 310));
                e.Graphics.DrawString("Total Imposto", fontNormalNegrito, cor, new Rectangle(300, 300, 200, 310));
                e.Graphics.DrawString("Retenção", fontNormalNegrito, cor, new Rectangle(380, 300, 300, 200));
                e.Graphics.DrawString("Total da Factura", fontNormalNegrito, cor, new Rectangle(450, 300, 200, 310));
                e.Graphics.DrawString("Total Pago", fontNormalNegrito, cor, new Rectangle(570, 300, 200, 310));
                e.Graphics.DrawString("Valor Pendente", fontNormalNegrito, cor, new Rectangle(650, 300, 200, 310));
                e.Graphics.DrawLine(caneta, 50, 315, 750, 315);

                e.Graphics.DrawString($"{documentoLabel.Text}", fontNormal, cor, new Rectangle(50, 330, 200, 340));
                e.Graphics.DrawString($"{DateTime.Now.Date.ToString("dd-mm-yyyy")}", fontNormal, cor, new Rectangle(200, 330, 350, 340));
                e.Graphics.DrawString($"{0.00.ToString("F4")}", fontNormal, cor, new Rectangle(300, 330, 200, 340));
                e.Graphics.DrawString($"{0.00.ToString("F4")}", fontNormal, cor, new Rectangle(380, 330, 200, 340));
                e.Graphics.DrawString($"{float.Parse(valorTxt.Text.ToString()).ToString("F4")}", fontNormal, cor, new Rectangle(450, 330, 200, 340));
                e.Graphics.DrawString($"{float.Parse(valorTxt.Text.ToString()).ToString("F4")}", fontNormal, cor, new Rectangle(570, 330, 200, 340));
                e.Graphics.DrawString($"{divida}", fontNormal, cor, new Rectangle(650, 330, 200, 340));


                /*       int i = 15;
                       foreach (vendaArtigo va in vendaArtigos)
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


                       e.Graphics.DrawRectangle(caneta, new Rectangle(540, 530 + i, 210, 65 + i));

                       e.Graphics.DrawString(mercadoria, fontCabecalho, cor, new PointF(550, 545 + i), formatToLeft);
                       e.Graphics.DrawString(totalLiquido.ToString("F2"), fontCabecalho, cor, new PointF(680, 545 + i), formatToLeft);
                       e.Graphics.DrawString(iva, fontCabecalho, cor, new PointF(550, 555 + i), formatToLeft);
                       e.Graphics.DrawString(totalIva.ToString("F2"), fontCabecalho, cor, new PointF(680, 555 + i), formatToLeft);
                       e.Graphics.DrawString(totalIvaValor, fontCabecalho, cor, new PointF(550, 565 + i), formatToLeft);
                       e.Graphics.DrawString((total * (totalIva / 100)).ToString("F2"), fontCabecalho, cor, new PointF(680, 565 + i), formatToLeft);

                       e.Graphics.DrawLine(canetaFina, 550, 583 + i, 740, 583 + i);
                       e.Graphics.DrawString(totalFinal, fontNormalNegrito, cor, new PointF(550, 590 + i), formatToLeft);
                       e.Graphics.DrawString(total.ToString("F2"), fontNormalNegrito, cor, new PointF(680, 590 + i), formatToLeft);

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
                */
                e.Graphics.DrawString($"Precessado pelo programa válido nº{"nn/AGT/AAA"} Asc - Smart Entity", fontCabecalho, cor, new PointF(250, 870), formatToCenter);
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

        private void tabelaFaturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            documentoLabel.Text = tabelaFaturas.Rows[e.RowIndex].Cells[1].Value.ToString(); 
            valorTxt.Text = tabelaFaturas.Rows[e.RowIndex].Cells[2].Value.ToString();
            _docId = int.Parse(tabelaFaturas.Rows[e.RowIndex].Cells[0].Value.ToString());

            vendaArtigos.Clear();

            if(_entidade == Entidade.cliente) 
            {
                foreach(var item in StaticProperty.fts.Where(x => x.id == _docId && x.pago == OpcaoBinaria.Nao).First().ftArtigo) 
                {
                    vendaArtigos.Add(new VendaArtigo() { codigo = dados.Where(x=>x.id == item.artigoId).First().codigo,
                                                         preco = item.preco,
                                                         iva = item.iva,
                                                         qtd = item.qtd});
                }
            }
            else 
            {
                foreach (var item in StaticProperty.vfts.Where(x => x.id == _docId && x.pago == OpcaoBinaria.Nao).First().vftArtigo)
                {
                    vendaArtigos.Add(new VendaArtigo()
                    {
                        codigo = dados.Where(x => x.id == item.artigoId).First().codigo,
                        preco = item.preco,
                        iva = item.iva,
                        qtd = item.qtd
                    });
                }
            }
        }

        //===================================================================================
        private void LoadRefresh()
        {
            string codigo = string.Empty;
            float divida = 0, regulado = 0;
            var client = new HttpClient();

            dados = StaticProperty.artigos;


            if (StaticProperty.series == null)
            {
                MessageBox.Show("Nenhuma Serie Foi Criada", "Precisa de uma Serie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            faturas.Rows.Clear();

            if (_entidade == Entidade.fornecedor)
            {
                codigo = "np";

                vftResult = StaticProperty.vfts.Where(vft => vft.id == _docId).First();
                var result = StaticProperty.vfts.Where(vft => vft.fornecedorId == vftResult.fornecedorId).ToList();

                foreach (var item in result)
                {
                    if (item.pago == Enums.OpcaoBinaria.Nao)
                    {
                        divida += item.vftArtigo.Sum(d => d.preco * d.qtd);
                        regulado += StaticProperty.nps.Where(np => np.vftId == item.id).Sum(np => np.quantia);

                        faturas.Rows.Add(item.id, item.documento, item.vftArtigo.Sum(d => d.preco * d.qtd));
                    }

                    
                }
                entidadeLabel.Text = StaticProperty.fornecedores.Where(f => f.id == vftResult.fornecedorId).First().nome_fantasia;
                dividaLabel.Text = $"Divida: {divida}";
                liquidado.Text = $"Liquidado: {regulado}";

            }
            if (_entidade == Entidade.cliente)
            {
                codigo = "re";
                ftResult = StaticProperty.fts.Where(ft => ft.id == _docId).First();
                var result = StaticProperty.fts.Where(ft => ft.clienteId == ftResult.clienteId).ToList();

                foreach (var item in result)
                {
                    if (item.pago == Enums.OpcaoBinaria.Nao)
                    {
                        divida += item.ftArtigo.Sum(d => d.preco * d.qtd);
                        regulado += StaticProperty.recibos.Where(re => re.ftId == item.id).Sum(np => np.quantia);

                        faturas.Rows.Add(item.id, item.documento, item.ftArtigo.Sum(d => d.preco * d.qtd));
                    }

                   
                }

                entidadeLabel.Text = StaticProperty.clientes.Where(f => f.id == ftResult.clienteId).First().nome_fantasia;
                dividaLabel.Text = $"Divida: {divida}";
                liquidado.Text = $"Liquidado: {regulado}";
            }
        }
    }
}
