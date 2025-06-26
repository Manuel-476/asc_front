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
using DocumentFormat.OpenXml.Office.CustomUI;
using DocumentFormat.OpenXml.Office2010.Word;
using DocumentFormat.OpenXml.Spreadsheet;
using AscFrontEnd.DTOs.Funcionario;

namespace AscFrontEnd
{
    public partial class LiquidaDivida : Form
    {
        int _docId;
        Entidade _entidade;
        string codigoDocumento;

        VftDTO vftResult;
        FtDTO ftResult;
        NpDTO np;
        ReciboDTO re;
        List<FtReciboDTO> ftRecibo;
        List<VftNpDTO> vftNp;

        List<VendaArtigo> vendaArtigos;
        List<ArtigoDTO> dados;
        DataTable faturas;
        HttpClient client;
        UserDTO _user;
        float divida = 0, regulado = 0;

        string codigo = string.Empty;

        public LiquidaDivida(int docId, Entidade entidade,UserDTO user)
        {
            InitializeComponent();

            _docId = docId;
            this._entidade = entidade;

            vftResult = new VftDTO();
            ftResult = new FtDTO();

            np = new NpDTO();
            ftRecibo = new List<FtReciboDTO>();
            vftNp = new List<VftNpDTO>();

            vendaArtigos = new List<VendaArtigo>();
            dados = new List<ArtigoDTO>();
            faturas = new DataTable();

            client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            client.BaseAddress = new Uri("http://localhost:7200/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            valorTxt.KeyPress += ValidacaoForms.TratarKeyPress; // Ajustado
            valorTxt.TextChanged += ValidacaoForms.TratarTextChanged;

            _user = user;
        }

        private void LiquidaDivida_Load(object sender, EventArgs e)
        {
            dados = StaticProperty.artigos;

            OutrasValidacoes.SerieExist(_user);


            faturas.Columns.Add("id", typeof(int));
            faturas.Columns.Add("Documento", typeof(string));
            faturas.Columns.Add("Valor Total", typeof(float));


            if (_entidade == Entidade.fornecedor)
            {
                this.codigo = "np";
                if (StaticProperty.vfts != null)
                {
                    vftResult = StaticProperty.vfts.Where(vft => vft.id == _docId).First();
                    var result = StaticProperty.vfts.Where(vft => vft.fornecedorId == vftResult.fornecedorId).ToList();

                    foreach (var item in result)
                    {
                        if (item.pago == Enums.OpcaoBinaria.Nao)
                        {
                            divida += item.vftArtigo.Sum(d => d.preco * d.qtd);
                            regulado += StaticProperty.nps != null && StaticProperty.nps.Any() ? StaticProperty.nps.Where(np => np.vftNps.Where(f => f.vftId == item.id).Any()).Sum(np => np.quantia) : 0f;

                            var reguladoByLinha = StaticProperty.nps != null && StaticProperty.nps.Any() ? StaticProperty.nps.Where(np => np.vftNps.Where(f => f.vftId == item.id).Any()).Sum(np => np.quantia) : 0f;

                            faturas.Rows.Add(item.id, item.documento, item.vftArtigo.Sum(d => d.preco * d.qtd) - reguladoByLinha);
                        }


                    }
                    entidadeLabel.Text = StaticProperty.fornecedores.Where(f => f.id == vftResult.fornecedorId).First().nome_fantasia;
                    dividaLabel.Text = $"Divida: {divida}";
                    liquidado.Text = $"Liquidado: {regulado}";
                }

            }
            if (_entidade == Entidade.cliente)
            {
                if (StaticProperty.fts != null)
                {
                    this.codigo = "rg";
                    ftResult = StaticProperty.fts.Where(ft => ft.id == _docId).First();
                    var result = StaticProperty.fts.Where(ft => ft.clienteId == ftResult.clienteId).ToList();

                    foreach (var item in result)
                    {
                        if (item.pago == Enums.OpcaoBinaria.Nao)
                        {
                            divida += item.ftArtigo.Sum(d => d.preco * d.qtd);
                            regulado += StaticProperty.recibos != null && StaticProperty.recibos.Any() ? StaticProperty.recibos.Where(re => re.ftRecibos.Where(x => x.ftId == item.id).Any()).Sum(np => np.quantia) : 0f;

                            var reguladoByLinha = StaticProperty.recibos != null && StaticProperty.recibos.Any() ? StaticProperty.recibos.Where(re => re.ftRecibos.Where(x => x.ftId == item.id).Any()).Sum(np => np.quantia) : 0f;

                            faturas.Rows.Add(item.id, item.documento, item.ftArtigo.Sum(d => d.preco * d.qtd) - reguladoByLinha);
                        }

                    }

                    entidadeLabel.Text = StaticProperty.clientes.Where(f => f.id == ftResult.clienteId).First().nome_fantasia;
                    dividaLabel.Text = $"Divida: {divida}";
                    liquidado.Text = $"Liquidado: {regulado}";
                }
            }

            tabelaFaturas.DataSource = faturas;
            tabelaFaturas.ClearSelection();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
             FaturaDetalhes form;

            var request = new Requisicoes();

            string json = string.Empty;

            codigoDocumento = await Documento.GetCodigoDocumentoAsync(this.codigo);

            codigoDocumento = codigoDocumento.Replace("\"", "");

            var valor = !string.IsNullOrEmpty(valorTxt.Text.ToString()) ? float.Parse(valorTxt.Text.ToString().Replace(".", "").Replace(",", "."), CultureInfo.InvariantCulture) : 0f;

            if (_entidade == Entidade.fornecedor)
            {
                np = new NpDTO()
                {
                    documento = codigoDocumento,
                    created = DateTime.Now,
                    quantia = valor,
                    vftNps =vftNp,
                };


                // Envio dos dados para a API
                form = new FaturaDetalhes(valor, np);
                if (form.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }
            if (_entidade == Entidade.cliente)
            {
                re = new ReciboDTO()
                {
                    documento = codigoDocumento,
                    created_at = DateTime.Now,
                    quantia = valor,
                    ftRecibos = ftRecibo
                };

                form = new FaturaDetalhes(valor, re);
                if (form.ShowDialog() != DialogResult.OK)
                {
                    return;
                }         
            }

            preVisualizacaoDialog.Document = Imprimir;

            if (preVisualizacaoDialog.ShowDialog() == DialogResult.OK)
            {
                Imprimir.Print();
            }

            await request.SystemRefresh();

            this.LoadRefresh();

            WindowsConfig.LimparFormulario(this);

            faturas =new DataTable();

            LiquidaDivida_Load(this, EventArgs.Empty);
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

                    var phone = entidade.phones.Any() ? entidade.phones.First().telefone : string.Empty;

                    empresaNome = $"{empresa.nome_fantasia}";
                    empresaCabecalho = $"{empresa.endereco}\nContribuente: {empresa.nif}\n" +
                                              $"Email: {empresa.email}\nTel: {empresa.telefone}";

                    clienteCabecalho = $"{entidade.nome_fantasia.ToUpper()}\n";
                    clienteOutros = $"Cliente Nº {entidade.id}\nEndereco: {entidade.localizacao}\nContribuente: {entidade.nif}\n" +
                                              $"Email: {entidade.email}\nTel: {phone}";
                }
                else
                {
                    var entidade = StaticProperty.fornecedores.Where(cl => cl.id == vftResult.fornecedorId).First();

                    var phone = entidade.phones.Any() ? entidade.phones.First().telefone : string.Empty;

                    empresaNome = $"{entidade.nome_fantasia}";
                    empresaCabecalho = $"{entidade.localizacao}\nContribuente: {entidade.nif}\n" +
                                              $"Email: {entidade.email}\nTel: {phone}";

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

                int k = 0;
                var listDoc = string.Empty;
                if (_entidade == Entidade.cliente)
                {
                    if (ftRecibo != null)
                    {
                        foreach (var doc in ftRecibo)
                        {
                            listDoc = StaticProperty.fts.Where(x => x.id == doc.ftId).Any() ?
                                            StaticProperty.fts.Where(x => x.id == doc.ftId).First().documento : string.Empty;

                            e.Graphics.DrawString($"{listDoc}", fontNormal, cor, new Rectangle(50, 330 + k, 200, 340));
                            k += 15;
                        }
                    }              
                }
                else 
                {
                    if (ftRecibo != null)
                    {
                        foreach (var doc in ftRecibo)
                        {
                            listDoc = StaticProperty.vfts.Where(x => x.id == doc.ftId).Any() ?
                                  StaticProperty.vfts.Where(x => x.id == doc.ftId).First().documento : string.Empty;

                            e.Graphics.DrawString($"{listDoc}", fontNormal, cor, new Rectangle(50, 330 + k, 200, 340));
                            k += 15;
                        }
                    }
                }
                e.Graphics.DrawString($"{DateTime.Now.Date.ToString("dd-mm-yyyy")}", fontNormal, cor, new Rectangle(200, 330, 350, 340));
                e.Graphics.DrawString($"{0.00.ToString("F4")}", fontNormal, cor, new Rectangle(300, 330, 200, 340));
                e.Graphics.DrawString($"{0.00.ToString("F4")}", fontNormal, cor, new Rectangle(380, 330, 200, 340));
                e.Graphics.DrawString($"{float.Parse(valorTxt.Text.ToString()).ToString("F4")}", fontNormal, cor, new Rectangle(450, 330, 200, 340));
                e.Graphics.DrawString($"{float.Parse(valorTxt.Text.ToString()).ToString("F4")}", fontNormal, cor, new Rectangle(570, 330, 200, 340));
                e.Graphics.DrawString($"{divida}", fontNormal, cor, new Rectangle(650, 330, 200, 340));
             
                e.Graphics.DrawString($"Precessado pelo programa válido nº{"31.1/AGT20"} Asc - Smart Entity", fontCabecalho, cor, new PointF(250, 870), formatToCenter);
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
            float valorTotal = 0f;
            try
            {
                listDocumentos.Items.Clear();
              _docId = int.Parse(tabelaFaturas.Rows[e.RowIndex].Cells[0].Value.ToString());        

                if (ModifierKeys == Keys.Control)
                {
                    valorTxt.ReadOnly = true;
                    //==================================================================
                    vendaArtigos.Clear(); // Limpa a lista antes de carregar

                    if (_entidade == Entidade.cliente)
                    {
                        ftRecibo.Clear();
                        // Obtém o documento correspondente

                        // Itera pelas linhas selecionadas no DataGridView
                        foreach (DataGridViewRow row in tabelaFaturas.SelectedRows)
                        {
                            // Suponha que a coluna "artigoId" está vinculada a uma célula ou propriedade
                            int documentoId = Convert.ToInt32(row.Cells["id"].Value); // Ajuste o nome da coluna conforme necessário

                            if(documentoId <= 0) 
                            {
                                continue;
                            }

                            var codDocumento = row.Cells["documento"].Value.ToString();

                             listDocumentos.Items.Add(codDocumento);


                            ftRecibo.Add(new FtReciboDTO() { Id = 0, reciboId = 0, ftId = documentoId });

                            var documento = StaticProperty.fts.FirstOrDefault(x => x.id == documentoId && x.pago == OpcaoBinaria.Nao);

                            foreach (var item in documento.ftArtigo.ToList())
                            {
                                // Busca o item correspondente em ftArtigo
                                // var item = documento.ftArtigo.FirstOrDefault(x => x.artigoId == artigoId);

                                if (item != null)
                                {
                                    vendaArtigos.Add(new VendaArtigo()
                                    {
                                        codigo = dados.FirstOrDefault(x => x.id == item.artigoId)?.codigo,
                                        preco = item.preco,
                                        iva = item.iva,
                                        qtd = item.qtd
                                    });
                                }

                                valorTotal += float.Parse(row.Cells[2].Value.ToString()); 
                            }
                        }
                    }
                    else
                    {
                        vftNp.Clear();

                        // Itera pelas linhas selecionadas no DataGridView
                        foreach (DataGridViewRow row in tabelaFaturas.SelectedRows)
                        {
                            // Suponha que a coluna "artigoId" está vinculada a uma célula ou propriedade
                            int documentoId = Convert.ToInt32(row.Cells["id"].Value); // Ajuste o nome da coluna conforme necessário

                            if (documentoId <= 0)
                            {
                                continue;
                            }

                            vftNp.Add(new VftNpDTO() { Id = 0, npId = 0, vftId = documentoId });

                            var codDocumento = row.Cells["documento"].Value.ToString();

                            listDocumentos.Items.Add(codDocumento);

                            var documento = StaticProperty.vfts.FirstOrDefault(x => x.id == documentoId && x.pago == OpcaoBinaria.Nao);

                            foreach (var item in documento.vftArtigo.ToList())
                            {
                                if (item != null)
                                {
                                    vendaArtigos.Add(new VendaArtigo()
                                    {
                                        codigo = dados.FirstOrDefault(x => x.id == item.artigoId)?.codigo,
                                        preco = item.preco,
                                        iva = item.iva,
                                        qtd = item.qtd
                                    });
                                }
                                valorTotal += float.Parse(row.Cells[2].Value.ToString());
                            }
                        }

                    }
                    //==================================================================

                }
                else
                {
                    // Desabilita o multisseleção

                    valorTxt.ReadOnly = false;

                    vendaArtigos.Clear();

                    var codDocumento = tabelaFaturas.Rows[e.RowIndex].Cells[1].Value.ToString();
                    valorTotal = 0f;
                    if (_entidade == Entidade.cliente)
                    {
                        ftRecibo.Clear();

                        ftRecibo.Add(new FtReciboDTO() { Id = 0, reciboId = 0, ftId = _docId });
                        if (StaticProperty.fts != null)
                        {
                            foreach (var item in StaticProperty.fts.Where(x => x.id == _docId && x.pago == OpcaoBinaria.Nao).First().ftArtigo)
                            {
                                vendaArtigos.Add(new VendaArtigo()
                                {
                                    codigo = dados.Where(x => x.id == item.artigoId).First().codigo,
                                    preco = item.preco,
                                    iva = item.iva,
                                    qtd = item.qtd
                                });

                                valorTotal += float.Parse(tabelaFaturas.Rows[e.RowIndex].Cells[2].Value.ToString());
                            }
                        }
                    }
                    else
                    {
                        vftNp.Clear();

                        vftNp.Add(new VftNpDTO() { Id = 0, npId = 0, vftId = _docId });

                        if (StaticProperty.vfts != null)
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
                                valorTotal += float.Parse(tabelaFaturas.Rows[e.RowIndex].Cells[2].Value.ToString());
                            }
                        }
                    }

                    listDocumentos.Items.Add(codDocumento);


                    // Opcional: Limpa seleções anteriores para evitar múltiplas linhas selecionadas
                    tabelaFaturas.ClearSelection();
                    tabelaFaturas.Rows[e.RowIndex].Selected = true;
                }
                valorTxt.Text = valorTotal.ToString("F2");
            }
            catch 
            {
                return;
            }
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.BackColor = Color.White;
            button2.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(64, 64, 64);
            button2.ForeColor = Color.White;
        }

