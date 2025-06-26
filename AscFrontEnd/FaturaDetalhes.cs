using AscFrontEnd.Application;
using AscFrontEnd.Application.Validacao;
using AscFrontEnd.DTOs;
using AscFrontEnd.DTOs.Compra;
using AscFrontEnd.DTOs.ContasCorrentes;
using AscFrontEnd.DTOs.Deposito;
using AscFrontEnd.DTOs.StaticsDto;
using AscFrontEnd.DTOs.Venda;
using EAscFrontEnd;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AscFrontEnd
{
    public partial class FaturaDetalhes : Form
    {
        float _totalPreco;
        int id;
        FrDTO _fr;
        GrDTO _gr;

        VfrDTO _vfr;
        VgrDTO _vgr;

        NpDTO _np;
        ReciboDTO _re;
        float _valorParcialRemocao = 0;


        int _documentoId;
        string _documento;

        DateTime _data;

        List<ParcelasFormaPagamentoDTO> parcelas;
        HttpClient _client;
        public FaturaDetalhes(float totalPreco,FrDTO fr)
        {
            InitializeComponent();
            _totalPreco = totalPreco;
            _fr = fr;
            parcelas = new List<ParcelasFormaPagamentoDTO>();
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:7200/");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);

            _documentoId = fr.id;
            _documento = fr.documento;
            _data = fr.data;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  

            valorTxt.KeyPress += ValidacaoForms.TratarKeyPress; // Ajustado
            valorTxt.TextChanged += ValidacaoForms.TratarTextChanged;
        }
        public FaturaDetalhes(float totalPreco, GrDTO gr)
        {
            InitializeComponent();
            _totalPreco = totalPreco;
            _gr = gr;
            parcelas = new List<ParcelasFormaPagamentoDTO>();
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:7200/");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);

            _documentoId = gr.id;
            _documento = gr.documento;
            _data = gr.data;

            valorTxt.KeyPress += ValidacaoForms.TratarKeyPress; // Ajustado
            valorTxt.TextChanged += ValidacaoForms.TratarTextChanged;
        }
        public FaturaDetalhes(float totalPreco, VfrDTO vfr)
        {
            InitializeComponent();
            _totalPreco = totalPreco;
            _vfr = vfr;
            parcelas = new List<ParcelasFormaPagamentoDTO>();

            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:7200/");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);

            _documentoId = vfr.id;
            _documento = vfr.documento;
            _data = vfr.data;


            valorTxt.KeyPress += ValidacaoForms.TratarKeyPress; // Ajustado
            valorTxt.TextChanged += ValidacaoForms.TratarTextChanged;
        }
        public FaturaDetalhes(float totalPreco, VgrDTO vgr)
        {
            InitializeComponent();
            _totalPreco = totalPreco;
            _vgr = vgr;
            parcelas = new List<ParcelasFormaPagamentoDTO>();

            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:7200/");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);

            _documentoId = vgr.id;
            _documento = vgr.documento;
            _data = vgr.data;

            valorTxt.KeyPress += ValidacaoForms.TratarKeyPress; // Ajustado
            valorTxt.TextChanged += ValidacaoForms.TratarTextChanged;
        }
        public FaturaDetalhes(float totalPreco, NpDTO np)
        {
            InitializeComponent();
            _totalPreco = totalPreco;
            _np = np;
            parcelas = new List<ParcelasFormaPagamentoDTO>();
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:7200/");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);

            _documentoId = np.id;
            _documento= np.documento;

            valorTxt.KeyPress += ValidacaoForms.TratarKeyPress; // Ajustado
            valorTxt.TextChanged += ValidacaoForms.TratarTextChanged;
        }
        public FaturaDetalhes(float totalPreco, ReciboDTO re)
        {
            InitializeComponent();
            _totalPreco = totalPreco;
            _re = re;
            parcelas = new List<ParcelasFormaPagamentoDTO>();

            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:7200/");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);

            _documentoId = re.id;
            _documento = re.documento;

            valorTxt.KeyPress += ValidacaoForms.TratarKeyPress; // Ajustado
            valorTxt.TextChanged += ValidacaoForms.TratarTextChanged;
        }

        private void FaturaDetalhes_Load(object sender, EventArgs e)
        {
            radioBanco.Enabled = true;
            radioBanco.Checked = true;
            removerPicture.Enabled = false;

            valorTxt.Text = _totalPreco.ToString("F2");

            DataTable dt = new DataTable();
            dt.Columns.Add("Forma",typeof(string));
            dt.Columns.Add("Valor (KZ)", typeof(float));
            dt.Columns.Add("Deposito",typeof(string));

            formaPagamentoTable.DataSource = dt;
            if (StaticProperty.formasPagamento != null)
            {
                if (StaticProperty.formasPagamento.Any())
                {
                    foreach (var item in StaticProperty.formasPagamento.Where(x => x.empresaId == StaticProperty.empresaId || x.empresaId == 0))
                    {
                        formaPagamentoCombo.Items.Add(item.descricao);
                    }
                }
            }

            if (StaticProperty.bancos != null)
            {
                if (StaticProperty.bancos.Any())
                {
                    foreach (var item in StaticProperty.bancos.Where(x => x.empresaId == StaticProperty.empresaId))
                    {
                        bancoCombo.Items.Add(item.descricao);
                    }
                }
            }

            if (StaticProperty.caixas != null)
            {
                if (StaticProperty.caixas.Any())
                {
                    foreach (var item in StaticProperty.caixas.Where(x => x.empresaId == StaticProperty.empresaId))
                    {
                        caixaCombo.Items.Add(item.descricao);
                    }
                }
            }

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string formaPagamento = formaPagamentoCombo.Text;
            float valorPago = 0f;
            int depositoId;
            int fPagamentoId;

            if (StaticProperty.formasPagamento.Where(x => x.descricao == formaPagamento && (x.empresaId == StaticProperty.empresaId || x.empresaId == 0)).Any())
            {
                fPagamentoId = StaticProperty.formasPagamento.Where(x => x.descricao == formaPagamento && (x.empresaId == StaticProperty.empresaId || x.empresaId == 0)).First().id;
            }
            else 
            {
                MessageBox.Show("Forma de Pagamento  não encontrado", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }

            valorPago = float.Parse(valorTxt.Text.ToString().Replace(".", "").Replace(",", "."), CultureInfo.InvariantCulture);

            if (bancoCombo.Enabled)
            {
                if (StaticProperty.bancos != null)
                {
                    if (StaticProperty.bancos.Where(x => x.descricao == bancoCombo.Text.ToString() && x.empresaId == StaticProperty.empresaId).Any())
                    {
                        depositoId = StaticProperty.bancos.Where(x => x.descricao == bancoCombo.Text.ToString() && x.empresaId == StaticProperty.empresaId).Any() ? StaticProperty.bancos.Where(x => x.descricao == bancoCombo.Text.ToString() && x.empresaId == StaticProperty.empresaId).First().id : 0;

                        parcelas.Add(new ParcelasFormaPagamentoDTO() { formaPagamentoId = fPagamentoId,documentoId = _documentoId,documento = _documento, valor = valorPago, bancoId = depositoId, caixaId = 0, data =_data,empresaId = StaticProperty.empresaId });
                    }
                    else
                    {
                        MessageBox.Show("Codigo do banco  não encontrado", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            else if (caixaCombo.Enabled)
            {
                if (StaticProperty.caixas != null)
                {
                    if (StaticProperty.caixas.Where(x => x.descricao == caixaCombo.Text.ToString() && x.empresaId == StaticProperty.empresaId).Any())
                    {
                        depositoId = StaticProperty.caixas.Where(x => x.descricao == caixaCombo.Text.ToString() && x.empresaId == StaticProperty.empresaId).Any()?StaticProperty.caixas.Where(x => x.descricao == caixaCombo.Text.ToString() && x.empresaId == StaticProperty.empresaId).First().id:0;

                        parcelas.Add(new ParcelasFormaPagamentoDTO() { formaPagamentoId = fPagamentoId, documentoId = _documentoId, documento = _documento, valor = valorPago, bancoId = 0, caixaId = depositoId,data = _data, empresaId = StaticProperty.empresaId });
                    }
                    else
                    {
                        MessageBox.Show("Codigo do Caixa não encontrado", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            if (string.IsNullOrEmpty(valorTxt.Text.ToString()) || float.Parse(valorTxt.Text.ToString().Replace(".", "").Replace(",", "."), CultureInfo.InvariantCulture) == 0f) 
            {
                MessageBox.Show("Nenhum valor foi inserido", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                return;
            }
           
            
            this.FillTable(parcelas);

            _totalPreco = _totalPreco - valorPago;
            valorTxt.Text = _totalPreco.ToString("F2");
        }

        private void radioCaixa_CheckedChanged(object sender, EventArgs e)
        {
            if (radioCaixa.Checked)
            {
                bancoCombo.Enabled = false;
                caixaCombo.Enabled = true;
            }
        }

        private void radioBanco_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBanco.Checked)
            {
                caixaCombo.Enabled = false;
                bancoCombo.Enabled = true;
            }
        }

        private void removerPicture_MouseMove(object sender, MouseEventArgs e)
        {
            removerPicture.BackColor = Color.Red;
        }

        private void removerPicture_MouseLeave(object sender, EventArgs e)
        {
            removerPicture.BackColor = Color.Transparent;
        }

        private void formaPagamentoTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            removerPicture.Enabled = true;
            id = e.RowIndex;
            _valorParcialRemocao = float.Parse(formaPagamentoTable.Rows[e.RowIndex].Cells[1].Value.ToString());
        }

        private void removerPicture_Click(object sender, EventArgs e)
        {
            parcelas.RemoveAt(id);
            this.FillTable(parcelas);

            _totalPreco = _totalPreco + _valorParcialRemocao;

            valorTxt.Text = _totalPreco.ToString("F2");

        }

        public void FillTable(List<ParcelasFormaPagamentoDTO> parcelas) 
        {
            string deposito = string.Empty;

            DataTable dt = new DataTable();
            dt.Columns.Add("Forma", typeof(string));
            dt.Columns.Add("Valor (KZ)", typeof(float));
            dt.Columns.Add("Deposito", typeof(string));

            if (parcelas != null)
            {
                foreach (var item in parcelas)
                {
                    if (!StaticProperty.formasPagamento.Where(x => x.id == item.formaPagamentoId && (x.empresaId == StaticProperty.empresaId || x.empresaId == 0)).Any())
                    {
                        MessageBox.Show("Forma de Pagamento  não encontrado", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }
                        string fPagamento = StaticProperty.formasPagamento.Where(x => x.id == item.formaPagamentoId && (x.empresaId == StaticProperty.empresaId || x.empresaId == 0)).First().descricao;
                    

                    if (item.bancoId != 0)
                    {
                        deposito = StaticProperty.bancos.Where(x => x.id == item.bancoId).First().codigo;
                    }
                    else if (item.caixaId != 0)
                    {
                        deposito = StaticProperty.caixas.Where(x => x.id == item.caixaId).First().codigo;
                    }

                    dt.Rows.Add(fPagamento, item.valor, deposito);
                }
            }

            formaPagamentoTable.DataSource = dt;
        }

        private async void Salvar_Click(object sender, EventArgs e)
        {
            string rota = string.Empty;
            string json = string.Empty;
            string jsonDeposito = string.Empty;

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticProperty.token);

            if (_fr != null) 
            {
                json = System.Text.Json.JsonSerializer.Serialize(_fr);

                rota = $"api/Venda/Fr/{StaticProperty.funcionarioId}";
            }
            if (_gr != null)
            {
                json = System.Text.Json.JsonSerializer.Serialize(_gr);

                rota = $"api/Venda/Gr/{StaticProperty.funcionarioId}";
            }

            else if (_vfr != null)
            {
                json = System.Text.Json.JsonSerializer.Serialize(_vfr);

                rota = $"api/Compra/Vfr/{StaticProperty.funcionarioId}";
            }
            else if (_vgr != null)
            {
                json = System.Text.Json.JsonSerializer.Serialize(_vgr);

                rota = $"api/Compra/Vgr/{StaticProperty.funcionarioId}";
            }
            else if(_np != null) 
            {
                // Conversão do objeto Film para JSON
                json = System.Text.Json.JsonSerializer.Serialize(_np);

                rota = $"api/ContaCorrente/Np/{StaticProperty.funcionarioId}";
            }
            else if(_re != null) 
            {
                // Conversão do objeto Film para JSON
                json = System.Text.Json.JsonSerializer.Serialize(_re);

                rota = $"api/ContaCorrente/Re/{StaticProperty.funcionarioId}";
            }

            var response = await _client.PostAsync(rota, new StringContent(json, Encoding.UTF8, "application/json"));

            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Ocorreu um erro ao executar esta operação", "Ocorreu um erro", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                return;

                
            }
            else 
            {
                var result = await response.Content.ReadAsStringAsync();
                if (result == "-1")
                {
                    MessageBox.Show("A data deste documento é inferior a data da ultimo documento", "Não é possível concluir a acão!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }
                else if(result == "-2") 
                {
                    MessageBox.Show("A data do sistema não segue a sequencia dos documentos anterior\n Verfique a se a data do sistema está correcto e reinicie", "Não é possível concluir a acão!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    
                    return;                 
                }

                jsonDeposito = System.Text.Json.JsonSerializer.Serialize(parcelas);

                var responseDeposito = await _client.PostAsync("api/Deposito/Parcelas/FormaPagamento", new StringContent(jsonDeposito, Encoding.UTF8, "application/json"));

                if (_fr != null)
                {
                    var fr = JsonConvert.DeserializeObject<FrDTO>(result);
                    StaticProperty.hash = fr.shortHash;
                }
                else if (_gr != null)
                {
                    var gr = JsonConvert.DeserializeObject<GrDTO>(result);
                    StaticProperty.hash = gr.shortHash;
                }



                if (!responseDeposito.IsSuccessStatusCode) 
                {
                    MessageBox.Show("Ocorreu um erro ao salvar os dados no deposito", "Ocorreu um erro", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
    
}
