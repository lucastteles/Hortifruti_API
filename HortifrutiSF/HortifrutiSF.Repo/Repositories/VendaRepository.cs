using HortifrutiSF.Domain.Entidade;
using HortifrutiSF.Domain.Repositories;
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
    }
}
