using HortifruitiSF.Application.Interface;
using HortifruitiSF.Application.ViewModel;
using HortifrutiSF.Domain.Entidade;
using HortifrutiSF.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortifruitiSF.Application.Application
{
    public class ProdutoEntradaApplication : IProdutoEntradaApplication
    {
        private readonly IProdutoEntradaRepository _produtoEntradaRepository;

        public ProdutoEntradaApplication(IProdutoEntradaRepository produtoEntradaRepository)
        {
            _produtoEntradaRepository = produtoEntradaRepository;
        }

        public async Task AdicionarProdutoEntrada(ProdutoEntradaViewModel produtoEntradaVM)
        {
            var produtoEntrada = new ProdutoEntrada(produtoEntradaVM.Preco,
                                                    produtoEntradaVM.Quantidade,
                                                    produtoEntradaVM.Peso,
                                                    produtoEntradaVM.ProdutoId,
                                                    produtoEntradaVM.Fornecedor);

            await _produtoEntradaRepository.AdicionarProdutoEntradas(produtoEntrada);
        }
    }
}
