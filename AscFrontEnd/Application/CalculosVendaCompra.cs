using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static float TotalVenda(List<VendaArtigo> vendaArtigos) 
        {
            totalVenda = 0;

            foreach(var item in vendaArtigos) 
            {
                var precoSemIva = item.preco * item.qtd;

                var valorDoIva = precoSemIva * (item.iva / 100);

                var valorDesconto = (precoSemIva + valorDoIva) * (item.desconto/100);

                totalVenda +=  (precoSemIva + valorDoIva) - valorDesconto;
            }

            return totalVenda;
        }

        public static float TotalDescontoVenda(List<VendaArtigo> vendaArtigos)
        {
            totalDesconto = 0;

            foreach (var item in vendaArtigos)
            {
                var precoSemIva = item.preco * item.qtd;

                var valorDoIva = precoSemIva * (item.iva / 100);

                var valorDesconto = (precoSemIva + valorDoIva) * (item.desconto / 100);

                totalDesconto += valorDesconto;
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

        public static float TotalCompra(List<CompraArtigo> compraArtigos)
        {
            totalCompra = 0;

            foreach (var item in compraArtigos)
            {
                var precoSemIva = item.preco * item.qtd;

                var valorDoIva = precoSemIva * (item.iva / 100);

                var valorDesconto = (precoSemIva + valorDoIva) * (item.desconto / 100);

                totalCompra += (precoSemIva + valorDoIva) - valorDesconto;
            }

            return totalCompra;
        }

        public static float TotalDescontoCompra(List<CompraArtigo> compraArtigos)
        {
            totalDesconto = 0;

            foreach (var item in compraArtigos)
            {
                var precoSemIva = item.preco * item.qtd;

                var valorDoIva = precoSemIva * (item.iva / 100);

                var valorDesconto = (precoSemIva + valorDoIva) * (item.desconto / 100);

                totalDesconto += valorDesconto;
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
