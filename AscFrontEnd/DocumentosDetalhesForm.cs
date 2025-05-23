using AscFrontEnd.Application;
using AscFrontEnd.DTOs;
using AscFrontEnd.DTOs.Cliente;
using AscFrontEnd.DTOs.Compra;
using AscFrontEnd.DTOs.Fornecedor;
using AscFrontEnd.DTOs.StaticsDto;
using AscFrontEnd.DTOs.Venda;
using DocumentFormat.OpenXml.Drawing.Charts;
using EAscFrontEnd;
using ERP_Buyer.Application.DTOs.Documentos;
using ERP_Seller.Application.DTOs.Documentos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AscFrontEnd.Compra;
using static AscFrontEnd.DTOs.Enums.Enums;
using static AscFrontEnd.Venda;
using DataTable = System.Data.DataTable;

namespace AscFrontEnd
{
    public partial class DocumentosDetalhesForm : Form
    {
        private string _documento;
        private Entidade _entidade;
        private int _documentoId;
        bool anulado = false;

        ClienteDTO clienteResult;
        FornecedorDTO fornecedorResult;

        List<VendaArtigo> vendaArtigos;
        List<CompraArtigo> compraArtigos;

        float incidencia = 0;
        string localEntrega = string.Empty;

        private string codigoDoc = string.Empty;
        private string descricaoDocumento = string.Empty;

