﻿

using HortifrutiSF.Domain.Entidade;
using HortifrutiSF.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<Produto> ObterProdutoPorId(Guid idProduto)
        {
            return await _produtoContext.Produtos.FirstOrDefaultAsync(x => x.Id == idProduto);
        }
    }
}