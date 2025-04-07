using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscFrontEnd.DTOs.Configuration
{
    public class StockMinimDTO
    {
        public int id { get; set; }
        public float qtdMinim { get; set; }
        public int empresaId { get; set; }
    }
}