        //===================================================================================
        private void LoadRefresh()
        {
            string codigo = string.Empty;
            float divida = 0, regulado = 0;
            var client = new HttpClient();
    

            dados = StaticProperty.artigos;


            if (StaticProperty.series != null)
            {
                if (!StaticProperty.series.Any())
                {
                    MessageBox.Show("Nenhuma Serie Foi Criada", "Precisa de uma Serie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            faturas.Rows.Clear();

            if (_entidade == Entidade.fornecedor)
            {
                codigo = "np";
                if (StaticProperty.vfts != null)
                {
                    vftResult = StaticProperty.vfts.Where(vft => vft.id == _docId).First();
                    var result = StaticProperty.vfts.Where(vft => vft.fornecedorId == vftResult.fornecedorId).ToList();

                    foreach (var item in result)
                    {
                        if (item.pago == Enums.OpcaoBinaria.Nao)
                        {
                            divida += item.vftArtigo.Sum(d => d.preco * d.qtd);
                            regulado += StaticProperty.nps.Where(np => np.vftNps.Where(f => f.vftId == item.id).Any()).Sum(np => np.quantia);

                            faturas.Rows.Add(item.id, item.documento, item.vftArtigo.Sum(d => d.preco * d.qtd));
                        }

                    }
                    entidadeLabel.Text = StaticProperty.fornecedores.Where(f => f.id == vftResult.fornecedorId).First().nome_fantasia;
                    dividaLabel.Text = $"Divida: {divida}";
                    liquidado.Text = $"Liquidado: {regulado}";
                }
            }
            if (_entidade == Entidade.cliente)
            {
                if (StaticProperty.fts != null)
                {
                    codigo = "rg";
                    ftResult = StaticProperty.fts.Where(ft => ft.id == _docId).First();
                    var result = StaticProperty.fts.Where(ft => ft.clienteId == ftResult.clienteId).ToList();

                    foreach (var item in result)
                    {
                        if (item.pago == Enums.OpcaoBinaria.Nao)
                        {
                            divida += item.ftArtigo.Sum(d => d.preco * d.qtd);
                            regulado += StaticProperty.recibos.Where(re => re.ftRecibos.First().ftId == item.id).Sum(np => np.quantia);

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
}
