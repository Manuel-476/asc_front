
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd
{
    public class ArtigoDTO
    {
        public int id { get; set; }
        public string codigo { get; set; } = string.Empty;
        public string descricao { get; set; } = string.Empty;
        public float preco_unitario { get; set; }
        public string num_serie { get; set; } = string.Empty;
        public string codigo_barra { get; set; } = string.Empty;
        public OpcaoBinaria mov_stock { get; set; }
        public OpcaoBinaria mov_lote { get; set; }
        public Status status { get; set; }
        public string unidadeCompra { get; set; } = string.Empty;
        public string unidadeVenda { get; set; } = string.Empty;
        public FamiliaArtigoDTO familia { get; set; }
        public SubFamiliaDTO subfamilia { get; set; }
        public MarcaDTO marca { get; set; }
        public ModeloDTO modelo { get; set; }
        public int empresaId { get; set; }
        public int? familiaId { get; set; }
        public int? subFamiliaId { get; set; }
        public int? marcaId { get; set; }
        public int? modeloId { get; set; }
        public int armazemId { get; set; }
        public int localizacaoArtigoId { get; set; }
    }
}
