using AscFrontEnd.DTOs.StaticsDto;
using DocumentFormat.OpenXml.Drawing.Charts;
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
    public partial class DocumentosDetalhesForm : Form
    {
        private string _documento;
        private Entidade _entidade;
        private int _documentoId;
        public DocumentosDetalhesForm(string documento,int documentoId,Entidade entidade)
        {
            InitializeComponent();

            _documento = documento;
            _entidade = entidade;
            _documentoId = documentoId;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void DocumentosDetalhesForm_Load(object sender, EventArgs e)
        {
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

                    serie = documentoDados.documento.Substring(indexSpace+1,index);

                    codigoDocumento.Text = codigo;
                    numDocumento.Text = num;
                    serieDocumento.Text = serie;
                    dataDocumento.Text = documentoDados.data.ToString();
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
                        artigos.Text += $"\n{StaticProperty.artigos.Where(a => a.id == art.artigoId).First().descricao}";
                        qtds.Text += $"\n{art.qtd}";
                        ivas.Text += $"\n{art.iva}";
                        precos.Text += $"\n{art.preco}";
                    }
                }
                else if (_documento.ToUpper().Equals("ECF"))
                {
                    var documentoDados = StaticProperty.ecfs.Where(v => v.id == _documentoId).First();

                    indexSpace = documentoDados.documento.IndexOf(" ");
                    codigo = documentoDados.documento.Substring(0, indexSpace);

                    index = documentoDados.documento.IndexOf("/");
                    num = documentoDados.documento.Substring(index + 1);

                    serie = documentoDados.documento.Substring(indexSpace , index);

                    codigoDocumento.Text = codigo;
                    numDocumento.Text = num;
                    serieDocumento.Text = serie;
                    dataDocumento.Text = documentoDados.data.ToString();
                }
                else if (_documento.ToUpper().Equals("VGT"))
                {
                    var documentoDados = StaticProperty.vgts.Where(v => v.id == _documentoId).First();

                    indexSpace = documentoDados.documento.IndexOf(" ");
                    codigo = documentoDados.documento.Substring(0, indexSpace);

                    index = documentoDados.documento.IndexOf("/");
                    num = documentoDados.documento.Substring(index + 1);

                    serie = documentoDados.documento.Substring(indexSpace + 1, index);

                    codigoDocumento.Text = codigo;
                    numDocumento.Text = num;
                    serieDocumento.Text = serie;
                    dataDocumento.Text = documentoDados.data.ToString();
                }
                else if (_documento.ToUpper().Equals("VNC"))
                {
                    var documentoDados = StaticProperty.vncs.Where(v => v.id == _documentoId).First();

                    indexSpace = documentoDados.documento.IndexOf(" ");
                    codigo = documentoDados.documento.Substring(0, indexSpace);

                    index = documentoDados.documento.IndexOf("/");
                    num = documentoDados.documento.Substring(index + 1);

                    serie = documentoDados.documento.Substring(indexSpace + 1, index);

                    codigoDocumento.Text = codigo;
                    numDocumento.Text = num;
                    serieDocumento.Text = serie;
                    dataDocumento.Text = documentoDados.data.ToString();
                }
                else if (_documento.ToUpper().Equals("VND"))
                {
                    var documentoDados = StaticProperty.vnds.Where(v => v.id == _documentoId).First();

                    indexSpace = documentoDados.documento.IndexOf(" ");
                    codigo = documentoDados.documento.Substring(0, indexSpace);

                    index = documentoDados.documento.IndexOf("/");
                    num = documentoDados.documento.Substring(index + 1);

                    serie = documentoDados.documento.Substring(indexSpace + 1, index);

                    codigoDocumento.Text = codigo;
                    numDocumento.Text = num;
                    serieDocumento.Text = serie;
                    dataDocumento.Text = documentoDados.data.ToString();
                }
                else if (_documento.ToUpper().Equals("PCO"))
                {
                    var documentoDados = StaticProperty.pcos.Where(v => v.id == _documentoId).First();

                    indexSpace = documentoDados.documento.IndexOf(" ");
                    codigo = documentoDados.documento.Substring(0, indexSpace);

                    index = documentoDados.documento.IndexOf("/");
                    num = documentoDados.documento.Substring(index + 1);

                    serie = documentoDados.documento.Substring(indexSpace + 1, index);

                    codigoDocumento.Text = codigo;
                    numDocumento.Text = num;
                    serieDocumento.Text = serie;
                    dataDocumento.Text = documentoDados.data.ToString();
                }
                else if (_documento.ToUpper().Equals("COT"))
                {
                    var documentoDados = StaticProperty.cots.Where(v => v.id == _documentoId).First();

                    indexSpace = documentoDados.documento.IndexOf(" ");
                    codigo = documentoDados.documento.Substring(0, indexSpace);

                    index = documentoDados.documento.IndexOf("/");
                    num = documentoDados.documento.Substring(index + 1);

                    serie = documentoDados.documento.Substring(indexSpace + 1, index);

                    codigoDocumento.Text = codigo;
                    numDocumento.Text = num;
                    serieDocumento.Text = serie;
                    dataDocumento.Text = documentoDados.data.ToString();
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

                    serie = documentoDados.documento.Substring(indexSpace + 1, index);

                    codigoDocumento.Text = codigo;
                    numDocumento.Text = num;
                    serieDocumento.Text = serie;
                    dataDocumento.Text = documentoDados.data.ToString();
                }
                else if (_documento.ToUpper().Equals("FT"))
                {
                    var documentoDados = StaticProperty.fts.Where(v => v.id == _documentoId).First();

                    indexSpace = documentoDados.documento.IndexOf(" ");
                    codigo = documentoDados.documento.Substring(0, indexSpace);

                    index = documentoDados.documento.IndexOf("/");
                    num = documentoDados.documento.Substring(index + 1);

                    serie = documentoDados.documento.Substring(indexSpace + 1, index);

                    codigoDocumento.Text = codigo;
                    numDocumento.Text = num;
                    serieDocumento.Text = serie;
                    dataDocumento.Text = documentoDados.data.ToString();
                }
                else if (_documento.ToUpper().Equals("ECL"))
                {
                    var documentoDados = StaticProperty.ecls.Where(v => v.id == _documentoId).First();

                    indexSpace = documentoDados.documento.IndexOf(" ");
                    codigo = documentoDados.documento.Substring(0, indexSpace);

                    index = documentoDados.documento.IndexOf("/");
                    num = documentoDados.documento.Substring(index + 1);

                    serie = documentoDados.documento.Substring(indexSpace + 1, index);

                    codigoDocumento.Text = codigo;
                    numDocumento.Text = num;
                    serieDocumento.Text = serie;
                    dataDocumento.Text = documentoDados.data.ToString();
                }
                else if (_documento.ToUpper().Equals("GT"))
                {
                    var documentoDados = StaticProperty.gts.Where(v => v.id == _documentoId).First();

                    indexSpace = documentoDados.documento.IndexOf(" ");
                    codigo = documentoDados.documento.Substring(0, indexSpace);

                    index = documentoDados.documento.IndexOf("/");
                    num = documentoDados.documento.Substring(index + 1);

                    serie = documentoDados.documento.Substring(indexSpace + 1, index);

                    codigoDocumento.Text = codigo;
                    numDocumento.Text = num;
                    serieDocumento.Text = serie;
                    dataDocumento.Text = documentoDados.data.ToString();
                }
                else if (_documento.ToUpper().Equals("NC"))
                {
                    var documentoDados = StaticProperty.ncs.Where(v => v.id == _documentoId).First();

                    indexSpace = documentoDados.documento.IndexOf(" ");
                    codigo = documentoDados.documento.Substring(0, indexSpace);

                    index = documentoDados.documento.IndexOf("/");
                    num = documentoDados.documento.Substring(index + 1);

                    serie = documentoDados.documento.Substring(indexSpace + 1, index);

                    codigoDocumento.Text = codigo;
                    numDocumento.Text = num;
                    serieDocumento.Text = serie;
                    dataDocumento.Text = documentoDados.data.ToString();
                }
                else if (_documento.ToUpper().Equals("ND"))
                {
                    var documentoDados = StaticProperty.nds.Where(v => v.id == _documentoId).First();
                 
                    indexSpace = documentoDados.documento.IndexOf(" ");
                    codigo = documentoDados.documento.Substring(0, indexSpace);

                    index = documentoDados.documento.IndexOf("/");
                    num = documentoDados.documento.Substring(index + 1);

                    serie = documentoDados.documento.Substring(indexSpace + 1, index);

                    codigoDocumento.Text = codigo;
                    numDocumento.Text = num;
                    serieDocumento.Text = serie;
                    dataDocumento.Text = documentoDados.data.ToString();
                }
                else if (_documento.ToUpper().Equals("FP"))
                {
                    var documentoDados = StaticProperty.fps.Where(v => v.id == _documentoId).First();

                    indexSpace = documentoDados.documento.IndexOf(" ");
                    codigo = documentoDados.documento.Substring(0, indexSpace);

                    index = documentoDados.documento.IndexOf("/");
                    num = documentoDados.documento.Substring(index + 1);

                    serie = documentoDados.documento.Substring(indexSpace + 1, index);

                    codigoDocumento.Text = codigo;
                    numDocumento.Text = num;
                    serieDocumento.Text = serie;
                    dataDocumento.Text = documentoDados.data.ToString();
                    
                }
            }
         
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
