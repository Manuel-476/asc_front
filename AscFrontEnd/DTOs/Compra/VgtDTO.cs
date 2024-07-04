

using AscFrontEnd.DTOs.Fornecedor;
using ERP_Buyer.Application.DTOs.Documentos;
using System;
using System.Collections.Generic;

namespace AscFrontEnd.DTOs
{
    public class VgtDTO
    {
        public int id { get; set; }
        public string documento { get; set; }
        public int fornecedorId { get; set; }
        public int status { get; set; }
        public DateTime data { get; set; }
        public List<VgtArtigoDTO> vgtArtigo { get; set; }
        public FornecedorDTO fornecedor { get; set; }
    }
}
