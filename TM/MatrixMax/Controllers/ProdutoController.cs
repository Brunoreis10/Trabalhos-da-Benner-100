using MatrixMax.DAO;
using MatrixMax.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MatrixMax.Controllers
{
    public class ProdutoController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Produtos";
            return View();
        }

        public ActionResult Estoque()
        {
            ViewBag.Title = "Estoque";
            return View();
        }

        public JsonResult getProduto(int id)
        {
            return Json(new ProdutoDAO().BuscaPorId(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult getListaEstoque()
        {
            var listaEstoque = new List<object>();

            foreach (var produto in new ProdutoDAO().Lista())
            {
                string estadoEstoque = produto.ProcessaEstoque();

                listaEstoque.Add(
                    new
                    {
                        produto.Id,
                        produto.Nome,
                        produto.Estoque,
                        produto.EstoqueMinimo,
                        estadoEstoque
                    });
            }

            return Json(new
            {
                data = listaEstoque
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getProdutos()
        {
            return Json(new
            {
                data = new ProdutoDAO().Lista()
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getDesativados()
        {
            return Json(new
            {
                data = new ProdutoDAO().ListaDesativados()
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Adiciona(Produto produto)
        {
            if (produto.Valida())
            {
                new ProdutoDAO().Adiciona(produto);
                return Json(new { adicionou = true });
            }
            else return Json(new { adicionou = false, msg = "Dados inválidos informados." });
        }

        [HttpPost]
        public JsonResult Atualiza(Produto produtoedit)
        {
            if (produtoedit.Valida())
            {
                var dao = new ProdutoDAO();
                if (dao.Existe(produtoedit.Id) && !dao.ExisteIgual(produtoedit))
                {
                    dao.Atualiza(produtoedit);
                    return Json(new { atualizou = true });
                }
                else return Json(new { atualizou = false, msg = "Nenhuma alteração feita no produto." });
            }
            else return Json(new { atualizou = false, msg = "Dados inválidos informados." });
        }

        public JsonResult Desativa(int[] ids)
        {
            var dao = new ProdutoDAO();
            foreach (var id in ids)
                dao.Desativa(id);
            return Json(new { apagou = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Ativa(int[] ids)
        {
            var dao = new ProdutoDAO();
            foreach (var id in ids)
                dao.Ativa(id);
            return Json(new { ativou = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RepoeEstoque(int id, int unidades)
        {
            try
            {
                new ProdutoDAO().IncrementaEstoque(id, unidades);
                return Json(new { incrementou = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { incrementou = false, msg = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult BuscaProdutosVenda()
        {
            var catDAO = new CategoriaDAO();
            var produtos = new ProdutoDAO().ListaComEstoque();

            var results = new List<object>();

            foreach (var categoria in catDAO.ListaCategoriasAtivas())
            {
                foreach (var subcategoria in catDAO.ListaTodasAsSubcategoriasAtivas())
                {
                    if (categoria.Id == subcategoria.CategoriaId)
                    {
                        var children = new List<object>();
                        foreach (var produto in new ProdutoDAO().ListaComEstoque().Where(p => p.SubcategoriaId == subcategoria.Id))
                        {
                            var precoRecarga = produto.PrecoRecarga.HasValue ? produto.PrecoRecarga.Value.ToString(CultureInfo.InvariantCulture) : "";
                            var precoTroca = produto.PrecoTroca.HasValue ? produto.PrecoTroca.Value.ToString(CultureInfo.InvariantCulture) : "";
                            children.Add(new { id = $"id={produto.Id}&pun={produto.PrecoUnitario.ToString(CultureInfo.InvariantCulture)}&prec={precoRecarga}&ptr={precoTroca}&est={produto.Estoque}", text = produto.Nome });
                        }
                        if (children.Count > 0) results.Add(new { text = $"{categoria.Nome} - {subcategoria.Nome}", children });
                    }
                }
            }
            return Json(results, JsonRequestBehavior.AllowGet);
        }
    }
}