using HortifrutiSF.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortifrutiSF.Domain.Repositories
{
    public interface IProdutoEntradaRepository
    {
        Task AdicionarProdutoEntradas(ProdutoEntrada produtoEntrada);
        Task AtualizarProdutoEntradas(ProdutoEntrada produtoEntrada);
        Task <ProdutoEntrada> ObterProdutoEntradasPorId (Guid idProdutoEntrada);
        Task<List<ProdutoEntrada>> ObterTodosOsProdutoEntradas();
        public Task DeletarProdutoEntrada(Guid idProdutoEntrada);
        Task<List<ProdutoEntrada>> ObterProdutoEntradaPorData(DateTime? dataInicial, DateTime? dataFinal);
        decimal ObterSaldoPorData( DateTime? dataInicial, DateTime? dataFinal);
        Task<ProdutoEntrada> ObterProdutoEntradasPorProdutoId(Guid idProduto);
    }
}
