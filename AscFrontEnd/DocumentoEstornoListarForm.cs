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
using DocumentFormat.OpenXml.Office2010.Excel;
using static AscFrontEnd.Compra;
using static AscFrontEnd.DTOs.Enums.Enums;
using static AscFrontEnd.Venda;

namespace AscFrontEnd
{
    public partial class DocumentoEstornoListarForm : Form
    {
        Entidade _entidade;
        List<CompraArtigo> compraArtigos;
        List<DocumentoCompra> documentoCompras;

        List<VendaArtigo> vendaArtigos;
        List<DocumentoVenda> documentoVendas;
        public DocumentoEstornoListarForm(Entidade entidade)
        {
            _entidade = entidade;
            if(entidade == Entidade.fornecedor) 
            {
                compraArtigos = new List<CompraArtigo>();
                documentoCompras = new List<DocumentoCompra>();
                this.SetCompras();
            }
            else 
            {
                vendaArtigos = new List<VendaArtigo>();
                documentoVendas = new List<DocumentoVenda>();
                this.SetVendas();
            }

            InitializeComponent();
        }

        private void DocumentoEstornoListarForm_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("Cliente", typeof(string));
            dt.Columns.Add("Documento", typeof(string));
            dt.Columns.Add("Estado", typeof(string));
            dt.Columns.Add("Data", typeof(string));

            if (_entidade == Entidade.cliente)
            {
                if (documentoVendas != null)
                {
                    if (documentoVendas.Any())
                    {
                        foreach (var item in documentoVendas.Where(x => x.status != DocState.estornado && x.status != DocState.anulado && x.clienteId == StaticProperty.entityId))
                        {
                            var clienteNome = StaticProperty.clientes.Where(cl => cl.id == item.clienteId).Any() ?
                                             StaticProperty.clientes.Where(cl => cl.id == item.clienteId).First().nome_fantasia : string.Empty;

                            var estado = string.Empty;
                            if (item.status == DocState.anulado) { estado = "Anulado"; }
                            else if (item.status == DocState.estornado) { estado = "Estornado"; }
                            else { estado = "activo"; }

                            dt.Rows.Add(item.id, clienteNome, item.documento, estado, item.data);
                        }

                        docsTable.DataSource = dt;
                    }
                }
            }
            else
            {
                if (documentoCompras != null)
                {
                    if (documentoCompras.Any())
                    {
                        foreach (var item in documentoCompras.Where(x => x.status != DocState.estornado && x.status != DocState.anulado && x.fornecedorId == StaticProperty.entityId).OrderByDescending(x => x.data))
                        {
                            if (StaticProperty.fornecedores.Where(f => f.id == item.fornecedorId).Any())
                            {
                                var fornecedorNome = StaticProperty.fornecedores.Where(f => f.id == item.fornecedorId).Any() ?
                                                     StaticProperty.fornecedores.Where(f => f.id == item.fornecedorId).First().nome_fantasia : string.Empty;

                                var estado = string.Empty;
                                if (item.status == DocState.anulado) { estado = "Anulado"; }
                                else if (item.status == DocState.estornado) { estado = "Estornado"; }
                                else { estado = "activo"; }

                                dt.Rows.Add(item.id, fornecedorNome, item.documento, estado, item.data);
                            }
                        }
                        docsTable.DataSource = dt;
                    }
                }
            }
        }

        public void SetCompras()
        {
            documentoCompras.Clear();
            if (StaticProperty.vfts != null)
            {
                foreach (var item in StaticProperty.vfts.Where(x => x.empresaId == StaticProperty.empresaId))
                {
                    documentoCompras.Add(new DocumentoCompra()
                    {
                        id = item.id,
                        fornecedorId = item.fornecedorId,
                        documento = item.documento,
                        data = item.data,
                        status = item.status
                    });
                }
            }
            if (StaticProperty.vfts != null)
            {
                foreach (var item in StaticProperty.vfrs.Where(x => x.empresaId == StaticProperty.empresaId))
                {
                    documentoCompras.Add(new DocumentoCompra()
                    {
                        id = item.id,
                        fornecedorId = item.fornecedorId,
                        documento = item.documento,
                        data = item.data,
                        status = item.status
                    });
                }
            }
            if (StaticProperty.vgrs != null)
            {
                foreach (var item in StaticProperty.vgrs.Where(x => x.empresaId == StaticProperty.empresaId))
                {
                    documentoCompras.Add(new DocumentoCompra()
                    {
                        id = item.id,
                        fornecedorId = item.fornecedorId,
                        documento = item.documento,
                        data = item.data,
                        status = item.status
                    });
                }
            }
        }

        public void SetVendas()
        {
            documentoVendas.Clear();

            if (StaticProperty.fts != null)
            {
                foreach (var item in StaticProperty.fts.Where(x => x.empresaId == StaticProperty.empresaId))
                {
                    documentoVendas.Add(new DocumentoVenda()
                    {
                        id = item.id,
                        clienteId = item.clienteId,
                        documento = item.documento,
                        data = item.data,
                        status = item.status
                    });
                }
            }
            if (StaticProperty.frs != null) {
                foreach (var item in StaticProperty.frs.Where(x => x.empresaId == StaticProperty.empresaId))
                {
                    documentoVendas.Add(new DocumentoVenda()
                    {
                        id = item.id,
                        clienteId = item.clienteId,
                        documento = item.documento,
                        data = item.data,
                        status = item.status
                    });
                }
            }
            if (StaticProperty.ors != null)
            {
                foreach (var item in StaticProperty.ors.Where(x => x.empresaId == StaticProperty.empresaId && x.aprovado == OpcaoBinaria.Sim))
                {
                    documentoVendas.Add(new DocumentoVenda()
                    {
                        id = item.id,
                        clienteId = item.clienteId,
                        documento = item.documento,
                        data = item.data,
                        status = item.status
                    });
                }
            }
            if (StaticProperty.grs != null)
            {
                foreach (var item in StaticProperty.grs.Where(x => x.empresaId == StaticProperty.empresaId))
                {
                    documentoVendas.Add(new DocumentoVenda()
                    {
                        id = item.id,
                        clienteId = item.clienteId,
                        documento = item.documento,
                        data = item.data,
                        status = item.status
                    });
                }
            }
        }

        private void docsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            StaticProperty.documentoOrigem = docsTable.Rows[e.RowIndex].Cells[2].Value.ToString();

            this.Close();
        }
    }
}
