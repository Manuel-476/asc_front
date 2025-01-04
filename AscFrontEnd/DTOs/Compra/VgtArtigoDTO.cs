namespace ERP_Buyer.Application.DTOs.Documentos
{
    public class VgtArtigoDTO
    {
        public int id { get; set; }
        public int artigoId { get; set; }
        public float preco { get; set; }
        public float iva { get; set; }
        public float desconto { get; set; }
        public int qtd { get; set; }
    }
}
