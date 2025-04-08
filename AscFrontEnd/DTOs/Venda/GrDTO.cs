using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AscFrontEnd.DTOs.Cliente;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd.DTOs.Venda
{
    public class GrDTO
    {
        public int id { get; set; }
        public string documento { get; set; } = string.Empty;
        public int clienteId { get; set; }
        public DocState status { get; set; }
        public DateTime data { get; set; }
        public int? bancoClienteId { get; set; }
        public int? caixaClienteId { get; set; }
        public List<GrArtigoDTO> grArtigo { get; set; }
        public string fullHash { get; set; }
        public string shortHash { get; set; }
        public DateTime created_at { get; set; }
        public int empresaId { get; set; }
    }
}
