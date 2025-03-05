using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscFrontEnd.DTOs.Venda
{
    public class VendaDTO
    {
        public int id { get; set; }
        public string documento { get; set; } = string.Empty;
        public int numeroDocumento { get; set; }
        public string fullHash { get; set; } = string.Empty;
        public string shortHash { get; set; } = string.Empty;
        public string serie { get; set; } = string.Empty;
        public int artigoId { get; set; }
        public int clienteId { get; set; }
        public int empresaId { get; set; }
        public DateTime data { get; set; }
        public DateTime created_at { get; set; }

        public List<ArtigoVenda> artigoVendas { get; set; }
    }

    public class ArtigoVenda
    {
        public int id { get; set; }
        public int artigoId { get; set; }
        public float preco { get; set; }
        public float desconto { get; set; }
        public float iva { get; set; }
        public int qtd { get; set; }
    }
}
