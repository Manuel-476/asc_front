using AscFrontEnd.DTOs.Fornecedor;
using ERP_Buyer.Application.DTOs.Documentos;


using System;
using System.Collections.Generic;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd.DTOs
{
    public class PedidoCotacaoDTO
    {
        public int id { get; set; }
        public string documento { get; set; }
        public int fornecedorId { get; set; }
        public DocState status { get; set; }
        public DateTime data { get; set; }
        public int empresaId { get; set; }
        public List<PedidoCotacaoArtigoDTO> pcArtigo { get; set; }
        public FornecedorDTO fornecedor { get; set; }
    }
}
