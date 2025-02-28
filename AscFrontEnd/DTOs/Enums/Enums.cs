using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscFrontEnd.DTOs.Enums
{
    public class Enums
    {
        public enum ValueCompareResult
        {
            Igualdade = 0,
            Superior,
            Inferior
        }


        public enum OpcaoBinaria
        {
            Nao = 0,
            Sim
        }
        public enum DocState
        {
            ativo = 0,
            anulado,
            estornado
        }
        public enum Status
        {
            inactivo = 0,
            activo
        }
        public enum Entidade
        {
            cliente = 1,
            fornecedor
        }
        public enum TransferenciaResult
        {
            qtdInsuficiente = 0,
            destinoIvalido,
            success
        }
        public enum Acao 
        {
            Salvar, 
            Editar, 
            Eliminar, 
            Ler 
        };
        public enum Actividade
        {
            cliente = 0,
            clienteEdit,
            fornecedor,
            fornecedorEdit,
            funcionario,
            funcionarioEdit,
            transformacao,
            tranformacaoCli,
            compraVFR,
            compraVFT,
            compraVNC,
            compraVGT,
            compraEdit,
            vendaFR,
            vendaFT,
            vendaNC,
            vendaGT,
            vendaEdit,
            stockTransf,
            stockDec,
            stockInc,
            artigo,
            artigoEdit,
            serie,
            armazem,
            armazemEdit,
            ccLiqCli,
            ccLiqCliEdit,
            ccAdCli,
            ccAdCliEdit,
            ccLiqFor,
            ccLiqForEdit,
            ccAdFor,
            ccAdCliForn,
        }
    }
}
