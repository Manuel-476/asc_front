﻿

using AscFrontEnd.DTOs.ContasCorrentes;
using AscFrontEnd.DTOs.Fornecedor;
using System;
using System.Collections.Generic;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd.DTOs
{
    public class VfrDTO
    {
        public int id { get; set; }
        public string documento { get; set; }
        public int fornecedorId { get; set; }
        public DocState status { get; set; }
        public DateTime data { get; set; }
        public DateTime created_at { get; set; }
        public int empresaId { get; set; }
        public List<VfrArtigoDTO> vfrArtigo { get; set; }
        public FornecedorDTO fornecedor { get; set; }
        public ICollection<AdiantaVfrDTO> adiantaVfrs { get; set; }
    }
}
