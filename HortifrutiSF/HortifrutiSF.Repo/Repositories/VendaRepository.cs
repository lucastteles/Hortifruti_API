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
    public class VendaRepository : IVendaRepository
    {
        private readonly ProdutoContext _produtoContext;

        public VendaRepository(ProdutoContext produtoContext)
        {
            _produtoContext = produtoContext;
        }

        public async Task AdicionarVenda(Venda venda)
        {

            await _produtoContext.Vendas.AddAsync(venda);
            _produtoContext.SaveChanges();
        }

        public async Task<List<Venda>> ObterVendaPorData(DateTime? dataInicial, DateTime? dataFinal)
        {
            return await _produtoContext.Vendas
                .Include(x => x.Produto)
                .Where(x => x.DataCadastro.Date >= dataInicial && x.DataCadastro.Date <= dataFinal)
                .ToListAsync();
        }

        public async Task Deletar(Guid idVenda)
        {
            var venda = await _produtoContext.Vendas.FirstOrDefaultAsync(x=> x.Id == idVenda);
            _produtoContext.Vendas.Remove(venda);
            _produtoContext.SaveChanges();
        }
    }
}
