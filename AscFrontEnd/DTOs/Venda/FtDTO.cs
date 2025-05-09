﻿

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
        public DocState status { get; set; }
        public string fullHash { get; set; }
        public string shortHash { get; set; }
        public OpcaoBinaria pago { get; set; }
        public DateTime data { get; set; }
        public DateTime created_at { get; set; }
        public int empresaId { get; set; }
        public List<FtArtigoDTO> ftArtigo { get; set; }
        public ICollection<ReciboDTO>  recibos { get; set; }
        public ClienteDTO cliente { get; set; }
    }
}
