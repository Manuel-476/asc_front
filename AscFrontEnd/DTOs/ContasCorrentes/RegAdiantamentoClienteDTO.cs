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
        public string documento { get; set; }
        public DocState status { get; set; }
        public int empresaId { get; set; }
        public DateTime created_at { get; set; }
        public ICollection<AdiantaFrDTO> adiantaFrs { get; set; }
    }

    public class AdiantaFrDTO
    {
        public int Id { get; set; }
        public List<int> frId { get; set; }
        public List<int> adiantamentoClienteId { get; set; }
        public int regAdiantamentoClientesid { get; set; }
    }
}
