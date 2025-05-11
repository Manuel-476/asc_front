using AscFrontEnd.DTOs.Cliente;
using AscFrontEnd.DTOs.Fornecedor;
using AscFrontEnd.DTOs.StaticsDto;
using AscFrontEnd.DTOs.Stock;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AscFrontEnd.DTOs.Enums.Enums;
using AscFrontEnd.DTOs.ContasCorrentes;
using AscFrontEnd.Application;
using AscFrontEnd.Application.Validacao;

namespace AscFrontEnd
{
    public partial class RegularAdiantamentoForm : Form
    {
        ClienteDTO cliente;
        FornecedorDTO fornecedor;
        Entidade _entidade;
        Documento _getCodigoDocumento;

        int _entidadeId;
        int adiantamentoId;
        int documentoId;

        float valorAdiantado = 0;
        float valorRegulado = 0;

        public RegularAdiantamentoForm(Entidade entidade, int entidadeId)
        {
            InitializeComponent();

            _entidade = entidade;
            _entidadeId = entidadeId;
            _getCodigoDocumento = new Documento();

            if(entidade == Entidade.cliente) 
            {
                if(StaticProperty.clientes.Where(cl => cl.id == entidadeId).Any())
                {
                    cliente = StaticProperty.clientes.Where(cl => cl.id == entidadeId).First();
                }
            }
            else if(entidade == Entidade.fornecedor) 
            {
                if(StaticProperty.fornecedores.Where(f => f.id == entidadeId).Any())
                { 
                       fornecedor = StaticProperty.fornecedores.Where(f => f.id == entidadeId).First();
                }

            }

            valorDocumento.KeyPress += ValidacaoForms.TratarKeyPress; // Ajustado
            valorDocumento.TextChanged += ValidacaoForms.TratarTextChanged;
        }

        private void RegularAdiantamentoForm_Load(object sender, EventArgs e)
        {

            this.carregarTabelas( ref valorAdiantado, ref valorRegulado);

            adiantado.Text = $"Adiantado: {valorAdiantado.ToString("F2")}";
            liquidado.Text = $"Liquidado: {valorRegulado.ToString("F2")}";
        }

        private void adiantamentoTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                adiantamentoId = int.Parse(adiantamentoTable.Rows[e.RowIndex].Cells[0].Value.ToString());

