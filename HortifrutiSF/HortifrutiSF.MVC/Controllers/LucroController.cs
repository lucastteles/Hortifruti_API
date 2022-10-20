using HortifruitiSF.Application.Dto;
using HortifruitiSF.Application.Interface;
using HortifruitiSF.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HortifrutiSF.MVC.Controllers
{
    public class LucroController : Controller
    {
        private readonly ILucroApplication _lucroApplication;
        private readonly IProdutoApplication _produtoApplication;
        public LucroController(ILucroApplication lucroApplication, IProdutoApplication produtoApplication)
        {
            _lucroApplication = lucroApplication;
            _produtoApplication = produtoApplication;



        }
       // GET: LucroController
        public async Task<IActionResult> Index(LucroDto lucro, DateTime? data)
        {
            var produto = await _produtoApplication.ObterProdutosApplication();

            ViewBag.produto = produto.Select(c => new SelectListItem()
            { Text = c.Nome, Value = c.ProdutoId.ToString() })
             .ToList();

            if (lucro.ProdutoId != Guid.Empty)
            {
                var lucrototal = await _lucroApplication.ObterTodaVendaPorProduto(lucro.ProdutoId, lucro.Data);

                ViewBag.mensagem = lucrototal != null ? null : "Não há registro de lucro para o produto selecionado";

                return View(lucrototal);
            }
            if (data == null)
                return View(new LucroDto());
            ViewData["data"] = data.Value.ToString("yyyy-MM-dd");

            return View();
        }
        

    }
}
