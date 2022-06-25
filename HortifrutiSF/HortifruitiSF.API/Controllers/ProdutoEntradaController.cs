using HortifruitiSF.Application.Interface;
using HortifruitiSF.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
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
        public async Task <IActionResult> Adicionar(ProdutoEntradaViewModel produtoVM)
        {
       
        }

    }
}
