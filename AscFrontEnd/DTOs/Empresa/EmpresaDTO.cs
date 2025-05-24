using AscFrontEnd.DTOs.Deposito;
using AscFrontEnd.DTOs.Pessoa;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AscFrontEnd.DTOs.Enums.Enums;

namespace AscFrontEnd.DTOs.Empresa
{
    public class EmpresaDTO:PessoaDTO
    {
        public int id { get; set; }
        public string nome_fantasia { get; set; }
        public string razao_social { get; set; }
        public string endereco { get; set; }
        public string bairro { get; set; }
        public string pronvicia { get; set; }
        public string telefone { get; set; }
        public string website { get; set; }
        public string ramo_actividade { get; set; }
        public string descricao { get; set; }
        public string logotipo { get; set; } = string.Empty;
        public IFormFile imagem { get; set; }
        public Status status { get; set; }
        public List<FuncionarioDTO> funcionarios { get; set; }
        public ICollection<BancoDTO> bancos { get; set; }
        public ICollection<CaixaDTO> caixas { get; set; }
    }
}
