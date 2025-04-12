using AscFrontEnd.DTOs;
using AscFrontEnd.DTOs.ContasCorrentes;
using AscFrontEnd.DTOs.Deposito;
using AscFrontEnd.DTOs.StaticsDto;
using AscFrontEnd.DTOs.Venda;
using EAscFrontEnd;
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
    public partial class FaturaDetalhes : Form
    {
        float _totalPreco;
        int id;
        FrDTO _fr;
        GtDTO _gt;
        VfrDTO _vfr;
        VgtDTO _vgt;
        NpDTO _np;
        ReciboDTO _re;

        List<ParcelasFormaPagamentoDTO> parcelas;

        public FaturaDetalhes(float totalPreco,FrDTO fr)
        {
            InitializeComponent();
            _totalPreco = totalPreco;
            _fr = fr;
            parcelas = new List<ParcelasFormaPagamentoDTO>();
        }
        public FaturaDetalhes(float totalPreco, GtDTO gt)
        {
            InitializeComponent();
            _totalPreco = totalPreco;
            _gt = gt;
            parcelas = new List<ParcelasFormaPagamentoDTO>();
        }
        public FaturaDetalhes(float totalPreco, VfrDTO vfr)
        {
            InitializeComponent();
            _totalPreco = totalPreco;
            _vfr = vfr;
            parcelas = new List<ParcelasFormaPagamentoDTO>();
        }
        public FaturaDetalhes(float totalPreco, VgtDTO vgt)
        {
            InitializeComponent();
            _totalPreco = totalPreco;
            _vgt = vgt;
            parcelas = new List<ParcelasFormaPagamentoDTO>();
        }
        public FaturaDetalhes(float totalPreco, NpDTO np)
        {
            InitializeComponent();
            _totalPreco = totalPreco;
            _np = np;
            parcelas = new List<ParcelasFormaPagamentoDTO>();
        }
        public FaturaDetalhes(float totalPreco, ReciboDTO re)
        {
            InitializeComponent();
            _totalPreco = totalPreco;
            _re = re;
            parcelas = new List<ParcelasFormaPagamentoDTO>();
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
                foreach (var item in StaticProperty.formasPagamento)
                {
                    formaPagamentoCombo.Items.Add(item.descricao);
                }
            }

            if (StaticProperty.bancos != null) 
            {
                foreach (var item in StaticProperty.bancos)
                {
                    bancoCombo.Items.Add(item.descricao);
                }
            }

            if (StaticProperty.caixas != null)
            {
                foreach (var item in StaticProperty.caixas)
                {
                    caixaCombo.Items.Add(item.descricao);
                }
            }

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string formaPagamento = formaPagamentoCombo.Text;
            float valorPago = float.Parse(valorTxt.Text);
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

            if (bancoCombo.Enabled)
            {
                if (StaticProperty.bancos != null)
                {
                    if (StaticProperty.bancos.Where(x => x.descricao == bancoCombo.Text.ToString() && x.empresaId == StaticProperty.empresaId).Any())
                    {
                        depositoId = StaticProperty.bancos.Where(x => x.descricao == bancoCombo.Text.ToString() && x.empresaId == StaticProperty.empresaId).First().id;
                        parcelas.Add(new ParcelasFormaPagamentoDTO() { formaPagamentoId = fPagamentoId, valor = valorPago, bancoId = depositoId, caixaId = 0 });
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
                        depositoId = StaticProperty.caixas.Where(x => x.descricao == caixaCombo.Text.ToString() && x.empresaId == StaticProperty.empresaId).First().id;
                        parcelas.Add(new ParcelasFormaPagamentoDTO() { formaPagamentoId = fPagamentoId, valor = valorPago, bancoId = 0, caixaId = depositoId });
                    }
                    else
                    {
                        MessageBox.Show("Codigo do Caixa não encontrado", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            this.FillTable(parcelas);
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
        }

        private void removerPicture_Click(object sender, EventArgs e)
        {
            parcelas.RemoveAt(id);
            this.FillTable(parcelas);

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
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",StaticProperty.token);

            if(_fr != null) 
            {
                json = System.Text.Json.JsonSerializer.Serialize(_fr);

                rota = $"https://localhost:7200/api/Venda/Fr/{StaticProperty.funcionarioId}";
            }

            else if (_vfr != null)
            {
                json = System.Text.Json.JsonSerializer.Serialize(_vfr);

                rota = $"https://localhost:7200/api/Compra/Vfr/{StaticProperty.funcionarioId}";
            }
            else if(_np != null) 
            {
                // Conversão do objeto Film para JSON
                json = System.Text.Json.JsonSerializer.Serialize(_np);

                rota = $"https://localhost:7200/api/ContaCorrente/Np/{StaticProperty.funcionarioId}";
            }
            else if(_re != null) 
            {
                // Conversão do objeto Film para JSON
                json = System.Text.Json.JsonSerializer.Serialize(_re);

                rota = $"https://localhost:7200/api/ContaCorrente/Re/{StaticProperty.funcionarioId}";
            }

            var response = await client.PostAsync(rota, new StringContent(json, Encoding.UTF8, "application/json"));

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
            }
            
        }
    }
}
