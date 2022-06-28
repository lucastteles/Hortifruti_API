using HortifruitiSF.Application.Dto;
using HortifruitiSF.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortifruitiSF.Application.Interface
{
    public interface IProdutoApplication
    {
        Task AdicionarProduto(ProdutoViewModel produtoVM);
        Task<List<ProdutoDto>> ObterProdutosApplication();
        Task AtualizarProduto(ProdutoViewModel produtoVM);
        Task<ProdutoDto> ObterProdutoPorId(Guid idProduto);
        Task DeletarProduto(Guid idProduto);
    }
}
