using AscFrontEnd.DTOs.Enums;
using AscFrontEnd.DTOs.StaticsDto;
using AscFrontEnd.DTOs.Stock;
using ERP_Buyer.Application.DTOs.Documentos;
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
            StaticProperty.vfts.GroupBy(vft => vft.fornecedorId);

            entidadeTable.Columns.Add("Codigo Entidade", typeof(int));
            entidadeTable.Columns.Add("Entidade", typeof(string));
            entidadeTable.Columns.Add("Por Pagar", typeof(float));
            entidadeTable.Columns.Add("Estado", typeof(float));


                // Adicionando linhas ao DataTable
                foreach (var vft in dados)
                {
                    string status = vft.status == 0 ? "Não Regulada" : "Regulada";

                    float result = vft.vftArtigo.Sum(vt => vt.preco);

                    string nomeFornecedor = StaticProperty.fornecedores.Where(f => f.id == vft.fornecedorId).First().nome_fantasia;

                    entidadeTable.Rows.Add(vft.fornecedorId, nomeFornecedor, result, status);

                    correnteTable.DataSource = entidadeTable;
                }
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
                else 
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
    }
}
