

using AscFrontEnd.DTOs.Fornecedor;
using ERP_Buyer.Application.DTOs.Documentos;
using System;
using System.Collections.Generic;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd.DTOs
{
    public class VncDTO
    {
        public int id { get; set; }
        public string documento { get; set; } = string.Empty;
        public int fornecedorId { get; set; }
        public DocState status { get; set; }
        public DateTime data { get; set; }
        public int empresaId { get; set; }
        public string documentoOrigem { get; set; } = string.Empty;
        public string motivo { get; set; } = string.Empty;
        public DateTime created { get; set; }
        public List<VncArtigoDTO> vncArtigo { get; set; }
        public FornecedorDTO fornecedor { get; set; }
    }
}
