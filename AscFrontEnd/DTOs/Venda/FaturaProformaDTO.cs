

using System;
using System.Collections.Generic;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd
{
    public class FaturaProformaDTO
    {
        public int id { get; set; }
        public string documento { get; set; }
        public int clienteId { get; set; }
        public DocState status { get; set; }
        public DateTime data { get; set; }
        public List<FaturaProformaArtigoDTO> fpArtigo { get; set; }
    }
}
