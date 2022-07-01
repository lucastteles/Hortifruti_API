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


        public Produto(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;

            ValidarNome();
            ValidarMaximo200Caracteres();
            ValidarDescricao();

        }


        public string Nome { get; set; }
        public string Descricao { get; set; }

        public ICollection<ProdutoEntrada> ProdutoEntradas { get; set; }
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

        public void AtualizarDadosDoProduto(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;

            ValidarNome();
            ValidarMaximo200Caracteres();
            ValidarDescricao();


        }

    }
}
