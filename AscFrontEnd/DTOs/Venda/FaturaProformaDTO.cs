

using System;
using System.Collections.Generic;

namespace AscFrontEnd
{
    public class FaturaProformaDTO
    {
        public int id { get; set; }
        public string documento { get; set; }
        public int clienteId { get; set; }
        public int status { get; set; }
        public DateTime data { get; set; }
        public List<FaturaProformaArtigoDTO> fpArtigo { get; set; }
    }
}
