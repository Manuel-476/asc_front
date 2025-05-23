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
using System.Windows.Forms.DataVisualization.Charting;
using DocumentFormat.OpenXml.Bibliography;

namespace AscFrontEnd
{
    public partial class RegularAdiantamentoForm : Form
    {
        ClienteDTO cliente;
        FornecedorDTO fornecedor;
        Entidade _entidade;
        Documento _getCodigoDocumento;
        Requisicoes _requisicoes;
        List<int> _docUsed;

        List<int> _adiantamentoIdList;
        List<int> _regAdiantamentoIdList;

        int _entidadeId;
        int _adiantamentoId;
        int _regAdiantamentoId;
        int _documentoId;

        float _valorAdiantado = 0;
        float _valorRegulado = 0;

        float _totalAdiantado = 0f;
        float _totalPorRegular = 0f;

        public RegularAdiantamentoForm(Entidade entidade, int entidadeId)
        {
            InitializeComponent();

            _entidade = entidade;
            _entidadeId = entidadeId;
            _getCodigoDocumento = new Documento();
            _adiantamentoIdList = new List<int>();
            _regAdiantamentoIdList = new List<int>();
            _requisicoes = new Requisicoes();
            _docUsed = new List<int>();

            if (entidade == Entidade.cliente)
            {
                if (StaticProperty.clientes.Where(cl => cl.id == entidadeId).Any())
                {
                    cliente = StaticProperty.clientes.Where(cl => cl.id == entidadeId).First();
                }
            }
            else if (entidade == Entidade.fornecedor)
            {
                if (StaticProperty.fornecedores.Where(f => f.id == entidadeId).Any())
                {
                    fornecedor = StaticProperty.fornecedores.Where(f => f.id == entidadeId).First();
                }

            }

            valorDocumento.KeyPress += ValidacaoForms.TratarKeyPress; // Ajustado
            valorDocumento.TextChanged += ValidacaoForms.TratarTextChanged;
        }

        private void RegularAdiantamentoForm_Load(object sender, EventArgs e)
        {
            docRegularTable.DataSource = null;
            adiantamentoTable.DataSource = null;

            this.carregarTabelas(ref _valorAdiantado, ref _valorRegulado);

            adiantado.Text = $"Adiantado: {_valorAdiantado.ToString("F2")}";
            liquidado.Text = $"Liquidar: {_valorRegulado.ToString("F2")}";
        }

        private void adiantamentoTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var selectedRows = adiantamentoTable.SelectedRows;

                _totalAdiantado = 0;

                _adiantamentoIdList.Clear();

