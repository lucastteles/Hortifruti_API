using HortifruitiSF.Application.Interface;
using HortifruitiSF.Application.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HortifrutiSF.MVC.Controllers
{
    public class EstoqueController : Controller
    {
        private readonly IEstoqueApplication _estoqueApplication;
        private readonly IProdutoEntradaApplication _produtoEntradaApplication;

        public EstoqueController(IEstoqueApplication estoqueApplication, IProdutoEntradaApplication produtoEntradaApplication)
        {
            _estoqueApplication = estoqueApplication;
            _produtoEntradaApplication = produtoEntradaApplication;
        }



        // GET: EstoqueController
        public async Task <IActionResult> Index()
        {

            var estoque = await _estoqueApplication.ObterEstoqueApplication();

            return View(estoque);
        }

        // GET: EstoqueController/Details/5
        public async Task <IActionResult> Details(Guid id)
        {
            var estoque = await _estoqueApplication.ObterEstoquePorId(id);

            return View(estoque);
        }

       

       
        
    }
}
