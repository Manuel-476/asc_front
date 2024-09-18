using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscFrontEnd.DTOs.Deposito
{
    public class FormaPagamentoDTO
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string descricao { get; set; }
        public int empresaId { get; set; }
    }
}
