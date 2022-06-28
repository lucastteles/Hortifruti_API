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
    public class ProdutoEntradaRepository : IProdutoEntradaRepository
    {
        private readonly ProdutoContext _produtoContext;


        public ProdutoEntradaRepository(ProdutoContext produtoContext)
        {
            _produtoContext = produtoContext;
        }

        public async Task AdicionarProdutoEntradas(ProdutoEntrada produtoEntrada)
        {
            await _produtoContext.ProdutoEntradas.AddAsync(produtoEntrada);
            _produtoContext.SaveChanges();
        }


        public async Task AtualizarProdutoEntradas(ProdutoEntrada produtoEntrada)
        {
            _produtoContext.ProdutoEntradas.Update(produtoEntrada);
            _produtoContext.SaveChanges();
        }

        public async Task DeletarProdutoEntrada(Guid idProdutoEntrada)
        {
            var produtoEntrada = await ObterProdutoEntradasPorId(idProdutoEntrada);
            _produtoContext.ProdutoEntradas.Remove(produtoEntrada);
            _produtoContext.SaveChanges();
        }

        public async Task<ProdutoEntrada> ObterProdutoEntradasPorId(Guid idProdutoEntrada)
        {
            return await _produtoContext.ProdutoEntradas
                                        .Include(x=> x.Produto)
                                        .FirstOrDefaultAsync(x => x.Id == idProdutoEntrada);

        }

        public async Task<List<ProdutoEntrada>> ObterTodosOsProdutoEntradas()
        {
            return await _produtoContext.ProdutoEntradas
                                        .Include(x => x.Produto)
                                        .ToListAsync();
        }
    }
}
