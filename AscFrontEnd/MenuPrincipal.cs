using AscFrontEnd.Application;
using AscFrontEnd.DTOs;
using AscFrontEnd.DTOs.Funcionario;
using AscFrontEnd.DTOs.StaticsDto;
using AscFrontEnd.DTOs.Stock;
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
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd
{
    public partial class MenuPrincipal : Form
    {
        UserDTO _user;
        List<string> _notifications;
        List<string> _notificationsOrder;
        List<string> _notificationsOrderForn;

        Requisicoes _requisicao;
        List<EncomendaClienteDTO> _encomendaPendentes;
        List<EncomendaFornecedorDTO> _encomendaPendentesForn;
        public MenuPrincipal(UserDTO user)
        {
            InitializeComponent();
            _user = user;
            _notifications = new List<string>();
            _notificationsOrder = new List<string>();
            _notificationsOrderForn = new List<string>();
            _requisicao = new Requisicoes();

            _encomendaPendentes = new List<EncomendaClienteDTO>();
            _encomendaPendentesForn = new List<EncomendaFornecedorDTO>();
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

        private async void MenuPrincipal_Load(object sender, EventArgs e)
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
                    if (string.Compare(permission.descricao, "Gerenciar clientes e contatos.", true) == 0)
                    {
                        clienteToolStripMenuItem1.Visible = true;

                        clienteToolStripMenuItem.Visible = true;
                    }
                    if (string.Compare(permission.descricao, "Criar e editar pedidos de compra.", true) == 0)
                    {
                        compraToolStripMenuItem.Visible = true;
                    }
                    if (string.Compare(permission.descricao, "Gerenciar fornecedores e contratos.", true) == 0)
                    {
                        fornecedorToolStripMenuItem1.Visible = true;

                        fornecedorToolStripMenuItem.Visible = true;
                    }
                    if (string.Compare(permission.descricao, "Visualizar e ajustar níveis de estoque.", true) == 0)
                    {
                        listaToolStripMenuItem.Visible = true;
                    }
                    if (string.Compare(permission.descricao, "Gerenciar contas a pagar e a receber.", true) == 0)
                    {
                        contaCorrenteToolStripMenuItem.Visible=true;
                    }
                    if (string.Compare(permission.descricao, "Criar Serie.", true) == 0)
                    {
                        criacaoSerieToolStripMenuItem.Visible = true;
                    }
                    if (string.Compare(permission.descricao, "Criar e ver fluxo de depositos Depositos.", true) == 0)
                    {
                        depositoToolStripMenuItem.Visible = true;
                    }
                    if (string.Compare(permission.descricao, "Cadastrar artigos.", true) == 0)
                    {
                        cadastroToolStripMenuItem.Visible = true;
                    }
                    if (string.Compare(_user.nivel_acesso, "Tecnico", true) == 0 || string.Compare(_user.nivel_acesso, "Administrador", true) == 0)
                    {
                        funcionarioToolStripMenuItem.Visible = true;         
                    }
                    if (string.Compare(_user.nivel_acesso, "Tecnico", true) == 0 || string.Compare(_user.nivel_acesso, "Administrador", true) == 0)
                    {
                        cadastroToolStripMenuItem1.Visible = true;
                    }
                    if (string.Compare(_user.nivel_acesso, "Tecnico", true) == 0)
                    {
                        empresaToolStripMenuItem.Visible = true;
                    }
                    if (string.Compare(permission.descricao, "Gerar relatórios.", true) == 0)
                    {
                        relatoriosToolStripMenuItem.Visible = true;
                    }
                    //Gerar relatórios.
                    //
                }

              
            }
            timer1.Start();

            var qtdMinim = StaticProperty.stockMinims.Where(x => x.empresaId == StaticProperty.empresaId).FirstOrDefault() == null
                          ? 0: StaticProperty.stockMinims.Where(x => x.empresaId == StaticProperty.empresaId).FirstOrDefault().qtdMinim;
            
            await this.NotificationStockAsync(qtdMinim);

            await NotificationOrderAsync();

            await NotificationOrderFornAsync();

            if(_notifications.Count<=0 && _notificationsOrder.Count <= 0 && _notificationsOrderForn.Count <= 0) 
            {
                stockLabel.Text = "Sem Notificação";
                orderClLabel.Text = "";
                orderFornLabel.Text = "";
            }

            totalVendaLabel.Text = $"Total Vendas:\n{DashBoard.VendaTotal().ToString("F2")}";
            totalCompraLabel.Text = $"Total Compras:\n{DashBoard.CompraTotal().ToString("F2")}";

        }

        public bool ApagarTodosTools() 
        {
            vendaToolStripMenuItem.Visible = false;

            fornecedorToolStripMenuItem1.Visible = false;

            fornecedorToolStripMenuItem.Visible = false;

            clienteToolStripMenuItem1.Visible = false;

            clienteToolStripMenuItem.Visible = false;

            cadastroToolStripMenuItem.Visible=false;

            compraToolStripMenuItem.Visible = false;

            cadastroToolStripMenuItem1.Visible=false;

            listaToolStripMenuItem.Visible = false;

            contaCorrenteToolStripMenuItem.Visible = false;

            criacaoSerieToolStripMenuItem.Visible = false;

            funcionarioToolStripMenuItem.Visible = false;

            empresaToolStripMenuItem.Visible = false;

          //  bancoToolStripMenuItem.Visible = false;

         //   caixaToolStripMenuItem.Visible = false ;

            depositoToolStripMenuItem.Visible = false;

            // historicoToolStripMenuItem.Visible = false;

            // formaPagamentoToolStripMenuItem.Visible = false;

            relatoriosToolStripMenuItem.Visible = false;

            return true;
        }

        private void relatoriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RelatorioForm(_user).ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void configuracoesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ConfigForm().ShowDialog();
        }

        public async Task NotificationStockAsync(float qtdMinim)
        {
            List<StockDTO> stocks = await new Requisicoes().GetStockArtigo();
            _notifications.Clear();
            foreach (var s in stocks)
            {

                if (s.qtd <= qtdMinim)
                {
                    _notifications.Add($"Restaram apenas {s.qtd} em stock do artigo {s.artigo} ({s.descricao})");
                }
            }
            if (_notifications.Count > 0)
            {
                stockLabel.Text = $"{_notifications.Count} artigo(s) terminando";
            }
            else 
            {
                stockLabel.Text = "";
            }
        }

        public async Task NotificationOrderAsync()
        {
            List<EncomendaClienteDTO> ecls = StaticProperty.ecls.Where(x => x.empresaId == StaticProperty.empresaId && x.status == DocState.ativo).ToList();

            _notificationsOrder.Clear();
            _encomendaPendentes.Clear();

            foreach (var ecl in ecls)
            {
                double i = 3;
                while (i >= 0)
                {

                    if (DateTime.Now.AddDays(i).Date == ecl.dataEntrega.Date)
                    {
                        _notificationsOrder.Add($"Faltam {i} dia(s) para fazer a entrega da encomenda do documento {ecl.documento}");
                        _encomendaPendentes.Add(ecl);
                    }

                    i--;
                }
            }
            if (_notificationsOrder.Count > 0)
            {
                orderClLabel.Text = $"{_notificationsOrder.Count} encomenda(s) por entregar";
            }
            else 
            {
                orderClLabel.Text = "";
            }

            NotificacaoOrderForm._encomendas = _encomendaPendentes.ToList();
        }

        public async Task NotificationOrderFornAsync()
        {
            List<EncomendaFornecedorDTO> ecfs = StaticProperty.ecfs.Where(x => x.empresaId == StaticProperty.empresaId && x.status == DocState.ativo).ToList();

            _notificationsOrderForn.Clear();
            _encomendaPendentesForn.Clear();

            foreach (var ecf in ecfs)
            {
                double i = 3;
                while (i >= 0)
                {

                    if (DateTime.Now.AddDays(i).Date == ecf.dataEntrega.Date)
                    {
                        _notificationsOrderForn.Add($"Faltam {i} dia(s) para receber a encomenda do documento {ecf.documento}");
                        _encomendaPendentesForn.Add(ecf);
                    }

                    i--;
                }
            }
            if (_notificationsOrderForn.Count > 0)
            {
                orderFornLabel.Text = $"{_notificationsOrderForn.Count} encomenda(s) por receber";
            }
            else 
            {
                orderFornLabel.Text = $"";
            }
            NotificacaoOrderForm._encomendasForn = _encomendaPendentesForn.ToList();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void stockLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_notifications.Count > 0)
            {
                stockLabel.Font = new Font(stockLabel.Font, stockLabel.Font.Style | FontStyle.Underline);
            }

        }

        private void stockLabel_Click(object sender, EventArgs e)
        {
            if (_notifications.Count > 0)
            {
                new NotificacoForm(_notifications).ShowDialog();
            }
            
        }

        private void totalVendaLabel_Click(object sender, EventArgs e)
        {
            new DashBoardForm(Consulta.venda).ShowDialog();
        }

        private void totalCompraLabel_Click(object sender, EventArgs e)
        {
            new DashBoardForm(Consulta.compra).ShowDialog();
        }

        private void totalVendaLabel_MouseMove(object sender, MouseEventArgs e)
        {
            totalVendaLabel.Font = new Font(stockLabel.Font, stockLabel.Font.Style | FontStyle.Underline);
        }

        private void totalCompraLabel_MouseMove(object sender, MouseEventArgs e)
        {
            totalCompraLabel.Font = new Font(stockLabel.Font, stockLabel.Font.Style | FontStyle.Underline);
        }

        private void totalVendaLabel_MouseLeave(object sender, EventArgs e)
        {
            totalVendaLabel.Font = new Font(stockLabel.Font, FontStyle.Bold | FontStyle.Italic);
        }

        private void totalCompraLabel_MouseLeave(object sender, EventArgs e)
        {
            totalCompraLabel.Font = new Font(stockLabel.Font, FontStyle.Bold | FontStyle.Italic);
        }

        private void stockLabel_MouseLeave(object sender, EventArgs e)
        {
            stockLabel.Font = new Font(stockLabel.Font, FontStyle.Bold | FontStyle.Italic);
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            RefreshSystem();
        }

        private async void atualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshSystem();
        }

        private async void orderClLabel_Click(object sender, EventArgs e)
        {
            var form = new NotificacaoOrderForm(Entidade.cliente,_user);

            form.ShowDialog();
        }
        

        private async void orderFornLabel_Click(object sender, EventArgs e)
        {
            var form =  new NotificacaoOrderForm(Entidade.fornecedor,_user);

            form.ShowDialog();
        }

        private void orderClLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_notificationsOrder.Count > 0)
            {
                orderClLabel.Font = new Font(stockLabel.Font, stockLabel.Font.Style | FontStyle.Underline);
            }
        }

        private void orderFornLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_notificationsOrderForn.Count > 0)
            {
                orderFornLabel.Font = new Font(stockLabel.Font, stockLabel.Font.Style | FontStyle.Underline);
            }
        }

        private void orderClLabel_MouseLeave(object sender, EventArgs e)
        {
            orderClLabel.Font = new Font(stockLabel.Font, FontStyle.Bold | FontStyle.Italic);
        }

        private void orderFornLabel_MouseLeave(object sender, EventArgs e)
        {
            orderFornLabel.Font = new Font(stockLabel.Font, FontStyle.Bold | FontStyle.Italic);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public async void RefreshSystem() 
        {
            await _requisicao.SystemRefresh();

            MenuPrincipal_Load(this, EventArgs.Empty);
        }

        private void MenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            timer1.Dispose();
        }

        private void MenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}


