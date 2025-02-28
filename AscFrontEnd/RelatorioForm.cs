using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AscFrontEnd.DTOs.Funcionario;
using AscFrontEnd.DTOs.StaticsDto;
using DocumentFormat.OpenXml.Spreadsheet;
using Color = System.Drawing.Color;

namespace AscFrontEnd
{
    public partial class RelatorioForm : Form
    {
        UserDTO _user;
        public RelatorioForm(UserDTO user)
        {
            _user = user;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureVenda_MouseLeave(object sender, EventArgs e)
        {
            pictureVenda.BackColor = Color.FromArgb(0, 120, 215);
        }

        private void pictureVenda_MouseMove(object sender, MouseEventArgs e)
        {
            pictureVenda.BackColor = Color.DeepSkyBlue;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            pictureCompra.BackColor = Color.DeepSkyBlue;
        }

        private void pictureCompra_Click(object sender, EventArgs e)
        {

        }

        private void pictureCompra_MouseLeave(object sender, EventArgs e)
        {
            pictureCompra.BackColor = Color.FromArgb(0, 120, 215);
        }

        private void pictureStock_MouseLeave(object sender, EventArgs e)
        {
            pictureStock.BackColor = Color.FromArgb(0, 120, 215);
        }

        private void pictureStock_MouseMove(object sender, MouseEventArgs e)
        {
            pictureStock.BackColor = Color.DeepSkyBlue;
        }

        private void pictureFinanceiro_MouseLeave(object sender, EventArgs e)
        {
            pictureFinanceiro.BackColor = Color.FromArgb(0, 120, 215);
        }

        private void pictureFinanceiro_MouseMove(object sender, MouseEventArgs e)
        {
            pictureFinanceiro.BackColor = Color.DeepSkyBlue;
        }

        private void RelatorioForm_Load(object sender, EventArgs e)
        {
            this.ApagarTodosTools();

            foreach (var item in _user.userPermissions)
            {
                if (StaticProperty.permissions.Where(x => x.Id == item.permissionId).Any())
                {
                    var permission = StaticProperty.permissions.Where(x => x.Id == item.permissionId).First();
                    if (string.Compare(permission.descricao, "Gerar relatorios de venda.", true) == 0)
                    {
                        pictureVenda.Enabled = true;
                    }
                    if (string.Compare(permission.descricao, "Gerar Relatorio de compra.", true) == 0)
                    {
                        pictureCompra.Enabled = true;
                    }
                    if (string.Compare(permission.descricao, "Gerar relatórios Financeiro.", true) == 0)
                    {
                        pictureFinanceiro.Enabled = true;
                    }
                    if (string.Compare(permission.descricao, "Gerar relatórios de estoque.", true) == 0)
                    {
                        pictureStock.Enabled = true;
                    }

                }
            }

        }

        public bool ApagarTodosTools()
        {
            pictureVenda.Enabled = false;

            pictureCompra.Enabled = false;

            pictureStock.Enabled = false;

            pictureFinanceiro.Enabled = false;

            return true;
        }
    }
}
