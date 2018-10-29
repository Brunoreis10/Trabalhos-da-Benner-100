using MatrixMax.DAO;
using MatrixMax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatrixMax.Controllers
{
    public class VendaController : Controller
    {
        public ActionResult Index()
        {
            var formaPagamentoDAO = new FormaDePagamentoDAO();
            var categoriaDAO = new CategoriaDAO();
            ViewBag.FormasDePagamento = formaPagamentoDAO.ListaFormasDePagamento();
            ViewBag.Bandeiras = formaPagamentoDAO.ListaBandeiras();
            ViewBag.Produtos = new ProdutoDAO().ListaComEstoque();
            ViewBag.Categorias = categoriaDAO.ListaCategoriasAtivas();
            ViewBag.Subcategorias = categoriaDAO.ListaTodasAsSubcategoriasAtivas();
            ViewBag.Title = "Nova Venda";
            return View();
        }

        public ActionResult Historico()
        {
            ViewBag.Title = "Histórico";
            return View();
        }

        public JsonResult getVendas()
        {
            return Json(new { data = new VendaDAO().Lista() }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getProdutosDaVenda(int id)
        {
            return Json(new { data = new ProdutosDaVendaDAO().ListaPorVenda(id) }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Cadastra(List<ProdutosDaVenda> produtosDaVenda, Venda venda)
        {
            try
            {
                var usuario = (Usuario)Session["usuarioLogado"];
                venda.UsuarioId = usuario.Id;

                var formaDAO = new FormaDePagamentoDAO();
                var formaDePagamentoSelecionada = new FormaDePagamentoDAO().BuscaPorId((int)venda.FormaDePagamentoId);

                if (venda.Parcelas > 0)
                {
                    var cartao = formaDAO.BuscaPorId(3);
                    venda.Previsao = venda.Data.AddDays(cartao.Previsao * venda.Parcelas);
                }
                else
                {
                    venda.Previsao = venda.Data.AddDays(formaDePagamentoSelecionada.Previsao);
                }

                venda.Produtos = produtosDaVenda;
                new VendaDAO().Adiciona(venda);
                new ProdutoDAO().DecrementaEstoqueDos(produtosDaVenda);
                return Json(new { adicionou = true });
            }
            catch (Exception e)
            {
                return Json(new { adicionou = false, msg = e.Message });
            }
        }

        public JsonResult getVendasDoCliente(int id)
        {
            var vendas = new VendaDAO().BuscaPorCliente(id);
            var resumoVendas = new List<object>();

            foreach (var venda in vendas)
            {
                var ValorTotal = venda.ValorTotal;

                if (venda.DescontoPorcento > 0)
                    ValorTotal -= (ValorTotal * (int)venda.DescontoPorcento) / 100;
                else if (venda.DescontoValorFixo > 0)
                    ValorTotal -= venda.DescontoValorFixo;

                resumoVendas.Add(
                    new
                    {
                        venda.Data,
                        Produtos = venda.Produtos.Sum(p => p.Quantidade),
                        ValorTotal,
                    });
            }

            return Json(new { data = resumoVendas }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getRelatorioVendasPorCategoria()
        {
            return Json(new VendaDAO().RelatorioVendasPorCategoria(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult getRelatorioVendasPorMesAnual(List<int> anos)
        {
            var lista = new List<List<double>>();
            var dao = new VendaDAO();
            foreach (var ano in anos)
            {
                lista.Add(dao.RelatorioVendasPorMesAnual(ano));
            }
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
    }
}