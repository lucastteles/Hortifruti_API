using HortifrutiSF.Domain.Entidade;
using HortifrutiSF.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortifrutiSF.Repo.Repositories
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly ProdutoContext _produtoContext;

        public EstoqueRepository(ProdutoContext produtoContext)
        {
            _produtoContext = produtoContext;
        }

        public async Task AdicionarEstoque(Estoque estoque)
        {
            await _produtoContext.Estoques.AddAsync(estoque);
            _produtoContext.SaveChanges();
        }

        public async Task AtualizarEstoque(Estoque estoque)
        {
            _produtoContext.Estoques.Update(estoque);
            _produtoContext.SaveChanges();
        }

        public async Task <List<Estoque>> ObterEstoque()//Todos Estoques
        {
            return await _produtoContext.Estoques
                .Include(x=> x.Produto)
                .ToListAsync();
        }

        public async Task<Estoque> ObterProdutoNoEstoque(Guid idProduto)
        {
            return await _produtoContext.Estoques.FirstOrDefaultAsync(x => x.ProdutoId == idProduto);
        }

        public async Task<Estoque> ObterEstoquePorId(Guid idEstoque)
        {
            return await _produtoContext.Estoques
                                        .Include(x=>x.Produto)
                                        .FirstOrDefaultAsync(x => x.Id == idEstoque);
        }

        public async Task<List<Estoque>> ObterTodosProdutosNoEstoque()
        {
            return await _produtoContext.Estoques.Include(x => x.Produto).ToListAsync();
        }


    }
}
