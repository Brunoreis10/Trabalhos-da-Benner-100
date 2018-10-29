using CaelumEstoque.DAO;
using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    public class CategoriaController : Controller
    {
        [Route("categorias", Name = "ListaCategorias")]
        public ActionResult Index()
        {
            var categoriaDAO = new CategoriasDAO();
            var categorias = categoriaDAO.Lista();
            ViewBag.Categorias = categorias;
            return View();
        }

        [Route("categorias/cadastro", Name = "CadastraCategoria")]
        public ActionResult Form()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Adiciona(CategoriaDoProduto categoria)
        {
            var categoriasDAO = new CategoriasDAO();
            categoriasDAO.Adiciona(categoria);
            return RedirectToAction("Index");
        }
    }
}