        public DocumentosDetalhesForm(string documento,int documentoId,Entidade entidade)
        {
            InitializeComponent();

            _documento = documento;
            _entidade = entidade;
            _documentoId = documentoId;
            if(_entidade == Entidade.cliente) 
            {
                vendaArtigos = new List<VendaArtigo>();
            }
            else 
            {
                compraArtigos = new List<CompraArtigo>();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void DocumentosDetalhesForm_Load(object sender, EventArgs e)
        {
            DataTable data = new DataTable();

            data.Columns.Add("Artigo",typeof(string));
            data.Columns.Add("Qtd", typeof(float));
            data.Columns.Add("Iva", typeof(float));
            data.Columns.Add("Preço", typeof(float));

            string codigo;
            string num;
            string serie;

            int index;
            int indexSpace;

            if (_entidade == Entidade.fornecedor) 
            {
                if (_documento.ToUpper().Equals("VFR")) 
                {
                  var documentoDados =  StaticProperty.vfrs.Where(v => v.id == _documentoId).First();

                    indexSpace = documentoDados.documento.IndexOf(" ");
                    codigo = documentoDados.documento.Substring(0, indexSpace);

                    index = documentoDados.documento.IndexOf("/");
                    num = documentoDados.documento.Substring(index+1);

                    serie = documentoDados.documento.Substring(indexSpace, (index - indexSpace));

                    codigoDocumento.Text = codigo;
                    numDocumento.Text = num;
                    serieDocumento.Text = serie;
                    dataDocumento.Text = documentoDados.data.ToString();


                    foreach (var art in documentoDados.vfrArtigo)
                    {
                        var artigoDescricao = StaticProperty.artigos.Where(a => a.id == art.artigoId).First().descricao;
                     
                        data.Rows.Add(artigoDescricao, art.qtd, art.iva, art.preco);
                    }
                }
                else if (_documento.ToUpper().Equals("VFT"))
                {
                   var documentoDados = StaticProperty.vfts.Where(v => v.id == _documentoId).First();
                 
                    indexSpace = documentoDados.documento.IndexOf(" ");
                    codigo = documentoDados.documento.Substring(0, indexSpace);

                    index = documentoDados.documento.IndexOf("/");
                    num = documentoDados.documento.Substring(index + 1);

                    serie = documentoDados.documento.Substring(indexSpace,(index-indexSpace));

                    codigoDocumento.Text = codigo;
                    numDocumento.Text = num;
                    serieDocumento.Text = serie;
                    dataDocumento.Text = documentoDados.data.ToString();
                   

                    foreach(var art in documentoDados.vftArtigo) 
                    {
                        var artigoDescricao = StaticProperty.artigos.Where(a => a.id == art.artigoId).First().descricao;

                        data.Rows.Add(artigoDescricao, art.qtd, art.iva, art.preco);
                    }
                }
                else if (_documento.ToUpper().Equals("ECF"))
                {
                    var documentoDados = StaticProperty.ecfs.Where(v => v.id == _documentoId).First();

                    indexSpace = documentoDados.documento.IndexOf(" ");
                    codigo = documentoDados.documento.Substring(0, indexSpace);

                    index = documentoDados.documento.IndexOf("/");
                    num = documentoDados.documento.Substring(index + 1);

                    serie = documentoDados.documento.Substring(indexSpace , (index - indexSpace));

                    codigoDocumento.Text = codigo;
                    numDocumento.Text = num;
                    serieDocumento.Text = serie;
                    dataDocumento.Text = documentoDados.data.ToString();
                    localEntrega = documentoDados.local_entrega;


                    foreach (var art in documentoDados.ecfArtigo)
                    {
                        var artigoDescricao = StaticProperty.artigos.Where(a => a.id == art.artigoId).First().descricao;

                        data.Rows.Add(artigoDescricao, art.qtd, art.iva, art.preco);
                    }
                }
                else if (_documento.ToUpper().Equals("VGT"))
                {
                    var documentoDados = StaticProperty.vgts.Where(v => v.id == _documentoId).First();

                    indexSpace = documentoDados.documento.IndexOf(" ");
                    codigo = documentoDados.documento.Substring(0, indexSpace);

                    index = documentoDados.documento.IndexOf("/");
                    num = documentoDados.documento.Substring(index + 1);

                    serie = documentoDados.documento.Substring(indexSpace , (index - indexSpace));

                    codigoDocumento.Text = codigo;
                    numDocumento.Text = num;
                    serieDocumento.Text = serie;
                    dataDocumento.Text = documentoDados.data.ToString();
                 


                    foreach (var art in documentoDados.vgtArtigo)
                    {
                        var artigoDescricao = StaticProperty.artigos.Where(a => a.id == art.artigoId).First().descricao;

                        data.Rows.Add(artigoDescricao, art.qtd, art.iva, art.preco);
                    }
                }
                else if (_documento.ToUpper().Equals("VGR"))
                {
                    var documentoDados = StaticProperty.vgrs.Where(v => v.id == _documentoId).First();

                    indexSpace = documentoDados.documento.IndexOf(" ");
                    codigo = documentoDados.documento.Substring(0, indexSpace);

                    index = documentoDados.documento.IndexOf("/");
                    num = documentoDados.documento.Substring(index + 1);

                    serie = documentoDados.documento.Substring(indexSpace, (index - indexSpace));

                    codigoDocumento.Text = codigo;
                    numDocumento.Text = num;
                    serieDocumento.Text = serie;
                    dataDocumento.Text = documentoDados.data.ToString();
               

                    foreach (var art in documentoDados.vgrArtigo)
                    {
                        var artigoDescricao = StaticProperty.artigos.Where(a => a.id == art.artigoId).First().descricao;

                        data.Rows.Add(artigoDescricao, art.qtd, art.iva, art.preco);
                    }
                }
                else if (_documento.ToUpper().Equals("VNC"))
                {
                    var documentoDados = StaticProperty.vncs.Where(v => v.id == _documentoId).First();

                    indexSpace = documentoDados.documento.IndexOf(" ");
                    codigo = documentoDados.documento.Substring(0, indexSpace);

                    index = documentoDados.documento.IndexOf("/");
                    num = documentoDados.documento.Substring(index + 1);

                    serie = documentoDados.documento.Substring(indexSpace , (index - indexSpace));

                    codigoDocumento.Text = codigo;
                    numDocumento.Text = num;
                    serieDocumento.Text = serie;
                    dataDocumento.Text = documentoDados.data.ToString();


                    foreach (var art in documentoDados.vncArtigo)
                    {
                        var artigoDescricao = StaticProperty.artigos.Where(a => a.id == art.artigoId).First().descricao;

                        data.Rows.Add(artigoDescricao, art.qtd, art.iva, art.preco);
                    }
                }
                else if (_documento.ToUpper().Equals("VND"))
                {
                    var documentoDados = StaticProperty.vnds.Where(v => v.id == _documentoId).First();

                    indexSpace = documentoDados.documento.IndexOf(" ");
                    codigo = documentoDados.documento.Substring(0, indexSpace);

                    index = documentoDados.documento.IndexOf("/");
                    num = documentoDados.documento.Substring(index + 1);

                    serie = documentoDados.documento.Substring(indexSpace , (index - indexSpace));

                    codigoDocumento.Text = codigo;
                    numDocumento.Text = num;
                    serieDocumento.Text = serie;
                    dataDocumento.Text = documentoDados.data.ToString();


                    foreach (var art in documentoDados.vndArtigo)
                    {
                        var artigoDescricao = StaticProperty.artigos.Where(a => a.id == art.artigoId).First().descricao;

                        data.Rows.Add(artigoDescricao, art.qtd, art.iva, art.preco);
                    }
                }
                else if (_documento.ToUpper().Equals("PCO"))
                {
                    var documentoDados = StaticProperty.pcos.Where(v => v.id == _documentoId).First();

                    indexSpace = documentoDados.documento.IndexOf(" ");
                    codigo = documentoDados.documento.Substring(0, indexSpace);

                    index = documentoDados.documento.IndexOf("/");
                    num = documentoDados.documento.Substring(index + 1);

                    serie = documentoDados.documento.Substring(indexSpace , (index - indexSpace));

                    codigoDocumento.Text = codigo;
                    numDocumento.Text = num;
                    serieDocumento.Text = serie;
                    dataDocumento.Text = documentoDados.data.ToString();


                    foreach (var art in documentoDados.pcArtigo)
                    {
                        var artigoDescricao = StaticProperty.artigos.Where(a => a.id == art.artigoId).First().descricao;

                        data.Rows.Add(artigoDescricao, art.qtd, art.iva, art.preco);
                    }
                }
                else if (_documento.ToUpper().Equals("COT"))
                {
                    var documentoDados = StaticProperty.cots.Where(v => v.id == _documentoId).First();

                    indexSpace = documentoDados.documento.IndexOf(" ");
                    codigo = documentoDados.documento.Substring(0, indexSpace);

                    index = documentoDados.documento.IndexOf("/");
                    num = documentoDados.documento.Substring(index + 1);

                    serie = documentoDados.documento.Substring(indexSpace , (index - indexSpace));

                    codigoDocumento.Text = codigo;
                    numDocumento.Text = num;
                    serieDocumento.Text = serie;
                    dataDocumento.Text = documentoDados.data.ToString();


                    foreach (var art in documentoDados.cArtigo)
                    {
                        var artigoDescricao = StaticProperty.artigos.Where(a => a.id == art.artigoId).First().descricao;

                        data.Rows.Add(artigoDescricao, art.qtd, art.iva, art.preco);
                    }
                }
            }
            if (_entidade == Entidade.cliente)
            {
                if (_documento.ToUpper().Equals("FR"))
                {
                    var documentoDados = StaticProperty.frs.Where(v => v.id == _documentoId).First();

                    indexSpace = documentoDados.documento.IndexOf(" ");
                    codigo = documentoDados.documento.Substring(0, indexSpace);

                    index = documentoDados.documento.IndexOf("/");
                    num = documentoDados.documento.Substring(index + 1);

                    serie = documentoDados.documento.Substring(indexSpace , (index - indexSpace));

                    codigoDocumento.Text = codigo;
                    numDocumento.Text = num;
                    serieDocumento.Text = serie;
                    dataDocumento.Text = documentoDados.data.ToString();


                    foreach (var art in documentoDados.frArtigo)
                    {
                        var artigoDescricao = StaticProperty.artigos.Where(a => a.id == art.artigoId).First().descricao;

                        data.Rows.Add(artigoDescricao, art.qtd, art.iva, art.preco);
                    }
                }
                else if (_documento.ToUpper().Equals("FT"))
                {
                    var documentoDados = StaticProperty.fts.Where(v => v.id == _documentoId).First();

                    indexSpace = documentoDados.documento.IndexOf(" ");
                    codigo = documentoDados.documento.Substring(0, indexSpace);

                    index = documentoDados.documento.IndexOf("/");
                    num = documentoDados.documento.Substring(index + 1);

                    serie = documentoDados.documento.Substring(indexSpace, (index - indexSpace));

                    codigoDocumento.Text = codigo;
                    numDocumento.Text = num;
                    serieDocumento.Text = serie;
                    dataDocumento.Text = documentoDados.data.ToString();


                    foreach (var art in documentoDados.ftArtigo)
                    {
                        var artigoDescricao = StaticProperty.artigos.Where(a => a.id == art.artigoId).First().descricao;

                        data.Rows.Add(artigoDescricao, art.qtd, art.iva, art.preco);
                    }
                }
                else if (_documento.ToUpper().Equals("ECL"))
                {
                    var documentoDados = StaticProperty.ecls.Where(v => v.id == _documentoId).First();

                    indexSpace = documentoDados.documento.IndexOf(" ");
                    codigo = documentoDados.documento.Substring(0, indexSpace);

                    index = documentoDados.documento.IndexOf("/");
                    num = documentoDados.documento.Substring(index + 1);

                    serie = documentoDados.documento.Substring(indexSpace, (index - indexSpace));

                    codigoDocumento.Text = codigo;
                    numDocumento.Text = num;
                    serieDocumento.Text = serie;
                    dataDocumento.Text = documentoDados.data.ToString();


                    foreach (var art in documentoDados.eclArtigo)
                    {
                        var artigoDescricao = StaticProperty.artigos.Where(a => a.id == art.artigoId).First().descricao;

                        data.Rows.Add(artigoDescricao, art.qtd, art.iva, art.preco);
                    }
                }
                else if (_documento.ToUpper().Equals("GT"))
                {
                    var documentoDados = StaticProperty.gts.Where(v => v.id == _documentoId).First();

                    indexSpace = documentoDados.documento.IndexOf(" ");
                    codigo = documentoDados.documento.Substring(0, indexSpace);

                    index = documentoDados.documento.IndexOf("/");
                    num = documentoDados.documento.Substring(index + 1);

                    serie = documentoDados.documento.Substring(indexSpace , (index - indexSpace));

                    codigoDocumento.Text = codigo;
                    numDocumento.Text = num;
                    serieDocumento.Text = serie;
                    dataDocumento.Text = documentoDados.data.ToString();


                    foreach (var art in documentoDados.gtArtigo)
                    {
                        var artigoDescricao = StaticProperty.artigos.Where(a => a.id == art.artigoId).First().descricao;

                        data.Rows.Add(artigoDescricao, art.qtd, art.iva, art.preco);
                    }
                }
                else if (_documento.ToUpper().Equals("GR"))
                {
                    var documentoDados = StaticProperty.grs.Where(v => v.id == _documentoId).First();

                    indexSpace = documentoDados.documento.IndexOf(" ");
                    codigo = documentoDados.documento.Substring(0, indexSpace);

                    index = documentoDados.documento.IndexOf("/");
                    num = documentoDados.documento.Substring(index + 1);

                    serie = documentoDados.documento.Substring(indexSpace, (index - indexSpace));

                    codigoDocumento.Text = codigo;
                    numDocumento.Text = num;
                    serieDocumento.Text = serie;
                    dataDocumento.Text = documentoDados.data.ToString();


                    foreach (var art in documentoDados.grArtigo)
                    {
                        var artigoDescricao = StaticProperty.artigos.Where(a => a.id == art.artigoId).First().descricao;

                        data.Rows.Add(artigoDescricao, art.qtd, art.iva, art.preco);
                    }
                }
                else if (_documento.ToUpper().Equals("NC"))
                {
                    var documentoDados = StaticProperty.ncs.Where(v => v.id == _documentoId).First();

                    indexSpace = documentoDados.documento.IndexOf(" ");
                    codigo = documentoDados.documento.Substring(0, indexSpace);

                    index = documentoDados.documento.IndexOf("/");
                    num = documentoDados.documento.Substring(index + 1);

                    serie = documentoDados.documento.Substring(indexSpace , (index - indexSpace));

                    codigoDocumento.Text = codigo;
                    numDocumento.Text = num;
                    serieDocumento.Text = serie;
                    dataDocumento.Text = documentoDados.data.ToString();


                    foreach (var art in documentoDados.ncArtigo)
                    {
                        var artigoDescricao = StaticProperty.artigos.Where(a => a.id == art.artigoId).First().descricao;

                        data.Rows.Add(artigoDescricao, art.qtd, art.iva, art.preco);
                    }
                }
                else if (_documento.ToUpper().Equals("ND"))
                {
                    var documentoDados = StaticProperty.nds.Where(v => v.id == _documentoId).First();
                 
                    indexSpace = documentoDados.documento.IndexOf(" ");
                    codigo = documentoDados.documento.Substring(0, indexSpace);

                    index = documentoDados.documento.IndexOf("/");
                    num = documentoDados.documento.Substring(index + 1);

                    serie = documentoDados.documento.Substring(indexSpace, (index - indexSpace));

                    codigoDocumento.Text = codigo;
                    numDocumento.Text = num;
                    serieDocumento.Text = serie;
                    dataDocumento.Text = documentoDados.data.ToString();


                    foreach (var art in documentoDados.ndArtigo)
                    {
                        var artigoDescricao = StaticProperty.artigos.Where(a => a.id == art.artigoId).First().descricao;

                        data.Rows.Add(artigoDescricao, art.qtd, art.iva, art.preco);
                    }
                }
                else if (_documento.ToUpper().Equals("OR"))
                {
                    var documentoDados = StaticProperty.ors.Where(v => v.id == _documentoId).First();

                    indexSpace = documentoDados.documento.IndexOf(" ");
                    codigo = documentoDados.documento.Substring(0, indexSpace);

                    index = documentoDados.documento.IndexOf("/");
                    num = documentoDados.documento.Substring(index + 1);

                    serie = documentoDados.documento.Substring(indexSpace, (index - indexSpace));

                    codigoDocumento.Text = codigo;
                    numDocumento.Text = num;
                    serieDocumento.Text = serie;
                    dataDocumento.Text = documentoDados.data.ToString();


                    foreach (var art in documentoDados.orArtigos)
                    {
                        var artigoDescricao = StaticProperty.artigos.Where(a => a.id == art.artigoId).First().descricao;

                        data.Rows.Add(artigoDescricao, art.qtd, art.iva, art.preco);
                    }
                }
                else if (_documento.ToUpper().Equals("FP"))
                {
                    var documentoDados = StaticProperty.fps.Where(v => v.id == _documentoId).First();

                    indexSpace = documentoDados.documento.IndexOf(" ");
                    codigo = documentoDados.documento.Substring(0, indexSpace);

                    index = documentoDados.documento.IndexOf("/");
                    num = documentoDados.documento.Substring(index + 1);

                    serie = documentoDados.documento.Substring(indexSpace , (index - indexSpace));

                    codigoDocumento.Text = codigo;
                    numDocumento.Text = num;
                    serieDocumento.Text = serie;
                    dataDocumento.Text = documentoDados.data.ToString();


                    foreach (var art in documentoDados.fpArtigo)
                    {
                        var artigoDescricao = StaticProperty.artigos.Where(a => a.id == art.artigoId).First().descricao;

                        data.Rows.Add(artigoDescricao, art.qtd, art.iva, art.preco);
                    }
                }
            }
         
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
       
            
            if (_entidade == Entidade.cliente)
            {
                vendaArtigos.Clear();
                if (_documento == "FR") { descricaoDocumento = "Factura Recibo"; }
                else if (_documento == "FT") { descricaoDocumento = "Factura"; }
                else if (_documento == "ECL") { descricaoDocumento = "Encomenda a Cliente"; }
                else if (_documento == "GT") { descricaoDocumento = "Guia de Transporte"; }
                else if (_documento == "PP") { descricaoDocumento = "Factura Proforma"; }
                else if (_documento == "NC") { descricaoDocumento = "Nota Credito"; }
                else if (_documento  == "ND") { descricaoDocumento = "Nota Debito"; }
                else if (_documento == "OR") { descricaoDocumento = "Orçamento"; }
                else if (_documento == "GR") { descricaoDocumento = "Guia Remessa"; }

                if (_documento.Equals("FT"))
                {
                     var entidade = StaticProperty.fts.Where(x => x.id == _documentoId).Any()?
                                    StaticProperty.fts.Where(x => x.id == _documentoId).First() : new FtDTO();

                    StaticProperty.hash = entidade.shortHash;
                    codigoDoc = entidade.documento;

                    anulado = entidade.status == DocState.anulado ? true : false;

                    foreach (var item in entidade.ftArtigo) 
                    {
                        vendaArtigos.Add(new VendaArtigo { codigo = StaticProperty.artigos.Where(x => x.id == item.artigoId).First().codigo ?? string.Empty,
                                                           desconto = item.desconto, iva = item.iva, preco = item.preco, qtd = item.qtd});

                    }

                    clienteResult = StaticProperty.clientes.Where(x => x.id == entidade.clienteId ).Any() ? StaticProperty.clientes.Where(x => x.id == entidade.clienteId).First() : new ClienteDTO();
                }
                else if (_documento.Equals("FR"))
                {

                    var entidade = StaticProperty.frs.Where(x => x.id == _documentoId).Any() ?
                                   StaticProperty.frs.Where(x => x.id == _documentoId).First() : new FrDTO();

                    StaticProperty.hash = entidade.shortHash;
                    codigoDoc = entidade.documento;
                    anulado = entidade.status == DocState.anulado ? true : false;

                    foreach (var item in entidade.frArtigo)
                    {
                        vendaArtigos.Add(new VendaArtigo
                        {
                            codigo = StaticProperty.artigos.Where(x => x.id == item.artigoId).First().codigo ?? string.Empty,
                            desconto = item.desconto,
                            iva = item.iva,
                            preco = item.preco,
                            qtd = item.qtd
                        });

                    }

                    clienteResult = StaticProperty.clientes.Where(x => x.id == entidade.clienteId).Any() ? StaticProperty.clientes.Where(x => x.id == entidade.clienteId).First() : new ClienteDTO();
                }
                else if (_documento.Equals("ECL"))
                {
                    var entidade = StaticProperty.ecls.Where(x => x.id == _documentoId).Any() ?
                                   StaticProperty.ecls.Where(x => x.id == _documentoId).First(): new EncomendaClienteDTO();

                    StaticProperty.hash = entidade.shortHash;

                    codigoDoc = entidade.documento;
                    anulado = entidade.status == DocState.anulado ? true : false;

                    foreach (var item in entidade.eclArtigo)
                    {
                        vendaArtigos.Add(new VendaArtigo
                        {
                            codigo = StaticProperty.artigos.Where(x => x.id == item.artigoId).First().codigo ?? string.Empty,
                            desconto = item.desconto,
                            iva = item.iva,
                            preco = item.preco,
                            qtd = item.qtd
                        });

                    }

                    clienteResult = StaticProperty.clientes.Where(x => x.id == entidade.clienteId).Any() ? StaticProperty.clientes.Where(x => x.id == entidade.clienteId).First() : new ClienteDTO();
                }
                else if (_documento.Equals("PP"))
                {
                    var entidade = StaticProperty.fps.Where(x => x.id == _documentoId).Any() ?
                                   StaticProperty.fps.Where(x => x.id == _documentoId).First() : new FaturaProformaDTO();

                    StaticProperty.hash = entidade.shortHash;

                    codigoDoc = entidade.documento;
                    anulado = entidade.status == DocState.anulado ? true : false;

                    foreach (var item in entidade.fpArtigo)
                    {
                        vendaArtigos.Add(new VendaArtigo
                        {
                            codigo = StaticProperty.artigos.Where(x => x.id == item.artigoId).First().codigo ?? string.Empty,
                            desconto = item.desconto,
                            iva = item.iva,
                            preco = item.preco,
                            //qtd = item.qtd
                        });

                    }

                    clienteResult = StaticProperty.clientes.Where(x => x.id == entidade.clienteId).Any() ? StaticProperty.clientes.Where(x => x.id == entidade.clienteId).First() : new ClienteDTO();
                }
                else if (_documento.Equals("GT"))
                {
                    var entidade = StaticProperty.gts.Where(x => x.id == _documentoId).Any() ?
                                   StaticProperty.gts.Where(x => x.id == _documentoId).First() : new GtDTO();

                    StaticProperty.hash = entidade.shortHash;

                    codigoDoc = entidade.documento;
                    anulado = entidade.status == DocState.anulado ? true : false;

                    foreach (var item in entidade.gtArtigo)
                    {
                        vendaArtigos.Add(new VendaArtigo
                        {
                            codigo = StaticProperty.artigos.Where(x => x.id == item.artigoId).First().codigo ?? string.Empty,
                            desconto = item.desconto,
                            iva = item.iva,
                            preco = item.preco,
                            qtd = item.qtd
                        });

                    }

                    clienteResult = StaticProperty.clientes.Where(x => x.id == entidade.clienteId).Any() ? StaticProperty.clientes.Where(x => x.id == entidade.clienteId).First() : new ClienteDTO();
                }
                else if (_documento.Equals("GR"))
                {
                    var entidade = StaticProperty.grs.Where(x => x.id == _documentoId).Any() ?
                                   StaticProperty.grs.Where(x => x.id == _documentoId).First() : new GrDTO();

                    codigoDoc = entidade.documento;
                    StaticProperty.hash = entidade.shortHash;

                    foreach (var item in entidade.grArtigo)
                    {
                        vendaArtigos.Add(new VendaArtigo
                        {
                            codigo = StaticProperty.artigos.Where(x => x.id == item.artigoId).First().codigo ?? string.Empty,
                            desconto = item.desconto,
                            iva = item.iva,
                            preco = item.preco,
                            qtd = item.qtd
                        });

                    }

                    clienteResult = StaticProperty.clientes.Where(x => x.id == entidade.clienteId).Any() ? StaticProperty.clientes.Where(x => x.id == entidade.clienteId).First() : new ClienteDTO();
                }
                else if (_documento.Equals("NC"))
                {
                    var entidade = StaticProperty.ncs.Where(x => x.id == _documentoId).Any() ?
                                   StaticProperty.ncs.Where(x => x.id == _documentoId).First(): new NcDTO();

                    codigoDoc = entidade.documento;
                    StaticProperty.hash = entidade.shortHash;
                    StaticProperty.motivoAnulacao = entidade.motivo;
                    StaticProperty.documentoOrigem = entidade.documentoOrigem;

                    anulado = entidade.status == DocState.anulado ? true : false;

                    foreach (var item in entidade.ncArtigo)
                    {
                        vendaArtigos.Add(new VendaArtigo
                        {
                            codigo = StaticProperty.artigos.Where(x => x.id == item.artigoId).First().codigo ?? string.Empty,
                            desconto = item.desconto,
                            iva = item.iva,
                            preco = item.preco,
                            qtd = item.qtd
                        });

                    }

                    clienteResult = StaticProperty.clientes.Where(x => x.id == entidade.clienteId).Any() ? StaticProperty.clientes.Where(x => x.id == entidade.clienteId).First() : new ClienteDTO();
                }
                else if (_documento.Equals("OR"))
                {
                    var entidade = StaticProperty.ors.Where(x => x.id == _documentoId).Any() ?
                                   StaticProperty.ors.Where(x => x.id == _documentoId).First() : new OrDTO();

                    StaticProperty.hash = entidade.shortHash;

                    codigoDoc = entidade.documento;
                    anulado = entidade.status == DocState.anulado ? true : false;

                    foreach (var item in entidade.orArtigos)
                    {
                        vendaArtigos.Add(new VendaArtigo
                        {
                            codigo = StaticProperty.artigos.Where(x => x.id == item.artigoId).First().codigo ?? string.Empty,
                            desconto = item.desconto,
                            iva = item.iva,
                            preco = item.preco,
                            qtd = item.qtd
                        });

                    }

                    clienteResult = StaticProperty.clientes.Where(x => x.id == entidade.clienteId).Any() ? StaticProperty.clientes.Where(x => x.id == entidade.clienteId).First() : new ClienteDTO();
                }
                else if (_documento.Equals("ND"))
                {
                    var entidade = StaticProperty.nds.Where(x => x.id == _documentoId).Any() ?
                                   StaticProperty.nds.Where(x => x.id == _documentoId).First() : new NdDTO();

                    codigoDoc = entidade.documento;
                    StaticProperty.hash = entidade.shortHash;

                    anulado = entidade.status == DocState.anulado ? true : false;

                    foreach (var item in entidade.ndArtigo)
                    {
                        vendaArtigos.Add(new VendaArtigo
                        {
                            codigo = StaticProperty.artigos.Where(x => x.id == item.artigoId).First().codigo ?? string.Empty,
                            desconto = item.desconto,
                            iva = item.iva,
                            preco = item.preco,
                            qtd = item.qtd
                        });

                    }

                    clienteResult = StaticProperty.clientes.Where(x => x.id == entidade.clienteId).Any() ? StaticProperty.clientes.Where(x => x.id == entidade.clienteId).First() : new ClienteDTO();
                }

                preVisualizacaoDialog.Document = printVenda;

                if (preVisualizacaoDialog.ShowDialog() == DialogResult.OK)
                {
                    printVenda.Print();
                }
                
            }

            if (_entidade == Entidade.fornecedor)
            {
                compraArtigos.Clear();

                if (_documento == "VFR") { descricaoDocumento = "V/Factura Recibo"; }
                else if (_documento == "VFT") { descricaoDocumento = "V/Factura"; }
                else if (_documento == "ECF") { descricaoDocumento = "Encomenda a Fornecedor"; }
                else if (_documento == "VGT") { descricaoDocumento = "V/Guia de Transporte"; }
                else if (_documento == "PCO") { descricaoDocumento = "Pedido Cotação"; }
                else if (_documento == "COT") { descricaoDocumento = "Cotação"; }
                else if (_documento == "VNC") { descricaoDocumento = "V/Nota Crédito"; }
                else if (_documento == "VND") { descricaoDocumento = "V/Nota Débito"; }
                else if (_documento == "VGR") { descricaoDocumento = "V/Guia de Remessa"; }

                if (_documento.Equals("VFT"))
                {
                    var entidade = StaticProperty.vfts.Where(x => x.id == _documentoId).Any() ?
                                   StaticProperty.vfts.Where(x => x.id == _documentoId).First() : new VftDTO();

                    codigoDoc = entidade.documento;
                    anulado = entidade.status == DocState.anulado ? true : false;

                    foreach (var item in entidade.vftArtigo)
                    {
                        compraArtigos.Add(new CompraArtigo
                        {
                            codigo = StaticProperty.artigos.Where(x => x.id == item.artigoId).First().codigo ?? string.Empty,
                            desconto = item.desconto,
                            iva = item.iva,
                            preco = item.preco,
                            qtd = item.qtd
                        });

                    }

                    fornecedorResult = StaticProperty.fornecedores.Where(x => x.id == entidade.fornecedorId).Any() ? StaticProperty.fornecedores.Where(x => x.id == entidade.fornecedorId).First() : new FornecedorDTO();
                }
                else if (_documento.Equals("VFR"))
                {
                    var entidade = StaticProperty.vfrs.Where(x => x.id == _documentoId).Any() ?
                            StaticProperty.vfrs.Where(x => x.id == _documentoId).First() : new VfrDTO();
                    codigoDoc = entidade.documento;
                    anulado = entidade.status == DocState.anulado ? true : false;

                    foreach (var item in entidade.vfrArtigo)
                    {
                        compraArtigos.Add(new CompraArtigo
                        {
                            codigo = StaticProperty.artigos.Where(x => x.id == item.artigoId).First().codigo ?? string.Empty,
                            desconto = item.desconto,
                            iva = item.iva,
                            preco = item.preco,
                            qtd = item.qtd
                        });

                    }

                    fornecedorResult = StaticProperty.fornecedores.Where(x => x.id == entidade.fornecedorId).Any() ? StaticProperty.fornecedores.Where(x => x.id == entidade.fornecedorId).First() : new FornecedorDTO();
                }
                else if (_documento.Equals("ECF"))
                {
                    var entidade = StaticProperty.ecfs.Where(x => x.id == _documentoId).Any() ?
                                   StaticProperty.ecfs.Where(x => x.id == _documentoId).First() : new EncomendaFornecedorDTO();
                    
                    codigoDoc = entidade.documento;
                    anulado = entidade.status == DocState.anulado ? true : false;

                    foreach (var item in entidade.ecfArtigo)
                    {
                        compraArtigos.Add(new CompraArtigo
                        {
                            codigo = StaticProperty.artigos.Where(x => x.id == item.artigoId).First().codigo ?? string.Empty,
                            desconto = item.desconto,
                            iva = item.iva,
                            preco = item.preco,
                            qtd = item.qtd
                        });

                    }

                    fornecedorResult = StaticProperty.fornecedores.Where(x => x.id == entidade.fornecedorId).Any() ? StaticProperty.fornecedores.Where(x => x.id == entidade.fornecedorId).First() : new FornecedorDTO();
                }
                else if (_documento.Equals("PCO"))
                {
                    var entidade = StaticProperty.pcos.Where(x => x.id == _documentoId).Any() ?
                             StaticProperty.pcos.Where(x => x.id == _documentoId).First() : new PedidoCotacaoDTO();

                    codigoDoc = entidade.documento;
                    anulado = entidade.status == DocState.anulado ? true : false;

                    foreach (var item in entidade.pcArtigo)
                    {
                        compraArtigos.Add(new CompraArtigo
                        {
                            codigo = StaticProperty.artigos.Where(x => x.id == item.artigoId).First().codigo ?? string.Empty,
                            desconto = item.desconto,
                            iva = item.iva,
                            preco = item.preco,
                          //  qtd = item.qtd
                        });

                    }

                    fornecedorResult = StaticProperty.fornecedores.Where(x => x.id == entidade.fornecedorId).Any() ? StaticProperty.fornecedores.Where(x => x.id == entidade.fornecedorId).First() : new FornecedorDTO();
                }
                else if (_documento.Equals("VGT"))
                {
                    var entidade = StaticProperty.vgts.Where(x => x.id == _documentoId).Any() ?
                                   StaticProperty.vgts.Where(x => x.id == _documentoId).First(): new VgtDTO();

                    codigoDoc = entidade.documento;
                    anulado = entidade.status == DocState.anulado ? true : false;

                    foreach (var item in entidade.vgtArtigo)
                    {
                        compraArtigos.Add(new CompraArtigo
                        {
                            codigo = StaticProperty.artigos.Where(x => x.id == item.artigoId).First().codigo ?? string.Empty,
                            desconto = item.desconto,
                            iva = item.iva,
                            preco = item.preco,
                            qtd = item.qtd
                        });

                    }

                    fornecedorResult = StaticProperty.fornecedores.Where(x => x.id == entidade.fornecedorId).Any() ? StaticProperty.fornecedores.Where(x => x.id == entidade.fornecedorId).First() : new FornecedorDTO();
                }
                else if (_documento.Equals("VGR"))
                {
                    var entidade = StaticProperty.vgrs.Where(x => x.id == _documentoId).Any() ?
                                StaticProperty.vgrs.Where(x => x.id == _documentoId).First() : new VgrDTO();

                    codigoDoc = entidade.documento;
                    anulado = entidade.status == DocState.anulado ? true : false;

                    foreach (var item in entidade.vgrArtigo)
                    {
                        compraArtigos.Add(new CompraArtigo
                        {
                            codigo = StaticProperty.artigos.Where(x => x.id == item.artigoId).First().codigo ?? string.Empty,
                            desconto = item.desconto,
                            iva = item.iva,
                            preco = item.preco,
                            qtd = item.qtd
                        });

                    }

                    fornecedorResult = StaticProperty.fornecedores.Where(x => x.id == entidade.fornecedorId).Any() ? StaticProperty.fornecedores.Where(x => x.id == entidade.fornecedorId).First() : new FornecedorDTO();
                }
                else if (_documento.Equals("VNC"))
                {
                    var entidade = StaticProperty.vncs.Where(x => x.id == _documentoId).Any() ?
                                   StaticProperty.vncs.Where(x => x.id == _documentoId).First() : new VncDTO();

                    codigoDoc = entidade.documento;
                    anulado = entidade.status == DocState.anulado ? true : false;

                    foreach (var item in entidade.vncArtigo)
                    {
                        compraArtigos.Add(new CompraArtigo
                        {
                            codigo = StaticProperty.artigos.Where(x => x.id == item.artigoId).First().codigo ?? string.Empty,
                            desconto = item.desconto,
                            iva = item.iva,
                            preco = item.preco,
                            qtd = item.qtd
                        });

                    }

                    fornecedorResult = StaticProperty.fornecedores.Where(x => x.id == entidade.fornecedorId).Any() ? StaticProperty.fornecedores.Where(x => x.id == entidade.fornecedorId).First() : new FornecedorDTO();
                }
                else if (_documento.Equals("VND"))
                {
                    var entidade = StaticProperty.vnds.Where(x => x.id == _documentoId).Any() ?
                                   StaticProperty.vnds.Where(x => x.id == _documentoId).First() : new VndDTO();

                    codigoDoc = entidade.documento;
                    anulado = entidade.status == DocState.anulado ? true : false;

                    foreach (var item in entidade.vndArtigo)
                    {
                        compraArtigos.Add(new CompraArtigo
                        {
                            codigo = StaticProperty.artigos.Where(x => x.id == item.artigoId).First().codigo ?? string.Empty,
                            desconto = item.desconto,
                            iva = item.iva,
                            preco = item.preco,
                            qtd = item.qtd
                        });

                    }

                    fornecedorResult = StaticProperty.fornecedores.Where(x => x.id == entidade.fornecedorId).Any() ? StaticProperty.fornecedores.Where(x => x.id == entidade.fornecedorId).First() : new FornecedorDTO();
                }

                preVisualizacaoDialog.Document = printCompra;

                if (preVisualizacaoDialog.ShowDialog() == DialogResult.OK)
                {
                    printCompra.Print();
                }
            }

        }

        private void printVenda_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            try
            {
                float totalLiquido = 0f;
                float totalIva = 0f;
                float total = 0f;
                float incidencia = 0f;
                float descontoCliente = CalculosVendaCompra.TotalDescontoCliente(vendaArtigos, clienteResult.desconto);
                List<float> listaIvas = new List<float>();

                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string projectPath = Path.GetFullPath(Path.Combine(basePath, @"..\.."));
                string imagePathEmpresa = Path.Combine(projectPath, "Files", "Smart_Entity.png");
                string imagePathAsc = Path.Combine(projectPath, "Files", "asc.png");
                // Testar com valores fixos para desenhar uma string
                Font fontNormal = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Pixel);
                Font fontNormalNegrito = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Pixel);
                Font fontCabecalho = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Pixel);
                Font fontCabecalhoNegrito = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Pixel);
                Brush cor = new SolidBrush(Color.Black);

