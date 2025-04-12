using AscFrontEnd.DTOs.Deposito;
using AscFrontEnd.DTOs.StaticsDto;
using AscFrontEnd.DTOs.Stock;
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
    public partial class BancoForm : Form
    {
        List<BancoDTO> bancos;
        DataTable dt;
        List<int> idBanco;
        public BancoForm()
        {
            InitializeComponent();
            bancos = new List<BancoDTO>();
            dt = new DataTable();
            idBanco = new List<int>();
        }

        private void BancoFomr_Load(object sender, EventArgs e)
        {
            eliminarPicture.Enabled = false;
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Codigo", typeof(string));
            dt.Columns.Add("Descricao", typeof(string));
            dt.Columns.Add("Conta", typeof(string));
            dt.Columns.Add("Iban", typeof(string));

            bancoTable.DataSource = dt;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            int id = bancoTable.Rows.Count;
            dt.Rows.Clear();
            bancoTable.DataSource = dt;

            bancos.Add(new BancoDTO
            {
                id = 0,
                codigo = codigoText.Text,
                descricao = descText.Text.ToString(),
                conta = contaText.Text.ToString(),
                iban = ibanText.Text.ToString(),
                status = DTOs.Enums.Enums.Status.activo,
                empresaId = StaticProperty.empresaId
            });

            foreach (var banco in bancos)
            {
               
                dt.Rows.Add(banco.id, banco.codigo.ToString(), banco.descricao.ToString(), banco.conta.ToString(),banco.iban.ToString());

                bancoTable.DataSource = dt;
            }
        }

        private void eliminarPicture_Click(object sender, EventArgs e)
        {
            var selectedRows = bancoTable.SelectedRows;

            foreach (DataGridViewRow row in selectedRows)
            {
                if (row != null && row.Index >= 0) // Verifica se a linha está válida
                {
                    int id = int.Parse(row.Cells[0].Value?.ToString()); // Substitua 0 pelo índice da coluna desejada
                                                                        // Ou faça algo mais útil com o valor
                    idBanco.Add(id);
                }
            }

            foreach (int id in idBanco)
            {
                var result = bancos.Where(c => c.id == id).First();

                int index = bancos.IndexOf(result);

                bancos.RemoveAt(index);
            }

            dt.Rows.Clear();
            bancoTable.DataSource = dt;


            foreach (var banco in bancos)
            {
                
                dt.Rows.Add(banco.id, banco.codigo.ToString(), banco.descricao.ToString(), banco.conta,banco.iban);

                bancoTable.DataSource = dt;
            }
            idBanco.Clear();
        }

        private void bancoTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            eliminarPicture.Enabled = true;
        }

        private void feitoBtn_Click(object sender, EventArgs e)
        {
            StaticProperty.bancosEmpresa = bancos;
            this.Close();  
        }
    }
}
