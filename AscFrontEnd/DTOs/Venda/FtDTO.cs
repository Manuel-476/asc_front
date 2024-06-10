

using AscFrontEnd;
using AscFrontEnd.DTOs.Cliente;
using System;
using System.Collections.Generic;

namespace EAscFrontEnd
{
    public class FtDTO
    {
        public int id { get; set; }
        public string documento { get; set; }
        public int clienteId { get; set; }
        public int status { get; set; }
        public int pago { get; set; }
        public DateTime data { get; set; }
        public List<FtArtigoDTO> ftArtigo { get; set; }
       // public ICollection<ReciboDTO> recibos { get; set; }
       // public ClienteDTO cliente { get; set; }
    }
}
