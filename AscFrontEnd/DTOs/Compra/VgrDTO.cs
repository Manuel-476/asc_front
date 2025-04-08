using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd.DTOs.Compra
{
    public class VgrDTO
    {
        public int id { get; set; }
        public string documento { get; set; } = string.Empty;
        public int fornecedorId { get; set; }
        public DocState status { get; set; }
        public DateTime data { get; set; }
        public int? bancoClienteId { get; set; }
        public int? caixaClienteId { get; set; }
        public List<VgrArtigoDTO> vgrArtigo { get; set; }
        public DateTime created_at { get; set; }
        public int empresaId { get; set; }
    }
}
