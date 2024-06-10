using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscFrontEnd.DTOs.Fornecedor
{
    internal class FornecedorFilialDTO
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string localizacao { get; set; }
        public string email { get; set; }
        public string nif { get; set; }
        public string foto { get; set; }
        public List<FornFilialPhoneDTO> fornFilialPhones { get; set; }
    }
}