                PointF ponto = new PointF(50, 150);
                PointF pontoRight = new PointF(550, 150);

                StringFormat formatToRight = new StringFormat();
                formatToRight.Alignment = StringAlignment.Far;

                StringFormat formatToLeft = new StringFormat();
                formatToLeft.Alignment = StringAlignment.Near;

                StringFormat formatToCenter = new StringFormat();
                formatToCenter.Alignment = StringAlignment.Near;

                var empresa = StaticProperty.empresa;

                string empresaNome = $"{empresa.nome_fantasia}";
                string empresaCabecalho = $"Endereço: {empresa.endereco}\nNif: {empresa.nif}\n" +
                                          $"Email: {empresa.email}\nContactos: {empresa.telefone}";

                var tel = clienteResult.phones.Any() ? clienteResult.phones.First().telefone : "000000000";

                string clienteCabecalho = $"Exmo (s) Senhor (a)\n";
                string clienteOutros = $"{clienteResult.nome_fantasia.ToUpper()}\nEndereço: {clienteResult.localizacao}\nNif: {clienteResult.nif}\n" +
                                          $"Email: {clienteResult.email}\nTel: {tel}";


                Pen caneta = new Pen(Color.Black, 2); // Define a cor e a largura da linha
                Pen canetaFina = new Pen(Color.Black, 1);
                float linhaInicioX = 550; // Ponto X de início da linha
                float linhaInicioY = 136; // Ajuste conforme necessário para a posição vertical da linha
                float linhaFimX = 750; // Ponto X de fim da linha


