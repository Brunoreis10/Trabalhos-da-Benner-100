using MatrixMax.DAO;
using MatrixMax.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatrixMax.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autentica(string login, string senha)
        {
            var usuario = new UsuarioDAO().Autentica(login, senha);
            if (usuario != null)
            {
                if (usuario.Ativo)
                {
                    Session["usuarioLogado"] = usuario;
                    Session["Alerta"] = "sim";
                    return RedirectToAction("Index", "Home");
                } else
                {
                    ModelState.AddModelError("UsuarioInativo", "Usuário inativo.");
                    return View("Index");
                }
            }
            else
            {
                ModelState.AddModelError("CredenciaisIncorretas", "Login e/ou senha inválido(s)!");
                return View("Index");
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return View("Index");
        }
    }
}