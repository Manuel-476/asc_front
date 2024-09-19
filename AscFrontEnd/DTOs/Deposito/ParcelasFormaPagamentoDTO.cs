using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscFrontEnd.DTOs.Deposito
{
    public class ParcelasFormaPagamentoDTO
    {
        public int id { get; set; }
        public int formaPagamentoId { get; set; }
        public int documentoId { get; set; }
        public string documento { get; set; }
        public float valor { get; set; }
        public int? bancoId { get; set; }
        public int? caixaId { get; set; }
    }
}
