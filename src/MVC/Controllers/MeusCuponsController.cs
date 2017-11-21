using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Berrini.Application.AppInterfaces;
using Berrini.Application.ViewModels;
namespace MVC.Controllers
{
    [Authorize(Roles = "Cliente")]
    public class MeusCuponsController : Controller
    {
        private readonly ICupomAppService _cupomAppService;
        private readonly IPremioAppService _premioAppService;
        public MeusCuponsController(ICupomAppService cupomAppService, 
            IPremioAppService premioAppService)
        {
            _cupomAppService=cupomAppService;
            _premioAppService=premioAppService;
        }

        // GET: MeusCupons
        public ActionResult Index()
        {

            var modelo=_cupomAppService.ObterPorCliente(this.IdUsuarioAtual());
            return View(modelo);
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Novo(CadastroCupomViewModel modelo)
        {
            var clienteId=this.IdUsuarioAtual();
            if (!ModelState.IsValid)
                return View(modelo);

            if(!_cupomAppService.ExisteCupom(modelo.NumeroCupom))
            {
                ModelState.AddModelError("", "Esse cupom não existe, verifique o número e tente novamente.");
                return View(modelo);
            }
            if(_cupomAppService.JaCadastrado(modelo))
            {
                ModelState.AddModelError("", "Esse cupom já foi utilizado");
                return View(modelo);
            }

            if(!_cupomAppService.PodeCadastrar(clienteId))
            {
                ModelState.AddModelError("", "Você já atingiu o número máximo de cupons");
                return View(modelo);
            }

            var resultado=_cupomAppService.Cadastrar(modelo, clienteId);
            return RedirectToAction("Redirecionar","MeusCupons",new{id=resultado.Id});
        }

        public ActionResult Redirecionar(Guid id)
        {
            var cupom=_cupomAppService.ObterPorId(id);
            if(cupom.PremioId.HasValue)
                return RedirectToAction("Premiado", "MeusCupons", new {id=cupom.PremioId});

            return RedirectToAction("Index");
        }

        public ActionResult Premiado(Guid id)
        {
            var modelo=_premioAppService.ObterPorId(id);
            return View(modelo);
        }
    }
}