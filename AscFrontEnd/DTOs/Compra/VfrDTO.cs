

using AscFrontEnd.DTOs.Fornecedor;
using System;
using System.Collections.Generic;

namespace AscFrontEnd.DTOs
{
    public class VfrDTO
    {
        public int id { get; set; }
        public string documento { get; set; }
        public int fornecedorId { get; set; }
        public int status { get; set; }
        public DateTime data { get; set; }
        public List<VfrArtigoDTO> vfrArtigo { get; set; }
        public FornecedorDTO fornecedor { get; set; }
    }
}
