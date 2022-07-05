using HortifruitiSF.Application.Interface;
using HortifruitiSF.Application.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HortifruitiSF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : Controller
    {
        private readonly IVendaApplication _vendaApplication;

        public VendaController(IVendaApplication vendaApplication)
        {
            _vendaApplication = vendaApplication;
        }

        [HttpPost]
        public async Task <IActionResult> Adicionar(VendaViewModel vendaVM)
        {
            try
            {
                await _vendaApplication.AdicionarVenda(vendaVM);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("ObterPorData/{dataInicial}/{dataFinal}")]
        public async Task<IActionResult> ObterPorData(DateTime dataInicial, DateTime dataFinal)
        {
            var resultado = await _vendaApplication.ObterVendaPorData(dataInicial, dataFinal);

            return Ok(resultado);
        }

        [HttpDelete("idVenda")]
        public async Task<IActionResult> Delete(Guid idVenda)
        {
            await _vendaApplication.DeletarVenda(idVenda);

            return Ok();
        }
    }
}
