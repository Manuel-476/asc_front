using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd.DTOs.Funcionario
{
    public class UserDTO
    {
        public int id { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public string nivel_acesso { get; set; } = string.Empty;
        public string salt { get; set; } = string.Empty;
        public int funcionarioid { get; set; }
        public OpcaoBinaria state { get; set; }
        public ICollection<RelationUserPermissionDTO> userPermissions { get; set; }
    }

    public class UserResult
    {
        public string token { get; set; } = string.Empty;
        public UserDTO user { get; set; }
    }
}
