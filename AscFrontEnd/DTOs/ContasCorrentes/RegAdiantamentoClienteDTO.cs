using AscFrontEnd.DTOs.Cliente;
using AscFrontEnd.DTOs.Venda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd.DTOs.ContasCorrentes
{
    public class RegAdiantamentoClienteDTO
    {
        public int id { get; set; }
        public int adiantamentoId { get; set; }
        public string documento { get; set; }
        public int frId { get; set; }
        public DocState status { get; set; }
        public int empresaId { get; set; }
        public FrDTO fr { get; set; }
        public AdiantamentoClienteDTO adiantamento { get; set; }
    }
}
