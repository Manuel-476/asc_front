using AscFrontEnd.DTOs.Cliente;
using AscFrontEnd.DTOs.ContasCorrentes;
using AscFrontEnd.DTOs.Fornecedor;
using AscFrontEnd.DTOs.Stock;
using AscFrontEnd.DTOs.Venda;
using EAscFrontEnd;
using ERP_Buyer.Application.DTOs.Documentos;
using ERP_Seller.Application.DTOs.Documentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscFrontEnd.DTOs.StaticsDto
{
    public class StaticProperty
    {
        public static int entityId {  get; set; }
        public static int empresaId {get; set;}
        public static string nome { get; set; }
        public static string codigo { get; set; }
        public static string descricao { get; set; }
        public static List<ClienteDTO> clientes { get; set; }
        public static List<FornecedorDTO> fornecedores { get; set; }
        public static List<ArtigoDTO> artigos { get; set; }

        // Compra
        public static List<VftDTO> vfts { get; set; }
        public static List<VfrDTO> vfrs { get; set; }
        public static List<VgtDTO> vgts { get; set; }
        public static List<VncDTO> vncs { get; set; }
        public static List<VndDTO> vnds { get; set; }
        public static List<EncomendaFornecedorDTO> ecfs { get; set; }
        public static List<PedidoCotacaoDTO> pcos { get; set; }
        public static List<CotacaoDTO> cots { get; set; }

        // Venda
        public static List<FtDTO> fts { get; set; }
        public static List<FrDTO> frs { get; set; }
        public static List<GtDTO> gts { get; set; }
        public static List<NcDTO> ncs { get; set; }
        public static List<NdDTO> nds { get; set; }
        public static List<EncomendaClienteDTO> ecls { get; set; }
        public static List<FaturaProformaDTO> fps { get; set; }

        // Stocks
        public static List<ArmazemDTO> armazens { get; set; }

        // Contas Correntes
        public static List<NpDTO> nps { get; set; }
        public static List<ReciboDTO> recibos { get; set; }
        public static object contaCorrenteFornecedor { get; set; }
        public static object contaCorrenteCliente { get; set; }
    }
}
