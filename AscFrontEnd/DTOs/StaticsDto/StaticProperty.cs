using AscFrontEnd.DTOs.Actividades;
using AscFrontEnd.DTOs.Artigo;
using AscFrontEnd.DTOs.Cliente;
using AscFrontEnd.DTOs.ContasCorrentes;
using AscFrontEnd.DTOs.Deposito;
using AscFrontEnd.DTOs.Empresa;
using AscFrontEnd.DTOs.Fornecedor;
using AscFrontEnd.DTOs.Funcionario;
using AscFrontEnd.DTOs.Regiao;
using AscFrontEnd.DTOs.Serie;
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
        public static int funcionarioId { get; set; }
        public static int empresaId {get; set;}
        public static string nome { get; set; }
        public static string codigo { get; set; }
        public static string descricao { get; set; }
        public static string token {  get; set; }
        public static string motivoAnulacao { get; set; }
        public static string documentoOrigem { get; set; }

        // Cliente
        public static List<ClienteDTO> clientes { get; set; }
        public static List<ClienteFilialDTO> clienteFiliais { get; set; }

        // Fornecedor
        public static List<FornecedorDTO> fornecedores { get; set; }
        public static List<FornecedorFilialDTO> fornFilais { get; set; }

        // Artigo
        public static List<ArtigoDTO> artigos { get; set; }
        public static List<FamiliaArtigoDTO> familias { get; set; }
        public static List<SubFamiliaDTO> subFamilias { get; set; }
        public static List<ModeloDTO> modelos { get; set; }
        public static List<MarcaDTO> marcas { get; set; }
        public static List<MotivosIsencaoIvaDTO> motivosIsencao { get; set; }
        public static List<IvaDTO> ivas { get; set; }
        public static List<UnidadeDTO> unidades { get; set; }
        public static List<PaisDTO> paises { get; set; }
        public static List<ProvinciaDTO> provincias { get; set; }


        // Actividade
        public static List<ActividadeDTO> actividades { get; set; }

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
        public static List<LocationStoreDTO> locationStores { get; set; }
        public static List<LocationArtigoDTO> locationArtigos { get; set; }
        public static List<ArmazemHistoricoDTO> historico { get; set; }

        // Contas Correntes
        public static List<NpDTO> nps { get; set; }
        public static List<ReciboDTO> recibos { get; set; }
        public static object contaCorrenteFornecedor { get; set; }
        public static object contaCorrenteCliente { get; set; }
        public static List<AdiantamentoFornDTO> adiantamentoForns { get; set; }
        public static List<AdiantamentoClienteDTO> adiantamentoClientes { get; set; }
        public static List<RegAdiantamentoFornDTO> regAdiantamentoForns { get; set; }
        public static List<RegAdiantamentoClienteDTO> regAdiantamentoClientes { get; set; }

        // Serie
        public static List<SerieDTO> series { get; set; }

        // Funcionario
        public static List<FuncionarioDTO> funcionarios { get; set; }
        public static UserDTO user { get; set; }


        // Depositos
        public static List<BancoDTO> bancos { get; set; }
        public static List<CaixaDTO> caixas { get; set; }
        public static List<FormaPagamentoDTO> formasPagamento { get; set; }


        // Empresa
        public static List<EmpresaDTO> empresas { get; set; }
        public static EmpresaDTO empresa { get; set; }

        // Permissions
        public static List<UserPermissionsDTO> permissions { get; set; }
        public static List<RelationUserPermissionDTO> relationUserPermissions { get; set; }
    }
}
