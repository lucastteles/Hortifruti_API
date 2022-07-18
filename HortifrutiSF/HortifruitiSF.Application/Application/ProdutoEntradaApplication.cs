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
        private readonly IEstoqueRepository _estoqueRepository;

        public ProdutoEntradaApplication(IProdutoEntradaRepository produtoEntradaRepository, IEstoqueRepository estoqueRepository)
        {
            _produtoEntradaRepository = produtoEntradaRepository;
            _estoqueRepository = estoqueRepository;
        }

        public async Task AdicionarProdutoEntrada(ProdutoEntradaViewModel produtoEntradaVM)
        {
            var produtoEntrada = new ProdutoEntrada(produtoEntradaVM.Preco,
                                                    produtoEntradaVM.Quantidade,
                                                    produtoEntradaVM.Peso,
                                                    produtoEntradaVM.ProdutoId,
                                                    produtoEntradaVM.Fornecedor);

            await _produtoEntradaRepository.AdicionarProdutoEntradas(produtoEntrada);




            //consultar se o produto já existe no estoque 
            var estoque = await _estoqueRepository.ObterProdutoNoEstoque(produtoEntradaVM.ProdutoId);

            if (estoque == null) //se ele não existir... Chama o adicionar estoque
            {
                var estoqueEntity = new Estoque(produtoEntradaVM.Quantidade,
                                     produtoEntradaVM.ProdutoId);

                await _estoqueRepository.AdicionarEstoque(estoqueEntity);
            }
            else     // se o produto já existe no estoque chama o atualizar (a quantidade)
            {
                estoque.AdicionarQuantiadeDeProdutoNoEstoque(produtoEntradaVM.Quantidade);

                await _estoqueRepository.AtualizarEstoque(estoque);
            }



            // await _estoqueRepository.AdicionarEstoque(estoque);

            //Adciionar no estoque  lógica
        }

        public async Task AtualizarProdutoEntrada(ProdutoEntradaViewModel produtoEntradaVm)
        {
            // Obter o produtoId fazer a consulta no repositorio
            var produtoEntradas = await _produtoEntradaRepository.ObterProdutoEntradasPorId(produtoEntradaVm.Id);


            var estoque = await _estoqueRepository.ObterProdutoNoEstoque(produtoEntradaVm.ProdutoId);

            estoque.AtualizarQuantidadeDeProdutoNoEstoque(produtoEntradas.Quantidade, produtoEntradaVm.Quantidade);

            //Atribuir e atualizar na entidade
            produtoEntradas.AtualizarDadosDoProdutoEntrada(produtoEntradaVm.Preco,
                                                           produtoEntradaVm.Quantidade,
                                                           produtoEntradaVm.Peso,
                                                           produtoEntradaVm.ProdutoId,
                                                           produtoEntradaVm.Fornecedor);



            await _estoqueRepository.AtualizarEstoque(estoque);

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
            return _produtoEntradaRepository.ObterSaldoPorData(dataInicial, dataFinal);
        }


        /*
         Entidade estoque campos Quantidade, ProdutoId, Id, datacadastro, dataalteracao

        Regra: Toda vez que for adicionado um novo produto entrada (Isso ja esta implementado)
        1 - Consultar no repositoryEstoque o estoque com o IdProduto (açucar)

          Se o IdProduto ja existe na tabela Estoque
             Vai retornar Estoque com o IdProduto e vou atualizar a quantidade.

          Se o IdProduto não existe na tabela estoque
             Preciso fazer um insert da entidade Estoque


         */


    }
}