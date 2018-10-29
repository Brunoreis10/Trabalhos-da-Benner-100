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
    public class MarcaController : Controller
    {
        public JsonResult getMarcas()
        {
            return Json(new
            {
                data = new MarcaDAO().Lista()
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getMarcasAtivas()
        {
            return Json(new
            {
                data = new MarcaDAO().ListaAtivas()
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Adiciona(Marca marca)
        {
            if (new Regex(@"^[A-ZÁÉÍÓÚÃÕ][A-záéíóúãõ]{1,}(\s[A-zÁÉÍÓÚÃÕáéíóúãõ]{2,})*$").IsMatch(marca.Nome))
            {
                new MarcaDAO().Adiciona(marca);
                return Json(new { adicionou = true });
            } else
            {
                return Json(new { adicionou = false, msg = "Nome inválido." });
            }
        }

        public JsonResult Atualiza(Marca marca)
        {
            var dao = new MarcaDAO();
            var oldMarca = dao.BuscaPorId(marca.Id);
            if (oldMarca != null && new Regex(@"^[A-ZÁÉÍÓÚÃÕ][A-záéíóúãõ]{1,}(\s[A-zÁÉÍÓÚÃÕáéíóúãõ]{2,})*$").IsMatch(marca.Nome))
            {
                if (!oldMarca.Equals(marca))
                { 
                    dao.Atualiza(marca);
                    return Json(new { atualizou = true });
                } else
                {
                    return Json(new { atualizou = false, msg = "O nome não foi alterado." }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { adicionou = false, msg = "Dados inválidos." }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Ativa(int id)
        {
            new MarcaDAO().Ativa(id);
            return Json(new { ativou = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Desativa(int id)
        {
            new MarcaDAO().Desativa(id);
            return Json(new { desativou = true }, JsonRequestBehavior.AllowGet);
        }
    }
}