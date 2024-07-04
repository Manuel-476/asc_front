using AscFrontEnd.DTOs;
using AscFrontEnd.DTOs.Cliente;
using AscFrontEnd.DTOs.Fornecedor;
using AscFrontEnd.DTOs.StaticsDto;
using AscFrontEnd.DTOs.Venda;
using EAscFrontEnd;
using ERP_Buyer.Application.DTOs.Documentos;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AscFrontEnd
{
    public partial class Compra : Form
    {
        List<VfrArtigoDTO> artigos;
        List<VftArtigoDTO> vftArtigos;
        List<PedidoCotacaoArtigoDTO> pcoArtigos;
        List<CotacaoArtigoDTO> cotArtigos;
        List<EcfArtigoDTO> ecfArtigos;
        List<VgtArtigoDTO> vgtArtigos;
        List<VncArtigoDTO> vncArtigos;
        List<VndArtigoDTO> vndArtigos;
        List<ArtigoDTO> dados;
        List<compraArtigo> compraArtigos;
        List<int> idCompra; 
        static int artigoId = 0;
        DataTable dtCompra;

        private class compraArtigo 
        {
            public int id {  get; set; }
            public string codigo { get; set; }
            public float preco { get; set; }
            public int qtd { get; set; }
            public float iva { get; set; }
        }
        public Compra()
        {
            InitializeComponent();
            artigos = new List<VfrArtigoDTO>();
            vftArtigos = new List<VftArtigoDTO>();
            pcoArtigos = new List<PedidoCotacaoArtigoDTO>();
            cotArtigos = new List<CotacaoArtigoDTO> ();
           ecfArtigos = new List<EcfArtigoDTO>();
            vgtArtigos = new List<VgtArtigoDTO>();
            vncArtigos = new List<VncArtigoDTO>();
            vndArtigos = new List<VndArtigoDTO>();
            compraArtigos = new List<compraArtigo>();
            dados = new List<ArtigoDTO>();
            dtCompra = new DataTable();
            idCompra = new List<int>();

        }
        private async void Compra_Load(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7200/api/Artigo");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                dados = JsonConvert.DeserializeObject<List<ArtigoDTO>>(content);

                dtCompra.Columns.Add("id", typeof(int));
                dtCompra.Columns.Add("Artigo", typeof(string));
                dtCompra.Columns.Add("Preco", typeof(float));
                dtCompra.Columns.Add("Qtd", typeof(int));
                dtCompra.Columns.Add("Iva", typeof(float));

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

                documento.Items.Add("PCO");
                documento.Items.Add("COT");
                documento.Items.Add("ECF");
                documento.Items.Add("VFR");
                documento.Items.Add("VFT");
                documento.Items.Add("VGT");
                documento.Items.Add("VNC");
                documento.Items.Add("VND");

                eliminarBtn.Enabled = false;

            }

            timerRefresh.Start();
        }

        private async void salvarBtn_Click(object sender, EventArgs e)
        {
            HttpResponseMessage response = null;

            if (documento.Text == "VFR")
            {

                artigos.Clear();
                foreach (var compraArtigo in compraArtigos)
                {
                    artigos.Add(new VfrArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = compraArtigo.preco,
                        qtd = compraArtigo.qtd,
                        iva = compraArtigo.iva
                    });
                }

                VfrDTO vfrs = new VfrDTO()
                {
                    documento = codigoDocumento.Text,
                    data = DateTime.Now,
                    fornecedorId = FornecedorDTO.fornecedorId,
                    vfrArtigo = artigos,
                    status = 1,
                };


                // Configuração do HttpClient
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://sua-api.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(vfrs);

                // Envio dos dados para a API
                response = await client.PostAsync("https://localhost:7200/api/Compra/Vfr", new StringContent(json, Encoding.UTF8, "application/json"));
            }

            if (documento.Text == "VFT")
            {

                vftArtigos.Clear();

                foreach (var compraArtigo in compraArtigos)
                {
                    vftArtigos.Add(new VftArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = compraArtigo.preco,
                        qtd = compraArtigo.qtd,
                        iva = compraArtigo.iva
                    });
                }

                VftDTO vfts = new VftDTO()
                {
                    documento = codigoDocumento.Text,
                    data = DateTime.Now,
                    fornecedorId = FornecedorDTO.fornecedorId,
                    vftArtigo = vftArtigos,
                    status = 1,
                };

                // Configuração do HttpClient
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://sua-api.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(vfts);

                // Envio dos dados para a API
                response = await client.PostAsync("https://localhost:7200/api/Compra/Vft", new StringContent(json, Encoding.UTF8, "application/json"));
            }

            if (documento.Text == "VGT")
            {
                vgtArtigos.Clear();

                foreach (var compraArtigo in compraArtigos)
                {
                    vgtArtigos.Add(new VgtArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = compraArtigo.preco,
                        qtd = compraArtigo.qtd,
                        iva = compraArtigo.iva
                    });
                }

                VgtDTO vgts = new VgtDTO()
                {
                    documento = codigoDocumento.Text,
                    data = DateTime.Now,
                    fornecedorId = FornecedorDTO.fornecedorId,
                    vgtArtigo = vgtArtigos,
                    status = 1,
                };


                // Configuração do HttpClient
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://sua-api.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(vgts);

                // Envio dos dados para a API
                response = await client.PostAsync("https://localhost:7200/api/Compra/Vgt", new StringContent(json, Encoding.UTF8, "application/json"));
            }

            if (documento.Text == "ECF")
            {

                ecfArtigos.Clear();

                foreach (var compraArtigo in compraArtigos)
                {
                    ecfArtigos.Add(new EcfArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = compraArtigo.preco,
                        qtd = compraArtigo.qtd,
                        iva = compraArtigo.iva
                    });
                }

                EncomendaFornecedorDTO ecfs = new EncomendaFornecedorDTO()
                {
                    documento = codigoDocumento.Text,
                    data = DateTime.Now,
                    fornecedorId = FornecedorDTO.fornecedorId,
                    ecfArtigo = ecfArtigos,
                    status = 1,
                };


                // Configuração do HttpClient
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://sua-api.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(ecfs);

                // Envio dos dados para a API
                response = await client.PostAsync("https://localhost:7200/api/Compra/Ecf", new StringContent(json, Encoding.UTF8, "application/json"));
            }

            if (documento.Text == "VNC")
            {
                vncArtigos.Clear();
                foreach (var compraArtigo in compraArtigos)
                {
                    vncArtigos.Add(new VncArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = compraArtigo.preco,
                        qtd = compraArtigo.qtd,
                        iva = compraArtigo.iva
                    });
                }

                VncDTO vncs = new VncDTO()
                {
                    documento = codigoDocumento.Text,
                    data = DateTime.Now,
                    fornecedorId = FornecedorDTO.fornecedorId,
                    vncArtigo = vncArtigos,
                    status = 1,
                };

             

                // Configuração do HttpClient
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://sua-api.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(vncs);

                // Envio dos dados para a API
                response = await client.PostAsync("https://localhost:7200/api/Compra/Vnc", new StringContent(json, Encoding.UTF8, "application/json"));
            }

            if (documento.Text == "VND")
            {
                VndDTO vncs = new VndDTO()
                {
                    documento = codigoDocumento.Text,
                    data = DateTime.Now,
                    fornecedorId = FornecedorDTO.fornecedorId,
                    vndArtigo = vndArtigos,
                    status = 1,
                };
                vndArtigos.Clear();
                foreach (var compraArtigo in compraArtigos)
                {
                    vndArtigos.Add(new VndArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = compraArtigo.preco,
                        qtd = compraArtigo.qtd,
                        iva = compraArtigo.iva
                    });
                }

                // Configuração do HttpClient
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://sua-api.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(vncs);

                // Envio dos dados para a API
                response = await client.PostAsync("https://localhost:7200/api/Compra/Vnd", new StringContent(json, Encoding.UTF8, "application/json"));
            }

            if (documento.Text == "PCO")
            {

                pcoArtigos.Clear();

                foreach (var compraArtigo in compraArtigos)
                {
                    pcoArtigos.Add(new PedidoCotacaoArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = compraArtigo.preco,
                        iva = compraArtigo.iva
                    });
                }

                PedidoCotacaoDTO pcos = new PedidoCotacaoDTO()
                {
                    documento = codigoDocumento.Text,
                    data = DateTime.Now,
                    fornecedorId = FornecedorDTO.fornecedorId,
                    pcArtigo = pcoArtigos,
                    status = 1,
                    
                };

                // Configuração do HttpClient
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://sua-api.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(pcos);

                // Envio dos dados para a API
                response = await client.PostAsync("https://localhost:7200/api/Compra/Pco", new StringContent(json, Encoding.UTF8, "application/json"));
            }

            if (documento.Text == "COT")
            {
                cotArtigos.Clear();

                foreach (var compraArtigo in compraArtigos)
                {
                    cotArtigos.Add(new CotacaoArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = compraArtigo.preco,
                        qtd = compraArtigo.qtd,
                        iva = compraArtigo.iva
                    });
                }


                CotacaoDTO cots = new CotacaoDTO()
                {
                    documento = codigoDocumento.Text,
                    data = DateTime.Now,
                    fornecedorId = FornecedorDTO.fornecedorId,
                    cArtigo = cotArtigos,
                    status = 1,
                };


                // Configuração do HttpClient
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://sua-api.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Conversão do objeto Film para JSON
                string json = System.Text.Json.JsonSerializer.Serialize(cots);

                // Envio dos dados para a API
                response = await client.PostAsync("https://localhost:7200/api/Compra/Pco", new StringContent(json, Encoding.UTF8, "application/json"));

            }

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Compra Com Sucesso", "Feito Com Sucesso", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Ocorreu um erro ao tentar Salvar", "Erro", MessageBoxButtons.RetryCancel);
            }
        }

        private void clienteBtn_Click(object sender, EventArgs e)
        {
            FornecedorListagem clienteListagem = new FornecedorListagem();
            clienteListagem.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo;
                int idCompraArtigo = tabelaCompra.Rows.Count;
                List<compraArtigo> refreshCompraArtigo = new List<compraArtigo>();
                int i = 1;

                dtCompra.Rows.Clear();
                tabelaCompra.DataSource = dtCompra;

                codigo = dados.Where(art => art.id == artigoId).First().codigo;

                foreach (var ca in compraArtigos) 
                {
                    var cArtigo = new compraArtigo
                    {
                        id = i,
                        codigo = ca.codigo,
                        preco = ca.preco,
                        qtd = ca.qtd,
                        iva = ca.iva,
                    };
                    refreshCompraArtigo.Add(cArtigo);
                    i++;          
                }

                compraArtigos.Clear();

                compraArtigos = refreshCompraArtigo;

                compraArtigos.Add(new compraArtigo()
                {
                    id = idCompraArtigo,
                    codigo = codigo,
                    preco = float.Parse(precotxt.Text),
                    qtd = int.Parse(Qtd.Text),
                    iva = float.Parse(iva.Text)

                });

                if (documento.Text == "VFR")
                {
                    artigos.Add(new VfrArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = float.Parse(precotxt.Text),
                        qtd = int.Parse(Qtd.Text),
                        iva = float.Parse(iva.Text)
                    });

                    foreach (var vfr in compraArtigos)
                    {

                        dtCompra.Rows.Add(vfr.id, vfr.codigo, vfr.preco, vfr.qtd, vfr.iva);

                        tabelaCompra.DataSource = dtCompra;
                    }
                }

                if (documento.Text == "VFT")
                {
                    vftArtigos.Add(new VftArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = float.Parse(precotxt.Text),
                        qtd = int.Parse(Qtd.Text),
                        iva = float.Parse(iva.Text)
                    });

                    foreach (var vft in compraArtigos)
                    {
                        idCompraArtigo = tabelaCompra.Rows.Count;
                        dtCompra.Rows.Add(vft.id, vft.codigo, vft.preco, vft.qtd, vft.iva);

                        tabelaCompra.DataSource = dtCompra;
                    }
                }

                if (documento.Text == "PCO")
                {
                    pcoArtigos.Add(new PedidoCotacaoArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = float.Parse(precotxt.Text),
                        iva = float.Parse(iva.Text)
                    });


                    foreach (var pco in compraArtigos)
                    {

                        dtCompra.Rows.Add(pco.id, pco.codigo, pco.preco, 0, pco.iva);

                        tabelaCompra.DataSource = dtCompra;
                    }
                }

                if (documento.Text == "COT")
                {
                    cotArtigos.Add(new CotacaoArtigoDTO()
                    {

                        artigoId = artigoId,
                        preco = float.Parse(precotxt.Text),
                        qtd = int.Parse(Qtd.Text),
                        iva = float.Parse(iva.Text)
                    });


                    foreach (var cot in compraArtigos)
                    {

                        dtCompra.Rows.Add(cot.id, cot.codigo, cot.preco, cot.qtd, cot.iva);

                        tabelaCompra.DataSource = dtCompra;
                    }
                }

                if (documento.Text == "VND")
                {
                    vndArtigos.Add(new VndArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = float.Parse(precotxt.Text),
                        qtd = int.Parse(Qtd.Text),
                        iva = float.Parse(iva.Text)
                    });

                    foreach (var vnd in compraArtigos)
                    {
                        dtCompra.Rows.Add(vnd.id, vnd.codigo, vnd.preco, vnd.qtd, vnd.iva);

                        tabelaCompra.DataSource = dtCompra;
                    }
                }

                if (documento.Text == "VNC")
                {
                    vncArtigos.Add(new VncArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = float.Parse(precotxt.Text),
                        qtd = int.Parse(Qtd.Text),
                        iva = float.Parse(iva.Text)
                    });

                    foreach (var vnc in compraArtigos)
                    {
                        dtCompra.Rows.Add(vnc.id, vnc.codigo, vnc.preco, vnc.qtd, vnc.iva);

                        tabelaCompra.DataSource = dtCompra;
                    }
                }
                if (documento.Text == "VGT")
                {
                    vncArtigos.Add(new VncArtigoDTO()
                    {
                        artigoId = artigoId,
                        preco = float.Parse(precotxt.Text),
                        qtd = int.Parse(Qtd.Text),
                        iva = float.Parse(iva.Text)
                    });

                    foreach (var vgt in compraArtigos)
                    {
                        dtCompra.Rows.Add(vgt.id, vgt.codigo, vgt.preco, vgt.qtd, vgt.iva);

                        tabelaCompra.DataSource = dtCompra;
                    }
                }
            }
            catch { return; }
        }

        private void tabelaArtigos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Obtém o valor da célula clicada
                    string id = tabelaArtigos.Rows[e.RowIndex].Cells[0].Value.ToString();

                    artigoId = int.Parse(id);

                }
            }
            catch { return; }
        }

        private async void documento_SelectedIndexChanged(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"https://localhost:7200/api/serie/codigoDocumento/{documento.Text}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                string dados = content.ToString();

                codigoDocumentotxt.Text = dados.ToString();
            }
        }

        private void eliminarBtn_Click(object sender, EventArgs e)
        {
            var selectedRows = tabelaCompra.SelectedRows;

            foreach (DataGridViewRow row in selectedRows)
            {
                if (row != null && row.Index >= 0) // Verifica se a linha está válida
                {
                    int id = int.Parse(row.Cells[0].Value?.ToString()); // Substitua 0 pelo índice da coluna desejada
                                                                        // Ou faça algo mais útil com o valor
                    idCompra.Add(id);
                }
            }

            foreach (int id in idCompra)
            {
                var result = compraArtigos.Where(c => c.id == id).First();

                int index = compraArtigos.IndexOf(result);

                compraArtigos.RemoveAt(index);
            }

            dtCompra.Rows.Clear();
            tabelaCompra.DataSource = dtCompra;


            foreach (var ca in compraArtigos)
            {

                dtCompra.Rows.Add(ca.id, ca.codigo.ToString(), ca.preco, ca.qtd, ca.iva);

                tabelaCompra.DataSource = dtCompra;
            }
            idCompra.Clear();
        }

        private void tabelaCompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            eliminarBtn.Enabled = true;
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var response= await client.GetAsync($"https://localhost:7200/api/Artigo/Search/{textBox1.Text}"); ;

            if (string.IsNullOrWhiteSpace(textBox1.Text.ToString()))
            {
                response = await client.GetAsync("https://localhost:7200/api/Artigo");
            }

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

        private void fecharBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void excelBtn_Click(object sender, EventArgs e)
        {
            exportar exp = new exportar();
            exp.ShowDialog();
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

        private void excelBtn_MouseLeave(object sender, EventArgs e)
        {
            excelBtn.BackColor = Color.FromArgb(64,64,64);
            excelBtn.ForeColor = Color.White;
        }

        private void excelBtn_MouseMove(object sender, MouseEventArgs e)
        {
            excelBtn.BackColor= Color.White; 
            excelBtn.ForeColor= Color.Black;   
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            fornecedortxt.Text = $"Fornecedor: {StaticProperty.nome}";
        }
    }
}
