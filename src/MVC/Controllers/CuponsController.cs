using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Berrini.Application.AppInterfaces;
using Berrini.Application.ViewModels;
using MVC.Models;

namespace MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CuponsController : Controller
    {
       
        private readonly ICupomAppService _cupomAppService;
        private readonly IPremioAppService _premioAppService;
        

        public CuponsController(ICupomAppService cupomAppService, 
            IPremioAppService premioAppService)
        {
            _cupomAppService=cupomAppService;
            _premioAppService=premioAppService;
        }

        // GET: Cupons
        public ActionResult Index()
        {
            return View(_cupomAppService.ObterTodos());
        }

        private IEnumerable<SelectListItem> ObterPremiosDisponiveis()
        {
            var premios=_premioAppService.ObterTodos();
            var listaItems=new List<SelectListItem>();
            foreach(var p in premios)
            {
                listaItems.Add(new SelectListItem { Value=p.Id.ToString(),Text=p.Nome});
            }
            //SelectList lista=new SelectList();
            return listaItems;

        }
        // GET: Cupons/Details/5
        public ActionResult Detalhes(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CupomViewModel cupomViewModel=_cupomAppService.ObterPorId(id.Value);
            if (cupomViewModel == null)
            {
                return HttpNotFound();
            }
            return View(cupomViewModel);
        }

        // GET: Cupons/Create
        public ActionResult Criar()
        {
            var cupom=new CupomViewModel();
            cupom.PremiosDisponiveis=ObterPremiosDisponiveis();
            return View(cupom);
        }

        // POST: Cupons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(CupomViewModel cupomViewModel)
        {
            cupomViewModel.PremiosDisponiveis = ObterPremiosDisponiveis();
            if (ModelState.IsValid)
            {
                //cupomViewModel.Id = Guid.NewGuid();
                //db.CupomViewModels.Add(cupomViewModel);
                //db.SaveChanges();
                _cupomAppService.Adicionar(cupomViewModel);
                return RedirectToAction("Index");
            }

            
            return View(cupomViewModel);
        }

        // GET: Cupons/Edit/5
        public ActionResult Editar(Guid? id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CupomViewModel modelo =_cupomAppService.ObterPorId(id.Value);
            ViewBag.Alerta=_cupomAppService.JaCadastrado(modelo)
                ? "O cupom já foi cadastrado por um cliente, não pode realizar alterações"
                : "";
            modelo.PremiosDisponiveis = ObterPremiosDisponiveis();
            if (modelo == null)
            {
                return HttpNotFound();
            }
            return View(modelo);
        }

        // POST: Cupons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(CupomViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                var resultado=_cupomAppService.Atualizar(modelo);

                return RedirectToAction("Index");
            }
            modelo.PremiosDisponiveis = ObterPremiosDisponiveis();
            return View(modelo);
        }

        // GET: Cupons/Delete/5
        public ActionResult Remover(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CupomViewModel cupomViewModel =_cupomAppService.ObterPorId(id.Value);
            ViewBag.Alerta = _cupomAppService.JaCadastrado(cupomViewModel)
                ? "O cupom já foi cadastrado por um cliente, não pode ser removido, isso seria trapacear!!!."
                : "";
            if (cupomViewModel == null)
            {
                return HttpNotFound();
            }
            return View(cupomViewModel);
        }

        // POST: Cupons/Delete/5
        [HttpPost, ActionName("Remover")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _cupomAppService.Remover(id);
            return RedirectToAction("Index");
        }

        public ActionResult CadastradosPelosClientes()
        {
            var modelo=_cupomAppService.CuponsCadastrados();
            return View(modelo);
        }
    }
}
