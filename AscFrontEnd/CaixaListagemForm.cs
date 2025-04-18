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
    public partial class CaixaListagemForm : Form
    {
        DataTable _dataTable;
        int id = 0;
        bool _multi = false;
        List<int> _depositoIds;

        public CaixaListagemForm()
        {
            InitializeComponent();
        }
        public CaixaListagemForm(bool multi, List<int> depositoIds)
        {
            InitializeComponent();

            _multi = multi;
            _depositoIds = depositoIds ?? new List<int>();
        }

        private void CaixaListagemForm_Load(object sender, EventArgs e)
        {
            _dataTable = new DataTable();

            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Codigo", typeof(string));
            dt.Columns.Add("descricao", typeof(string));

            if (_multi)
            {
                editarPicture.Visible = false;
                eliminarPicture.Visible = false;

                // Adiciona linhas ao DataTable
                foreach (var item in StaticProperty.caixas.Where(x => x.empresaId == StaticProperty.empresaId))
                {
                    dt.Rows.Add(item.id, item.codigo, item.descricao);
                }

                // Define o DataSource do DataGridView (fora do loop)
                dataGridView1.DataSource = dt;

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
                foreach (var item in StaticProperty.caixas.Where(x => x.empresaId == StaticProperty.empresaId))
                {
                    dt.Rows.Add(item.id, item.codigo, item.descricao);
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
                id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

                if (_multi)
                {
                    var id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

                    if (!_depositoIds.Contains(id))
                    {
                        _depositoIds.Add(id);
                    }
                    else
                    {
                        _depositoIds.Remove(id);
                    }
                }
            }
            catch { return; }
        }
    }
}
