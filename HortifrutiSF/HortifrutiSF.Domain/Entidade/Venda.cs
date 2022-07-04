using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortifrutiSF.Domain.Entidade
{
    public class Venda : EntidadeBase
    {
        private Venda() { }

        public Venda(decimal precoProduto, int quantidadeVenda, Guid produtoId)
        {
            PrecoProduto = precoProduto;
            QuantidadeVenda = quantidadeVenda;
            ProdutoId = produtoId;

            ValidarPrecoProduto();
            ValidarQuantidadeVenda();
            CalcularTotalDaVenda();
            ValidarCalculoTotalDaVenda();
        }



        public decimal PrecoProduto { get; set; }
        public int QuantidadeVenda { get; set; }
        public decimal ValorTotal { get; set; }
        public Guid ProdutoId { get; set; }
        public Produto Produto { get; set; }



        public void ValidarPrecoProduto()
        {
            if (PrecoProduto <= 0)
            {
                throw new Exception("O campo PreçoProduto não pode ser menor ou igual a zero");
            }
        }


        public void ValidarQuantidadeVenda()
        {
            if (QuantidadeVenda <= 0)
            {
                throw new Exception("O campo Quantidade não pode ser menor ou igual a zero ");
            }
        }


        public void CalcularTotalDaVenda()
        {

            ValorTotal = QuantidadeVenda * PrecoProduto;
        }

        public void ValidarCalculoTotalDaVenda()
        {
            if (ValorTotal <= 0)
            {
                throw new Exception("O Valor total não pode ser igual a zero");
            }
        }
        /*
         Entidade Venda

        Guid ProdutoId
        Guid ProdutoEntradaId
        decimal PrecoProduto
        int QuantidadeVenda
        decimal ValorTotal


        produto = refri
        preço = 10.00
        quantidade = 2
        valortotal = 20
        datacadastro = 30/06/2022 9:40

        produto = refri
 
        preço = 10.00
        quantidadeDeVenda = 2
        valortotal = 20
        datacadastro = 30/06/2022 10:40

        produto = refri
        preço = 20.00
        quantidade = 1
        valortotal = 20
        datacadastro = 30/06/2022 11:00

        produto = refri
        preço = 10.00
        quantidade = 4
        valortotal = 40
        datacadastro = 30/06/2022 12:00

        a query 
        pegar o produto refrigerante de uma data especifica, 
        somar a quantidade vendida 
        e somar o valor total

        DTO CalculoDeVenda
        produto = refri
        quantidade = 4
        valortotal = 100
         
         */

    }
}
