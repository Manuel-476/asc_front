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
                else 
                {
                    MessageBox.Show("Nao foi encontrado nenhum registro do adiantamento", "Sem registro", MessageBoxButtons.RetryCancel);
                }
            }
            else if(entidade == Entidade.fornecedor) 
            {
                if(StaticProperty.fornecedores.Where(f => f.id == entidadeId).Any())
                { 
                       fornecedor = StaticProperty.fornecedores.Where(f => f.id == entidadeId).First();
                }
                else 
                {
                    MessageBox.Show("Nao foi encontrado nenhum registro do adiantamento", "Sem registro", MessageBoxButtons.RetryCancel);
                }
            }
        }

        private void RegularAdiantamentoForm_Load(object sender, EventArgs e)
        {
            float valorAdiantado = 0;
            float valorRegulado = 0;

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
                    valorRegulado += StaticProperty.regAdiantamentoClientes.Where(x => x.adiantamentoId == item.id).Sum(x => x.fr.frArtigo.Sum(f => f.preco * f.qtd));

                    dt.Rows.Add(item.id, item.documento, item.valorAdiantado);

                    adiantamentoTable.DataSource = dt;
                }

                foreach (var item in StaticProperty.frs.Where(cl => cl.clienteId == _entidadeId))
                {
                    dtDocs.Rows.Add(item.id, item.documento, item.frArtigo.Sum(x=>x.preco * x.qtd));

                    docRegularTable.DataSource = dtDocs;
                }
               
            }
            else if (_entidade == Entidade.fornecedor)
            {
                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.adiantamentoForns.Where(f => f.fornecedorId == _entidadeId))
                {
                    valorAdiantado += item.valorAdiantado;
                    valorRegulado += StaticProperty.regAdiantamentoForns.Where(x => x.adiantamentoId == item.id).Sum(x => x.Vfr.vfrArtigo.Sum(f => f.preco * f.qtd));

                    dt.Rows.Add(item.id, item.documento, item.valorAdiantado);

                    docRegularTable.DataSource = dt;
                }

                foreach (var item in StaticProperty.vfrs.Where(f => f.fornecedorId == _entidadeId))
                {
                    dtDocs.Rows.Add(item.id, item.documento, item.vfrArtigo.Sum(x => x.preco * x.qtd));
                    
                    docRegularTable.DataSource = dtDocs;
                }
            }

            adiantado.Text = $"Adiantado: {valorAdiantado.ToString("F2")}";
            liquidado.Text = $"Liquidado: {valorRegulado.ToString("F2")}";
        }

        private void adiantamentoTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            adiantamentoId = int.Parse(adiantamentoTable.Rows[e.RowIndex].Cells[0].ToString());

            if (_entidade == Entidade.cliente)
            {
                documentoAdiantamento.Text = StaticProperty.adiantamentoClientes.Where(ad => ad.id == adiantamentoId).First().documento;
            }
            else if(_entidade == Entidade.fornecedor) 
            {
                documentoAdiantamento.Text = StaticProperty.adiantamentoForns.Where(ad => ad.id == adiantamentoId).First().documento;
            }
        }

        private void docRegularTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            documentoId = int.Parse(docRegularTable.Rows[e.RowIndex].Cells[0].ToString());

            if (_entidade == Entidade.cliente)
            {
                documentoPagamento.Text = StaticProperty.regAdiantamentoClientes.Where(ad => ad.id == adiantamentoId).First().documento;
                valorDocumento.Text = StaticProperty.frs.Where(x => x.id == documentoId).Sum(x => x.frArtigo.Sum(f=>f.preco * f.qtd)).ToString("F2");
            }
            else if (_entidade == Entidade.fornecedor)
            {
                documentoPagamento.Text = StaticProperty.regAdiantamentoForns.Where(ad => ad.id == adiantamentoId).First().documento;
                valorDocumento.Text = StaticProperty.vfrs.Where(x => x.id == documentoId).Sum(x => x.vfrArtigo.Sum(f => f.preco * f.qtd)).ToString("F2");
            }
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

                    if (responseRegAdCliente.IsSuccessStatusCode)
                    {
                        var contentRegAdCliente = await responseRegAdCliente.Content.ReadAsStringAsync();
                        StaticProperty.regAdiantamentoClientes = JsonConvert.DeserializeObject<List<RegAdiantamentoClienteDTO>>(contentRegAdCliente);
                    }
                    var result = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Ocorreu um erro ao tentar Salvar", "Feito Com Sucesso", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao tentar Salvar", "Erro", MessageBoxButtons.RetryCancel);
                }
            }
            else if (_entidade == Entidade.fornecedor)
            {
                documento = await Documento.GetCodigoDocumentoAsync("RGF");

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
    }
}
