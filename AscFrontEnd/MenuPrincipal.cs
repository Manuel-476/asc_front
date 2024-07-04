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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void fornecedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void clienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
         

        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.ShowDialog();
        }

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void vendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Venda venda = new Venda();
            venda.ShowDialog();
        }

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Artigo cadastro = new Artigo();
            cadastro.ShowDialog();
        }

        private void compraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compra compra = new Compra();
            compra.ShowDialog();
        }

        private void cadastroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Armazem armazem = new Armazem();
            armazem.ShowDialog();
        }
    }
}
