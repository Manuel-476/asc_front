using AscFrontEnd;
using System;
using System.Collections.Generic;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace EAscFrontEnd
{
    public class NcDTO
    {
        public int id { get; set; }
        public string documento { get; set; } = string.Empty;
        public int clienteId { get; set; }
        public DocState status { get; set; }
        public string motivo { get; set; } = string.Empty;
        public string documentoOrigem { get; set; } = string.Empty;
        public string fullHash { get; set; } = string.Empty;
        public string shortHash { get; set; } = string.Empty;
        public DateTime data { get; set; }
        public DateTime created_at { get; set; }
        public List<NcArtigoDTO> ncArtigo { get; set; }
    }
}