                // Verificar se e.Graphics é válido
                if (e.Graphics == null)
                {
                    throw new Exception("O objeto e.Graphics é nulo.");
                }

                e.Graphics.DrawImage(Image.FromFile(imagePathEmpresa), new Rectangle(40, 50, 100, 100));
                // Desenhar a string
                e.Graphics.DrawString(empresaNome, fontCabecalhoNegrito, cor, new PointF(50, 135), formatToLeft);
                e.Graphics.DrawString(empresaCabecalho, fontCabecalho, cor, ponto, formatToLeft);

                e.Graphics.DrawString("2ª Via ", fontNormal, cor, new PointF(750, 120), formatToRight);
                e.Graphics.DrawLine(caneta, linhaInicioX, linhaInicioY, linhaFimX, linhaInicioY);
                e.Graphics.DrawString(clienteCabecalho, fontNormalNegrito, cor, new PointF(550, 138), formatToLeft);
                e.Graphics.DrawString(clienteOutros, fontCabecalho, cor, pontoRight, formatToLeft);

                e.Graphics.DrawString($"Operador: {StaticProperty.user.user_name}", fontNormalNegrito, cor, new PointF(50, 215), formatToLeft);


                if (_documento.Equals("NC"))
                {
                    e.Graphics.DrawString("Anulação", fontNormalNegrito, cor, new PointF(550, 215), formatToLeft);
                    e.Graphics.DrawString("Motivo:", fontNormalNegrito, cor, new PointF(550, 230), formatToLeft);
                    e.Graphics.DrawString($"{StaticProperty.motivoAnulacao.ToString()}", fontNormal, cor, new PointF(600, 230), formatToLeft);
                    e.Graphics.DrawString("Documento de Origem:", fontNormalNegrito, cor, new PointF(550, 245), formatToLeft);
                    e.Graphics.DrawString($"{StaticProperty.documentoOrigem.ToString()}", fontNormal, cor, new PointF(690, 247), formatToLeft);
                }
                if (anulado) 
                {
                    e.Graphics.DrawString("Documento Anulado", fontNormalNegrito, new SolidBrush(Color.Red), new PointF(550, 215), formatToLeft);
                }


