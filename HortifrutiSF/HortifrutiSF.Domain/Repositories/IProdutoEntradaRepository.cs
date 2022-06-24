using HortifrutiSF.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortifrutiSF.Domain.Repositories
{
    public interface IProdutoEntradasRepository
    {
        Task AdicionarProduto(ProdutoEntrada produtoEntrada);
        Task AtualizarProduto(ProdutoEntrada produtoEntrada);
        Task <ProdutoEntrada> ObterProdutoEntradaPorId (Guid idProdutoEntrada);
    }
}
