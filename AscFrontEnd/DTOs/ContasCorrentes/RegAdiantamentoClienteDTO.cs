using AscFrontEnd.DTOs.Cliente;
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
        public string documento { get; set; }
        public float valorAdiantado { get; set; }
        public DocState state { get; set; }
        public int clienteId { get; set; }
        public ClienteDTO cliente { get; set; }
        ICollection<AdiantamentoClienteDTO> regAdiantamentos { get; set; }
    }
}
