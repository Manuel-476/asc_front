using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscFrontEnd.DTOs.ContasCorrentes
{
    public class ReciboDTO
    {
        public int id { get; set; }
        public string documento { get; set; }
        public float quantia { get; set; }
        public int ftId { get; set; }
        public DateTime created { get; set; }
    }
}
