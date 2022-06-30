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

        public async Task AtualizarProdutoEntrada(ProdutoEntradaViewModel produtoEntradaVm)
        {
            // Obter o produtoId fazer a consulta no repositorio
            var produtoEntradas = await _produtoEntradaRepository.ObterProdutoEntradasPorId(produtoEntradaVm.Id);

            //Atribuir e atualizar na entidade
            produtoEntradas.AtualizarDadosDoProdutoEntrada(produtoEntradaVm.Preco,
                                                           produtoEntradaVm.Quantidade,
                                                           produtoEntradaVm.Peso,
                                                           produtoEntradaVm.ProdutoId,
                                                           produtoEntradaVm.Fornecedor);



            await _produtoEntradaRepository.AtualizarProdutoEntradas(produtoEntradas);
        }

        public async Task DeletarProdutoEntrada(Guid idProdutoEntrada)
        {
            await _produtoEntradaRepository.DeletarProdutoEntrada(idProdutoEntrada);
        }

        public async Task<List<ProdutoEntradaDto>> ObterProdutoEntradasApplication()
        {
            var produtoEntradas = await _produtoEntradaRepository.ObterTodosOsProdutoEntradas();

            var listaProdutoEntradas = new List<ProdutoEntradaDto>();

            foreach (var produtoEntrada in produtoEntradas)
            {
                var produtoEntradaDto = new ProdutoEntradaDto()
                {
                    Preco = produtoEntrada.Preco,
                    Quantidade = produtoEntrada.Quantidade,
                    Peso = produtoEntrada.Peso,
                    ProdutoId = produtoEntrada.ProdutoId,
                    Data = produtoEntrada.DataCadastro.ToString("dd/MM/yyyy HH:mm"),
                    Fornecedor = produtoEntrada.Fornecedor,
                    NomeProduto = produtoEntrada.Produto.Nome,
                    IdProdutoEntrada = produtoEntrada.Id
                };

                listaProdutoEntradas.Add(produtoEntradaDto);
            }
            return listaProdutoEntradas;
        }

        public async Task<ProdutoEntradaDto> ObterProdutoEntradasPorId(Guid idProdutoEntrada)
        {
            var produtoEntrada = await _produtoEntradaRepository.ObterProdutoEntradasPorId(idProdutoEntrada);

            var produtoEntradaDto = new ProdutoEntradaDto()
            {
                Preco = produtoEntrada.Preco,
                Quantidade = produtoEntrada.Quantidade,
                Peso = produtoEntrada.Peso,
                ProdutoId = produtoEntrada.ProdutoId,
                Data = produtoEntrada.DataCadastro.ToString("dd/MM/yyyy HH:mm"),
                Fornecedor = produtoEntrada.Fornecedor,
                NomeProduto = produtoEntrada.Produto.Nome,
                IdProdutoEntrada = produtoEntrada.Id
            };

            return produtoEntradaDto;
        }

        public async Task<List<ProdutoEntradaDto>> ObterProdutoEntradaPorData(DateTime? dataInicial, DateTime? dataFinal)
        {
            var produtosEntrada = await _produtoEntradaRepository.ObterProdutoEntradaPorData(dataInicial, dataFinal);

            var listaProdutoEntradas = new List<ProdutoEntradaDto>();

            foreach (var produtoEntrada in produtosEntrada)
            {
                var produtoEntradaDto = new ProdutoEntradaDto()
                {
                    Preco = produtoEntrada.Preco,
                    Quantidade = produtoEntrada.Quantidade,
                    Peso = produtoEntrada.Peso,
                    ProdutoId = produtoEntrada.ProdutoId,
                    Data = produtoEntrada.DataCadastro.ToString("dd/MM/yyyy HH:mm"),
                    Fornecedor = produtoEntrada.Fornecedor,
                    NomeProduto = produtoEntrada.Produto.Nome,
                    IdProdutoEntrada = produtoEntrada.Id
                };

                listaProdutoEntradas.Add(produtoEntradaDto);
            }
            return listaProdutoEntradas;
        }

        public decimal ObterSaldoPorData(DateTime? dataInicial, DateTime? dataFinal)
        {
            return  _produtoEntradaRepository.ObterSaldoPorData(dataInicial, dataFinal);
            
        }
    }
}