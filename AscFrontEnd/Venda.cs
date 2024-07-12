
using AscFrontEnd.DTOs.Cliente;
using AscFrontEnd.DTOs.Venda;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using EAscFrontEnd;
using System.IO;
using ERP_Seller.Application.DTOs.Documentos;
using AscFrontEnd.DTOs.StaticsDto;
using System.Drawing.Printing;
using DocumentFormat.OpenXml.Drawing.Wordprocessing;


namespace AscFrontEnd
{
    public partial class Venda : Form
    {
        List<FrArtigoDTO> artigos;
        List<FtArtigoDTO> ftArtigos;
        List<FaturaProformaArtigoDTO> fpArtigos;
        List<EclArtigoDTO> eclArtigos;
        List<GtArtigoDTO> gtArtigos;
        List<NcArtigoDTO> ncArtigos;
        List<NdArtigoDTO> ndArtigos;
        List<ArtigoDTO> dados;
        ClienteDTO clienteResult;
        string descricaoDocumento = string.Empty;
   

        List<vendaArtigo> vendaArtigos;
        List<int> idVenda;
        DataTable dtVenda;

        static  int artigoId = 0;
        static float precoArtigo = 0;

        private class vendaArtigo
        {
            public int id { get; set; }
            public string codigo { get; set; }
            public float preco { get; set; }
            public int qtd { get; set; }
            public float iva { get; set; }
        }

        public Venda()
        {
            InitializeComponent();
            artigos = new List<FrArtigoDTO>();
            ftArtigos = new List<FtArtigoDTO>();
            fpArtigos = new List<FaturaProformaArtigoDTO>();
            eclArtigos = new List<EclArtigoDTO>();
            gtArtigos = new List<GtArtigoDTO>();
            ncArtigos = new List<NcArtigoDTO>();
            ndArtigos = new List<NdArtigoDTO>();
            dados = new List<ArtigoDTO>();
            vendaArtigos = new List<vendaArtigo>();
            dtVenda = new DataTable();
            idVenda = new List<int>();
            dtVenda = new DataTable();
            clienteResult = new ClienteDTO();
        }

        private async void Venda_Load(object sender, EventArgs e)
        {
            clientetxt.Text = "cliente: " + ClienteDTO.clienteId;
            var client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7200/api/Artigo");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                 dados = JsonConvert.DeserializeObject<List<ArtigoDTO>>(content);

                dtVenda.Columns.Add("id", typeof(int));
                dtVenda.Columns.Add("Artigo", typeof(string));
                dtVenda.Columns.Add("Preco", typeof(float));
                dtVenda.Columns.Add("Qtd", typeof(int));
                dtVenda.Columns.Add("Iva", typeof(float));

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

            documento.Items.Add("FP");
            documento.Items.Add("ECL");
            documento.Items.Add("FR");
            documento.Items.Add("FT");
            documento.Items.Add("GT");
            documento.Items.Add("NC");
            documento.Items.Add("ND");

            eliminarBtn.Enabled = false;

            timerRefresh.Start();
        }

        private void clienteBtn_Click(object sender, EventArgs e)
        {
            ClienteListagem clienteListagem = new ClienteListagem();
            clienteListagem.ShowDialog();
        }

        private void tabelaArtigos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Obtém o valor da célula clicada
                    string id = tabelaArtigos.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string preco = tabelaArtigos.Rows[e.RowIndex].Cells[3].Value.ToString();

