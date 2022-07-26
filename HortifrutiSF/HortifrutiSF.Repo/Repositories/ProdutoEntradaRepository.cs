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

        public async Task<List<ProdutoEntrada>> ObterProdutoEntradaPorData(DateTime? dataInicial, DateTime? dataFinal)
        {
            return await _produtoContext.ProdutoEntradas
                .Include(x => x.Produto)
                .Where(x => x.DataCadastro.Date >= dataInicial && x.DataCadastro.Date <= dataFinal)
                .OrderByDescending(x=>x.DataCadastro)
                .ToListAsync();
        }

        public async Task<ProdutoEntrada> ObterProdutoEntradasPorId(Guid idProdutoId)
        {
            return await _produtoContext.ProdutoEntradas
                                        .Include(x => x.Produto)
                                        .FirstOrDefaultAsync(x => x.Id == idProdutoId);

        }

        public async Task<ProdutoEntrada> ObterProdutoEntradasPorProdutoId(Guid idProduto)
        {
            return await _produtoContext.ProdutoEntradas
                                        .Include(x => x.Produto)
                                        .FirstOrDefaultAsync(x => x.ProdutoId == idProduto);
        }

        public decimal ObterSaldoPorData(DateTime? dataInicial, DateTime? dataFinal)
        {
            var saldo =
                 _produtoContext.ProdutoEntradas
                 .Where(x => x.DataCadastro.Date >= dataInicial && x.DataCadastro.Date <= dataFinal)
                 .Sum(x => x.Preco);

            return saldo;
            

            
        }

        public async Task<List<ProdutoEntrada>> ObterTodosOsProdutoEntradas()
        {
            return await _produtoContext.ProdutoEntradas
                                        .Include(x => x.Produto)
                                        .ToListAsync();
        }
    }
}
