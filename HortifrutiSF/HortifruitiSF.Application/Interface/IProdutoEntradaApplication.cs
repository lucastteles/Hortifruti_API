using HortifruitiSF.Application.Dto;
using HortifruitiSF.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortifruitiSF.Application.Interface
{
    public interface IProdutoEntradaApplication
    {
        Task AdicionarProdutoEntrada(ProdutoEntradaViewModel produtoEntradaVM);
        Task AtualizarProdutoEntrada(ProdutoEntradaViewModel produtoEntradaVm);
        Task<List<ProdutoEntradaDto>> ObterProdutoEntradasApplication();
        Task<ProdutoEntradaDto> ObterProdutoEntradasPorId(Guid idProduto);
        Task DeletarProdutoEntrada(Guid idProdutoEntrada);
    }
}
