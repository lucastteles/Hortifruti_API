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


        public async Task AdicionarProdutoEntrada(ProdutoEntrada produtoEntrada)
        {
          await  _produtoContext.ProdutoEntrada.AddAsync(produtoEntrada);
            _produtoContext.SaveChanges();
        }

        public async Task AtualizarProdutoEntrada(ProdutoEntrada produtoEntrada)
        {
            _produtoContext.ProdutoEntrada.Update(produtoEntrada);
            _produtoContext.SaveChanges();
        }

        public async Task<ProdutoEntrada> ObterProdutoEntradaPorId(Guid idProdutoEntrada)
        {
            return await _produtoContext.ProdutoEntrada.FirstOrDefaultAsync(x => x.Id == idProdutoEntrada);
        }
    }
}
