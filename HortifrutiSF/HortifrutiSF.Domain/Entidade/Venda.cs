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

        public Venda(decimal precoProduto, decimal precoCusto, int quantidadeVenda, Guid produtoId)
        {
            PrecoProduto = precoProduto;
            QuantidadeVenda = quantidadeVenda;
            ProdutoId = produtoId;
            PrecoCusto = precoCusto;


            ValidarPrecoProduto();
            ValidarQuantidadeVenda();
            CalcularTotalDaVenda();
            ValidarCalculoTotalDaVenda();
            CalcularTotalPrecoCusto(precoCusto, quantidadeVenda);
        }



        public decimal PrecoProduto { get; set; }
        public decimal PrecoCusto { get; set; }
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

        private void CalcularTotalPrecoCusto(decimal precoCusto, int quantidadeVenda)
        {
            PrecoCusto = precoCusto * quantidadeVenda;
        }

        public void ValidarCalculoTotalDaVenda()
        {
            if (ValorTotal <= 0)
            {
                throw new Exception("O Valor total não pode ser igual a zero");
            }
        }




    }
}
