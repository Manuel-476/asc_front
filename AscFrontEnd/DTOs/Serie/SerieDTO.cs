using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd.DTOs.Serie
{
    public class SerieDTO
    {
        public int id { get; set; }
        public string serie { get; set; }
        public OpcaoBinaria status { get; set; }
        public int EmpresaId { get; set; }
    }
}
