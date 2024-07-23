using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AscFrontEnd.DTOs.Cliente
{
    public class ClienteDTO
    {
        public static int clienteId = 0;
        public int id { get; set; }
        public string nome_fantasia { get; set; } = string.Empty;
        public string razao_social { get; set; } = string.Empty;
        public string espaco_fiscal { get; set; } = string.Empty;
        public string pessoa { get; set; } = string.Empty;
        public int pais_id { get; set; }
        public int provincia_id { get; set; }
        public string localizacao { get; set; } = string.Empty;
        public int empresaid { get; set; }
        public int status { get; set; }
        public string foto { get; set; }
        public string email { get; set; }
        public string nif { get; set; }
        public ICollection<ClienteFilialDTO> clienteFiliais { get; set; }
        public ICollection<ClientePhoneDTO> phones { get; set; }
       // public ICollection<FtDTO>? ft { get; set; }
    }
}
