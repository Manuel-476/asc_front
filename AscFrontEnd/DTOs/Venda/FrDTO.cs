

using AscFrontEnd.DTOs.Deposito;
using System;
using System.Collections.Generic;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd.DTOs.Venda
{
    public class FrDTO
    {
        public int id { get; set; }
        public string documento { get; set; }
        public int clienteId { get; set; }
        public DocState status { get; set; }
        public string fullHash { get; set; }
        public string shortHash { get; set; }
        public int? bancoClienteId { get; set; }
        public int? caixaClienteId { get; set; }
        public DateTime data { get; set; }
        public DateTime created_at { get; set; }
        public List<FrArtigoDTO> frArtigo { get; set; }
        public List<ParcelasFormaPagamentoDTO> parcelas { get; set; }
        public List<BancoDTO> bancos { get; set; }
        public List<CaixaDTO> caixas { get; set; }
    }
}
