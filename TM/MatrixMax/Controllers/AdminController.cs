using MatrixMax.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatrixMax.Controllers
{
    [AdminFilter]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Usuários";
            return View();
        }
    }
}