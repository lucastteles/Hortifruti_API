using HortifrutiSF.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortifrutiSF.Domain.Repositories
{
    public interface IEstoqueRepository
    {
        Task AdicionarEstoque(Estoque estoque);
        Task AtualizarEstoque(Estoque estoque);
        Task<List<Estoque>> ObterEstoque();
        Task<Estoque> ObterProdutoNoEstoque(Guid idProduto);
        Task<Estoque> ObterEstoquePorId(Guid idEstoque);
        Task<List<Estoque>> ObterTodosProdutosNoEstoque();


    }
}