                foreach (DataGridViewRow row in selectedRows)
                {
                    _adiantamentoId = int.Parse(row.Cells[0].Value.ToString());
                    _totalAdiantado += float.Parse(row.Cells[2].Value.ToString());

                    _adiantamentoIdList.Add(_adiantamentoId);

                }
                adiantarLabel.Text = $"Adiantar: {_totalAdiantado.ToString("F2")}";
            }
            catch { return; }
        }

        private void docRegularTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var selectedRows = docRegularTable.SelectedRows;

                _totalPorRegular = 0;

                _regAdiantamentoIdList.Clear();

                foreach (DataGridViewRow row in selectedRows)
                {
                    _regAdiantamentoId = int.Parse(row.Cells[0].Value.ToString());
                    _totalPorRegular += float.Parse(row.Cells[2].Value.ToString());

                    _regAdiantamentoIdList.Add(_regAdiantamentoId);

                }

                regularLabel.Text = $"Regular: {_totalPorRegular.ToString("F2")}";

                valorDocumento.Text = _totalPorRegular.ToString("F2");
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

            if (!_adiantamentoIdList.Any()) 
            {
                MessageBox.Show("Nenhum documento de adiantamento foi selecionado!","Selecione um adiantamento",MessageBoxButtons.OK,MessageBoxIcon.Information);
            
                return;
            }
            if (!_regAdiantamentoIdList.Any())
            {
                MessageBox.Show("Nenhum documento de venda foi selecionado!", "Selecione uma venda", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (_entidade == Entidade.cliente)
            {
                documento = await Documento.GetCodigoDocumentoAsync("RGC");


                var regAdiantamento = new RegAdiantamentoClienteDTO()
                {
                    documento = documento,
                    adiantaFrs = new List<AdiantaFrDTO>() { new AdiantaFrDTO() { regAdiantamentoClientesid = 0, frId = _regAdiantamentoIdList, adiantamentoClienteId = _adiantamentoIdList } },
                    status = DocState.ativo,
                    empresaId = StaticProperty.empresaId,
                };
                json = System.Text.Json.JsonSerializer.Serialize(regAdiantamento);

                // Envio dos dados para a API
                response = await client.PostAsync($"https://localhost:7200/api/ContaCorrente/Regular/Adiantamento/Cliente", new StringContent(json, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    await _requisicoes.GetRegAdiantamantoCliente();                 
                    await _requisicoes.GetAdCliente();                 

                    var result = await response.Content.ReadAsStringAsync();

                    MessageBox.Show(result.ToString(), "Feito Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao tentar Salvar", "Erro", MessageBoxButtons.RetryCancel);
                }
            }
            else if (_entidade == Entidade.fornecedor)
            {
                documento = await Documento.GetCodigoDocumentoAsync("RGF");
                var vfr = StaticProperty.vfrs.Where(x => x.id == _documentoId).First();

                var regAdiantamento = new RegAdiantamentoFornDTO()
                {
                    documento = documento,
                    adiantaVfrs = new List<AdiantaVfrDTO>() { new AdiantaVfrDTO() { regAdiantamentoFornecedorid = 0, vfrId = _regAdiantamentoIdList, adiantamentoFornId = _adiantamentoIdList } },
                    status = DocState.ativo,
                    empresaId = StaticProperty.empresaId,
                };
                json = System.Text.Json.JsonSerializer.Serialize(regAdiantamento);

                // Envio dos dados para a API
                response = await client.PostAsync($"https://localhost:7200/api/ContaCorrente/Regular/Adiantamento/Fornecedor", new StringContent(json, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    await _requisicoes.GetRegAdFornecedor();
                    await _requisicoes.GetAdFornecedor();
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao tentar Salvar", "Erro", MessageBoxButtons.RetryCancel);
                }
            }

            WindowsConfig.LimparFormulario(this);

            RegularAdiantamentoForm_Load(this, EventArgs.Empty);
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
                    }
                }

                adiantamentoTable.DataSource = dt;
            }
            else if (_entidade == Entidade.fornecedor)
            {
                foreach (var item in StaticProperty.adiantamentoForns.Where(f => f.fornecedorId == _entidadeId))
                {
                    if (item.documento.ToUpper().Contains(textBox1.Text.ToUpper().ToString()) || item.created_at.ToString().ToUpper().Contains(textBox1.Text.ToUpper().ToString()))
                    {
                        dt.Rows.Add(item.id, item.documento, item.valorAdiantado);                  
                    }
                }

                docRegularTable.DataSource = dt;
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
                        dtDocs.Rows.Add(item.id, item.documento, item.frArtigo.Sum(x => x.preco * x.qtd).ToString("F2")); 
                    }
                }

                docRegularTable.DataSource = dtDocs;
            }
            else if (_entidade == Entidade.fornecedor)
            {
                foreach (var item in StaticProperty.vfrs.Where(f => f.fornecedorId == _entidadeId))
                {
                    if (item.documento.ToUpper().Contains(textBox1.Text.ToUpper().ToString()) || item.created_at.ToString().ToUpper().Contains(textBox1.Text.ToUpper().ToString()))
                    {
                        dtDocs.Rows.Add(item.id, item.documento, item.vfrArtigo.Sum(x => x.preco * x.qtd).ToString("F2"));                
                    }
                }

                docRegularTable.DataSource = dtDocs;
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

                    if (StaticProperty.regAdiantamentoClientes != null)
                    {
                        if (StaticProperty.regAdiantamentoClientes.Where(x => x.adiantaFrs.Where(a => a.adiantamentoClienteId.Contains(item.id)).Any()).Any())
                        {
                            foreach (var reg in StaticProperty.regAdiantamentoClientes.Where(x => x.adiantaFrs.Where(a => a.adiantamentoClienteId.Contains(item.id)).Any()))
                            {
                                foreach (var af in reg.adiantaFrs)
                                {
                                    foreach (var frId in af.frId)
                                    {
                                        valorRegulado += StaticProperty.frs.FirstOrDefault(x => x.id == frId).frArtigo.Sum(f => f.preco * f.qtd);
                                    }
                                }
                            }
                        }
                    }

                    dt.Rows.Add(item.id, item.documento, item.valorAdiantado.ToString("F2"));
                }

                //carregar o _docUsed
                VendasReguladasCliente();

                // listar a tabela com as facturas FR
                foreach (var item in StaticProperty.frs.Where(cl => cl.clienteId == _entidadeId).ToList())
                {
                    if (!_docUsed.Contains(item.id))
                    {
                        dtDocs.Rows.Add(item.id, item.documento, item.frArtigo.Sum(x => x.preco * x.qtd).ToString("F2"));
                    }
                }

                // carregar tabela
                adiantamentoTable.DataSource = dt;
                docRegularTable.DataSource = dtDocs;
            }
            else if (_entidade == Entidade.fornecedor)
            {
                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.adiantamentoForns.Where(f => f.fornecedorId == _entidadeId && f.resolvido == OpcaoBinaria.Nao))
                {
                    valorAdiantado += item.valorAdiantado;

                    if (StaticProperty.regAdiantamentoForns != null)
                    {
                        if (StaticProperty.regAdiantamentoForns.Where(x => x.adiantaVfrs.Where(a => a.adiantamentoFornId.Contains(item.id)).Any()).Any())
                        {
                            foreach (var reg in StaticProperty.regAdiantamentoForns.Where(x => x.adiantaVfrs.Where(a => a.adiantamentoFornId.Contains(item.id)).Any()))
                            {
                                foreach (var av in reg.adiantaVfrs)
                                {
                                    foreach (var vfrId in av.vfrId)
                                    {
                                        valorRegulado += StaticProperty.vfrs.FirstOrDefault(x => x.id == item.id).vfrArtigo.Sum(f => f.preco * f.qtd);
                                    }
                                }
                            }
                        }
                    }

                    dt.Rows.Add(item.id, item.documento, item.valorAdiantado.ToString("F2"));
                }

                //Carregar _docUsed
                ComprasReguladaForn();

                foreach (var item in StaticProperty.vfrs.Where(f => f.fornecedorId == _entidadeId))
                {
                    if (!_docUsed.Contains(item.id))
                    {
                        dtDocs.Rows.Add(item.id, item.documento, item.vfrArtigo.Sum(x => x.preco * x.qtd).ToString("F2"));
                    }
                }

                adiantamentoTable.DataSource = dt;
                docRegularTable.DataSource = dtDocs;
            }
        }

        private void documentoAdiantamento_Click(object sender, EventArgs e)
        {

        }

        private void docRegularTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void VendasReguladasCliente()
        {
            foreach (var item in StaticProperty.adiantamentoClientes.Where(cl => cl.clienteId == _entidadeId ))
            {
                if (StaticProperty.regAdiantamentoClientes != null)
                {
                    if (StaticProperty.regAdiantamentoClientes.Where(x => x.adiantaFrs.Where(a => a.adiantamentoClienteId.Contains(item.id)).Any()).Any())
                    {
                        foreach (var reg in StaticProperty.regAdiantamentoClientes.Where(x => x.adiantaFrs.Where(a => a.adiantamentoClienteId.Contains(item.id)).Any()))
                        {
                            foreach (var af in reg.adiantaFrs)
                            {
                                foreach (var frId in af.frId)
                                {
                                    if (!_docUsed.Contains(frId))
                                    {
                                        _docUsed.Add(frId);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public void ComprasReguladaForn()        
        {
            foreach (var item in StaticProperty.adiantamentoForns.Where(f => f.fornecedorId == _entidadeId))
            {
                if (StaticProperty.regAdiantamentoForns != null)
                {
                    if (StaticProperty.regAdiantamentoForns.Where(x => x.adiantaVfrs.Where(a => a.adiantamentoFornId.Contains(item.id)).Any()).Any())
                    {
                        foreach (var reg in StaticProperty.regAdiantamentoForns.Where(x => x.adiantaVfrs.Where(a => a.adiantamentoFornId.Contains(item.id)).Any()))
                        {
                            foreach (var av in reg.adiantaVfrs)
                            {
                                foreach (var vfrId in av.vfrId)
                                {
                                    if (!_docUsed.Contains(vfrId))
                                    {
                                        _docUsed.Add(vfrId);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
