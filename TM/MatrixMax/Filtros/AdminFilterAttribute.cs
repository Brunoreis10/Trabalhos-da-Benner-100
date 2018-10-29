using MatrixMax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MatrixMax.Filtros
{
    public class AdminFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool login = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == "Login";
            var usuario = (Usuario)filterContext.HttpContext.Session["usuarioLogado"];
            if (usuario.TipoUsuario != 'A') filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary(
                    new { controller = "Home", action = "Index" }
                )
            );

        }
    }
}