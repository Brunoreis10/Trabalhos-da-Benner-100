using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixMax.Models;
using System.Threading;
using System.Globalization;

namespace MatrixMax.DAO
{
    public class VendaDAO
    {
        public void Adiciona(Venda venda)
        {
            using (var contexto = new MatrixMaxContext())
            {
                contexto.Vendas.Add(venda);
                contexto.SaveChanges();
            }
        }

        public void Atualiza(Venda venda)
        {
            using (var contexto = new MatrixMaxContext())
            {
                contexto.Entry(venda).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public Venda BuscaPorId(int id)
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Vendas
                    .Include(v => v.Produtos)
                    .ThenInclude(vp => vp.Produto)
                    .Include(v => v.FormaDePagamento)
                    .Include(v => v.Pessoa)
                    .Where(v => v.Id == id)
                    .SingleOrDefault();
            }
        }

        public IList<Venda> BuscaPorCliente(int id)
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Vendas
                    .Include(v => v.Produtos)
                    .Where(v => v.PessoaId == id)
                    .ToList();
            }
        }

        public IList<Venda> Lista()
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Vendas
                    .Include(v => v.FormaDePagamento)
                    .Include(v => v.Pessoa)
                    .Include(v => v.Usuario)
                    .OrderByDescending(v => v.Data)
                    .ToList();
            }
        }

        public IList<ProdutosDaVenda> ListaProdutos(int id)
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Vendas
                    .Include(v => v.Produtos)
                    .ThenInclude(vp => vp.Produto)
                    .Where(v => v.Id == id)
                    .SingleOrDefault().Produtos;
            }
        }

        public double TotalBrutoHoje()
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Vendas.Where(v => v.Data == DateTime.Today).ToList().Sum(v => v.ProcessaDesconto().ValorTotal);
            }
        }

        public int TotalVendasHoje()
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Vendas.Where(v => v.Data == DateTime.Today).ToList().Count;
            }
        }

        public int TotalProdutosVendidosHoje()
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Vendas.Include(v => v.Produtos).Where(v => v.Data == DateTime.Today).ToList().Sum(v => v.Produtos.Sum(pv => pv.Quantidade));
            }
        }

        public List<int> VendasHojePorCategoria()
        {
            using (var contexto = new MatrixMaxContext())
            {
                var lista = new List<int>();
                var vendas = contexto.Vendas.Where(v => v.Data == DateTime.Today).ToList();
                lista.Add(vendas.Where(v => v.FormaDePagamentoId == 1).Count());
                lista.Add(vendas.Where(v => v.FormaDePagamentoId == 2).Count());
                lista.Add(vendas.Where(v => v.FormaDePagamento.BandeiraCartao).Count());
                lista.Add(vendas.Where(v => v.FormaDePagamentoId == 5).Count());
                return lista;
            }
        }

        public List<object> VendasHojeFormasDePagamentoPorcentagem()
        {
            using (var contexto = new MatrixMaxContext())
            {
                var lista = new List<object>();

                var total = TotalVendasHoje();
                var plural = "";

                var quantidadeDinheiro = contexto.Vendas.Where(v => v.FormaDePagamentoId == 1 && v.Data == DateTime.Today).Count();
                if (quantidadeDinheiro > 0)
                {
                    plural = quantidadeDinheiro > 1 ? "s" : "";
                    var porcentagemDinheiro = Decimal.Round(Decimal.Divide(quantidadeDinheiro * 100, total), 2);
                    lista.Add(new
                    {
                        Porcentagem = porcentagemDinheiro.ToString(CultureInfo.InvariantCulture),
                        ClasseBarra = "bg-success",
                        Descricao = $"{Decimal.Round(porcentagemDinheiro)}% - {quantidadeDinheiro} venda{plural} no dinheiro"
                    });
                }

                var quantidadeBoleto = contexto.Vendas.Where(v => v.FormaDePagamentoId == 2 && v.Data == DateTime.Today).Count();
                if (quantidadeBoleto > 0)
                {
                    plural = quantidadeBoleto > 1 ? "s" : "";
                    var porcentagemBoleto = Decimal.Round(Decimal.Divide(quantidadeBoleto * 100, total), 2);
                    lista.Add(new
                    {
                        Porcentagem = porcentagemBoleto.ToString(CultureInfo.InvariantCulture),
                        ClasseBarra = "bg-primary",
                        Descricao = $"{Decimal.Round(porcentagemBoleto)}% - {quantidadeBoleto} venda{plural} no boleto"
                    });
                }

                var quantidadeCredito = contexto.Vendas.Where(v => v.FormaDePagamentoId > 5 && v.Parcelas > 0 && v.Data == DateTime.Today).Count();
                if (quantidadeCredito > 0)
                {
                    plural = quantidadeCredito > 1 ? "s" : "";
                    var porcentagemCredito = Decimal.Round(Decimal.Divide(quantidadeCredito * 100, total), 2);
                    lista.Add(new
                    {
                        Porcentagem = porcentagemCredito.ToString(CultureInfo.InvariantCulture),
                        ClasseBarra = "bg-laranjaEscuro",
                        Descricao = $"{Decimal.Round(porcentagemCredito)}% - {quantidadeCredito} venda{plural} no crédito"
                    });
                }

                var quantidadeDebito = contexto.Vendas.Where(v => v.FormaDePagamentoId > 5 && v.Parcelas == 0 && v.Data == DateTime.Today).Count();
                if (quantidadeDebito > 0)
                {
                    plural = quantidadeDebito > 1 ? "s" : "";
                    var porcentagemDebito = Decimal.Round(Decimal.Divide(quantidadeDebito * 100, total), 2);
                    lista.Add(new
                    {
                        Porcentagem = porcentagemDebito.ToString(CultureInfo.InvariantCulture),
                        ClasseBarra = "bg-dark",
                        Descricao = $"{Decimal.Round(porcentagemDebito)}% - {quantidadeDebito} venda{plural} no débito"
                    });
                }

                var quantidadeCheque = contexto.Vendas.Where(v => v.FormaDePagamentoId == 5 && v.Data == DateTime.Today).Count();
                if (quantidadeCheque > 0)
                {
                    plural = quantidadeCheque > 1 ? "s" : "";
                    var porcentagemCheque = Decimal.Round(Decimal.Divide(quantidadeCheque * 100, total), 2);
                    lista.Add(new
                    {
                        Porcentagem = porcentagemCheque.ToString(CultureInfo.InvariantCulture),
                        ClasseBarra = "bg-danger",
                        Descricao = $"{Decimal.Round(porcentagemCheque)}% - {quantidadeCheque} venda{plural} no cheque"
                    });
                }

                return lista;
            }
        }

        public List<double> RelatorioVendasPorMesAnual(int ano)
        {
            using (var contexto = new MatrixMaxContext())
            {
                var lista = new List<double>();
                for (int i = 1; i <= 12; i++)
                {
                    lista.Add(contexto.Vendas.Where(v => v.Data.Year == ano && v.Data.Month == i).Sum(v => v.ProcessaDesconto().ValorTotal));
                }
                return lista;
            }
        }

        public List<object> RelatorioVendasPorCategoria()
        {
            using (var contexto = new MatrixMaxContext())
            {
                var lista = new List<object>();
                foreach (var categoria in new CategoriaDAO().ListaCategoriasAtivas())
                {
                    var Soma = contexto.ProdutosDaVenda
                        .Include(pv => pv.Produto).ThenInclude(p => p.Subcategoria)
                        .Where(pv => pv.Produto.Subcategoria.CategoriaId == categoria.Id)
                        .Sum(pv => pv.Quantidade);

                    if (Soma > 0) lista.Add(new { categoria.Nome, Soma });
                }
                return lista;
            }
        }
    }
}
