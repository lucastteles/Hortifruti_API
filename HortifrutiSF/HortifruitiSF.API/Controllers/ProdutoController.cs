using HortifruitiSF.Application.Interface;
using HortifruitiSF.Application.ViewModel;
using HortifrutiSF.Domain.Entidade;
using HortifrutiSF.Repo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HortifruitiSF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoApplication _produtoApplication;

        public ProdutoController(IProdutoApplication produtoApplication)
        {
            _produtoApplication = produtoApplication;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(ProdutoViewModel produtoVm)
        {
            try
            {
                await _produtoApplication.AdicionarProduto(produtoVm);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }       
        }


    }
}
