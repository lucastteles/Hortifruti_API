using HortifruitiSF.Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HortifruitiSF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LucroController : ControllerBase
    {
        private readonly ILucroApplication _lucroApplication;

        public LucroController(ILucroApplication lucroApplication)
        {
            _lucroApplication = lucroApplication;
        }

        [HttpGet("idProduto")]
        public async Task<IActionResult> Obter(Guid idProduto, DateTime? data)
        {
            var produto = await _lucroApplication.ObterTodaVendaPorProduto(idProduto, data);

            return Ok(produto);
        }


    }
}

