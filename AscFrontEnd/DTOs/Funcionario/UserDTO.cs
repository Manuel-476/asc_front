﻿using System;
using System.Collections.Generic;
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
        public int funcionarioid { get; set; }
        public OpcaoBinaria state { get; set; }
    }
}
