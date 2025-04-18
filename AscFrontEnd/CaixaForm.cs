using AscFrontEnd.DTOs.Deposito;
using AscFrontEnd.DTOs.StaticsDto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AscFrontEnd
{
    public partial class CaixaForm : Form
    {
        List<CaixaDTO> caixas;
        DataTable dt;
        List<int> idCaixa;
        public CaixaForm()
        {
            InitializeComponent();
            caixas = new List<CaixaDTO>();
            dt = new DataTable();
            idCaixa = new List<int>();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(codigoText.Text.ToString()))
            {
                MessageBox.Show("O campo do codigo esta vazio", "Impossivel Concluir a acao", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (!string.IsNullOrEmpty(descText.Text.ToString()))
            {
                MessageBox.Show("O campo do descricao esta vazio", "Impossivel Concluir a acao", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            int id = caixaTable.Rows.Count;
            dt.Rows.Clear();
            caixaTable.DataSource = dt;

            caixas.Add(new CaixaDTO
            {
                id = id,
                codigo = codigoText.Text,
                descricao = descText.Text.ToString(),
                status = DTOs.Enums.Enums.Status.activo,
                empresaId = StaticProperty.empresaId
            });

            foreach (var caixa in caixas)
            {

                dt.Rows.Add(caixa.id, caixa.codigo.ToString(), caixa.descricao.ToString());

                caixaTable.DataSource = dt;
            }
        }

        private void eliminarPicture_Click(object sender, EventArgs e)
        {
            var selectedRows = caixaTable.SelectedRows;

            foreach (DataGridViewRow row in selectedRows)
            {
                if (row != null && row.Index >= 0) // Verifica se a linha está válida
                {
                    int id = int.Parse(row.Cells[0].Value?.ToString()); // Substitua 0 pelo índice da coluna desejada
                                                                        // Ou faça algo mais útil com o valor
                    idCaixa.Add(id);
                }
            }

            foreach (int id in idCaixa)
            {
                var result = caixas.Where(c => c.id == id).First();

                int index = caixas.IndexOf(result);

                caixas.RemoveAt(index);
            }

            dt.Rows.Clear();
            caixaTable.DataSource = dt;


            foreach (var caixa in caixas)
            {

                dt.Rows.Add(caixa.id, caixa.codigo.ToString(), caixa.descricao.ToString());

                caixaTable.DataSource = dt;
            }
            idCaixa.Clear();
        }

        private void feitoBtn_Click(object sender, EventArgs e)
        {
            if (!caixas.Any())
            {
                MessageBox.Show("Nao existe caixas na lista", "Impossivel Concluir a acao", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            StaticProperty.caixasEmpresa = caixas;
            this.Close();
        }

        private void caixaTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            eliminarPicture.Enabled = true;
        }

        private void CaixaForm_Load(object sender, EventArgs e)
        {
            eliminarPicture.Enabled = false;
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Codigo", typeof(string));
            dt.Columns.Add("Descricao", typeof(string));


            caixaTable.DataSource = dt;
        }
    }
}
