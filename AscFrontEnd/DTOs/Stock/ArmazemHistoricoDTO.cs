using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscFrontEnd.DTOs.Stock
{
    public class ArmazemHistoricoDTO
    {
        public int id { get; set; }
        public int armazemId { get; set; }
        public int localizacaoId { get; set; }
        public int qtd { get; set; }
        public int empresaId { get; set; }
        public int funcionarioId { get; set; }
    }
}
