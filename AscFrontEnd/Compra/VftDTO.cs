using ERP_Buyer.Application.DTOs.ContaCorrente;
using ERP_Buyer.Application.DTOs.Fornecedor;
using ERP_Buyer.Domain.Entities.Documentos;
using ERP_Buyer.Domain.Entities.Fornecedor;
using static SystemAux.Application.Enums.Enums;

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
        public List<VftArtigoDTO>? vftArtigo { get; set; }
        public ICollection<NpDTO>? nps { get; set; }
        public FornecedorDTO? fornecedor { get; set; }
    }
}
