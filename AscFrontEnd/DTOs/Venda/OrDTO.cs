using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AscFrontEnd.DTOs.Cliente;
using AscFrontEnd.DTOs.Compra;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd.DTOs.Venda
{
    public class OrDTO
    {
        public int id { get; set; }
        public string documento { get; set; } = string.Empty;
        public int clienteId { get; set; }
        public DocState status { get; set; }
        public OpcaoBinaria aprovado { get; set; }
        public DateTime data { get; set; }
        public List<OrArtigoDTO> orArtigos { get; set; }
        public ClienteDTO cliente { get; set; }
        public string fullHash { get; set; }
        public string shortHash { get; set; }
        public int empresaId { get; set; }
        public DateTime created_at { get; set; }
    }
}
