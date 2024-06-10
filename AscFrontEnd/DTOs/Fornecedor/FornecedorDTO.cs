using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscFrontEnd.DTOs.Fornecedor
{
    internal class FornecedorDTO
    {
        public static int fornecedorId {  get; set; } 
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
        public string nif { get; set; }
        public string foto { get; set; }
        public string email { get; set; }
        public List<FornecedorFilialDTO> fornecedorFiliais { get; set; }
        public List<FornecedorPhoneDTO> phones { get; set; }
    }
}
