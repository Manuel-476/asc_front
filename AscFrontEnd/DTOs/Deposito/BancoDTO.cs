using AscFrontEnd.DTOs.Empresa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd.DTOs.Deposito
{
    public class BancoDTO
    {
        public int id { get; set; }
        public string codigo { get; set; } = string.Empty;
        public string descricao { get; set; } = string.Empty;
        public string conta { get; set; } = string.Empty;
        public string iban { get; set; } = string.Empty;
        public Status status { get; set; }
        public int empresaId { get; set; }
        public EmpresaDTO empresa { get; set; }
    }
}
