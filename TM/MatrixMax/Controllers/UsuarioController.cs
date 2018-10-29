using MatrixMax.DAO;
using MatrixMax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MatrixMax.Controllers
{
    public class UsuarioController : Controller
    {
        public JsonResult getUsuarios()
        {
            return Json(new { data = new UsuarioDAO().Lista() }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult togglePrivilegio(int id)
        {
            try
            {
                new UsuarioDAO().TrocaPrivilegio(id);
                return Json(new { trocou = true }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new { trocou = false, msg = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult toggleAtivo(int id)
        {
            try
            {
                new UsuarioDAO().TrocaAtivo(id);
                return Json(new { trocou = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { trocou = false, msg = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Adiciona(Usuario usuario, string senhaUsuario, string senhaUsuarioRepetida)
        {
            var dao = new PessoaDAO();
             
            if (dao.Existe(usuario.Pessoa.CpfCnpj) != null)
            {
                return Json(new { adicionou = false, msg = "Já existe um cadastro para este CPF/CNPJ." });
            }
            else
            {
                if (usuario.Pessoa.Valida() && usuario.Pessoa.Endereco.Valida())
                {
                    if (ValidaNovoUsuario(usuario, senhaUsuario, senhaUsuarioRepetida))
                    {
                        usuario.Senha = encriptaSenha(senhaUsuario);
                        new UsuarioDAO().Adiciona(usuario);
                        return Json(new { adicionou = true });
                    } 
                    else
                    {
                        return Json(new { adicionou = false, msg = "Dados do usuário inválidos." });
                    }
                }
                else
                {
                    return Json(new { adicionou = false, msg = "Dados de pessoa/endereço inválidos." });
                }
            }
        }

        private byte[] encriptaSenha(string senhaUsuario)
        {
            byte[] senhaHash = Encoding.ASCII.GetBytes(senhaUsuario);
            return new SHA256Managed().ComputeHash(senhaHash);
        }

        private bool ValidaNovoUsuario(Usuario usuario, string senhaUsuario, string senhaUsuarioRepetida)
        {
            if (usuario.Login == null || senhaUsuario == null || senhaUsuarioRepetida == null) return false;

            if ((usuario.Login.Length > 50) || (usuario.Login.Length < 3)) return false;

            if ((senhaUsuario.Length > 15) || (senhaUsuario.Length < 5)) return false;

            if (senhaUsuario != senhaUsuarioRepetida) return false;

            return true;
        }
    }
}