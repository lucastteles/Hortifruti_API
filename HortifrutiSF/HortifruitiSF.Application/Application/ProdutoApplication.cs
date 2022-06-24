using HortifruitiSF.Application.Interface;
using HortifruitiSF.Application.ViewModel;
using HortifrutiSF.Domain.Entidade;
using HortifrutiSF.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortifruitiSF.Application.Application
{
    public class ProdutoApplication : IProdutoApplication
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoApplication(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task AdicionarProduto(ProdutoViewModel produtoVM)
        {
            /* produtoViewModel são os dados que vem da minha camada API
             * Nesse momento estamos construindo uma entidade com os objetos que vieram da viewmodel
            */
            var produto = new Produto(produtoVM.Nome, produtoVM.Descricao);

            await _produtoRepository.AdicionarProduto(produto);
        }
    }
}
