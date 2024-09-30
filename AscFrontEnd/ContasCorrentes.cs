using AscFrontEnd.DTOs.Enums;
using AscFrontEnd.DTOs.StaticsDto;
using AscFrontEnd.DTOs.Stock;
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
        public int id;
        public ContasCorrentes()
        {
            InitializeComponent();
            dados = new List<VftDTO>();
            entidadeTable = new DataTable();
        }

        private async void groupBox1_Enter(object sender, EventArgs e)
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
            pictureBox3.BackColor = Color.DeepSkyBlue;
            label6.ForeColor = Color.DeepSkyBlue;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.FromArgb(0, 120, 215);
            label6.ForeColor = Color.FromArgb(0, 120, 215);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private async void ContasCorrentes_Load(object sender, EventArgs e)
        {
            var vftResult = StaticProperty.vfts.Where(x=>x.fornecedor.empresaid == StaticProperty.empresaId).GroupBy(vft => vft.fornecedorId);
            var adFornResult = StaticProperty.adiantamentoForns.Where(x => x.Fornecedor.empresaid == StaticProperty.empresaId).GroupBy(x => x.fornecedorId);

            entidadeTable.Columns.Add("Codigo Entidade", typeof(int));
            entidadeTable.Columns.Add("Entidade", typeof(string));
            entidadeTable.Columns.Add("Por Pagar", typeof(float));
            entidadeTable.Columns.Add("Estado", typeof(string));


                // Adicionando linhas ao DataTable
                foreach (var vft in vftResult)
                {
                    float result = vft.Sum(vt=>vt.vftArtigo.Sum(va=>va.preco*va.qtd));

                    string nomeFornecedor = StaticProperty.fornecedores.Where(f => f.id == vft.Key).First().nome_fantasia;

                    entidadeTable.Rows.Add(vft.Key, nomeFornecedor, result, "Não regulada");
                   
                }

            foreach (var ad in adFornResult)
            {
                float result = ad.Sum(x => x.valorAdiantado);

                string nomeFornecedor = StaticProperty.fornecedores.Where(f => f.id == ad.First().fornecedorId).First().nome_fantasia;

                entidadeTable.Rows.Add(ad.First().fornecedorId, nomeFornecedor, result, "Não regulada");

            }

            correnteTable.DataSource = entidadeTable;
            aprovaBtn.Enabled = false;
        }

        private void correnteTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            float divida = 0;
            float regulado = 0;
            float adianta = 0;

            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Obtém o valor da célula clicada
                    string id = correnteTable.Rows[e.RowIndex].Cells[0].Value.ToString();

                    this.id = int.Parse(id);
                }

                if(radioFornecedor.Checked)
                {
                    var result = StaticProperty.vfts.Where(vft => vft.fornecedorId == id).ToList();
                    

                    foreach (var item in result)
                    {
                        if(item.pago == Enums.OpcaoBinaria.Nao) 
                        {
                             divida += item.vftArtigo.Sum(d => d.preco * d.qtd);
                             regulado += StaticProperty.nps.Where(np => np.vftId == item.id).Sum(np => np.quantia);
                        }
                    }        
                }
                else if(radioCliente.Checked)
                {
                    var result = StaticProperty.fts.Where(ft => ft.clienteId == id).ToList();


                    foreach (var item in result)
                    {
                        if (item.pago == Enums.OpcaoBinaria.Nao)
                        {
                            divida += item.ftArtigo.Sum(d => d.preco * d.qtd);
                            regulado += StaticProperty.recibos.Where(re => re.ftId == item.id).Sum(re => re.quantia);
                        }
                    }
                }

                dividaResult.Text = divida.ToString("F2");
                liqResult.Text = regulado.ToString("F2");

                aprovaBtn.Enabled = true;
            }
            catch 
            { 
                return; 
            }
        }

        private void correnteTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try 
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Obtém o valor da célula clicada
                    string id = correnteTable.Rows[e.RowIndex].Cells[0].Value.ToString();
                  
                    this.id = int.Parse(id);

                    if (radioCliente.Checked)
                    { 
                        ListasContasCorrentes lcCorrente = new ListasContasCorrentes(this.id, Entidade.cliente);
                        lcCorrente.ShowDialog();
                    }
                    else if (radioFornecedor.Checked)
                    { 
                        ListasContasCorrentes lcCorrente = new ListasContasCorrentes(this.id, Entidade.fornecedor);
                        lcCorrente.ShowDialog();
                    }
                }
              
            }
            catch 
            {
                return;
            }

        }

        private void radioFornecedor_CheckedChanged(object sender, EventArgs e)
        {

            if (radioCliente.Checked) 
            {
                if (!StaticProperty.fts.Any() && !StaticProperty.adiantamentoClientes.Any())
                {
                    MessageBox.Show("Nenhum Documento Encontrado!", "Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    radioFornecedor.Checked = true;
                    return;
                }

                DataTable dataTable = (DataTable)correnteTable.DataSource;

                if (dataTable != null)
                {
                    dataTable.Clear(); // Limpa todas as linhas da fonte de dados
                }

                var ftResult = StaticProperty.fts.Where(x=>x.cliente.empresaid == StaticProperty.empresaId).GroupBy(ft => ft.clienteId);

                // Adicionando linhas ao DataTable
                foreach (var ft in ftResult)
                {
                    float result = ft.Sum(vt => vt.ftArtigo.Sum(va => va.preco * va.qtd));

                    string nomeCliente = StaticProperty.clientes.Where(c => c.id == ft.Key).First().nome_fantasia;

                    entidadeTable.Rows.Add(ft.Key, nomeCliente, result, "Não regulada");

                    correnteTable.DataSource = entidadeTable;
                }

                var adClienteResult = StaticProperty.adiantamentoClientes.Where(x => x.cliente.empresaid == StaticProperty.empresaId).GroupBy(x => x.clienteId);

                foreach (var ad in adClienteResult)
                {
                    float result = ad.Sum(x => x.valorAdiantado);

                    string nomeFornecedor = StaticProperty.clientes.Where(f => f.id == ad.First().clienteId).First().nome_fantasia;

                    entidadeTable.Rows.Add(ad.First().clienteId, nomeFornecedor, result, "Não regulada");
                }
            }
        }

        private void radioCliente_CheckedChanged(object sender, EventArgs e)
        {

            if (radioFornecedor.Checked)
            {
                if (StaticProperty.vfts == null)
                {
                    MessageBox.Show("Nenhum Documento Encontrado!", "Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    radioCliente.Checked = true;
                    return;
                }
                DataTable dataTable = (DataTable)correnteTable.DataSource;

                if (dataTable != null)
                {
                    dataTable.Clear(); // Limpa todas as linhas da fonte de dados
                }

                var vftResult = StaticProperty.vfts.Where(x=>x.fornecedor.empresaid==StaticProperty.empresaId).GroupBy(vft => vft.fornecedorId);

                // Adicionando linhas ao DataTable
                foreach (var vft in vftResult)
                {
                    float result = vft.Sum(vt => vt.vftArtigo.Sum(va => va.preco * va.qtd));

                    string nomeFornecedor = StaticProperty.fornecedores.Where(f => f.id == vft.Key).First().nome_fantasia;

                    entidadeTable.Rows.Add(vft.Key, nomeFornecedor, result, "Não regulada");

                    correnteTable.DataSource = entidadeTable;
                }
            }
        }

        private void aprovaBtn_MouseMove(object sender, MouseEventArgs e)
        {
            aprovaBtn.BackColor = Color.White;
            aprovaBtn.ForeColor = Color.FromArgb(64,64,64);
        }

        private void aprovaBtn_MouseLeave(object sender, EventArgs e)
        {
            aprovaBtn.BackColor = Color.Transparent;
            aprovaBtn.ForeColor = Color.White;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LiquidaDivida ld = null;
            if (this.id > 0)
            {
                if (radioCliente.Checked)
                {
                    ld = new LiquidaDivida(id, Entidade.cliente);
                }
                else if (radioFornecedor.Checked)
                {
                    ld = new LiquidaDivida(id, Entidade.fornecedor);
                }
                ld.ShowDialog();
            }
            else 
            {
                return;
            }
        }

        private void aprovaBtn_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            RegularAdiantamentoForm form = null;
            if (this.id > 0)
            {
                if (radioCliente.Checked)
                {
                    form = new RegularAdiantamentoForm(Entidade.cliente, id);
                }
                else if (radioFornecedor.Checked)
                {
                    form = new RegularAdiantamentoForm(Entidade.fornecedor, id);
                }

                form.ShowDialog();
            }
            else 
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void adiantaBtn_Click(object sender, EventArgs e)
        {
            AdiantamentoForm form = new AdiantamentoForm();
            form.ShowDialog();
        }
    }


}
