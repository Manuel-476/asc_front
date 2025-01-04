namespace ERP_Buyer.Application.DTOs.Documentos
{
    public class PedidoCotacaoArtigoDTO
    {
        public int artigoId { get; set; }
        public float preco { get; set; }
        public float iva { get; set; }
        public float desconto { get; set; }
    }
}
