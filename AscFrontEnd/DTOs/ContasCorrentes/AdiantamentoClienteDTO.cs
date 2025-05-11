using AscFrontEnd.DTOs.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd.DTOs.ContasCorrentes
{
    public class AdiantamentoClienteDTO
    {
        public int id { get; set; }
        public string documento { get; set; }
        public float valorAdiantado { get; set; }
        public DocState state { get; set; }
        public OpcaoBinaria resolvido { get; set; }
        public int clienteId { get; set; }
        public DateTime created_at { get; set; }
        public ClienteDTO cliente { get; set; }
        public ICollection<AdiantaFrDTO> adiantaFrs { get; set; }
    }
}