                    artigoId = int.Parse(id);
                    precoArtigo = float.Parse(preco);

                }
            }
            catch { return; }
        }

        private async void salvarBtn_Click(object sender, EventArgs e)
        {
            HttpResponseMessage response = null;
            var client = new HttpClient();
            var clientGet = new HttpClient();
            // Configuração do HttpClient
            client.BaseAddress = new Uri("https://sua-api.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (documento.Text == "FR")
            {

                artigos.Clear();
                foreach (var vendaArtigo in vendaArtigos)
                {
                    artigos.Add(new FrArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = vendaArtigo.preco,
                        qtd = vendaArtigo.qtd,
                        iva = vendaArtigo.iva
                    });
                }

                FrDTO frs = new FrDTO()
                {
                    documento = codigoDocumento.Text,
                    data = DateTime.Now,
                    clienteId = StaticProperty.entityId,
                    frArtigo = artigos,
                    status = 1,
                };

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(frs);

                // Envio dos dados para a API
                response = await client.PostAsync("https://localhost:7200/api/Venda/Fr", new StringContent(json, Encoding.UTF8, "application/json"));

            }

            if (documento.Text == "FT")
            {
                FtDTO fts = new FtDTO()
                {
                    documento = codigoDocumento.Text,
                    data = DateTime.Now,
                    clienteId = ClienteDTO.clienteId,
                    ftArtigo = ftArtigos,
                    status = 1,
                };

                ftArtigos.Clear();
                foreach (var vendaArtigo in vendaArtigos)
                {
                    ftArtigos.Add(new FtArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = vendaArtigo.preco,
                        qtd = vendaArtigo.qtd,
                        iva = vendaArtigo.iva
                    });
                }

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(fts);

                // Envio dos dados para a API
                response = await client.PostAsync("https://localhost:7200/api/Venda/Ft", new StringContent(json, Encoding.UTF8, "application/json"));

            }

            if (documento.Text == "FP")
            {
                fpArtigos.Clear();
                foreach (var vendaArtigo in vendaArtigos)
                {
                    fpArtigos.Add(new FaturaProformaArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = vendaArtigo.preco,
                        iva = vendaArtigo.iva
                    });
                }

                FaturaProformaDTO fps = new FaturaProformaDTO()
                {
                    documento = codigoDocumento.Text,
                    data = DateTime.Now,
                    clienteId = ClienteDTO.clienteId,
                    fpArtigo = fpArtigos,
                    status = 1,
                };

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(fps);

                // Envio dos dados para a API
                response = await client.PostAsync("https://localhost:7200/api/Venda/Fp", new StringContent(json, Encoding.UTF8, "application/json"));
            }

            if (documento.Text == "GT")
            {
                gtArtigos.Clear();
                foreach (var vendaArtigo in vendaArtigos)
                {
                    gtArtigos.Add(new GtArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = vendaArtigo.preco,
                        qtd = vendaArtigo.qtd,
                        iva = vendaArtigo.iva
                    });
                }

                GtDTO gts = new GtDTO()
                {
                    documento = codigoDocumento.Text,
                    data = DateTime.Now,
                    clienteId = ClienteDTO.clienteId,
                    gtArtigo = gtArtigos,
                    status = 1,
                };

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(gts);

                // Envio dos dados para a API
                response = await client.PostAsync("https://localhost:7200/api/Venda/Gt", new StringContent(json, Encoding.UTF8, "application/json"));

            }

            if (documento.Text == "ECL")
            {
                eclArtigos.Clear();
                foreach (var vendaArtigo in vendaArtigos)
                {
                    eclArtigos.Add(new EclArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = vendaArtigo.preco,
                        qtd = vendaArtigo.qtd,
                        iva = vendaArtigo.iva
                    });
                }

                EncomendaClienteDTO ecls = new EncomendaClienteDTO()
                {
                    documento = codigoDocumento.Text,
                    data = DateTime.Now,
                    clienteId = ClienteDTO.clienteId,
                    eclArtigo = eclArtigos,
                    status = 1,
                };

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(ecls);

                // Envio dos dados para a API
                response = await client.PostAsync("https://localhost:7200/api/Venda/Ecl", new StringContent(json, Encoding.UTF8, "application/json")); 
            }

            if (documento.Text == "NC")
            {
                ncArtigos.Clear();
                foreach (var vendaArtigo in vendaArtigos)
                {
                    ncArtigos.Add(new NcArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = vendaArtigo.preco,
                        qtd = vendaArtigo.qtd,
                        iva = vendaArtigo.iva
                    });
                }

                NcDTO ncs = new NcDTO()
                {
                    documento = codigoDocumento.Text,
                    data = DateTime.Now,
                    clienteId = ClienteDTO.clienteId,
                    ncArtigo = ncArtigos,
                    status = 1,
                };

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(ncs);

                // Envio dos dados para a API
               response = await client.PostAsync("https://localhost:7200/api/Venda/Ecl", new StringContent(json, Encoding.UTF8, "application/json"));
  
            }

            if (documento.Text == "ND")
            {
                ndArtigos.Clear();
                foreach (var vendaArtigo in vendaArtigos)
                {
                    ndArtigos.Add(new NdArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = vendaArtigo.preco,
                        qtd = vendaArtigo.qtd,
                        iva = vendaArtigo.iva
                    });
                }
                NdDTO nds = new NdDTO()
                {
                    documento = codigoDocumento.Text,
                    data = DateTime.Now,
                    clienteId = ClienteDTO.clienteId,
                    ndArtigo = ndArtigos,
                    status = 1,
                };

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(nds);

                // Envio dos dados para a API
                response = await client.PostAsync("https://localhost:7200/api/Venda/Nd", new StringContent(json, Encoding.UTF8, "application/json"));
            }

            var responseGet = await clientGet.GetAsync($"https://localhost:7200/api/Cliente/{StaticProperty.entityId}");

            if (responseGet.IsSuccessStatusCode)
            {
                var content = await responseGet.Content.ReadAsStringAsync();
                clienteResult = JsonConvert.DeserializeObject<ClienteDTO>(content);
            }

             Imprimir.Print();
             vendaArtigos.Clear();

            if (response.IsSuccessStatusCode)
            {
                dtVenda.Rows.Clear();
                
                MessageBox.Show("Venda Com Sucesso", "Feito Com Sucesso", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Ocorreu um erro ao tentar Salvar", "Erro", MessageBoxButtons.RetryCancel);
            }
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            var client = new HttpClient();

            var response = await client.GetAsync($"https://localhost:7200/api/Artigo/Search/{textBox1.Text}");


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

        private async void documento_SelectedIndexChanged(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"https://localhost:7200/api/serie/codigoDocumento/{documento.Text}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                string dados = content.ToString();

                codigoDocumento.Text = dados;
            }
            if (documento.Text == "FR") { descricaoDocumento = "Factura Recibo"; }
            else if (documento.Text == "FT") { descricaoDocumento = "Factura"; }
            else if(documento.Text == "ECL") { descricaoDocumento = "Encomenda a Cliente"; }
            else if (documento.Text == "GT") { descricaoDocumento = "Guia de Transporte"; }
            else if (documento.Text == "FP") { descricaoDocumento = "Factura Proforma"; }
            else if (documento.Text == "NC") { descricaoDocumento = "Nota Credito"; }
            else if (documento.Text == "ND") { descricaoDocumento = "Nota Debito"; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (StaticProperty.entityId <=0) 
                {
                    MessageBox.Show("Precisas Selecionar o cliente","Atencao",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }
                if (artigoId <= 0) 
                {
                    MessageBox.Show("Nenhum Artigo Foi Selecionado", "Atencao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrWhiteSpace(documento.Text.ToString())) 
                {
                    MessageBox.Show("Selecione um documento de Venda", "Atencao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string codigo;
                int idVendaArtigo = tabelaVenda.Rows.Count;
                List<vendaArtigo> refreshVendaArtigo = new List<vendaArtigo>();
                int i = 1;

                dtVenda.Rows.Clear();
                tabelaVenda.DataSource = dtVenda;

                codigo = dados.Where(art => art.id == artigoId).First().codigo;

                foreach (var va in vendaArtigos)
                {
                    var vArtigo = new vendaArtigo
                    {
                        id = i,
                        codigo = va.codigo,
                        preco = va.preco,
                        qtd = va.qtd,
                        iva = va.iva,
                    };
                    refreshVendaArtigo.Add(vArtigo);
                    i++;
                }

                vendaArtigos.Clear();

                vendaArtigos = refreshVendaArtigo;

                vendaArtigos.Add(new vendaArtigo()
                {
                    id = idVendaArtigo,
                    codigo = codigo,
                    preco = precoArtigo,
                    qtd = int.Parse(Qtd.Text),
                    iva = float.Parse(iva.Text)

                });

                if (documento.Text == "FR")
                {
                    artigos.Add(new FrArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = precoArtigo,
                        qtd = int.Parse(Qtd.Text),
                        iva = float.Parse(iva.Text)
                    });


                    foreach (var fr in vendaArtigos)
                    {

                        dtVenda.Rows.Add(fr.id, fr.codigo, fr.preco, fr.qtd, fr.iva);

                        tabelaVenda.DataSource = dtVenda;
                    }
                }

                if (documento.Text == "FT")
                {
                    ftArtigos.Add(new FtArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = precoArtigo,
                        qtd = int.Parse(Qtd.Text),
                        iva = float.Parse(iva.Text)
                    });

                    foreach (var ft in vendaArtigos)
                    {

                        dtVenda.Rows.Add(ft.id, ft.codigo, ft.preco, ft.qtd, ft.iva);

                        tabelaVenda.DataSource = dtVenda;
                    }
                }

                if (documento.Text == "FP")
                {
                    fpArtigos.Add(new FaturaProformaArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = precoArtigo,
                        iva = float.Parse(iva.Text)
                    });

                    foreach (var fp in vendaArtigos)
                    {

                        dtVenda.Rows.Add(fp.id, fp.codigo, fp.preco, fp.qtd, fp.iva);

                        tabelaVenda.DataSource = dtVenda;
                    }
                }

                if (documento.Text == "ECL")
                {
                    eclArtigos.Add(new EclArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = precoArtigo,
                        qtd = int.Parse(Qtd.Text),
                        iva = float.Parse(iva.Text)
                    });

                    foreach (var ecl in vendaArtigos)
                    {

                        dtVenda.Rows.Add(ecl.id, ecl.codigo, ecl.preco, ecl.qtd, ecl.iva);

                        tabelaVenda.DataSource = dtVenda;
                    }
                }

                if (documento.Text == "GT")
                {
                    gtArtigos.Add(new GtArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = precoArtigo,
                        qtd = int.Parse(Qtd.Text),
                        iva = float.Parse(iva.Text)
                    });

                    foreach (var gt in vendaArtigos)
                    {

                        dtVenda.Rows.Add(gt.id, gt.codigo, gt.preco, gt.qtd, gt.iva);

                        tabelaVenda.DataSource = dtVenda;
                    }
                }

                if (documento.Text == "NC")
                {
                    ncArtigos.Add(new NcArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = precoArtigo,
                        qtd = int.Parse(Qtd.Text),
                        iva = float.Parse(iva.Text)
                    });

                    foreach (var nc in vendaArtigos)
                    {

                        dtVenda.Rows.Add(nc.id, nc.codigo, nc.preco, nc.qtd, nc.iva);

                        tabelaVenda.DataSource = dtVenda;
                    }
                }

                if (documento.Text == "ND")
                {
                    ndArtigos.Add(new NdArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = precoArtigo,
                        qtd = int.Parse(Qtd.Text),
                        iva = float.Parse(iva.Text)
                    });

                    foreach (var nd in vendaArtigos)
                    {

                        dtVenda.Rows.Add(nd.id, nd.codigo, nd.preco, nd.qtd, nd.iva);

                        tabelaVenda.DataSource = dtVenda;
                    }
                }
            }
            catch { return; }
        }

        private async void excelBtn_Click(object sender, EventArgs e)
        {
            exportar exp = new exportar();

            exp.ShowDialog();

        }

        private void eliminarBtn_Click(object sender, EventArgs e)
        {
            var selectedRows = tabelaVenda.SelectedRows;

            foreach (DataGridViewRow row in selectedRows)
            {
                if (row != null && row.Index >= 0) // Verifica se a linha está válida
                {
                    int id = int.Parse(row.Cells[0].Value?.ToString()); // Substitua 0 pelo índice da coluna desejada
                                                                        // Ou faça algo mais útil com o valor
                    idVenda.Add(id);
                }
            }

            foreach (int id in idVenda)
            {
                var result = vendaArtigos.Where(c => c.id == id).First();

                int index = vendaArtigos.IndexOf(result);

                vendaArtigos.RemoveAt(index);
            }

            dtVenda.Rows.Clear();
            tabelaVenda.DataSource = dtVenda;


            foreach (var ca in vendaArtigos)
            {

                dtVenda.Rows.Add(ca.id, ca.codigo.ToString(), ca.preco, ca.qtd, ca.iva);

                tabelaVenda.DataSource = dtVenda;
            }
            idVenda.Clear();
        }

        private void tabelaVenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            eliminarBtn.Enabled = true;
        }

        private void fecharBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void createPicture_Click(object sender, EventArgs e)
        {
           
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

        private void excelBtn_MouseMove(object sender, MouseEventArgs e)
        {
            excelBtn.BackColor = Color.White;
            excelBtn.ForeColor = Color.Black;
        }

        private void excelBtn_MouseLeave(object sender, EventArgs e)
        {
            excelBtn.BackColor = Color.FromArgb(64, 64, 64);
            excelBtn.ForeColor = Color.White;
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            clientetxt.Text = $"Cliente: {StaticProperty.nome}";
        }

        private void Imprimir_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                float totalLiquido = 0f;
                float totalIva = 0f;
                float total = 0f;

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

                string empresaNome = "Smart Entity\n".ToUpper();
                string empresaCabecalho = $"Zango2, Viana\nContribuente: 005899553LA042\n" +
                                          $"Email: SmartEntity476@gmail.com\nTel: 944720430";

                string clienteCabecalho = $"{clienteResult.nome_fantasia.ToUpper()}\n";
                string clienteOutros = $"Cliente Nº {clienteResult.id}\nEndereco: {clienteResult.localizacao}\nContribuente: {clienteResult.nif}\n" +
                                          $"Email: {clienteResult.email}\nTel: {clienteResult.phones.First().telefone}";

                Pen caneta = new Pen(Color.Black, 3); // Define a cor e a largura da linha
                Pen canetaFina = new Pen(Color.Black, 1);
                float linhaInicioX = 550; // Ponto X de início da linha
                float linhaInicioY = 136; // Ajuste conforme necessário para a posição vertical da linha
                float linhaFimX = 750; // Ponto X de fim da linha
                

                // Verificar se e.Graphics é válido
                if (e.Graphics == null)
                {
                    throw new Exception("O objeto e.Graphics é nulo.");
                }

                // Desenhar a string
                e.Graphics.DrawString(empresaNome, fontCabecalhoNegrito, cor, new PointF(50,135), formatToLeft);
                e.Graphics.DrawString(empresaCabecalho, fontCabecalho, cor, ponto,formatToLeft);

                e.Graphics.DrawString("Original", fontNormal, cor, new PointF(750, 120), formatToRight);
                e.Graphics.DrawLine(caneta, linhaInicioX, linhaInicioY, linhaFimX, linhaInicioY);
                e.Graphics.DrawString(clienteCabecalho, fontNormalNegrito, cor, new PointF(550,138), formatToLeft);
                e.Graphics.DrawString(clienteOutros, fontCabecalho, cor, pontoRight, formatToLeft);

                e.Graphics.DrawString($"{descricaoDocumento} {codigoDocumento.Text}", fontNormalNegrito, cor, new PointF(50,280), formatToLeft);
                e.Graphics.DrawLine(canetaFina, 50, 295, 250, 295);
                e.Graphics.DrawString("Contribuente", fontNormalNegrito, cor, new Rectangle(50, 300, 200, 310));
                e.Graphics.DrawString("Desc. Cli", fontNormalNegrito, cor, new Rectangle(200, 300, 350, 310));
                e.Graphics.DrawString("Data Emissão", fontNormalNegrito, cor, new Rectangle(350, 300, 500, 310));
                e.Graphics.DrawString("Data Vencimento", fontNormalNegrito, cor, new Rectangle(500, 300, 650, 310));
                e.Graphics.DrawLine(caneta, 50, 315, 750, 315);

                e.Graphics.DrawString($"{clienteResult.nif}", fontNormal, cor, new Rectangle(50, 330, 200, 340));
                e.Graphics.DrawString("0,00", fontNormal, cor, new Rectangle(200, 330, 350, 340));
                e.Graphics.DrawString($"{DateTime.Now.Date.ToString()}", fontNormal, cor, new Rectangle(350, 330, 450, 340));

                if (documento.Text.Equals("FR") || documento.Text.Equals("GT")) 
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
                foreach (vendaArtigo va in vendaArtigos) 
                {
                   
                    totalIva += va.iva * float.Parse(va.qtd.ToString());
                    totalLiquido += va.preco - (va.preco*(va.iva / 100));
                    total += va.preco * float.Parse(va.qtd.ToString());

                    e.Graphics.DrawString($"{va.codigo}", fontNormal, cor, new Rectangle(50, 410+i, 200, 425+i));
                    e.Graphics.DrawString($"{dados.Where(art => art.codigo == va.codigo).First().descricao}", fontNormal, cor, new Rectangle(200, 410+i, 350, 425+i));
                    e.Graphics.DrawString($"{va.qtd}", fontNormal, cor, new Rectangle(350, 410 + i, 450, 425 + i));
                    e.Graphics.DrawString($"{va.preco}", fontNormal, cor, new Rectangle(450, 410 + i, 550, 425 + i));
                    e.Graphics.DrawString($"{va.iva} %", fontNormal, cor, new Rectangle(550, 410 + i, 650, 425 + i));
                    e.Graphics.DrawString($"{va.preco * float.Parse(va.qtd.ToString())}", fontNormal, cor, new Rectangle(650, 410 + i, 750, 425 + i));
                    i = i + 15;
                }

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