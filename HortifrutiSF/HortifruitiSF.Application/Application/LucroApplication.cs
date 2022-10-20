using HortifruitiSF.Application.Dto;
using HortifruitiSF.Application.Interface;
using HortifrutiSF.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortifruitiSF.Application.Application
{
    public class LucroApplication : ILucroApplication
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IProdutoRepository _produtoRepository;

        public LucroApplication(IVendaRepository vendaRepository, IProdutoRepository produtoRepository)
        {
            _vendaRepository = vendaRepository;
            _produtoRepository = produtoRepository;

        }



        public async Task<LucroDto> ObterTodaVendaPorProduto(Guid idProduto, DateTime? data)
        {
            var listaDeVendas = await _vendaRepository.ObterTodaVendaPorProduto(idProduto, data);
            if (listaDeVendas.Count == 0)
            {
                return null;
            }

            var nomeProduto = listaDeVendas.FirstOrDefault().Produto.Nome;


            var quantidadeVenda = listaDeVendas.Sum(c => c.QuantidadeVenda);
            var valorTotal = listaDeVendas.Sum(c => c.ValorTotal);

            var custo = listaDeVendas.Sum(c => c.PrecoCusto);

            var lucro = valorTotal - custo;

            var lucroTotal = new LucroDto()
            {
                QuantidadeVenda = quantidadeVenda,
                ValorTotal = valorTotal,
                NomeProduto = nomeProduto,
                PrecoCusto = custo,
                Lucro = lucro
            };

            return lucroTotal;

        }


    }
    
}
