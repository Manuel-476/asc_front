

using AscFrontEnd;
using AscFrontEnd.DTOs.Cliente;
using AscFrontEnd.DTOs.ContasCorrentes;
using System;
using System.Collections.Generic;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace EAscFrontEnd
{
    public class FtDTO
    {
        public int id { get; set; }
        public string documento { get; set; }
        public int clienteId { get; set; }
        public int status { get; set; }
        public OpcaoBinaria pago { get; set; }
        public DateTime data { get; set; }
        public List<FtArtigoDTO> ftArtigo { get; set; }
        public ICollection<ReciboDTO>  recibos { get; set; }
        public ClienteDTO cliente { get; set; }
    }
}
