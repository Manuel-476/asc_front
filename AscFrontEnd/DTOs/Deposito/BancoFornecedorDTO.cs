using AscFrontEnd.DTOs.Fornecedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd.DTOs.Deposito
{
    public class BancoFornecedorDTO
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string descricao { get; set; }
        public string conta { get; set; }
        public string iban { get; set; }
        public Status status { get; set; }
        public int fornecedorId { get; set; }
        public FornecedorDTO fornecedor { get; set; }
    }
}
