

using System;
using System.Collections.Generic;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd.DTOs.Venda
{
    public class FrDTO
    {
        public int id { get; set; }
        public string documento { get; set; }
        public int clienteId { get; set; }
        public DocState status { get; set; }
        public DateTime data { get; set; }
        public List<FrArtigoDTO> frArtigo { get; set; }
    }
}