                e.Graphics.DrawString($"{descricaoDocumento}  {codigoDoc}", fontNormalNegrito, cor, new PointF(50, 280), formatToLeft);
                e.Graphics.DrawLine(canetaFina, 50, 295, 250, 295);
                e.Graphics.DrawString("NIF", fontNormalNegrito, cor, new Rectangle(50, 300, 200, 310));
                e.Graphics.DrawString("Desc. Cli", fontNormalNegrito, cor, new Rectangle(200, 300, 350, 310));
                e.Graphics.DrawString("Data Emissão", fontNormalNegrito, cor, new Rectangle(350, 300, 500, 310));
                e.Graphics.DrawString("Data Vencimento", fontNormalNegrito, cor, new Rectangle(500, 300, 650, 310));
                e.Graphics.DrawLine(caneta, 50, 315, 750, 315);

                e.Graphics.DrawString($"{clienteResult.nif}", fontNormal, cor, new Rectangle(50, 330, 200, 340));
                e.Graphics.DrawString($"{descontoCliente}", fontNormal, cor, new Rectangle(200, 330, 350, 340));
                e.Graphics.DrawString($"{DateTime.Now.Date.ToString("dd-mm-yyyy")}", fontNormal, cor, new Rectangle(350, 330, 450, 340));

                if (_documento.Equals("FR"))
                {
                    e.Graphics.DrawString($"{DateTime.Now.Date}", fontNormal, cor, new Rectangle(500, 330, 650, 340));
                }
                else
                {
                    e.Graphics.DrawString($"-", fontNormal, cor, new Rectangle(500, 330, 650, 340));
                }

