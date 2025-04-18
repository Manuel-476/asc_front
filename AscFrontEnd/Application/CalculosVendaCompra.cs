using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Math;
using static AscFrontEnd.Compra;
using static AscFrontEnd.Venda;

namespace AscFrontEnd.Application
{
    public class CalculosVendaCompra
    {
        private static float totalVenda { get; set; }
        private static float totalCompra { get; set; }
        private static float totalDesconto {get; set;}
        private static float totalIva { get; set; } 

        public static float TotalVenda(List<VendaArtigo> vendaArtigos, float descontoCliente) 
        {
            totalVenda = 0;

            foreach(var item in vendaArtigos) 
            {
                var precoSemIva = item.preco * item.qtd;

                var valorDoIva = precoSemIva * (item.iva / 100);

                var valorDesconto = TotalDescontoVenda(vendaArtigos, descontoCliente);

                totalVenda +=  (precoSemIva + valorDoIva) - valorDesconto;
            }

            return totalVenda;
        }

        public static float TotalDescontoVenda(List<VendaArtigo> vendaArtigos, float descontoCliente)
        {
            totalDesconto = 0;

            foreach (var item in vendaArtigos)
            {
                var precoSemIva = item.preco * item.qtd;

                var valorDoIva = precoSemIva * (item.iva / 100);

                var clienteDesconto = (precoSemIva + valorDoIva) * (descontoCliente / 100);

                var valorDesconto = (precoSemIva + valorDoIva - clienteDesconto) * (item.desconto / 100);

                totalDesconto += valorDesconto;
            }

            return totalDesconto;
        }

        public static float TotalDescontoCliente(List<VendaArtigo> vendaArtigos, float descontoCliente)
        {
            totalDesconto = 0;

            foreach (var item in vendaArtigos)
            {
                var precoSemIva = item.preco * item.qtd;

                var valorDoIva = precoSemIva * (item.iva / 100);

                var clienteDesconto = (precoSemIva + valorDoIva) * (descontoCliente / 100);

                totalDesconto += clienteDesconto;
            }

            return totalDesconto;
        }

        public static float TotalIvaVenda(List<VendaArtigo> vendaArtigos)
        {
            totalIva = 0;

            foreach (var item in vendaArtigos)
            {
                var precoSemIva = item.preco * item.qtd;

                var valorDoIva = precoSemIva * (item.iva / 100);

                totalIva += valorDoIva;
            }

            return totalIva;
        }

        public static float TotalCompra(List<CompraArtigo> compraArtigos, float descontoFornecedor)
        {
            totalCompra = 0;

            foreach (var item in compraArtigos)
            {
                var precoSemIva = item.preco * item.qtd;

                var valorDoIva = precoSemIva * (item.iva / 100);

                var valorDesconto = TotalDescontoCompra(compraArtigos, descontoFornecedor);

                totalCompra += (precoSemIva + valorDoIva) - valorDesconto;
            }

            return totalCompra;
        }

        public static float TotalDescontoCompra(List<CompraArtigo> compraArtigos, float descontoFornecedor)
        {
            totalDesconto = 0;

            foreach (var item in compraArtigos)
            {
                var precoSemIva = item.preco * item.qtd;

                var valorDoIva = precoSemIva * (item.iva / 100);

                var fornecedorDesconto = (precoSemIva + valorDoIva) * (descontoFornecedor / 100);

                var valorDesconto = (precoSemIva + valorDoIva - fornecedorDesconto) * (item.desconto / 100);

                totalDesconto += valorDesconto;
            }

            return totalDesconto;
        }

        public static float TotalDescontoFornecedor(List<CompraArtigo> compraArtigos, float descontoFornecedor)
        {
            totalDesconto = 0;

            foreach (var item in compraArtigos)
            {
                var precoSemIva = item.preco * item.qtd;

                var valorDoIva = precoSemIva * (item.iva / 100);

                var fornecedorDesconto = (precoSemIva + valorDoIva) * (descontoFornecedor / 100);


                totalDesconto += fornecedorDesconto;
            }

            return totalDesconto;
        }

        public static float TotalIvaCompra(List<CompraArtigo> compraArtigos)
        {
            totalIva = 0;

            foreach (var item in compraArtigos)
            {
                var precoSemIva = item.preco * item.qtd;

                var valorDoIva = precoSemIva * (item.iva / 100);

                totalIva += valorDoIva;
            }

            return totalIva;
        }
    }

}
