using HortifruitiSF.Application.Dto;
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
            var produto = new Produto(produtoVM.Nome, produtoVM.Descricao, produtoVM.PrecoVenda);

            await _produtoRepository.AdicionarProduto(produto);
        }

        public async Task AtualizarProduto(ProdutoViewModel produtoVM)//////
        {
            // Obter o produtoId fazer a consulta no repositorio
            var produto = await _produtoRepository.ObterProdutoPorId(produtoVM.IdProduto);


            //Atribuir e atualizar na entidade
            produto.AtualizarDadosDoProduto(produtoVM.Nome, produtoVM.Descricao,produtoVM.PrecoVenda);


            //Chamar o repositorio e atualizar
            await _produtoRepository.AtualizarProduto(produto);
        }

        public async Task DeletarProduto(Guid idProduto)
        {
            await _produtoRepository.Deletar(idProduto);
        }

        public async Task<ProdutoDto> ObterProdutoPorId(Guid idProduto)///
        {
            var produto = await _produtoRepository.ObterProdutoPorId(idProduto);

            var produtoDto = new ProdutoDto()
            {
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                PrecoVenda = produto.PrecoVenda,
                ProdutoId = produto.Id,
                Data = produto.DataCadastro
            };

            return produtoDto;
        }

        public async Task<List<ProdutoDto>> ObterProdutosApplication()
        {
            var produtos = await _produtoRepository.ObterTodosOsProdutos();

            var listaProdutos = new List<ProdutoDto>();

            foreach (var produto in produtos)
            {
                var produtoDto = new ProdutoDto()
                {
                    Nome = produto.Nome,
                    Descricao = produto.Descricao,
                    PrecoVenda = produto.PrecoVenda,
                    ProdutoId = produto.Id,
                    Data = produto.DataCadastro
                };

                listaProdutos.Add(produtoDto);
            }

            return listaProdutos;
        }
    }
}
