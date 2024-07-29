using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AscFrontEnd.DTOs.Enums ;
using static AscFrontEnd.DTOs.Enums.Enums;


namespace AscFrontEnd.DTOs.Actividades
{
    public  class ActividadeDTO
    {
        public int id { get; set; }
        public int funcionarioId { get; set; }
        public Actividade actividade { get; set; }
        public int acaoId { get; set; }
        public DateTime data { get; set; }
        public FuncionarioDTO funcionario { get; set; }
    }
}