                if (_entidade == Entidade.cliente)
                {
                   // documentoAdiantamento.Text = StaticProperty.adiantamentoClientes.Where(ad => ad.id == adiantamentoId).First().documento;
                }
                else if (_entidade == Entidade.fornecedor)
                {
                   // documentoAdiantamento.Text = StaticProperty.adiantamentoForns.Where(ad => ad.id == adiantamentoId).First().documento;
                }
            }
            catch { return; }
        }

        private void docRegularTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                documentoId = int.Parse(docRegularTable.Rows[e.RowIndex].Cells[0].Value.ToString());

                if (_entidade == Entidade.cliente)
                {
                    //documentoPagamento.Text = StaticProperty.frs.Where(ad => ad.id == documentoId).First().documento;
                    valorDocumento.Text = StaticProperty.frs.Where(x => x.id == documentoId).Sum(x => x.frArtigo.Sum(f => f.preco * f.qtd)).ToString("F2");

                }
                else if (_entidade == Entidade.fornecedor)
                {
                  //  documentoPagamento.Text = StaticProperty.vfrs.Where(ad => ad.id == documentoId).First().documento;
                    valorDocumento.Text = StaticProperty.vfrs.Where(x => x.id == documentoId).Sum(x => x.vfrArtigo.Sum(f => f.preco * f.qtd)).ToString("F2");
                }
            }
            catch { return; }
        }

        private async void botaoSalvar_Click(object sender, EventArgs e)
        {
            string json;
            string documento = string.Empty;
            HttpResponseMessage response = null;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);
            client.BaseAddress = new Uri("https://sua-api.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (_entidade == Entidade.cliente)
            {
                documento = await Documento.GetCodigoDocumentoAsync("RGC");

                var fr = StaticProperty.frs.Where(x => x.id == documentoId).First();
                
                var regAdiantamento = new RegAdiantamentoClienteDTO()
                {
                    adiantamentoId = adiantamentoId,
                    documento = documento,
                    frId = documentoId,
                    status = DocState.ativo,
                    empresaId = StaticProperty.empresaId,
                };
                json = System.Text.Json.JsonSerializer.Serialize(regAdiantamento);

                // Envio dos dados para a API
                response = await client.PostAsync($"https://localhost:7200/api/ContaCorrente/Regular/Adiantamento/Cliente", new StringContent(json, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var responseRegAdCliente = await client.GetAsync($"https://localhost:7200/api/ContaCorrente/Regular/Adiantamento/Cliente/WithRelations");

                    var responseRegAdForn = await client.GetAsync($"https://localhost:7200/api/ContaCorrente/Regular/Adiantamento/Fornecedor/WithRelations");
                 
                    var responseAdCliente = await client.GetAsync($"https://localhost:7200/api/ContaCorrente/Adiantamento/Cliente");

                    var responseAdForn = await client.GetAsync($"https://localhost:7200/api/ContaCorrente/Adiantamento/Fornecedor");

                    if (responseAdForn.IsSuccessStatusCode)
                    {
                        var contentAdForn = await responseAdForn.Content.ReadAsStringAsync();
                        StaticProperty.adiantamentoForns = JsonConvert.DeserializeObject<List<AdiantamentoFornDTO>>(contentAdForn);
                    }

                    if (responseAdCliente.IsSuccessStatusCode)
                    {
                        var contentAdCliente = await responseAdCliente.Content.ReadAsStringAsync();
                        StaticProperty.adiantamentoClientes = JsonConvert.DeserializeObject<List<AdiantamentoClienteDTO>>(contentAdCliente);
                    }

                    if (responseRegAdCliente.IsSuccessStatusCode)
                    {
                        var contentRegAdCliente = await responseRegAdCliente.Content.ReadAsStringAsync();
                        StaticProperty.regAdiantamentoClientes = JsonConvert.DeserializeObject<List<RegAdiantamentoClienteDTO>>(contentRegAdCliente);
                    }
                    if (responseRegAdForn.IsSuccessStatusCode)
                    {
                        var contentRegAdForn = await responseRegAdForn.Content.ReadAsStringAsync();
                        StaticProperty.regAdiantamentoForns = JsonConvert.DeserializeObject<List<RegAdiantamentoFornDTO>>(contentRegAdForn);
                    }

                    var result = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(result.ToString(), "Feito Com Sucesso", MessageBoxButtons.OK,MessageBoxIcon.Information);

                    this.carregarTabelas(ref valorAdiantado,ref valorRegulado);

                    adiantado.Text = $"Adiantado: {valorAdiantado.ToString("F2")}";
                    liquidado.Text = $"Liquidado: {valorRegulado.ToString("F2")}";
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao tentar Salvar", "Erro", MessageBoxButtons.RetryCancel);
                }
            }
            else if (_entidade == Entidade.fornecedor)
            {
                documento = await Documento.GetCodigoDocumentoAsync("RGF");
                var vfr = StaticProperty.vfrs.Where(x => x.id == documentoId).First();

                var regAdiantamento = new RegAdiantamentoFornDTO()
                {
                    adiantamentoId = adiantamentoId,
                    documento = documento,
                    vfrId = documentoId,
                    status = DocState.ativo,
                    empresaId = StaticProperty.empresaId,
                };
                json = System.Text.Json.JsonSerializer.Serialize(regAdiantamento);

                // Envio dos dados para a API
                response = await client.PostAsync($"https://localhost:7200/api/ContaCorrente/Regular/Adiantamento/Fornecedor", new StringContent(json, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var responseRegAdForn = await client.GetAsync($"https://localhost:7200/api/ContaCorrente/Regular/Adiantamento/Fornecedor/WithRelations");

                    if (responseRegAdForn.IsSuccessStatusCode)
                    {
                        var contentRegAdForn = await responseRegAdForn.Content.ReadAsStringAsync();
                        StaticProperty.regAdiantamentoForns = JsonConvert.DeserializeObject<List<RegAdiantamentoFornDTO>>(contentRegAdForn);
                    }
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao tentar Salvar", "Erro", MessageBoxButtons.RetryCancel);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("Documento", typeof(string));
            dt.Columns.Add("Valor", typeof(string));

            if (_entidade == Entidade.cliente)
            {
                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.adiantamentoClientes.Where(cl => cl.clienteId == _entidadeId && cl.resolvido == OpcaoBinaria.Nao))
                {
                    if (item.documento.ToUpper().Contains(textBox1.Text.ToUpper().ToString()) || item.created_at.ToString().ToUpper().Contains(textBox1.Text.ToUpper().ToString()))
                    {
                        dt.Rows.Add(item.id, item.documento, item.valorAdiantado);

                        adiantamentoTable.DataSource = dt;
                    }
                }
            }
            else if (_entidade == Entidade.fornecedor)
            {
                foreach (var item in StaticProperty.adiantamentoForns.Where(f => f.fornecedorId == _entidadeId))
                {
                    if (item.documento.ToUpper().Contains(textBox1.Text.ToUpper().ToString()) || item.created_at.ToString().ToUpper().Contains(textBox1.Text.ToUpper().ToString()))
                    {
                        dt.Rows.Add(item.id, item.documento, item.valorAdiantado);

                        docRegularTable.DataSource = dt;
                    }
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataTable dtDocs = new DataTable();
            dtDocs.Columns.Add("id", typeof(int));
            dtDocs.Columns.Add("Documento", typeof(string));
            dtDocs.Columns.Add("Valor", typeof(string));

            if (_entidade == Entidade.cliente)
            {
                foreach (var item in StaticProperty.frs.Where(cl => cl.clienteId == _entidadeId))
                {
                    if (item.documento.ToUpper().Contains(textBox1.Text.ToUpper().ToString()) || item.created_at.ToString().ToUpper().Contains(textBox1.Text.ToUpper().ToString()))
                    {
                        dtDocs.Rows.Add(item.id, item.documento, item.frArtigo.Sum(x => x.preco * x.qtd));

                        docRegularTable.DataSource = dtDocs;
                    }
                }
            }
            else if (_entidade == Entidade.fornecedor)
            {
                foreach (var item in StaticProperty.vfrs.Where(f => f.fornecedorId == _entidadeId))
                {
                    if (item.documento.ToUpper().Contains(textBox1.Text.ToUpper().ToString()) || item.created_at.ToString().ToUpper().Contains(textBox1.Text.ToUpper().ToString()))
                    {
                        dtDocs.Rows.Add(item.id, item.documento, item.vfrArtigo.Sum(x => x.preco * x.qtd));

                        docRegularTable.DataSource = dtDocs;
                    }
                }
            }
        }

        private void carregarTabelas(ref float valorAdiantado, ref float valorRegulado) 
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("Documento", typeof(string));
            dt.Columns.Add("Valor", typeof(string));

            DataTable dtDocs = new DataTable();
            dtDocs.Columns.Add("id", typeof(int));
            dtDocs.Columns.Add("Documento", typeof(string));
            dtDocs.Columns.Add("Valor", typeof(string));

            if (_entidade == Entidade.cliente)
            {
                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.adiantamentoClientes.Where(cl => cl.clienteId == _entidadeId && cl.resolvido == OpcaoBinaria.Nao))
                {
                    valorAdiantado += item.valorAdiantado;

                    if (StaticProperty.regAdiantamentoClientes.Where(x => x.adiantamentoId == item.id).Any())
                    {
                        valorRegulado += StaticProperty.regAdiantamentoClientes.Where(x => x.adiantamentoId == item.id).Sum(x => x.fr.frArtigo.Sum(f => f.preco * f.qtd));
                    }

                    dt.Rows.Add(item.id, item.documento, item.valorAdiantado);

                   
                }
               
                foreach (var item in StaticProperty.frs.Where(cl => cl.clienteId == _entidadeId).ToList())
                {
                    dtDocs.Rows.Add(item.id, item.documento, item.frArtigo.Sum(x => x.preco * x.qtd));
        
                }
                adiantamentoTable.DataSource = dt;
                docRegularTable.DataSource = dtDocs;
            }
            else if (_entidade == Entidade.fornecedor)
            {
                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.adiantamentoForns.Where(f => f.fornecedorId == _entidadeId))
                {
                    valorAdiantado += item.valorAdiantado;

                    if (StaticProperty.regAdiantamentoForns.Where(x => x.adiantamentoId == item.id).Any())
                    {
                        valorRegulado += StaticProperty.regAdiantamentoForns.Where(x => x.adiantamentoId == item.id).Sum(x => x.Vfr.vfrArtigo.Sum(f => f.preco * f.qtd));
                    }

                    dt.Rows.Add(item.id, item.documento, item.valorAdiantado);

                    docRegularTable.DataSource = dt;
                }

                foreach (var item in StaticProperty.vfrs.Where(f => f.fornecedorId == _entidadeId))
                {
                    dtDocs.Rows.Add(item.id, item.documento, item.vfrArtigo.Sum(x => x.preco * x.qtd));

                    docRegularTable.DataSource = dtDocs;
                }
            }
        }

        private void documentoAdiantamento_Click(object sender, EventArgs e)
        {

        }
    }
}