                e.Graphics.DrawString($"Artigo", fontNormalNegrito, cor, new Rectangle(50, 400, 200, 420));
                e.Graphics.DrawString("Descricao", fontNormalNegrito, cor, new Rectangle(200, 400, 350, 420));
                e.Graphics.DrawString($"Quantidade", fontNormalNegrito, cor, new Rectangle(350, 400, 450, 420));
                e.Graphics.DrawString($"P/Unitario", fontNormalNegrito, cor, new Rectangle(450, 400, 550, 420));
                e.Graphics.DrawString("Iva %", fontNormalNegrito, cor, new Rectangle(550, 400, 650, 420));
                e.Graphics.DrawString($"Desconto", fontNormalNegrito, cor, new Rectangle(600, 400, 700, 420));
                e.Graphics.DrawString($"Total", fontNormalNegrito, cor, new Rectangle(700, 400, 750, 420));
                e.Graphics.DrawLine(caneta, 50, 415, 750, 415);
                int i = 15;
                foreach (VendaArtigo va in vendaArtigos)
                {
                    totalIva += va.iva;
                    total += va.preco * float.Parse(va.qtd.ToString());

                    e.Graphics.DrawString($"{va.codigo}", fontNormal, cor, new Rectangle(50, 410 + i, 200, 425 + i));
                    e.Graphics.DrawString($"{StaticProperty.artigos.Where(art => art.codigo == va.codigo && art.empresaId == StaticProperty.empresaId).First().descricao}", fontNormal, cor, new Rectangle(200, 410 + i, 350, 425 + i));
                    e.Graphics.DrawString($"{va.qtd:F4}", fontNormal, cor, new Rectangle(350, 410 + i, 450, 425 + i));
                    e.Graphics.DrawString($"{va.preco.ToString("F4")}", fontNormal, cor, new Rectangle(450, 410 + i, 550, 425 + i));
                    e.Graphics.DrawString($"{(StaticProperty.artigos.Where(art => art.codigo == va.codigo && art.empresaId == StaticProperty.empresaId).First().regimeIva == OpcaoBinaria.Sim ? va.iva : 0).ToString("F4")} %", fontNormal, cor, new Rectangle(550, 410 + i, 650, 425 + i));
                    e.Graphics.DrawString($"{(((va.preco - (va.preco * (clienteResult.desconto / 100))) * (va.desconto / 100)) * va.qtd).ToString("F2")}", fontNormal, cor, new Rectangle(600, 410 + i, 700, 425 + i));
                    e.Graphics.DrawString($"{(va.preco * float.Parse(va.qtd.ToString())).ToString("F2")}", fontNormal, cor, new Rectangle(700, 410 + i, 750, 425 + i));

                    i = i + 15;
                }

                totalLiquido += CalculosVendaCompra.TotalVenda(vendaArtigos, clienteResult.desconto);
                total = total - (CalculosVendaCompra.TotalDescontoVenda(vendaArtigos, clienteResult.desconto));

                string mercadoria = $"Total Ilíquido";
                string totalIvaValor = $"Total Imposto:";
                string totalFinal = $"Total á pagar";
                var desconto = CalculosVendaCompra.TotalDescontoVenda(vendaArtigos, clienteResult.desconto) + CalculosVendaCompra.TotalDescontoCliente(vendaArtigos, clienteResult.desconto);


                e.Graphics.DrawRectangle(caneta, new Rectangle(540, 530 + i, 210, 70 + i));

                e.Graphics.DrawString(mercadoria, fontCabecalho, cor, new PointF(550, 545 + i), formatToLeft);
                e.Graphics.DrawString(totalLiquido.ToString("F2"), fontCabecalho, cor, new PointF(680, 545 + i), formatToLeft);
                e.Graphics.DrawString(totalIvaValor, fontCabecalho, cor, new PointF(550, 555 + i), formatToLeft);
                e.Graphics.DrawString((total * (totalIva / 100)).ToString("F2"), fontCabecalho, cor, new PointF(680, 555 + i), formatToLeft);
                e.Graphics.DrawString("Desconto", fontCabecalho, cor, new PointF(550, 565 + i), formatToLeft);
                e.Graphics.DrawString($"{desconto:F2}", fontCabecalho, cor, new PointF(680, 565 + i), formatToLeft);

                e.Graphics.DrawLine(canetaFina, 550, 580 + i, 740, 580 + i);
                e.Graphics.DrawString(totalFinal, fontNormalNegrito, cor, new PointF(550, 605 + i), formatToLeft);
                e.Graphics.DrawString(total.ToString("F2"), fontNormalNegrito, cor, new PointF(680, 605 + i), formatToLeft);

                string conta = $"Conta nº";
                string iban = $"IBAN ";
                string banco = $"Banco Angolano de Investimento";

                e.Graphics.DrawString($"{StaticProperty.hash} - Processado por programa válido nº 31.1/AGT20 Asc - Smart Entity", fontCabecalho, cor, new PointF(250, 515 + i), formatToCenter);
                e.Graphics.DrawString($"Resumo Imposto", fontCabecalho, cor, new PointF(50, 515 + i), formatToCenter);

                e.Graphics.DrawLine(caneta, 50, 530 + i, 530, 530 + i);
                e.Graphics.DrawString("Descrição", new Font("Arial", 10, GraphicsUnit.Pixel), cor, new PointF(50, 540 + i), formatToLeft);
                e.Graphics.DrawString("Taxa %", fontCabecalhoNegrito, cor, new PointF(130, 540 + i), formatToLeft);
                e.Graphics.DrawString("Incidência", fontCabecalho, cor, new PointF(200, 540 + i), formatToLeft);
                e.Graphics.DrawString($"Valor imposto", fontCabecalho, cor, new PointF(300, 540 + i), formatToLeft);
                e.Graphics.DrawString("Motivo Isenção", fontCabecalho, cor, new PointF(400, 540 + i), formatToLeft);


                // Pegar os dados dos artigo com iva aplicado
                foreach (var item in vendaArtigos)
                {
                    if (StaticProperty.artigos.Where(x => x.codigo == item.codigo).First().regimeIva == OpcaoBinaria.Sim)
                    {
                        if (!listaIvas.Contains(item.iva))
                        {
                            listaIvas.Add(item.iva);
                        }
                    }
                }
                e.Graphics.DrawLine(caneta, 50, 555 + i, 530, 555 + i);
                if (listaIvas.Any())
                {
                    foreach (float ivas in listaIvas)
                    {
                        e.Graphics.DrawString("Iva", fontCabecalhoNegrito, cor, new PointF(50, 560 + i), formatToLeft);
                        e.Graphics.DrawString(ivas.ToString("F2"), new Font("Arial", 10, FontStyle.Underline, GraphicsUnit.Pixel), cor, new PointF(130, 560 + i), formatToLeft);
                        e.Graphics.DrawString(vendaArtigos.Where(x => x.iva == ivas).Sum(x => x.preco * x.qtd).ToString("F2"), fontCabecalho, cor, new PointF(200, 560 + i), formatToLeft);
                        e.Graphics.DrawString(vendaArtigos.Where(x => x.iva == ivas).Sum(x => ((x.preco * x.qtd) * (x.iva / 100))).ToString("F2"), fontCabecalho, cor, new PointF(300, 560 + i), formatToLeft);
                        e.Graphics.DrawString("", fontCabecalho, cor, new PointF(430, 560 + i), formatToLeft);
                        i = i + 10;
                    }
                }
                // Artigos com iva isento
                foreach (var motivo in StaticProperty.motivosIsencao)
                {
                    foreach (var item in vendaArtigos)
                    {
                        if (StaticProperty.artigos.Where(x => x.codigo == item.codigo && x.codigoIva == motivo.codigo).Any())
                        {
                            if (StaticProperty.artigos.Where(x => x.codigo == item.codigo && x.codigoIva == motivo.codigo).First().regimeIva == OpcaoBinaria.Nao)
                            {
                                incidencia += item.preco * item.qtd;
                            }
                        }
                    }
                    if (incidencia > 0)
                    {

                        e.Graphics.DrawString("Isento", fontCabecalhoNegrito, cor, new PointF(50, 560 + i), formatToLeft);
                        e.Graphics.DrawString("0,00", new Font("Arial", 10, FontStyle.Underline, GraphicsUnit.Pixel), cor, new PointF(130, 560 + i), formatToLeft);
                        e.Graphics.DrawString(incidencia.ToString("F2"), fontCabecalho, cor, new PointF(200, 560 + i), formatToLeft);
                        e.Graphics.DrawString("0,00", fontCabecalho, cor, new PointF(300, 560 + i), formatToLeft);
                        e.Graphics.DrawString($"{motivo.mencao}", fontCabecalho, cor, new PointF(400, 560 + i), formatToLeft);
                        i = i + 10;
                        incidencia = 0;
                    }
                }
                if (!_documento.Equals("NC") && !_documento.Equals("ND") && !_documento.Equals("GT") && !_documento.Equals("GR"))
                {
                    e.Graphics.DrawString($"Retenção           0,00 ", fontCabecalho, new SolidBrush(Color.Red), new PointF(50, 680 + i), formatToCenter);
                }

                if (_documento.Equals("FP") || _documento.Equals("GR"))
                {
                    e.Graphics.DrawString($"Este documento não serve como factura ", fontCabecalho, new SolidBrush(Color.Red), new PointF(280, 720 + i), formatToCenter);
                }
                else if (_documento.Equals("FT") || _documento.Equals("FR"))
                {
                    e.Graphics.DrawString($"Os bens/serviços foram colocados á disposição do adquirente na data e local do documento", fontCabecalho, new SolidBrush(Color.Black), new PointF(280, 720 + i), formatToCenter);
                }
                else if (_documento.Equals("GT"))
                {
                    e.Graphics.DrawString("Entreguei", fontCabecalho, cor, new PointF(100, 720 + i), formatToLeft);
                    e.Graphics.DrawLine(caneta, 50, 780 + i, 200, 780 + i);

                    e.Graphics.DrawString("Recebi", fontCabecalho, cor, new PointF(660, 720 + i), formatToLeft);
                    e.Graphics.DrawLine(caneta, 600, 780 + i, 750, 780 + i);
                }
                if (_documento.Equals("NC"))
                {
                    e.Graphics.DrawString("O Cliente", fontCabecalho, cor, new PointF(100, 720 + i), formatToLeft);
                    e.Graphics.DrawLine(caneta, 50, 780 + i, 200, 780 + i);

                }
                // Desenhando a imagem no documento
                e.Graphics.DrawImage(Image.FromFile(imagePathAsc), new Rectangle(10, 900, 200, 90));


