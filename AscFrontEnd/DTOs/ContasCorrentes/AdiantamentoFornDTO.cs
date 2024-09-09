using AscFrontEnd.DTOs.Fornecedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd.DTOs.ContasCorrentes
{
    public class AdiantamentoFornDTO
    {
        public int id { get; set; }
        public string documento { get; set; }
        public float valorAdiantado { get; set; }
        public DocState state { get; set; }
        public int fornecedorId { get; set; }
        public FornecedorDTO Fornecedor { get; set; }
        ICollection<RegAdiantamentoFornDTO> regAdiantamentos { get; set; }
    }
}
