using HortifruitiSF.Application.Dto;
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
    public class VendaApplication : IVendaApplication
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IProdutoRepository _produtoRepository;


        public VendaApplication(IVendaRepository vendaRepository, IProdutoRepository produtoRepository)
        {
            _vendaRepository = vendaRepository;
            _produtoRepository = produtoRepository;
        }


        public async Task AdicionarVenda(VendaViewModel vendaVM)
        {

            var produto = await _produtoRepository.ObterProdutoPorId(vendaVM.ProdutoId);


            var venda = new Venda(produto.PrecoVenda,
                                  vendaVM.QuantidadeVenda,
                                  vendaVM.ProdutoId);

            await _vendaRepository.AdicionarVenda(venda);
        }
    }
}
