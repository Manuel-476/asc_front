using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd.DTOs.Stock
{
    public class ArmazemDTO
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string descricao { get; set; }
        public List<LocationStoreDTO> storeLocations { get; set; } = new List<LocationStoreDTO>();
        public int sectorId { get; set; }
        public int funcionarioId { get; set; }
        public Status status { get; set; }
        public int empresaId { get; set; }
    }

    public class StockDTO
    {
        public int id { get; set; }
        public string artigo { get; set; }
        public string descricao { get; set; }
        public int qtd { get; set; }
        public Status status { get; set; }
    }
}

