using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscFrontEnd.DTOs.Compra
{
    public class CompraDTO
    {
        public int id { get; set; }
        public string documento { get; set; } = string.Empty;
        public int numeroDocumento { get; set; }

        public string serie { get; set; } = string.Empty;
        public int artigoId { get; set; }
        public int fornecedorId { get; set; }
        public int empresaId { get; set; }
        public DateTime data { get; set; }
        public DateTime created_at { get; set; }

        public List<ArtigoCompra> artigoCompras { get; set; }
    }

    public class ArtigoCompra
    {
        public int id { get; set; }
        public int artigoId { get; set; }
        public float preco { get; set; }
        public float desconto { get; set; }
        public float iva { get; set; }
        public int qtd { get; set; }
    }
}
