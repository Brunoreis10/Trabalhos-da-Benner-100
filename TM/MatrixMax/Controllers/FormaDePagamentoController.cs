using MatrixMax.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatrixMax.Controllers
{
    public class FormaDePagamentoController : Controller
    {
        public JsonResult getBandeiras()
        {
            return Json(new { data = new FormaDePagamentoDAO().ListaBandeiras() });
        }
    }
}