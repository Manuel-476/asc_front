using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AscFrontEnd.DTOs.StaticsDto;

namespace AscFrontEnd
{
    public partial class BancoListagemForm : Form
    {
        DataTable _dataTable;
        int id = 0;
        bool _multi = false;
        List<int> _depositoIds;
        public BancoListagemForm()
        {
            InitializeComponent();
        }
        public BancoListagemForm(bool multi, List<int> depositoIds)
        {
            InitializeComponent();

            _multi = multi;
            _depositoIds = depositoIds ?? new List<int>();
        }

        private void BancoCaixaListagemForm_Load(object sender, EventArgs e)
        {
            _dataTable = new DataTable();


            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Codigo", typeof(string));
            dt.Columns.Add("descricao", typeof(string));
            dt.Columns.Add("Conta", typeof(string));
            dt.Columns.Add("IBAN", typeof(string));

            // Adicionando linhas ao DataTable
            if (_multi)
            {
                editarPicture.Visible = false;
                eliminarPicture.Visible = false;

                if (StaticProperty.bancos != null)
                {
                    // Adiciona linhas ao DataTable
                    foreach (var item in StaticProperty.bancos.Where(x => x.empresaId == StaticProperty.empresaId))
                    {
                        dt.Rows.Add(item.id, item.codigo, item.descricao, item.conta, item.iban);
                    }
                }
                // Define o DataSource do DataGridView (fora do loop)
                dataGridView1.DataSource = dt;
                dataGridView1.ClearSelection();

                // Seleciona automaticamente as linhas cujos IDs estão em _artigoIds
                if (_depositoIds != null && _depositoIds.Any())
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        int id = Convert.ToInt32(row.Cells["id"].Value); // Pega o valor da coluna "id"
                        if (_depositoIds.Contains(id))
                        {
                            row.Selected = true; // Seleciona a linha
                        }
                    }
                }

                // Opcional: Garante que o DataGridView permita seleção múltipla
                dataGridView1.MultiSelect = true;
            }
            else
            {
                if (StaticProperty.bancos != null)
                {
                    foreach (var item in StaticProperty.bancos.Where(x => x.empresaId == StaticProperty.empresaId))
                    {
                        dt.Rows.Add(item.id, item.codigo, item.descricao, item.conta, item.iban);
                    }
                }
                dataGridView1.DataSource = dt;

                dataGridView1.MultiSelect = false;
            }

            editarPicture.Enabled = false;
        }

        public List<int> GetDepositoIdList()
        {
            return _depositoIds;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _depositoIds.Clear();
                var rowsSelected = dataGridView1.SelectedRows;

                foreach(DataGridViewRow row in rowsSelected) 
                {
                  var id = int.Parse(row.Cells[0].Value.ToString());

                   _depositoIds.Add(id);
        
                }
            }
            catch { return; }
        }

        private void radioBanco_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioCaixa_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnActualizar_MouseMove(object sender, MouseEventArgs e)
        {
            btnActualizar.BackColor = Color.White;
            btnActualizar.ForeColor = Color.Black;
        }

        private void btnActualizar_MouseLeave(object sender, EventArgs e)
        {
            btnActualizar.BackColor = Color.Transparent;
            btnActualizar.ForeColor = Color.White;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            BancoCaixaListagemForm_Load(this, EventArgs.Empty);
        }
    }
}
