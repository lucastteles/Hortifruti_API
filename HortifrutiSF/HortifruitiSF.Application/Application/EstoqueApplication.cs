using HortifruitiSF.Application.Dto;
using HortifruitiSF.Application.Interface;
using HortifrutiSF.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortifruitiSF.Application.Application
{
    public class EstoqueApplication : IEstoqueApplication
    {
        private readonly IEstoqueRepository _estoqueRepository;

        public EstoqueApplication(IEstoqueRepository estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }

        public async Task<List<EstoqueDto>> ObterEstoqueApplication()
        {
            var estoques = await _estoqueRepository.ObterEstoque();//Todos

            var listaEstoque = new List<EstoqueDto>();

            foreach (var estoque in estoques)
            {
                var estoqueDto = new EstoqueDto()
                {
                  ProdutoId = estoque.ProdutoId,
                  QuantidadeEstoque = estoque.QuantidadeEstoque,
                  EstoqueId = estoque.Id,
                  NomeProduto = estoque.Produto.Nome
                };

                listaEstoque.Add(estoqueDto);
            }

            return listaEstoque;
        }

        public async Task<EstoqueDto> ObterEstoquePorId(Guid idEstoque)
        {
            var estoque = await _estoqueRepository.ObterEstoquePorId(idEstoque);


            var estoqueDto = new EstoqueDto()
            {
                QuantidadeEstoque = estoque.QuantidadeEstoque,
                NomeProduto = estoque.Produto.Nome,
                ProdutoId = estoque.ProdutoId,
                EstoqueId = estoque.Id,

            };

            return estoqueDto;
        }

        public async Task<List<ProdutoDto>> ObterTodosProdutosNoEstoque()
        {
            var estoques = await _estoqueRepository.ObterTodosProdutosNoEstoque();

            var listaProdutos = new List<ProdutoDto>();

            foreach (var estoque in estoques)
            {
                var produtoDto = new ProdutoDto()
                {
                    Nome = estoque.Produto.Nome,
                    Descricao = estoque.Produto.Descricao,
                    PrecoVenda = estoque.Produto.PrecoVenda,
                    ProdutoId = estoque.Produto.Id,
                    Data = estoque.Produto.DataCadastro
                };

                listaProdutos.Add(produtoDto);
            }

            return listaProdutos;
        }
    }
}
