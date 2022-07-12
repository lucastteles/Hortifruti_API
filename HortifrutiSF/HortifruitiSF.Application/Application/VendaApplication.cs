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
        private readonly IEstoqueRepository _estoqueRepository;


        public VendaApplication(IVendaRepository vendaRepository, IProdutoRepository produtoRepository, IEstoqueRepository estoqueRepository)
        {
            _vendaRepository = vendaRepository;
            _produtoRepository = produtoRepository;
            _estoqueRepository = estoqueRepository;
        }


        public async Task AdicionarVenda(VendaViewModel vendaVM)
        {

            var produto = await _produtoRepository.ObterProdutoPorId(vendaVM.ProdutoId);


            var venda = new Venda(produto.PrecoVenda,
                                  vendaVM.QuantidadeVenda,
                                  vendaVM.ProdutoId);

            await _vendaRepository.AdicionarVenda(venda);


            //consultar se o produto já existe no estoque 
            var estoque = await _estoqueRepository.ObterProdutoNoEstoque(vendaVM.ProdutoId);
             // se o produto já existe no estoque chama o atualizar (a quantidade)
            {
                estoque.ReduzirQunatidadeDeProdutoNoEstoque(vendaVM.QuantidadeVenda);

                await _estoqueRepository.AtualizarEstoque(estoque);
            }

        }


        public async Task<List<VendaDto>> ObterVendaPorData(DateTime? dataInicial, DateTime? dataFinal)
        {
            var vendas = await _vendaRepository.ObterVendaPorData(dataInicial, dataFinal);

            var listaVendas = new List<VendaDto>();

            foreach (var venda in vendas)
            {
                var vendaDto = new VendaDto()
                {
                    VendaId = venda.Id,
                    QuantidadeVenda = venda.QuantidadeVenda,
                    Data = venda.DataCadastro.ToString("dd/MM/yyyy HH:mm"),
                    ValorTotal = venda.ValorTotal,
                    NomeProduto = venda.Produto.Nome,
                    ProdutoId = venda.ProdutoId,
                    

                };

                listaVendas.Add(vendaDto);
            }
            return listaVendas;
        }


        public async Task DeletarVenda(Guid idVenda)
        {
            await _vendaRepository.Deletar(idVenda);
        }
    }
}
