

using AscFrontEnd;
using System;
using System.Collections.Generic;

namespace ERP_Seller.Application.DTOs.Documentos
{
    public class NdDTO
    {
        public int id { get; set; }
        public string documento { get; set; }
        public int clienteId { get; set; }
        public int status { get; set; }
        public DateTime data { get; set; }
        public List<NdArtigoDTO> ndArtigo { get; set; }
    }
}
