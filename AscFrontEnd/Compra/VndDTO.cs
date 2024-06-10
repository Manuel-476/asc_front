using ERP_Buyer.Application.DTOs.Fornecedor;
using ERP_Buyer.Domain.Entities.Documentos;
using ERP_Buyer.Domain.Entities.Fornecedor;
using static SystemAux.Application.Enums.Enums;

namespace ERP_Buyer.Application.DTOs.Documentos
{
    public class VndDTO
    {
        public int id { get; set; }
        public string documento { get; set; }
        public int fornecedorId { get; set; }
        public DocState status { get; set; }
        public DateTime data { get; set; }
        public List<VndArtigoDTO> vndArtigo { get; set; }
        public FornecedorDTO? fornecedor { get; set; }
    }
}