                Console.WriteLine("Texto desenhado com sucesso.");

                // Liberar recursos
                fontNormal.Dispose();
                cor.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                throw new Exception("Erro ao desenhar a string: " + ex.Message);
            }
        }

        private void printCompra_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                float totalLiquido = 0f;
                float totalIva = 0f;
                float total = 0f;
                float descontoFornecedor = CalculosVendaCompra.TotalDescontoFornecedor(compraArtigos, fornecedorResult.desconto);

                List<float> listaIvas = new List<float>();

                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string projectPath = Path.GetFullPath(Path.Combine(basePath, @"..\.."));
                string imagePathEmpresa = Path.Combine(projectPath, "Files", "Smart_Entity.png");
                string imagePathAsc = Path.Combine(projectPath, "Files", "asc.png");
                // Testar com valores fixos para desenhar uma string
                Font fontNormal = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Pixel);
                Font fontNormalNegrito = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Pixel);
                Font fontCabecalho = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Pixel);
                Font fontCabecalhoNegrito = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Pixel);
                Brush cor = new SolidBrush(Color.Black);

                PointF ponto = new PointF(50, 150);
                PointF pontoRight = new PointF(550, 150);

                StringFormat formatToRight = new StringFormat();
                formatToRight.Alignment = StringAlignment.Far;

                StringFormat formatToLeft = new StringFormat();
                formatToLeft.Alignment = StringAlignment.Near;

                StringFormat formatToCenter = new StringFormat();
                formatToCenter.Alignment = StringAlignment.Near;

                var tel = fornecedorResult.phones.Any() ? fornecedorResult.phones.First().telefone : "000000000";

                string empresaNome = $"{fornecedorResult.nome_fantasia.ToUpper()}\n";
                string empresaCabecalho = $"Endereço: {fornecedorResult.localizacao}\n" +
                                          $"Nif: {fornecedorResult.nif}\n" +
                                          $"Email: {fornecedorResult.email ?? ""}\n" +
                                          $"Tel: {tel}";

                string clienteCabecalho = $"Exmo (s) Senhor (a)\n".ToUpper();
                string clienteOutros = $"{StaticProperty.empresa.nome_fantasia}\nEndereço: {StaticProperty.empresa.endereco}\n" +
                                       $"Nif: {StaticProperty.empresa.nif}\n" +
                                       $"Email: {StaticProperty.empresa.email}\n" +
                                       $"Tel:{StaticProperty.empresa.telefone} ";

                Pen caneta = new Pen(Color.Black, 2); // Define a cor e a largura da linha
                Pen canetaFina = new Pen(Color.Black, 1);
                float linhaInicioX = 550; // Ponto X de início da linha
                float linhaInicioY = 136; // Ajuste conforme necessário para a posição vertical da linha
                float linhaFimX = 750; // Ponto X de fim da linha


                // Verificar se e.Graphics é válido
                if (e.Graphics == null)
                {
                    throw new Exception("O objeto e.Graphics é nulo.");
                }

                e.Graphics.DrawImage(Image.FromFile(imagePathEmpresa), new Rectangle(40, 50, 100, 100));
                // Desenhar a string
                e.Graphics.DrawString(empresaNome, fontCabecalhoNegrito, cor, new PointF(50, 135), formatToLeft);
                e.Graphics.DrawString(empresaCabecalho, fontCabecalho, cor, ponto, formatToLeft);

                e.Graphics.DrawString("2ª via", fontNormal, cor, new PointF(750, 120), formatToRight);
                e.Graphics.DrawLine(caneta, linhaInicioX, linhaInicioY, linhaFimX, linhaInicioY);
                e.Graphics.DrawString(clienteCabecalho, fontNormalNegrito, cor, new PointF(550, 138), formatToLeft);
                e.Graphics.DrawString(clienteOutros, fontCabecalho, cor, pontoRight, formatToLeft);

                if (_documento.Equals("VNC"))
                {
                    e.Graphics.DrawString("Anulação", fontNormalNegrito, cor, new PointF(550, 215), formatToLeft);
                   /* e.Graphics.DrawString("Motivo:", fontNormalNegrito, cor, new PointF(550, 230), formatToLeft);
                    e.Graphics.DrawString($"{StaticProperty.motivoAnulacao.ToString()}", fontNormal, cor, new PointF(600, 230), formatToLeft);
                    e.Graphics.DrawString("Documento de Origem:", fontNormalNegrito, cor, new PointF(550, 245), formatToLeft);
                    e.Graphics.DrawString($"{StaticProperty.documentoOrigem.ToString()}", fontNormal, cor, new PointF(690, 247), formatToLeft);*/
                }

                if (anulado)
                {
                    e.Graphics.DrawString("Documento Anulado", fontNormalNegrito, cor, new PointF(550, 215), formatToLeft);
                }

                e.Graphics.DrawString($"{descricaoDocumento}  {codigoDoc}", fontNormalNegrito, cor, new PointF(50, 280), formatToLeft);
                e.Graphics.DrawLine(canetaFina, 50, 295, 250, 295);
                e.Graphics.DrawString("NIF", fontNormalNegrito, cor, new Rectangle(50, 300, 200, 310));
                e.Graphics.DrawString("Desc. Cli", fontNormalNegrito, cor, new Rectangle(200, 300, 350, 310));
                e.Graphics.DrawString("Data Emissão", fontNormalNegrito, cor, new Rectangle(350, 300, 500, 310));
                e.Graphics.DrawString("Data Vencimento", fontNormalNegrito, cor, new Rectangle(500, 300, 650, 310));
                e.Graphics.DrawLine(caneta, 50, 315, 750, 315);


                e.Graphics.DrawString($"{StaticProperty.empresa.nif}", fontNormal, cor, new Rectangle(50, 330, 200, 340));
                e.Graphics.DrawString($"{descontoFornecedor}", fontNormal, cor, new Rectangle(200, 330, 350, 340));
                e.Graphics.DrawString($"{DateTime.Now.Date.ToString("dd-MM-yyyy")}", fontNormal, cor, new Rectangle(350, 330, 450, 340));

                if (_documento.Equals("VFR"))
                {
                    e.Graphics.DrawString($"{DateTime.Now.Date}", fontNormal, cor, new Rectangle(500, 330, 650, 340));

                }
                else
                {
                    e.Graphics.DrawString($"-", fontNormal, cor, new Rectangle(500, 330, 650, 340));
                }

                e.Graphics.DrawString($"Artigo", fontNormalNegrito, cor, new Rectangle(50, 400, 200, 420));
                e.Graphics.DrawString("Descricao", fontNormalNegrito, cor, new Rectangle(200, 400, 300, 420));
                e.Graphics.DrawString($"Qtd", fontNormalNegrito, cor, new Rectangle(300, 400, 400, 420));
                e.Graphics.DrawString($"Preco", fontNormalNegrito, cor, new Rectangle(400, 400, 500, 420));
                e.Graphics.DrawString("Iva %", fontNormalNegrito, cor, new Rectangle(500, 400, 600, 420));
                e.Graphics.DrawString($"Desconto", fontNormalNegrito, cor, new Rectangle(600, 400, 700, 420));
                e.Graphics.DrawString($"Valor", fontNormalNegrito, cor, new Rectangle(700, 400, 750, 420));
                e.Graphics.DrawLine(caneta, 50, 415, 750, 415);
                int i = 15;
                foreach (CompraArtigo va in compraArtigos)
                {
                    totalIva += va.iva;
                    total += va.preco * float.Parse(va.qtd.ToString());

                    e.Graphics.DrawString($"{va.codigo}", fontNormal, cor, new Rectangle(50, 410 + i, 200, 425 + i));
                    e.Graphics.DrawString($"{StaticProperty.artigos.Where(art => art.codigo == va.codigo).First().descricao}", fontNormal, cor, new Rectangle(200, 410 + i, 300, 425 + i));
                    e.Graphics.DrawString($"{va.qtd:F2}", fontNormal, cor, new Rectangle(300, 410 + i, 400, 425 + i));
                    e.Graphics.DrawString($"{va.preco.ToString("F2")}", fontNormal, cor, new Rectangle(400, 410 + i, 500, 425 + i));
                    e.Graphics.DrawString($"{(va.iva).ToString("F2")} %", fontNormal, cor, new Rectangle(500, 410 + i, 600, 425 + i));
                    e.Graphics.DrawString($"{(((va.preco - (va.preco * (fornecedorResult.desconto / 100))) * (va.desconto / 100)) * va.qtd).ToString("F2")}", fontNormal, cor, new Rectangle(600, 410 + i, 700, 425 + i));
                    e.Graphics.DrawString($"{(va.preco * float.Parse(va.qtd.ToString())).ToString("F2")}", fontNormal, cor, new Rectangle(700, 410 + i, 750, 425 + i));
                    i = i + 15;
                }

                totalLiquido += CalculosVendaCompra.TotalCompra(compraArtigos, fornecedorResult.desconto); ;
                total = total - CalculosVendaCompra.TotalDescontoCompra(compraArtigos, fornecedorResult.desconto);

                string mercadoria = $"Total Ilíquido";
                string totalIvaValor = $"Total Imposto:";
                string totalFinal = $"Total á pagar";
                var desconto = CalculosVendaCompra.TotalDescontoCompra(compraArtigos, fornecedorResult.desconto) + CalculosVendaCompra.TotalDescontoFornecedor(compraArtigos, fornecedorResult.desconto);

                e.Graphics.DrawString($"{StaticProperty.hash} - Processado por programa\r válido nº 31.1/AGT20 Asc - Smart Entity", fontCabecalho, cor, new PointF(250, 515 + i), formatToCenter);

                if (_documento != "VGR" && _documento != "VGT")
                {
                    e.Graphics.DrawRectangle(caneta, new Rectangle(540, 530 + i, 210, 70 + i));

                    e.Graphics.DrawString(mercadoria, fontCabecalho, cor, new PointF(550, 545 + i), formatToLeft);
                    e.Graphics.DrawString(totalLiquido.ToString("F2"), fontCabecalho, cor, new PointF(680, 545 + i), formatToLeft);
                    e.Graphics.DrawString(totalIvaValor, fontCabecalho, cor, new PointF(550, 555 + i), formatToLeft);
                    e.Graphics.DrawString((total * (totalIva / 100)).ToString("F2"), fontCabecalho, cor, new PointF(680, 555 + i), formatToLeft);
                    e.Graphics.DrawString("Desconto", fontCabecalho, cor, new PointF(550, 565 + i), formatToLeft);
                    e.Graphics.DrawString($"{desconto:F2}", fontCabecalho, cor, new PointF(680, 565 + i), formatToLeft);

                    e.Graphics.DrawLine(canetaFina, 550, 580 + i, 740, 580 + i);
                    e.Graphics.DrawString(totalFinal, fontNormalNegrito, cor, new PointF(550, 605 + i), formatToLeft);
                    e.Graphics.DrawString(total.ToString("F2"), fontNormalNegrito, cor, new PointF(680, 605 + i), formatToLeft);

                    string conta = $"Conta nº";
                    string iban = $"IBAN ";
                    string banco = $"Banco Angolano de Investimento";


                    e.Graphics.DrawString($"Resumo Imposto", fontCabecalho, cor, new PointF(50, 515 + i), formatToCenter);

                    e.Graphics.DrawLine(caneta, 50, 530 + i, 530, 530 + i);
                    e.Graphics.DrawString("Descrição", new Font("Arial", 10, GraphicsUnit.Pixel), cor, new PointF(50, 540 + i), formatToLeft);
                    e.Graphics.DrawString("Taxa %", fontCabecalhoNegrito, cor, new PointF(130, 540 + i), formatToLeft);
                    e.Graphics.DrawString("Incidência", fontCabecalho, cor, new PointF(200, 540 + i), formatToLeft);
                    e.Graphics.DrawString($"Valor imposto", fontCabecalho, cor, new PointF(300, 540 + i), formatToLeft);
                    e.Graphics.DrawString("Motivo Isenção", fontCabecalho, cor, new PointF(400, 540 + i), formatToLeft);


                    // Pegar os dados dos artigo com iva aplicado
                    foreach (var item in compraArtigos)
                    {
                        if (StaticProperty.artigos.Where(x => x.codigo == item.codigo).First().regimeIva == OpcaoBinaria.Sim)
                        {
                            if (!listaIvas.Contains(item.iva))
                            {
                                listaIvas.Add(item.iva);
                            }
                        }
                    }
                    e.Graphics.DrawLine(caneta, 50, 555 + i, 530, 555 + i);
                    if (listaIvas.Any())
                    {
                        foreach (float ivas in listaIvas)
                        {
                            e.Graphics.DrawString("Iva", fontCabecalhoNegrito, cor, new PointF(50, 560 + i), formatToLeft);
                            e.Graphics.DrawString(ivas.ToString("F2"), new Font("Arial", 10, FontStyle.Underline, GraphicsUnit.Pixel), cor, new PointF(130, 560 + i), formatToLeft);
                            e.Graphics.DrawString(compraArtigos.Where(x => x.iva == ivas).Sum(x => x.preco * x.qtd).ToString("F2"), fontCabecalho, cor, new PointF(200, 560 + i), formatToLeft);
                            e.Graphics.DrawString(compraArtigos.Where(x => x.iva == ivas).Sum(x => ((x.preco * x.qtd) * (x.iva / 100))).ToString("F2"), fontCabecalho, cor, new PointF(300, 560 + i), formatToLeft);
                            e.Graphics.DrawString("", fontCabecalho, cor, new PointF(430, 560 + i), formatToLeft);
                            i = i + 10;
                        }
                    }
                    // Artigos com iva isento
                    foreach (var motivo in StaticProperty.motivosIsencao)
                    {
                        foreach (var item in compraArtigos)
                        {
                            if (StaticProperty.artigos.Where(x => x.codigo == item.codigo && x.codigoIva == motivo.codigo).Any())
                            {
                                if (StaticProperty.artigos.Where(x => x.codigo == item.codigo && x.codigoIva == motivo.codigo).First().regimeIva == OpcaoBinaria.Nao)
                                {
                                    incidencia += item.preco * item.qtd;
                                }
                            }
                        }
                        if (incidencia > 0)
                        {

                            e.Graphics.DrawString("Isento", fontCabecalhoNegrito, cor, new PointF(50, 560 + i), formatToLeft);
                            e.Graphics.DrawString("0,00", new Font("Arial", 10, FontStyle.Underline, GraphicsUnit.Pixel), cor, new PointF(130, 560 + i), formatToLeft);
                            e.Graphics.DrawString(incidencia.ToString("F2"), fontCabecalho, cor, new PointF(200, 560 + i), formatToLeft);
                            e.Graphics.DrawString("0,00", fontCabecalho, cor, new PointF(300, 560 + i), formatToLeft);
                            e.Graphics.DrawString($"{motivo.mencao}", fontCabecalho, cor, new PointF(400, 560 + i), formatToLeft);
                            i = i + 10;
                            incidencia = 0;
                        }

                    }
                }
                if (!_documento.Equals("VNC") && !_documento.Equals("VND") && !_documento.Equals("VGT") && !_documento.Equals("VGR"))
                {
                    e.Graphics.DrawString($"Retenção           0,00 ", fontCabecalho, new SolidBrush(Color.Red), new PointF(50, 680 + i), formatToCenter);

                }
                if (_documento.Equals("PCO") || _documento.Equals("VGR"))
                {
                    e.Graphics.DrawString($"Este documento não serve como factura ", fontCabecalho, new SolidBrush(Color.Red), new PointF(280, 720 + i), formatToCenter);
                }
                else if (_documento.Equals("VFT") || _documento.Equals("VFR"))
                {
                    e.Graphics.DrawString($"Os bens/serviços foram colocados á disposição do adquirente na data e local do documento", fontCabecalho, new SolidBrush(Color.Black), new PointF(210, 720 + i), formatToCenter);
                }

                if (_documento.Equals("VGT") || _documento.Equals("VGR"))
                {
                    e.Graphics.DrawString("Entreguei", fontCabecalho, cor, new PointF(100, 720 + i), formatToLeft);
                    e.Graphics.DrawLine(caneta, 50, 780 + i, 200, 780 + i);

                    e.Graphics.DrawString("Recebi", fontCabecalho, cor, new PointF(660, 720 + i), formatToLeft);
                    e.Graphics.DrawLine(caneta, 600, 780 + i, 750, 780 + i);
                }

                if (_documento.Equals("VNC"))
                {
                    e.Graphics.DrawString("O Cliente", fontCabecalho, cor, new PointF(100, 720 + i), formatToLeft);
                    e.Graphics.DrawLine(caneta, 50, 780 + i, 200, 780 + i);

                }

                if (_documento.Equals("VGT") || _documento.Equals("ECF"))
                {
                    e.Graphics.DrawString("Local de Carga:", fontCabecalhoNegrito, cor, new PointF(50, 820 + i), formatToLeft);

                    e.Graphics.DrawString($"Viana", fontCabecalho, cor, new PointF(150, 820 + i), formatToLeft);

                    e.Graphics.DrawString("Local de Descarga:", fontCabecalhoNegrito, cor, new PointF(50, 835 + i), formatToLeft);

                    e.Graphics.DrawString($"{localEntrega}", fontCabecalho, cor, new PointF(150, 835 + i), formatToLeft);
                }

                // Desenhando a imagem no documento
                e.Graphics.DrawImage(Image.FromFile(imagePathAsc), new Rectangle(10, 900, 200, 90));


                Console.WriteLine("Texto desenhado com sucesso.");

                // Liberar recursos
                fontNormal.Dispose();
                cor.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                throw new Exception("Erro ao desenhar a string: " + ex.Message);
            }
        }
    }
}
