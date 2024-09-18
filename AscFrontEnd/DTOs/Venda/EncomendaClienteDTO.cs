

using System;
using System.Collections.Generic;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd
{
    public class EncomendaClienteDTO
    {
        public int id { get; set; }
        public string documento { get; set; }
        public int clienteId { get; set; }
        public string local_entrega { get; set; }
        public DocState status { get; set; }
        public string fullHash { get; set; }
        public string shortHash { get; set; }
        public DateTime data { get; set; }
        public DateTime created { get; set; } = DateTime.Now;
        public List<EclArtigoDTO> eclArtigo { get; set; }
    }
}
