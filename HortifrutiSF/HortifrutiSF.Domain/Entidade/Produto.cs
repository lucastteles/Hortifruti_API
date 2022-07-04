using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortifrutiSF.Domain.Entidade
{
    public class Produto : EntidadeBase
    {

        private Produto() { }


        public Produto(string nome, string descricao, decimal precoVenda)
        {
            Nome = nome;
            Descricao = descricao;
            PrecoVenda = precoVenda;

            ValidarNome(); 
            ValidarMaximo200Caracteres();
            ValidarDescricao();
            ValidarPrecoVenda();

        }


        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoVenda { get; set; }
        public ICollection<Venda> Vendas { get; set; }


        //Validação
        private void ValidarNome()
        {
            if (string.IsNullOrEmpty(Nome))
            {
                throw new Exception("O campo nome não pode ser vazio");
            }
        }

        private void ValidarDescricao()
        {
            if (string.IsNullOrEmpty(Descricao))
            {
                throw new Exception("O campo descrição não pode ser vazio");
            }
        }

        private void ValidarMaximo200Caracteres()
        {
            if (Nome.Length > 200)
            {
                throw new Exception("O campo nome não pode ser maior que 200 caracteres");
            }
        }

        private void ValidarPrecoVenda()
        {
            if(PrecoVenda <= 0)
            {
                throw new Exception("O campo preço não pode ser menor ou igual aaa zero");
            }
        }

        public void AtualizarDadosDoProduto(string nome, string descricao, decimal precoVenda)
        {
            Nome = nome;
            Descricao = descricao;
            PrecoVenda = precoVenda;

            ValidarNome();
            ValidarMaximo200Caracteres();
            ValidarDescricao();
            ValidarPrecoVenda();


        }

    }
}
