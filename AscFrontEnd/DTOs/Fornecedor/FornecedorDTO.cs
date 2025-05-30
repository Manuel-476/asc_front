﻿using AscFrontEnd.DTOs.ContasCorrentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd.DTOs.Fornecedor
{
    public class FornecedorDTO
    {
        public static int fornecedorId {  get; set; } 
        public static string nome { get; set; }
        public int id { get; set; }
        public string nome_fantasia { get; set; } = string.Empty;
        public string razao_social { get; set; } = string.Empty;
        public string espaco_fiscal { get; set; } = string.Empty;
        public string pessoa { get; set; } = string.Empty;
        public int pais_id { get; set; }
        public int provincia_id { get; set; }
        public string localizacao { get; set; } = string.Empty;
        public float desconto { get; set; }
        public int empresaid { get; set; }
        public Status status { get; set; }
        public string nif { get; set; }
        public string foto { get; set; }
        public string email { get; set; }
        public List<FornecedorFilialDTO> fornecedorFiliais { get; set; }
        public List<FornecedorPhoneDTO> phones { get; set; }
        public List<AdiantamentoFornDTO> adiantamentos { get; set; }
    }
}
