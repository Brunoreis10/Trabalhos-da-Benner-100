using CaelumEstoque.DAO;
using CaelumEstoque.Filtros;
using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    [AutorizacaoFilter]
    public class ProdutoController : Controller
    {
        [Route("produtos", Name = "ListaProdutos")]
        public ActionResult Index()
        {
            var produtoDAO = new ProdutosDAO();
            //IList<Produto> produtos = produtoDAO.Lista(); <- Desnecessário!
            var produtos = produtoDAO.Lista();
            return View(produtos);
        }

        [Route("produtos/cadastro", Name = "CadastraProduto")]
        public ActionResult Form()
        {
            ViewBag.Produto = new Produto();
            var categoriasDAO = new CategoriasDAO();
            ViewBag.Categorias = categoriasDAO.Lista();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adiciona(Produto produto)
        {
            var id_Informatica = 1;
            if (produto.CategoriaId.Equals(id_Informatica) && produto.Preco < 100)
                ModelState.AddModelError("produto.InformaticaPrecoInvalido", "Produtos de informática tem preço mínimo de R$100,00.");

            if (ModelState.IsValid)
            {
                var produtosDAO = new ProdutosDAO();
                produtosDAO.Adiciona(produto);
                return RedirectToAction("Index", "Produto");
            } else
            {
                var categoriasDAO = new CategoriasDAO();
                ViewBag.Categorias = categoriasDAO.Lista();
                ViewBag.Produto = produto;
                return View("Form");
            }
        }

        [Route("produtos/{id}", Name = "VisualizaProdutos")]
        public ActionResult Visualiza(int id)
        {
            var produtosDAO = new ProdutosDAO();
            var produto = produtosDAO.BuscaPorId(id);
            return View(produto);
        }

        public ActionResult DecrementaQtd(int id)
        {
            var produtosDAO = new ProdutosDAO();
            Produto produto = produtosDAO.BuscaPorId(id);
            produto.Quantidade--;
            produtosDAO.Atualiza(produto);
            return Json(produto);
        }
    }
}