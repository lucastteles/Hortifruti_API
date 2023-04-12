using HortifruitiSF.Application.Interface;
using HortifruitiSF.Application.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HortifrutiSF.MVC.Controllers
{
    public class VendaController : Controller
    {
        private readonly IVendaApplication _vendaApplication;
        private readonly IEstoqueApplication _estoqueApplication;

        public VendaController(IVendaApplication vendaApplication, IEstoqueApplication estoqueApplication)
        {
            _vendaApplication = vendaApplication;
            _estoqueApplication = estoqueApplication;
        }



        // GET: VendaController
        public async Task<IActionResult> Index(DateTime? dataInicial, DateTime? dataFinal)
        {

            if (dataInicial == null || dataFinal == null)
                return View(new List<HortifruitiSF.Application.Dto.VendaDto>());

            ViewData["dataInicial"] = dataInicial.Value.ToString("yyyy-MM-dd");
            ViewData["dataFinal"] = dataFinal.Value.ToString("yyyy-MM-dd");

            var venda = await _vendaApplication.ObterVendaPorData(dataInicial, dataFinal);

            return View(venda);
        }

        // GET: VendaController/Details/5
        public async Task <IActionResult> Details()
        {
           // var venda = await _vendaApplication.
            return View();
        }

        // GET: VendaController/Create
        public async Task <IActionResult> Create()
        {
            var produtos = await _estoqueApplication.ObterTodosProdutosNoEstoque();

            ViewBag.produtos = produtos.Select(c => new SelectListItem()
            { Text = c.Nome, Value = c.ProdutoId.ToString() })
                .ToList();

            return View();
        }

        // POST: VendaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(VendaViewModel VendaVM)
        {
            //    await _vendaApplication.AdicionarVenda(VendaVM);
            //    ViewBag.Mensagem = "Venda Realizada  com sucesso";
            //    ViewBag.Mensagem2 = "Alerta";

            //    ModelState.Clear();

            //    return View(VendaVM);
            try
            {
                await _vendaApplication.AdicionarVenda(VendaVM);
                ViewBag.Mensagem = "Venda Realizada com sucesso!";
                ViewBag.Mensagem2 = "Alerta";
                ModelState.Clear();
            }
            catch (Exception ex)
            {
                ViewBag.Mensagem = "Produto Indisponível.";
                ViewBag.Mensagem2 = "Erro";
            }

            return View(VendaVM);

        }

        // GET: VendaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VendaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
           
                return View();
            
        }

        // GET: VendaController/Delete/5
        public async Task <IActionResult> Delete()
        {
           

            return View();
           
        }

        // POST: VendaController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> DeleteConfirmed(Guid id)
        {
            await _vendaApplication.DeletarVenda(id);
            return RedirectToAction(nameof(Index));

            
            
        }
    }
}
