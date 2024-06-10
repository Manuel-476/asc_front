

using System;
using System.Collections.Generic;

namespace AscFrontEnd
{
    public class EncomendaClienteDTO
    {
        public int id { get; set; }
        public string documento { get; set; }
        public int clienteId { get; set; }
        public string local_entrega { get; set; }
        public int status { get; set; }
        public DateTime data { get; set; }
        public DateTime created { get; set; } = DateTime.Now;
        public List<EclArtigoDTO> eclArtigo { get; set; }
    }
}
