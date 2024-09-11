using AscFrontEnd.DTOs.Cliente;
using AscFrontEnd.DTOs.Fornecedor;
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
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd
{
    public partial class RegularAdiantamentoForm : Form
    {
        ClienteDTO cliente;
        FornecedorDTO fornecedor;
        Entidade _entidade;
        int _entidadeId;
        public RegularAdiantamentoForm(Entidade entidade, int entidadeId)
        {
            InitializeComponent();

            _entidade = entidade;
            _entidadeId = entidadeId;

            if(entidade == Entidade.cliente) {cliente = StaticProperty.clientes.Where(cl => cl.id == entidadeId).First();}
            else if(entidade == Entidade.fornecedor) { fornecedor = StaticProperty.fornecedores.Where(f => f.id == entidadeId).First(); }
        }

        private void RegularAdiantamentoForm_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("Documento", typeof(string));
            dt.Columns.Add("Valor", typeof(string));

            DataTable dtDocs = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("Documento", typeof(string));
            dt.Columns.Add("Valor", typeof(string));

            if (_entidade == Entidade.cliente)
            {
                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.adiantamentoClientes.Where(cl => cl.clienteId == _entidadeId))
                {
                    dt.Rows.Add(item.id, item.documento, item.valorAdiantado);

                    adiantamentoTable.DataSource = dt;
                }

                foreach (var item in StaticProperty.frs.Where(cl => cl.clienteId == _entidadeId))
                {
                    dt.Rows.Add(item.id, item.documento, item.frArtigo.Sum(x=>x.preco * x.qtd));

                    docRegularTable.DataSource = dt;
                }
            }
            else if (_entidade == Entidade.fornecedor)
            {
                // Adicionando linhas ao DataTable
                foreach (var item in StaticProperty.adiantamentoForns.Where(f => f.fornecedorId == _entidadeId))
                {
                    dt.Rows.Add(item.id, item.documento, item.valorAdiantado);

                    docRegularTable.DataSource = dt;
                }

                foreach (var item in StaticProperty.vfrs.Where(f => f.fornecedorId == _entidadeId))
                {
                    dt.Rows.Add(item.id, item.documento, item.vfrArtigo.Sum(x => x.preco * x.qtd));

                    docRegularTable.DataSource = dt;
                }
            }

        }
    }
}
