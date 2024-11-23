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
    public partial class MotivoAnulacao : Form
    {
        OpcaoBinaria _anulacaoDireta;
        public MotivoAnulacao(OpcaoBinaria anulacaoDireta)
        {
            _anulacaoDireta = anulacaoDireta;

            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void MotivoAnulacao_Load(object sender, EventArgs e)
        {
            if(_anulacaoDireta == OpcaoBinaria.Sim) 
            {
                documentoOrigemTxt.Dispose();
                textDocumento.Dispose();
                caixaDocs.Dispose();
            }
        }

        private void Anular_Click(object sender, EventArgs e)
        {
            if (_anulacaoDireta == OpcaoBinaria.Sim)
            {
                StaticProperty.motivoAnulacao = motivoAnulacaoTxt.Text.ToString();
            }
            else
            {
                StaticProperty.motivoAnulacao = motivoAnulacaoTxt.Text.ToString();
                StaticProperty.documentoOrigem = documentoOrigemTxt.Text.ToString();
            }
        }
    }
}
