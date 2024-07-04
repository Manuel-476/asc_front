using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AscFrontEnd.DTOs.Stock
{
    public class LocationStoreDTO
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string descricao { get; set; }
        public string localizacao_fisica { get; set; }
        public int status { get; set; }
        public int armazemId { get; set; }
        public List<LocationArtigoDTO> locationArtigos { get; set; }
    }
}
