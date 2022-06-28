

using HortifrutiSF.Domain.Entidade;
using HortifrutiSF.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HortifrutiSF.Repo.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProdutoContext _produtoContext;

        public ProdutoRepository(ProdutoContext produtoContext)
        {
            _produtoContext = produtoContext;
        }

        public async Task AdicionarProduto(Produto produto)
        {
            await _produtoContext.Produtos.AddAsync(produto);
            _produtoContext.SaveChanges();
        }

        public async Task AtualizarProduto(Produto produto)
        {
            _produtoContext.Produtos.Update(produto);
            _produtoContext.SaveChanges();
        }

        public async Task Deletar(Guid idProduto)
        {
            var produto = await ObterProdutoPorId(idProduto);
            _produtoContext.Produtos.Remove(produto);
            _produtoContext.SaveChanges();
        }

        public async Task<Produto> ObterProdutoPorId(Guid idProduto)
        {
            return await _produtoContext.Produtos.FirstOrDefaultAsync(x => x.Id == idProduto);
        }

        public async Task<List<Produto>> ObterTodosOsProdutos()
        {
            return await _produtoContext.Produtos.ToListAsync();
        }


    }
}
