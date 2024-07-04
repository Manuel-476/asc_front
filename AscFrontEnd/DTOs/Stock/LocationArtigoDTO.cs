using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscFrontEnd.DTOs.Stock
{
    public class LocationArtigoDTO
    {
        public int id { get; set; }
        public int armazemId { get; set; }
        public int locationStoreId { get; set; }
        public int artigoId { get; set; }
        public int qtd { get; set; }
        public ArtigoDTO Artigo { get; set; }
    }
}
