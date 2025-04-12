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
        Entidade _entidade;
        public MotivoAnulacao(OpcaoBinaria anulacaoDireta)
        {
            _anulacaoDireta = anulacaoDireta;

            InitializeComponent();
        }
        public MotivoAnulacao(Entidade entidade, OpcaoBinaria anulacaoDireta)
        {
            _anulacaoDireta = anulacaoDireta;
            _entidade = entidade;

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
                StaticProperty.documentoOrigem = !string.IsNullOrEmpty(StaticProperty.documentoOrigem)? StaticProperty.documentoOrigem : documentoOrigemTxt.Text.ToString();
            }
        }

        private void caixaDocs_Click(object sender, EventArgs e)
        {

            new DocumentoEstornoListarForm(_entidade).ShowDialog();

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(StaticProperty.documentoOrigem)) 
            {
                documentoOrigemTxt.Text = StaticProperty.documentoOrigem;
            }
        }

        private void MotivoAnulacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1?.Stop();
            timer1.Dispose();
        }

        private void documentoOrigemTxt_TextChanged(object sender, EventArgs e)
        {
            StaticProperty.documentoOrigem = documentoOrigemTxt.Text;
        }
    }
}
