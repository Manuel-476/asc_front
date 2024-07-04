using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscFrontEnd.DTOs.Stock
{
    public class ArmazemDTO
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string descricao { get; set; }
        public List<LocationStoreDTO> storeLocations { get; set; }
        public int sectorId { get; set; }
        public int funcionarioId { get; set; }
        public int status { get; set; }
        public int empresaId { get; set; }
    }
}

