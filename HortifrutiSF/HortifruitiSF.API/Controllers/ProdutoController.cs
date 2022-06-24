using HortifrutiSF.Domain.Entidade;
using HortifrutiSF.Repo;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HortifruitiSF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        

        [HttpPost]
        public ActionResult Adicionar()
        {
            string nome = "paçoca";
            string descricao = "Rafael";

            var produto = new Produto(nome, descricao);



            return Ok();
        }


    }
}
