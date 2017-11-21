// richoRichof fPremiosController.cs1810:41

using System;
using System.Web.Mvc;
using Berrini.Application.AppInterfaces;
using Berrini.Application.ViewModels;
namespace MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PremiosController : Controller
    {
        private readonly IPremioAppService _premioAppService;

        public PremiosController(IPremioAppService premioAppService)
        {
            _premioAppService=premioAppService;
        }

        // GET
        public ActionResult Index()
        {
            var modelo=_premioAppService.ObterTodos();
            return View(modelo);
        }

        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Criar(PremioViewModel modelo)
        {
            if(!ModelState.IsValid)
                return View(modelo);

            var result=_premioAppService.Adicionar(modelo);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(Guid? id)
        {
            if(!id.HasValue)
                return HttpNotFound();

            var modelo=_premioAppService.ObterPorId(id.Value);
            return View(modelo);
        }

        [HttpPost]
        public ActionResult Editar(PremioViewModel modelo)
        {
            if(!ModelState.IsValid)
                return View(modelo);

            var resultado=_premioAppService.Atualizar(modelo);
            return RedirectToAction("Index");
        }

    }

}