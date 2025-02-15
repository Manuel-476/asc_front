using AscFrontEnd.DTOs.Funcionario;
using AscFrontEnd.DTOs.StaticsDto;
using AscFrontEnd.Files;
using DocumentFormat.OpenXml;
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
        UserDTO _user;
        public MenuPrincipal(UserDTO user)
        {
            _user = user;
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

        private void listaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock stock = new Stock();
            stock.ShowDialog();
        }

        private void contaCorrenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContasCorrentes ccForm = new ContasCorrentes();
            ccForm.ShowDialog();
        }

        private void criacaoSerieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SerieForm serie = new SerieForm();
            serie.ShowDialog();
        }

        private void funcionarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FuncionarioForm funcionario = new FuncionarioForm();
            funcionario.ShowDialog();
        }

        private void empresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmpresaForm empresaForm = new EmpresaForm();    
            empresaForm.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void bancoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BancoCadastroForm().ShowDialog();
        }

        private void caixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CaixaCadastroForm().ShowDialog();
        }

        private void historicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Historico().ShowDialog();
        }

        private void formaPagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new  FormaPagamentoForm().ShowDialog();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            this.ApagarTodosTools();

            foreach (var item in _user.userPermissions) 
            {
                if(StaticProperty.permissions.Where(x => x.Id == item.permissionId).Any()) 
                {
                    var permission = StaticProperty.permissions.Where(x => x.Id == item.permissionId).First();
                    if (string.Compare(permission.descricao, "Criar e editar pedidos de venda.",true) == 0)
                    {
                        vendaToolStripMenuItem.Visible = true;
                    }
                }
            }
        }

        public bool ApagarTodosTools() 
        {
            vendaToolStripMenuItem.Visible = false;

            return true;
        }
    }
}


