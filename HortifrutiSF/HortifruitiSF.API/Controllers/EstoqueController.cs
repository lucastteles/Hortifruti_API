using HortifruitiSF.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HortifruitiSF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Estoque : ControllerBase
    {

        private readonly IEstoqueApplication _estoqueApplication;

        public Estoque(IEstoqueApplication estoqueApplication)
        {
            _estoqueApplication = estoqueApplication;
        } 

        [HttpGet]
        public async Task<IActionResult> ObterTodoEstoque()
        {
            var estoque = await _estoqueApplication.ObterEstoqueApplication();

            return Ok(estoque);

        }

        [HttpGet("idProduto")]
        public async Task<IActionResult> ObterPorId(Guid idEstoque)
        {
            var estoque = await _estoqueApplication.ObterEstoquePorId(idEstoque);

            return Ok(estoque);
        }

    }
}
