using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscFrontEnd.DTOs.Funcionario
{
    public class RelationUserPermissionDTO
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public int userEntityId { get; set; }
        public int permissionId { get; set; }
        public UserPermissionsDTO Permission { get; set; }
    }
}
