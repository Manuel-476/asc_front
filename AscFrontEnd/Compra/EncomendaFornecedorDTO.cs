using ERP_Buyer.Application.DTOs.Fornecedor;
using ERP_Buyer.Domain.Entities.Documentos;
using static SystemAux.Application.Enums.Enums;

namespace ERP_Buyer.Application.DTOs.Documentos;

public class EncomendaFornecedorDTO
{
    public int id { get; set; }
    public string documento { get; set; }
    public int fornecedorId { get; set; }
    public string local_entrega { get; set; }
    public DocState status { get; set; }
    public DateTime data { get; set; }
    public DateTime created { get; set; } = DateTime.Now;
    public List<EcfArtigoDTO> ecfArtigo { get; set; }
    public FornecedorDTO? fornecedor { get; set; }
}
