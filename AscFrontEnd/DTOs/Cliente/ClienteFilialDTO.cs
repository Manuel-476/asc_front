using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscFrontEnd.DTOs.Cliente
{
    internal class ClienteFilialDTO
    {
        public int id { get; set; }
        public string codigo { get; set; } = string.Empty;
        public string localizacao { get; set; } = string.Empty;
        public string email { get; set; }
        public string nif { get; set; }
        public string foto { get; set; }
        public ICollection<FilialPhoneDTO> filialPhones { get; set; }
    }
}
