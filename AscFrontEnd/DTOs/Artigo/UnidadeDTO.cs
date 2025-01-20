using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd.DTOs.Artigo
{
    public class UnidadeDTO
    {
        public int id { get; set; }
        public string codigo { get; set; } = string.Empty;
        public string descricao { get; set; } = string.Empty;
        public Status state { get; set; }
        public int? empresaId { get; set; }
        public DateTime? created_at { get; set; }
    }
}
