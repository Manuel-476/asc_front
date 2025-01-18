using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscFrontEnd.DTOs.Regiao
{
    public class ProvinciaDTO
    {
        public int id { get; set; }
        public string nome { get; set; } = string.Empty;
        public int paisId { get; set; }
    }
}
