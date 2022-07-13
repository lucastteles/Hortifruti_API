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
    public class ProdutoEntradaController : Controller
    {
        private readonly IProdutoEntradaApplication _produtoEntradaApplication;
        private readonly IProdutoApplication _produtoApplication;

        public ProdutoEntradaController(IProdutoEntradaApplication produtoEntradaApplication, IProdutoApplication produtoApplication)
        {
            _produtoEntradaApplication = produtoEntradaApplication;
            _produtoApplication = produtoApplication;
        }

        // GET: ProdutoEntradaController
        public async Task <IActionResult> Index()
        {
            var produtoEntrada = await _produtoEntradaApplication.ObterProdutoEntradasApplication();

            return View(produtoEntrada);
        }

        // GET: ProdutoEntradaController/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var produtoEntrada = await _produtoEntradaApplication.ObterProdutoEntradasPorId(id);

            return View(produtoEntrada);
        }

        // GET: ProdutoEntradaController/Create
        public async Task<IActionResult> Create()
        {
            var produtos = await _produtoApplication.ObterProdutosApplication();

            ViewBag.produtos = produtos.Select(c => new SelectListItem()
            { Text = c.Nome, Value = c.ProdutoId.ToString() })
                .ToList();

            return View();
        }

        // POST: ProdutoEntradaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(ProdutoEntradaViewModel produtoEntradaVM)
        {
            await _produtoEntradaApplication.AdicionarProdutoEntrada(produtoEntradaVM);

            return View(produtoEntradaVM);
        }

        // GET: ProdutoEntradaController/Edit/5
        public async Task <IActionResult> Edit(Guid id)
        {
            var produtos = await _produtoApplication.ObterProdutosApplication();

            ViewBag.produtos = produtos.Select(c => new SelectListItem()
            { Text = c.Nome, Value = c.ProdutoId.ToString() })
                .ToList();

            var produtoEntrada = await _produtoEntradaApplication.ObterProdutoEntradasPorId(id);

            return View(produtoEntrada);
        }

        // POST: ProdutoEntradaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit(ProdutoEntradaViewModel produtoEntradaVM)
        {
            await _produtoEntradaApplication.AtualizarProdutoEntrada(produtoEntradaVM);

            return RedirectToAction(nameof(Index));
        }

        // GET: ProdutoEntradaController/Delete/5
        public async Task <IActionResult> Delete(Guid id)
        {
            var produtoEntrada = await _produtoEntradaApplication.ObterProdutoEntradasPorId(id);

            return View(produtoEntrada);
        }

        // POST: ProdutoEntradaController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> DeleteConfirmed(Guid id)
        {
            await _produtoEntradaApplication.DeletarProdutoEntrada(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
