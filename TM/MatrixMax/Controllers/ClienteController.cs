using MatrixMax.DAO;
using MatrixMax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatrixMax.Controllers
{
    public class ClienteController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Clientes";
            return View();
        }

        public ActionResult Novo()
        {
            ViewBag.Title = "Novo Cliente";
            return View();
        }

        public JsonResult Adiciona(Pessoa pessoa)
        {
            var dao = new PessoaDAO();
            if (dao.Existe(pessoa.CpfCnpj) != null)
            {
                return Json(new { adicionou = false, msg = "Já existe um cliente cadastrado com este CPF/CNPJ." });
            }
            else
            {
                if (pessoa.Valida() && pessoa.Endereco.Valida())
                {
                    dao.Adiciona(pessoa);
                    return Json(new { adicionou = true });
                }
                else
                {
                    return Json(new { adicionou = false, msg = "Dados inválidos." });
                }
            }
        }

        public JsonResult Atualiza(Pessoa pessoa)
        {
            var dao = new PessoaDAO();
            var enderecodao = new EnderecoDAO();
            var enderecoOld = enderecodao.BuscaPorId(pessoa.Id);
            var pessoaOld = dao.BuscaPorId(pessoa.Id);
            if (pessoaOld != null && enderecoOld != null)
            {
                if (pessoa.Valida() && pessoa.Endereco.Valida())
                {
                    if (pessoa.Equals(pessoaOld) && enderecoOld.Equals(pessoa.Endereco))
                    {
                        return Json(new { adicionou = false, msg = "Nenhum dado alterado." });
                    }
                    else
                    {
                        dao.Atualiza(pessoa);
                        return Json(new { adicionou = true });
                    }
                }
                else
                {

                    return Json(new { adicionou = false, msg = "Dados inválidos." + pessoa.Valida().ToString() + " - " + pessoa.Endereco.Valida().ToString() });
                }
            }
            else
            {
                return Json(new { adicionou = false, msg = "Cliente não encontrado." });
            }
        }

        public JsonResult BuscaClienteVenda(string q)
        {
            var results = new List<object>();
            foreach (var pessoa in new PessoaDAO().BuscaPessoas(q))
            {
                results.Add(new { id = pessoa.Id, text = pessoa.NomeRazaoSocial });
            }
            return Json(new { results }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getClientes()
        {
            return Json(new { data = new PessoaDAO().Lista() }, JsonRequestBehavior.AllowGet);
        }
    }
}