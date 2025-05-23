using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AscFrontEnd.DTOs.StaticsDto;
using AscFrontEnd.Files;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Drawing;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd.Application.Validacao
{
    public class OutrasValidacoes
    {

        public static bool SerieExist() 
        {
            bool result = true;
            if (!StaticProperty.series.Where(x => x.status == OpcaoBinaria.Sim && x.EmpresaId == StaticProperty.empresaId).Any())
            {
                result = false;
                if (MessageBox.Show("Nenhuma serie foi criada\nDeseja criar uma serie?", "Imposivel concluir a acao", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    new SerieForm().ShowDialog();
                }
                else
                {
                    return result;
                }
            }
            return result;
        }
    }
}
