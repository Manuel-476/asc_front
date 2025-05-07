using AscFrontEnd.Application;
using AscFrontEnd.DTOs.StaticsDto;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
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
    public partial class ListasContasCorrentes : Form
    {
        public int id;
        public int _entidadeId;
        DataTable entidadeTable;
        public Entidade _entidade;
        
        public ListasContasCorrentes(int entidadeId,Entidade entidade)
        {
            InitializeComponent();
            _entidade = entidade;
            _entidadeId = entidadeId;
         
        }

        private void ListasContasCorrentes_Load(object sender, EventArgs e)
        {
            entidadeTable = new DataTable();

            entidadeTable.Columns.Add("Numero", typeof(int));
            entidadeTable.Columns.Add("Documento", typeof(string));
            entidadeTable.Columns.Add("Valor", typeof(float));

            radioDivida.Checked = true;

            entidadeTable.Rows.Clear();

            if (_entidade == Entidade.cliente)
            {
               if(!StaticProperty.fts.Where(ft => ft.clienteId == _entidadeId && ft.pago == OpcaoBinaria.Nao).Any()) 
               {
                    return;
               }

                var ftResult = StaticProperty.fts.Where(ft => ft.clienteId == _entidadeId && ft.pago == OpcaoBinaria.Nao).ToList();

                entidadeText.Text = StaticProperty.clientes.Where(c => c.id == _entidadeId).First().nome_fantasia;
               
                // Adicionando linhas ao DataTable
                foreach (var ft in ftResult.ToList())
                {
                    float result = ft.ftArtigo.Sum(fa => (fa.preco * fa.qtd));

                    entidadeTable.Rows.Add(ft.id, ft.documento, result);
                  
                }
                
            }
            else if (_entidade == Entidade.fornecedor) 
            {
                if (!StaticProperty.vfts.Where(vft => vft.fornecedorId == _entidadeId && vft.pago == OpcaoBinaria.Nao).Any())
                {
                    return;
                }

                var vftResult = StaticProperty.vfts.Where(vft => vft.fornecedorId == _entidadeId && vft.pago== OpcaoBinaria.Nao);
           
                entidadeText.Text = StaticProperty.fornecedores.Where(f => f.id == _entidadeId).First().nome_fantasia;

                // Adicionando linhas ao DataTable
                foreach (var vft in vftResult)
                {
                   float result = vft.vftArtigo.Sum(va => (va.preco * va.qtd)-(va.preco * (va.iva/100)));

                   entidadeTable.Rows.Add(vft.id,vft.documento , result);

                }
            }
            correnteTable.DataSource = entidadeTable;
        }

        private void correnteTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {     
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Obtém o valor da célula clicada
                    string id = correnteTable.Rows[e.RowIndex].Cells[0].Value.ToString();

                    string codigoDocumento = correnteTable.Rows[e.RowIndex].Cells[1].Value.ToString();

                    var doc = Documento.GetCodigoDocumento(codigoDocumento);

                    this.id = int.Parse(id);
                    
                    DocumentosDetalhesForm documentos = new DocumentosDetalhesForm(doc,this.id,_entidade);
                    documentos.ShowDialog();
                    /*  if (radioCliente.Checked)
                      {
                          ListasContasCorrentes lcCorrente = new ListasContasCorrentes(this.id, Entidade.cliente);
                          lcCorrente.ShowDialog();
                      }
                      else if (radioFornecedor.Checked)
                      {
                          ListasContasCorrentes lcCorrente = new ListasContasCorrentes(this.id, Entidade.fornecedor);
                          lcCorrente.ShowDialog();
                      }*/
                }

            }
            catch
            {
                return;
            }
            
        }

        private void radioDivida_CheckedChanged(object sender, EventArgs e)
        {
            entidadeTable = new DataTable();

            if (radioDivida.Checked) 
            {
                entidadeTable.Columns.Add("Numero", typeof(int));
                entidadeTable.Columns.Add("Documento", typeof(string));
                entidadeTable.Columns.Add("Valor", typeof(float));

                if (_entidade == Entidade.cliente)
                {
                    if (!StaticProperty.fts.Where(ft => ft.clienteId == _entidadeId && ft.pago == OpcaoBinaria.Nao).Any())
                    {
                        return;
                    }

                    var ftResult = StaticProperty.fts.Where(ft => ft.clienteId == _entidadeId && ft.pago == OpcaoBinaria.Nao);

                    entidadeText.Text = StaticProperty.clientes.Where(c => c.id == _entidadeId).First().nome_fantasia;

                    // Adicionando linhas ao DataTable
                    foreach (var ft in ftResult)
                    {
                        float result = ft.ftArtigo.Sum(fa => (fa.preco * fa.qtd));

                        entidadeTable.Rows.Add(ft.id, ft.documento, result);

                        correnteTable.DataSource = entidadeTable;
                    }
                }
                else if (_entidade == Entidade.fornecedor)
                {
                    if (!StaticProperty.vfts.Where(vft => vft.fornecedorId == _entidadeId && vft.pago == OpcaoBinaria.Nao).Any())
                    {
                        return;
                    }

                    var vftResult = StaticProperty.vfts.Where(vft => vft.fornecedorId == _entidadeId && vft.pago == OpcaoBinaria.Nao);

                    entidadeText.Text = StaticProperty.fornecedores.Where(f => f.id == _entidadeId).First().nome_fantasia;

                    // Adicionando linhas ao DataTable
                    foreach (var vft in vftResult)
                    {
                        float result = vft.vftArtigo.Sum(va => (va.preco * va.qtd) - (va.preco * (va.iva / 100)));

                        entidadeTable.Rows.Add(vft.id, vft.documento, result);

                        correnteTable.DataSource = entidadeTable;
                    }
                }
            }
        }

        private void radioAdiantamento_CheckedChanged(object sender, EventArgs e)
        {
            entidadeTable = new DataTable();

            if (radioAdiantamento.Checked) 
            {
                entidadeTable.Columns.Add("Numero", typeof(int));
                entidadeTable.Columns.Add("Documento", typeof(string));
                entidadeTable.Columns.Add("Valor", typeof(float));

                if (_entidade == Entidade.cliente)
                {
                    if (!StaticProperty.adiantamentoClientes.Where(ad => ad.clienteId == _entidadeId && ad.resolvido == OpcaoBinaria.Nao).Any()) 
                    {
                        return;
                    }

                    var adResult = StaticProperty.adiantamentoClientes.Where(ad => ad.clienteId == _entidadeId && ad.resolvido == OpcaoBinaria.Nao);

                    entidadeText.Text = StaticProperty.clientes.Where(c => c.id == _entidadeId).First().nome_fantasia;

                    // Adicionando linhas ao DataTable
                    foreach (var ad in adResult)
                    {
                        entidadeTable.Rows.Add(ad.id, ad.documento, ad.valorAdiantado);

                        correnteTable.DataSource = entidadeTable;
                    }
                }
                else if (_entidade == Entidade.fornecedor)
                {
                    if (!StaticProperty.adiantamentoForns.Where(ad => ad.fornecedorId == _entidadeId && ad.resolvido == OpcaoBinaria.Nao).Any())
                    {
                        return;
                    }

                    var adResult = StaticProperty.adiantamentoForns.Where(ad => ad.fornecedorId == _entidadeId && ad.resolvido == OpcaoBinaria.Nao);

                    entidadeText.Text = StaticProperty.fornecedores.Where(f => f.id == _entidadeId).First().nome_fantasia;

                    // Adicionando linhas ao DataTable
                    foreach (var ad in adResult)
                    {
                        entidadeTable.Rows.Add(ad.id, ad.documento, ad.valorAdiantado);

                        correnteTable.DataSource = entidadeTable;
                    }
                }
            }
        }
    }
}
