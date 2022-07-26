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

        public ProdutoEntrada(decimal preco, int quantidade, float peso, Guid produtoId, string fornecedor )
        {
            Preco = preco; //obtenho o valor total de produto // Quanto eu gastei de mercadoria
            Quantidade = quantidade;
            Peso = peso;
            Fornecedor = fornecedor;
            ProdutoId = produtoId;
            


            ValidarPreco();
            ValidarQuantidade();
            ValidarPeso();
            ValidarFornecedor();
            CalcularPrecoCusto();
            ValidarCalculoPrecoCusto();

        }


        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public float Peso { get; set; }
        public string Fornecedor { get; set; }
        public decimal PrecoCusto { get; set; }
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

        private void ValidarFornecedor()
        {
            if (Fornecedor.Length > 200)
            {
                throw new Exception("O campo Fornecedor não pode ser maior que 200 caracteres");
            }
        }

        public void CalcularPrecoCusto()
        {

            PrecoCusto = Preco / Quantidade;
        }

        public void ValidarCalculoPrecoCusto()
        {
            if (PrecoCusto <= 0)
            {
                throw new Exception("O Preço de Custo não pode ser igual a zero");
            }
        }

        public void AtualizarDadosDoProdutoEntrada(decimal preco, int quantidade, float peso, Guid produtoId, string fornecedor)
        {
            Preco = preco;
            Quantidade = quantidade;
            Peso = peso;
            Fornecedor = fornecedor;
            ProdutoId = produtoId;


            ValidarPreco();
            ValidarQuantidade();
            ValidarPeso();
            ValidarFornecedor();
        }

    }


}





