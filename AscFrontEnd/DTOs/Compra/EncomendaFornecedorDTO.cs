
using AscFrontEnd.DTOs.Fornecedor;
using System;
using System.Collections.Generic;

namespace AscFrontEnd.DTOs
{
    public class EncomendaFornecedorDTO
    {
        public int id { get; set; }
        public string documento { get; set; }
        public int fornecedorId { get; set; }
        public string local_entrega { get; set; }
        public int status { get; set; }
        public DateTime data { get; set; }
        public DateTime created { get; set; } = DateTime.Now;
        public List<EcfArtigoDTO> ecfArtigo { get; set; }
        public FornecedorDTO fornecedor { get; set; }
    }
}
