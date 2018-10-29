using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixMax.Models;

namespace MatrixMax.DAO
{
    public class ProdutoDAO
    {
        public void Adiciona(Produto produto)
        {
            using (var contexto = new MatrixMaxContext())
            {
                contexto.Produtos.Add(produto);
                contexto.SaveChanges();
            }
        }

        public void Atualiza(Produto produto)
        {
            using (var contexto = new MatrixMaxContext())
            {
                contexto.Entry(produto).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public IList<Produto> Lista()
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Produtos.Include(p => p.Marca).Include(p => p.Subcategoria).ThenInclude(c => c.CategoriaDaSubcategoria).Where(p => p.Ativo).ToList();
            }
        }

        public IList<Produto> ListaComEstoque()
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Produtos.Include(p => p.Marca).Include(p => p.Subcategoria).ThenInclude(c => c.CategoriaDaSubcategoria).Where(p => p.Ativo && p.Estoque >= 1).ToList();
            }
        }

        public IList<Produto> ListaDesativados()
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Produtos.Include(p => p.Marca).Include(p => p.Subcategoria).ThenInclude(c => c.CategoriaDaSubcategoria).Where(p => !p.Ativo).ToList();
            }
        }

        public Produto BuscaPorId(int id)
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Produtos.Include(p => p.Marca).Include(p => p.Subcategoria).ThenInclude(c => c.CategoriaDaSubcategoria).SingleOrDefault(p => p.Id == id);
            }
        }

        public bool Existe(int id)
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Produtos.Find(id) != null;
            }
        }

        public void Desativa(int id)
        {
            using (var contexto = new MatrixMaxContext())
            {
                var produto = contexto.Produtos.Find(id);
                produto.Ativo = false;
                contexto.Entry(produto).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Ativa(int id)
        {
            using (var contexto = new MatrixMaxContext())
            {
                var produto = contexto.Produtos.Find(id);
                produto.Ativo = true;
                contexto.Entry(produto).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public bool ExisteIgual(Produto produto)
        {
            using (var contexto = new MatrixMaxContext())
            {
                var busca = contexto.Produtos.Find(produto.Id);
                return busca.Equals(produto);
            }
        }

        public void DecrementaEstoqueDos(List<ProdutosDaVenda> produtosDaVenda)
        {
            using (var contexto = new MatrixMaxContext())
            {
                foreach (var produtoDaVenda in produtosDaVenda)
                {
                    DecrementaEstoque(produtoDaVenda.ProdutoId, produtoDaVenda.Quantidade);
                }
            }
        }

        public void DecrementaEstoque(int id, int quantidade)
        {
            using (var contexto = new MatrixMaxContext())
            {
                var produto = contexto.Produtos.Find(id);
                produto.Estoque -= quantidade;
                contexto.Entry(produto).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void IncrementaEstoque(int id, int quantidade)
        {
            using (var contexto = new MatrixMaxContext())
            {
                var produto = contexto.Produtos.Find(id);
                produto.Estoque += quantidade;
                contexto.Entry(produto).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public List<object> WidgetsEstoqueDashboard()
        {
            using (var contexto = new MatrixMaxContext())
            {
                return new List<object>
                {
                    new
                    {
                        Quantidade = contexto.Produtos.Where(p => p.ProcessaEstoque() == "Sem estoque" && p.Ativo).Count(),
                        ClasseWidget = "bg-secondary",
                        Descricao = "Produtos fora de estoque",
                        IconeWidget = "fa-minus-square"
                    },
                    new
                    {
                        Quantidade = contexto.Produtos.Where(p => p.ProcessaEstoque() == "Alerta" && p.Ativo).Count(),
                        ClasseWidget = "bg-flat-color-4",
                        Descricao = "Produtos em alerta",
                        IconeWidget = "fa-warning"
                    },
                    new
                    {
                        Quantidade = contexto.Produtos.Where(p => p.ProcessaEstoque() == "Neutro" && p.Ativo).Count(),
                        ClasseWidget = "bg-flat-color-3",
                        Descricao = "Produtos com estoque neutro",
                        IconeWidget = "fa-square"
                    },
                    new
                    {
                        Quantidade = contexto.Produtos.Where(p => p.ProcessaEstoque() == "Positivo" && p.Ativo).Count(),
                        ClasseWidget = "bg-flat-color-5",
                        Descricao = "Produtos com estoque positivo",
                        IconeWidget = "fa-check-square"
                    }
                };
            }
        }
    }
}
