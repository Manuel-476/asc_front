using AscFrontEnd.DTOs.Enums;
using AscFrontEnd.DTOs.StaticsDto;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
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
    public partial class LiquidaDivida : Form
    {
        int _docId;
        Entidade _entidade;
        
        public LiquidaDivida(int docId, Entidade entidade)
        {
            InitializeComponent();
            _docId = docId;
            this._entidade = entidade;
        }

        private void LiquidaDivida_Load(object sender, EventArgs e)
        {

            if(_entidade == Entidade.fornecedor) 
            {
                float divida=0, regulado=0;
                var vftResult = StaticProperty.vfts.Where(vft => vft.id == _docId).First();
                var result = StaticProperty.vfts.Where(vft => vft.fornecedorId == vftResult.fornecedorId).ToList();


                foreach (var item in result)
                {
                    if (item.pago == Enums.OpcaoBinaria.Nao)
                    {
                        divida += item.vftArtigo.Sum(d => d.preco * d.qtd);
                        regulado += StaticProperty.nps.Where(np => np.vftId == item.id).Sum(np => np.quantia);
                    }
                }
                fornecedorLabel.Text = StaticProperty.fornecedores.Where(f => f.id == vftResult.fornecedorId).First().nome_fantasia;
                dividaLabel.Text = $"Divida: {divida}";
                liquidado.Text = $"Liquidado: {liquidado}";
            }
        }
    }
}
