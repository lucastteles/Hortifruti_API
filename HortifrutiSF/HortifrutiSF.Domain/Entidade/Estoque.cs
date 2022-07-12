using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortifrutiSF.Domain.Entidade
{
    public class Estoque : EntidadeBase
    {
        private Estoque() { }

        public Estoque(int quantidadeEstoque, Guid produtoId)
        {
            QuantidadeEstoque = quantidadeEstoque;
            ProdutoId = produtoId;

            ValidarQuantidadeEstoque();
        }


       // Entidade estoque campos Quantidade, ProdutoId, Id, datacadastro, dataalteracao

        public int QuantidadeEstoque { get; set; }
        public Guid ProdutoId   { get; set; }
        public Produto Produto { get; set; }




        public void ValidarQuantidadeEstoque()
        {
            if(QuantidadeEstoque <= 0)
            {
                throw new Exception("O campo QuantidadeEstoque não pode ser menor ou igual a zero");
            }
        }


        public void AdicionarQuantiadeDeProdutoNoEstoque(int quantidade)
        {
            QuantidadeEstoque += quantidade;
        }

        public void ReduzirQunatidadeDeProdutoNoEstoque(int quantidade)
        {
            QuantidadeEstoque -= quantidade;
        }
    }

    


}
