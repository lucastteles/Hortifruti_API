using HortifruitiSF.Application.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HortifruitiSF.Application.Interface
{
    public interface IEstoqueApplication
    {
        Task<List<EstoqueDto>> ObterEstoqueApplication();
        Task<EstoqueDto> ObterEstoquePorId(Guid idEstoque);
        Task<List<ProdutoDto>> ObterTodosProdutosNoEstoque();
    }
}
 