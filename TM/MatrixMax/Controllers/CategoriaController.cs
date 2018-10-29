using MatrixMax.DAO;
using MatrixMax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace MatrixMax.Controllers
{
    public class CategoriaController : Controller
    {
        public JsonResult getCategorias()
        {
            return Json(new
            {
                data = from c in new CategoriaDAO().ListaCategorias()
                             select new { c.Nome, c.Id, c.Ativo }
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getCategoriasAtivas()
        {
            return Json(new
            {
                data = from c in new CategoriaDAO().ListaCategoriasAtivas()
                       select new { c.Nome, c.Id, c.Ativo }
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getSubcategorias(int id)
        {
            return Json(new
            {
                data = from c in new CategoriaDAO().ListaSubcategorias(id)
                                select new { c.Nome, c.Id }
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getSubcategoriasAtivas(int id)
        {
            return Json(new
            {
                data = from c in new CategoriaDAO().ListaSubcategoriasAtivas(id)
                       select new { c.Nome, c.Id }
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getTodasAsSubcategorias()
        {
            return Json(new
            {
                data = from c in new CategoriaDAO().ListaTodasAsSubcategorias()
                       select new { c.Nome, c.Id, Categoria = c.CategoriaDaSubcategoria.Nome, c.CategoriaId, c.Ativo }
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Adiciona(Categoria categoria)
        {
            if (new Regex(@"^[A-ZÁÉÍÓÚÃÕ][A-záéíóúãõ]{1,}(\s[A-zÁÉÍÓÚÃÕáéíóúãõ]{2,})*$").IsMatch(categoria.Nome))
            {
                new CategoriaDAO().Adiciona(categoria);
                return Json(new { adicionou = true });
            }
            else
            {
                return Json(new { adicionou = false, msg = "Nome inválido." });
            }
        }

        public JsonResult Atualiza(Categoria categoria)
        {
            var dao = new CategoriaDAO();
            var oldCategoria = dao.BuscaPorId(categoria.Id);
            if (oldCategoria != null && new Regex(@"^[A-ZÁÉÍÓÚÃÕ][A-záéíóúãõ]{1,}(\s[A-zÁÉÍÓÚÃÕáéíóúãõ]{2,})*$").IsMatch(categoria.Nome))
            {
                if (!oldCategoria.Equals(categoria))
                {
                    dao.Atualiza(categoria);
                    return Json(new { atualizou = true });
                }
                else
                {
                    return Json(new { atualizou = false, msg = "Nenhuma informação alterada." }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { atualizou = false, msg = "Dados inválidos." }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Ativa(int id)
        {
            new CategoriaDAO().Ativa(id);
            return Json(new { ativou = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Desativa(int id)
        {
            new CategoriaDAO().Desativa(id);
            return Json(new { desativou = true }, JsonRequestBehavior.AllowGet);
        }
    }
}