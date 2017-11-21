using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Berrini.Application.AppInterfaces;

namespace MVC.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ClientesController : Controller
    {

        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService=clienteAppService;
        }

        // GET: Clientes
        public ActionResult Index()
        {
            var modelo=_clienteAppService.ObterTodos();
            return View(modelo);
        }

        public ActionResult Premiados()
        {
            var modelo = _clienteAppService.Premiados();
            return View(modelo);
        }
    }
}