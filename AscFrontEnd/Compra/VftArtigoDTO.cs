using ERP_Buyer.Domain.Entities.Documentos;

namespace ERP_Buyer.Application.DTOs.Documentos
{
    public class VftArtigoDTO
    {
        public int id { get; set; }
        public int artigoId { get; set; }
        public float preco { get; set; }
        public float iva { get; set; }
        public int qtd { get; set; }
    }
}
