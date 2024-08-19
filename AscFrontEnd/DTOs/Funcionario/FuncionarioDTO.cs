using AscFrontEnd.DTOs.Actividades;
using AscFrontEnd.DTOs.Funcionario;
using AscFrontEnd.DTOs.Pessoa;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AscFrontEnd.DTOs.Enums.Enums;



namespace AscFrontEnd.DTOs
{
    public class FuncionarioDTO : PessoaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string morada { get; set; }
        public DateTime data_nascimento { get; set; }
        public string codigo_postal { get; set; }
        public string localidade { get; set; }
        public int paisId { get; set; }
        public int provinciaId { get; set; }
        public char genero { get; set; }
        public int naturalidadeId { get; set; }
        public Status status { get; set; }
        public int empresaid { get; set; }
        public ICollection<FuncionarioPhoneDTO> phones { get; set; }
        public UserDTO users { get; set; }
        public ICollection<ActividadeDTO> actividades { get; set; }
    }
}
