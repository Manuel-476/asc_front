using AscFrontEnd.DTOs.ContasCorrentes;
using AscFrontEnd.DTOs.Enums;
using AscFrontEnd.DTOs.StaticsDto;
using AscFrontEnd.DTOs.Stock;
using EAscFrontEnd;
using ERP_Buyer.Application.DTOs.Documentos;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd
{
    public partial class ContasCorrentes : Form
    {
        List<VftDTO> dados;
        DataTable entidadeTable;
        DataTable entidadeFornTable;
        public int id;
        HttpClient client;
        public ContasCorrentes()
        {
            InitializeComponent();

            dados = new List<VftDTO>();

            client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            client.BaseAddress = new Uri("https://localhost:7200/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.DeepSkyBlue;
            label5.ForeColor = Color.DeepSkyBlue;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromArgb(0, 120, 215);
            label5.ForeColor = Color.FromArgb(0, 120, 215);

        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            /*pictureBox3.BackColor = Color.DeepSkyBlue;
            label6.ForeColor = Color.DeepSkyBlue;*/
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            /*pictureBox3.BackColor = Color.FromArgb(0, 120, 215);
            label6.ForeColor = Color.FromArgb(0, 120, 215);*/
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ContasCorrentes_Load(object sender, EventArgs e)
        {
            float result = 0f;
            float valorAdiantamento = 0f;

            var vftResult = StaticProperty.vfts.Where(x => x.fornecedor.empresaid == StaticProperty.empresaId && x.pago == OpcaoBinaria.Nao).GroupBy(vft => vft.fornecedorId);
            var fornecedor = StaticProperty.fornecedores.Where(x => x.empresaid == StaticProperty.empresaId || x.empresaid == 0).ToList();

            GetContaPagar();

            GetContaReceber();

           // timer1.Start();

        }

        private void correnteTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void correnteTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void radioFornecedor_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioCliente_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void aprovaBtn_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void aprovaBtn_MouseLeave(object sender, EventArgs e)
        {

        }

        private async void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                LiquidaDivida ld = null;
                if (this.id > 0)
                {
                    if (tabControl1.SelectedTab == contaReceberTab)
                    {
                        ld = new LiquidaDivida(id, Entidade.cliente);
                        ld.ShowDialog();
                    }
                    else if (tabControl1.SelectedTab == contaPagarTab)
                    {
                        ld = new LiquidaDivida(id, Entidade.fornecedor);
                        ld.ShowDialog();
                    }

                    await this.RefreshDocs();

                    GetContaReceber();
                    GetContaPagar();
                }
                else
                {
                    return;
                }
            }
            catch { return; }
        }

        private void aprovaBtn_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            /*  RegularAdiantamentoForm form = null;
              if (this.id > 0)
              {
                  if (contaReceberTab.Focused)
                  {
                      form = new RegularAdiantamentoForm(Entidade.cliente, id);
                  }
                  else if (contaPagarTab.Focused)
                  {
                      form = new RegularAdiantamentoForm(Entidade.fornecedor, id);
                  }

                  form.ShowDialog();
              }
              else
              {
                  return;
              }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void adiantaBtn_Click(object sender, EventArgs e)
        {
            AdiantamentoForm form = new AdiantamentoForm();
            form.ShowDialog();
        }

        private async Task RefreshDocs()
        {
            var responseVft = await client.GetAsync($"api/Compra/VftByRelations");

            if (responseVft.IsSuccessStatusCode)
            {
                var contentVft = await responseVft.Content.ReadAsStringAsync();
                StaticProperty.vfts = JsonConvert.DeserializeObject<List<VftDTO>>(contentVft);

            }

            var responseFt = await client.GetAsync($"api/Venda/FtByRelations");

            if (responseFt.IsSuccessStatusCode)
            {
                var contentFt = await responseFt.Content.ReadAsStringAsync();
                StaticProperty.fts = JsonConvert.DeserializeObject<List<FtDTO>>(contentFt);
            }

            // Nota Pagamento
            var responseNp = await client.GetAsync($"api/ContaCorrente/Nps");

            if (responseNp.IsSuccessStatusCode)
            {
                var contentNp = await responseNp.Content.ReadAsStringAsync();
                StaticProperty.nps = JsonConvert.DeserializeObject<List<NpDTO>>(contentNp);

            }

            // Recibo
            var responseRe = await client.GetAsync($"api/ContaCorrente/Res");

            if (responseRe.IsSuccessStatusCode)
            {
                var contentRe = await responseRe.Content.ReadAsStringAsync();
                StaticProperty.recibos = JsonConvert.DeserializeObject<List<ReciboDTO>>(contentRe);

            }

            var responseAdForn = await client.GetAsync($"api/ContaCorrente/Adiantamento/Fornecedor");

            if (responseAdForn.IsSuccessStatusCode)
            {
                var contentAdForn = await responseAdForn.Content.ReadAsStringAsync();
                StaticProperty.adiantamentoForns = JsonConvert.DeserializeObject<List<AdiantamentoFornDTO>>(contentAdForn);


            }

            var responseAdCliente = await client.GetAsync($"api/ContaCorrente/Adiantamento/Cliente");

            if (responseAdCliente.IsSuccessStatusCode)
            {
                var contentAdCliente = await responseAdCliente.Content.ReadAsStringAsync();
                StaticProperty.adiantamentoClientes = JsonConvert.DeserializeObject<List<AdiantamentoClienteDTO>>(contentAdCliente);

            }

            var responseRegAdForn = await client.GetAsync($"api/ContaCorrente/Regular/Adiantamento/Fornecedor/WithRelations");

            if (responseRegAdForn.IsSuccessStatusCode)
            {
                var contentRegAdForn = await responseRegAdForn.Content.ReadAsStringAsync();
                StaticProperty.regAdiantamentoForns = JsonConvert.DeserializeObject<List<RegAdiantamentoFornDTO>>(contentRegAdForn);

            }

            var responseRegAdCliente = await client.GetAsync($"api/ContaCorrente/Regular/Adiantamento/Cliente/WithRelations");

            if (responseRegAdCliente.IsSuccessStatusCode)
            {
                var contentRegAdCliente = await responseRegAdCliente.Content.ReadAsStringAsync();
                StaticProperty.regAdiantamentoClientes = JsonConvert.DeserializeObject<List<RegAdiantamentoClienteDTO>>(contentRegAdCliente);

            }

        }

        private void correnteTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void correnteTableCl_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Obtém o valor da célula clicada
                    string id = correnteTableCl.Rows[e.RowIndex].Cells[0].Value.ToString();

                    this.id = int.Parse(id);

                    ListasContasCorrentes lcCorrente = new ListasContasCorrentes(this.id, Entidade.cliente);
                    lcCorrente.ShowDialog();
                }
            }
            catch { return; }
        }

        private void correnteTableCl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            float divida = 0;
            float regulado = 0;
            float valorAdiantamento = 0;

            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Obtém o valor da célula clicada
                    string id = correnteTableCl.Rows[e.RowIndex].Cells[0].Value.ToString();

                    this.id = int.Parse(id);
                }
                var result = StaticProperty.fts.Where(ft => ft.clienteId == id).ToList();

                foreach (var item in result)
                {
                    if (item.pago == Enums.OpcaoBinaria.Nao)
                    {
                        divida += item.ftArtigo.Sum(d => d.preco * d.qtd);
                        regulado += StaticProperty.recibos.Where(re => re.ftRecibos.First().ftId == item.id).Sum(np => np.quantia);
                        valorAdiantamento = StaticProperty.clientes.Where(f => f.id == id).Sum(f => f.adiantamentos.Where(x => x.resolvido == OpcaoBinaria.Nao).Sum(x => x.valorAdiantado));
                    }
                }

                dividaResult.Text = divida.ToString("F2");
                liqResult.Text = regulado.ToString("F2");
                adiantamentoResult.Text = valorAdiantamento.ToString("F2");

               
            }
            catch
            {
                return;
            }
        }

        public void GetContaPagar()
        {
            float result = 0f;
            float regulado = 0f;
            float valorAdiantamento = 0f;

            string nomeFornecedor = string.Empty;

            entidadeFornTable = new DataTable();

            entidadeFornTable.Columns.Add("Codigo Entidade", typeof(int));
            entidadeFornTable.Columns.Add("Entidade", typeof(string));
            entidadeFornTable.Columns.Add("Por Pagar", typeof(float));
            entidadeFornTable.Columns.Add("Adiantado", typeof(float));
            entidadeFornTable.Columns.Add("Estado", typeof(string));

            /* if (!StaticProperty.vfts.Any() && !StaticProperty.adiantamentoForns.Any())
             {
                 MessageBox.Show("Nenhum Documento Encontrado!", "Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 radioCliente.Checked = true;
                 return;
             }*/
            DataTable dataTable = (DataTable)correnteTable.DataSource;

            if (dataTable != null)
            {
                dataTable.Clear(); // Limpa todas as linhas da fonte de dados
            }
            var fornecedor = StaticProperty.fornecedores.Where(x => x.empresaid == StaticProperty.empresaId || x.empresaid == 0).ToList();
            var vftResult = StaticProperty.vfts.Where(x => x.pago == OpcaoBinaria.Nao).GroupBy(vft => vft.fornecedorId);

            // Adicionando linhas ao DataTable
            if (vftResult.Any())
            {
                foreach (var vft in vftResult)
                {
                    var fornEmpresaId = StaticProperty.fornecedores.Where(x => x.id == vft.Key).First().empresaid;
                    if (fornEmpresaId == StaticProperty.empresaId || fornEmpresaId == 0)
                    {
                        if (vft.First().vftArtigo.Any())
                        {
                            result = vft.Where(x => x.pago == OpcaoBinaria.Nao).Sum(vt => vt.vftArtigo.Sum(va => va.preco * va.qtd));
                            
                            foreach (var v in vft.ToList()) {
                                regulado += StaticProperty.nps.Where(np => np.vftNps.Where(vt => vt.vftId == v.id).Any()).Sum(np => np.quantia);
                            } 
                        }
                    }
                    if (StaticProperty.fornecedores.Where(f => f.id == vft.Key).Any())
                    {
                        if (StaticProperty.fornecedores.Where(f => f.id == vft.Key).First().adiantamentos.Any())
                        {
                            valorAdiantamento = StaticProperty.fornecedores.Where(f => f.id == vft.Key).Sum(f => f.adiantamentos.Where(x => x.resolvido == OpcaoBinaria.Nao).Sum(x => x.valorAdiantado));
                        }

                        if (StaticProperty.fornecedores.Where(f => f.id == vft.Key).Any())
                        {
                            nomeFornecedor = StaticProperty.fornecedores.Where(f => f.id == vft.Key).First().nome_fantasia;
                        }
                    }
                    entidadeFornTable.Rows.Add(vft.Key, nomeFornecedor, result - regulado, valorAdiantamento, "Não regulada");

                    //    correnteTable.DataSource = entidadeTable;
                }
            }
            else if (StaticProperty.adiantamentoForns.Any())
            {
                foreach (var ad in fornecedor)
                {
                    if (vftResult.Where(x => x.Key == ad.id).First().First().vftArtigo.Any())
                    {
                        result = vftResult.Where(x => x.Key == ad.id).First().Sum(vt => vt.vftArtigo.Sum(va => va.preco * va.qtd));
                    }

                    if (fornecedor.Where(f => f.id == ad.id).First().adiantamentos.Any())
                    {
                        valorAdiantamento = fornecedor.Where(f => f.id == ad.id).Sum(f => f.adiantamentos.Where(x => x.resolvido == OpcaoBinaria.Nao).Sum(x => x.valorAdiantado));
                    }
                    if (fornecedor.Where(f => f.id == ad.id).Any())
                    {
                        nomeFornecedor = fornecedor.Where(f => f.id == ad.id).First().nome_fantasia;
                    }
                    entidadeFornTable.Rows.Add(ad.id, nomeFornecedor, result - regulado, valorAdiantamento, "Não regulada");
                }
                //correnteTable.DataSource = entidadeTable;
            }
            correnteTable.DataSource = entidadeFornTable;
        }

        public void GetContaReceber()
        {
            string nomeCliente = string.Empty;
            float valorAdiantamento = 0;
            float regulado = 0f;
            float result = 0;
            var cliente = StaticProperty.clientes.Where(x => x.empresaid == StaticProperty.empresaId || x.empresaid == 0).ToList();

            entidadeTable = new DataTable();

            entidadeTable.Columns.Add("Codigo Entidade", typeof(int));
            entidadeTable.Columns.Add("Entidade", typeof(string));
            entidadeTable.Columns.Add("Por Pagar", typeof(float));
            entidadeTable.Columns.Add("Adiantado", typeof(float));
            entidadeTable.Columns.Add("Estado", typeof(string));


            /*  if (!StaticProperty.fts.Any() && !StaticProperty.adiantamentoClientes.Any())
              {
                  MessageBox.Show("Nenhum Documento Encontrado!", "Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  radioFornecedor.Checked = true;
                  return;
              }
            */
            DataTable dataTable = (DataTable)correnteTableCl.DataSource;

            if (dataTable != null)
            {
                dataTable.Clear(); // Limpa todas as linhas da fonte de dados
            }

            var ftResult = StaticProperty.fts.Where(x => x.pago == OpcaoBinaria.Nao).GroupBy(ft => ft.clienteId);

            // Adicionando linhas ao DataTable
            foreach (var ft in ftResult)
            {
                if (ftResult.Where(x => x.Key == ft.Key).Any())
                {
                    var clEmpresaId = StaticProperty.clientes.Where(x => x.id == ft.Key).First().empresaid;
                    if (clEmpresaId == StaticProperty.empresaId || clEmpresaId == 0)
                    {
                        if (ftResult.Where(x => x.Key == ft.Key).First().First().ftArtigo.Any())
                        {
                            result = ft.Sum(vt => vt.ftArtigo.Sum(va => va.preco * va.qtd));

                            foreach (var v in ft.ToList())
                            {
                                regulado += StaticProperty.recibos.Where(re => re.ftRecibos.Where(vt => vt.ftId == v.id).Any()).Sum(np => np.quantia);
                            }
                        }
                    }
                }
                if (cliente.Where(f => f.id == ft.Key).Any())
                {
                    if (cliente.Where(f => f.id == ft.Key).First().adiantamentos.Any())
                    {
                        valorAdiantamento = StaticProperty.clientes.Where(f => f.id == ft.Key).Sum(cl => cl.adiantamentos.Where(x => x.resolvido == OpcaoBinaria.Nao).Sum(x => x.valorAdiantado));
                    }
                    if (cliente.Where(f => f.id == ft.Key).Any())
                    {
                        nomeCliente = StaticProperty.clientes.Where(c => c.id == ft.Key).First().nome_fantasia;
                    }
                }

                entidadeTable.Rows.Add(ft.Key, nomeCliente, result - regulado, valorAdiantamento, "Não regulada");

                //  correnteTableCl.DataSource = entidadeTable;
            }

            if (StaticProperty.adiantamentoClientes.Any())
            {
                foreach (var ad in cliente)
                {
                    if (ftResult != null)
                    {
                        if (ftResult.Where(x => x.Key == ad.id).Any())
                        {
                            if (ftResult.Where(x => x.Key == ad.id).First().First().ftArtigo.Any())
                            {
                                result = ftResult.Where(x => x.Key == ad.id).First().Sum(vt => vt.ftArtigo.Sum(va => va.preco * va.qtd));
                            }
                        }
                    }
                    if (cliente.Where(f => f.id == ad.id).First().adiantamentos.Any())
                    {
                        valorAdiantamento = cliente.Where(f => f.id == ad.id).Sum(f => f.adiantamentos.Where(x => x.resolvido == OpcaoBinaria.Nao).Sum(x => x.valorAdiantado));
                    }
                    if (cliente.Where(f => f.id == ad.id).Any())
                    {
                        nomeCliente = cliente.Where(f => f.id == ad.id).First().nome_fantasia;
                    }

                    entidadeTable.Rows.Add(ad.id, nomeCliente, result - regulado, valorAdiantamento, "Não regulada");
                }
                // correnteTableCl.DataSource = entidadeTable;
            }
            correnteTableCl.DataSource = entidadeTable;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
         
        }

        private void ContasCorrentes_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            timer1.Dispose();
        }

        private void correnteTable_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            float divida = 0;
            float regulado = 0;
            float valorAdiantamento = 0;

            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Obtém o valor da célula clicada
                    string id = correnteTable.Rows[e.RowIndex].Cells[0].Value.ToString();

                    this.id = int.Parse(id);
                }

                var result = StaticProperty.vfts.Where(vft => vft.fornecedorId == id).ToList();

                foreach (var item in result)
                {
                    if (item.pago == Enums.OpcaoBinaria.Nao)
                    {
                        divida += item.vftArtigo.Sum(d => d.preco * d.qtd);
                        regulado += StaticProperty.nps.Where(np => np.vftNps.First().vftId == item.id).Sum(np => np.quantia);
                        valorAdiantamento = StaticProperty.fornecedores.Where(f => f.id == id).Sum(f => f.adiantamentos.Where(x => x.resolvido == OpcaoBinaria.Nao).Sum(x => x.valorAdiantado));
                    }
                }

                dividaResult.Text = divida.ToString("F2");
                liqResult.Text = regulado.ToString("F2");
                adiantamentoResult.Text = valorAdiantamento.ToString("F2");

              
            }
            catch
            {
                return;
            }
        }

        private void correnteTable_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void correnteTable_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Obtém o valor da célula clicada
                    string id = correnteTable.Rows[e.RowIndex].Cells[0].Value.ToString();

                    this.id = int.Parse(id);

                    ListasContasCorrentes lcCorrente = new ListasContasCorrentes(this.id, Entidade.fornecedor);
                    lcCorrente.ShowDialog();
                }

            }
            catch
            {
                return;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.GetContaPagar();
            this.GetContaReceber();
        }
    }


}
