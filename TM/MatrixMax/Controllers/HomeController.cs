using MatrixMax.DAO;
using MatrixMax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatrixMax.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var usuario = (Usuario)Session["usuarioLogado"];
            ViewBag.Title = "Dashboard";

            var vendaDAO = new VendaDAO();

            ViewBag.TotalBrutoDia = vendaDAO.TotalBrutoHoje();
            ViewBag.ProdutosVendidosDia = vendaDAO.TotalProdutosVendidosHoje();
            ViewBag.ContaVendasDia = vendaDAO.TotalVendasHoje();
            ViewBag.WidgetEstoque = new ProdutoDAO().WidgetsEstoqueDashboard();
            ViewBag.WidgetPorcentagem = vendaDAO.VendasHojeFormasDePagamentoPorcentagem();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt-BR");
            return View();
        }
    }
}