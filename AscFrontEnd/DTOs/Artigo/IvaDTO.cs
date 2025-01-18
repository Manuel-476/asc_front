using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd.DTOs.Artigo
{
    public class IvaDTO
    {
        public int id { get; set; }
        public float valorIva { get; set; }
        public Status state { get; set; }
        public int empresaId { get; set; }
        public DateTime created_at { get; set; }
    }
}
