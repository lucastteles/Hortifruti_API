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
    public class ProdutoController : Controller
    {
        private readonly IProdutoApplication _produtoApplication;

        public ProdutoController(IProdutoApplication produtoApplication)
        {
            _produtoApplication = produtoApplication;
        }

        // GET: ProdutoCadastroController
        public async Task<IActionResult> Index()
        {
            var produto = await _produtoApplication.ObterProdutosApplication();

            return View(produto);
        }

        // GET: ProdutoCadastroController/Details/5
        public async Task <IActionResult> Details(Guid id)
        {
            var produto = await _produtoApplication.ObterProdutoPorId(id);

            return View(produto);
        }

        // GET: ProdutoCadastroController/Create
        public async Task <IActionResult> Create()
        {
             

            return View();
        }

        // POST: ProdutoCadastroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(ProdutoViewModel produtoViewModel)
        {
            await _produtoApplication.AdicionarProduto(produtoViewModel);

            return View(produtoViewModel);
        }

        // GET: ProdutoCadastroController/Edit/5
        public async Task <IActionResult> Edit(Guid id)
        {
            var produto = await _produtoApplication.ObterProdutoPorId(id);

            return View(produto);
            
        }

        // POST: ProdutoCadastroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProdutoViewModel produtoVM)
        {
            await _produtoApplication.AtualizarProduto(produtoVM);

            return RedirectToAction(nameof(Index));
        }

        // GET: ProdutoCadastroController/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var produto = await _produtoApplication.ObterProdutoPorId(id);

            return View(produto);
        }

        // POST: ProdutoCadastroController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
           await _produtoApplication.DeletarProduto(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
