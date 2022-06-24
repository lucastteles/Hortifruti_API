using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortifrutiSF.Domain.Entidade
{
    public class ProdutoEntrada : EntidadeBase
    {

        private ProdutoEntrada() { }

        public ProdutoEntrada(decimal preco, int quantidade, float peso)
        {
            Preco = preco;
            Quantidade = quantidade;
            Peso = peso;

            ValidarPreco();
            ValidarQuantidade();
            ValidarPeso();
        }


        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public float Peso { get; set; }
        public Guid ProdutoId { get; set; }
        public Produto Produto { get; set; }


        private void ValidarPreco()
        {
            if (Preco <= 0)
            {
                throw new Exception("O campo preço não pode ser menor do que zero");

            }

        }

        private void ValidarQuantidade()
        {
            if (Quantidade < 0)
            {
                throw new Exception("O campo quantidade não pode ser menor do que zero");

            }

        }

        private void ValidarPeso()
        {
            if (Peso < 0)
            {
                throw new Exception("O campo peso não pode ser menor do que zero");

            }

        }

    }


}






//RELACIONAMENTO
//builder.HasOne(pd => pd.Produto)
//    .WithMany(v => v.ProdutoEntrada)
//    .HasForeignKey(pd => pd.ProdutoId);


/*
 * -------****--------- Produto -------- *****-------
  - vai ter que cadastrar produtos no sistema (Entidade Produto)
 para cadastrar  o produto ele precisa informar o nome do produto
 regra: Nome não pode ser vazio


-------****--------- ProdutoEntrada -------- *****-------
 - Entrada do produto (na entidade ProdutoEntrada)
passo 1:selecionar o produto 
passo 2: informar preço 
passo 3: informar a quantidade 
passo 4: informar o peso 
passo 5: Salvar as informações
 
 regra:
 O ProdutoId precisa ser informado
 O Preço não pode ser zero ou negativo
 A Quantidade não pode ser zero ou negativo
 O Peso não pode ser negativo

 
 */