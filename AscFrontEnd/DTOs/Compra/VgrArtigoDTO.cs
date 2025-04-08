using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscFrontEnd.DTOs.Compra
{
    public class VgrArtigoDTO
    {
        public int id { get; set; }
        public int artigoId { get; set; }
        public float preco { get; set; }
        public float desconto { get; set; }
        public float iva { get; set; }
        public float qtd { get; set; }
    }
}
