using HortifruitiSF.Application.Interface;
using HortifruitiSF.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HortifruitiSF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoEntradaController : ControllerBase
    {
        private readonly IProdutoEntradaApplication _produtoEntradaApplication;

        public ProdutoEntradaController(IProdutoEntradaApplication produtoEntradaApplication)
        {
            _produtoEntradaApplication = produtoEntradaApplication;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(ProdutoEntradaViewModel produtoEntradaVM)
        {
            try
            {
                await _produtoEntradaApplication.AdicionarProdutoEntrada(produtoEntradaVM);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ObterTodosProdutoEntradas")]
        public async Task<IActionResult> Obter()
        {
            var produtoEntradas = await _produtoEntradaApplication.ObterProdutoEntradasApplication();

            return Ok(produtoEntradas);
        }

        [HttpGet("idProdutoEntrada")]
        public async Task<IActionResult> ObterPorId(Guid idProdutoEntrada)
        {
            var produtoEntrada = await _produtoEntradaApplication.ObterProdutoEntradasPorId(idProdutoEntrada);

            return Ok(produtoEntrada);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(ProdutoEntradaViewModel produtoEntradaVm)
        {
            await _produtoEntradaApplication.AtualizarProdutoEntrada(produtoEntradaVm);

            return Ok();
        }

        [HttpDelete("idProdutoEntrada")]
        public async Task<IActionResult> Delete(Guid idProdutoEntrada)
        {
            await _produtoEntradaApplication.DeletarProdutoEntrada(idProdutoEntrada);

            return Ok();
        }

        [HttpGet("ObterPorData/{dataInicial}/{dataFinal}")]
        public async Task<IActionResult> ObterEntradasPorData(DateTime dataInicial, DateTime dataFinal)
        {
           var resultado = await _produtoEntradaApplication.ObterProdutoEntradaPorData(dataInicial, dataFinal);

            return Ok(resultado);
        }

        [HttpGet("ObterSaldoPorData/{dataInicial}/{dataFinal}")]
        public IActionResult ObterSaldoPorData(DateTime dataInicial, DateTime dataFinal)
        {
            var saldo =  _produtoEntradaApplication.ObterSaldoPorData(dataInicial, dataFinal);

            return Ok(saldo);
        }

    }
}
