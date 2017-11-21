// richoRichof fExtensions.cs1715:58

using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
namespace MVC.Controllers
{

    public static class Extensions
    {

        public static Guid IdUsuarioAtual(this Controller controller)
        {
            var id=new Guid(controller.HttpContext.User.Identity.GetUserId());
            return id;

        }

    }

}