using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd.DTOs.ContasCorrentes
{
    public class RegAdiantamentoFornDTO
    {
        public int id { get; set; }
        public string documento { get; set; }
        public DocState status { get; set; }
        public int empresaId { get; set; }
        public DateTime created_at { get; set; }
        public ICollection<AdiantaVfrDTO> adiantaVfrs { get; set; }
    }

    public class AdiantaVfrDTO
    {
        public int Id { get; set; }
        public List<int> vfrId { get; set; }
        public List<int> adiantamentoFornId { get; set; }
        public int regAdiantamentoFornecedorid { get; set; }
    }
}
