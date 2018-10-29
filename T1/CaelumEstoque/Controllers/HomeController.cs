using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    public class HomeController : Controller
    {
        //[Route("home", Name = "Home")]
        public ActionResult Index()
        {
            return View();
        }
	}
}