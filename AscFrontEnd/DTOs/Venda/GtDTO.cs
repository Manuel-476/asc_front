﻿
using AscFrontEnd;
using System;
using System.Collections.Generic;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace EAscFrontEnd
{
    public class GtDTO
    {
        public int id { get; set; }
        public string documento { get; set; }
        public int clienteId { get; set; }
        public DocState status { get; set; }
        public string fullHash { get; set; }
        public string shortHash { get; set; }
        public int? bancoId { get; set; }
        public int? caixaId { get; set; }
        public int? bancoClienteId { get; set; }
        public int? caixaClienteId { get; set; }
        public DateTime data { get; set; }
        public DateTime created_at { get; set; }
        public int empresaId { get; set; }
        public List<GtArtigoDTO> gtArtigo { get; set; }
    }
}
