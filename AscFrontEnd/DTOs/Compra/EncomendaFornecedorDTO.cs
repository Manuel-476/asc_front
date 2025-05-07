
using AscFrontEnd.DTOs.Fornecedor;
using System;
using System.Collections.Generic;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd.DTOs
{
    public class EncomendaFornecedorDTO
    {
        public int id { get; set; }
        public string documento { get; set; }
        public int fornecedorId { get; set; }
        public string local_entrega { get; set; }
        public DateTime dataEntrega { get; set; }
        public DocState status { get; set; }
        public DateTime data { get; set; }
        public DateTime created { get; set; } = DateTime.Now;
        public int empresaId { get; set; }
        public List<EcfArtigoDTO> ecfArtigo { get; set; }
        public FornecedorDTO fornecedor { get; set; }
    }
}
