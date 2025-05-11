
using AscFrontEnd.DTOs;
using AscFrontEnd.DTOs.ContasCorrentes;
using AscFrontEnd.DTOs.Fornecedor;
using System;
using System.Collections.Generic;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace ERP_Buyer.Application.DTOs.Documentos
{
    public class VftDTO
    {
        public int id { get; set; }
        public string documento { get; set; }
        public int fornecedorId { get; set; }
        public DocState status { get; set; }
        public OpcaoBinaria pago { get; set; }
        public OpcaoBinaria apr { get; set; }
        public DateTime data { get; set; }
        public int empresaId { get; set; }
        public List<VftArtigoDTO> vftArtigo { get; set; }
        public ICollection<VftNpDTO> vftNps { get; set; }
        public FornecedorDTO fornecedor { get; set; }
    }
}
