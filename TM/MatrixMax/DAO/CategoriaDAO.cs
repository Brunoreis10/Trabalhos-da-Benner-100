using MatrixMax.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMax.DAO
{
    public class CategoriaDAO
    {
        public void Adiciona(Categoria categoria)
        {
            using (var contexto = new MatrixMaxContext())
            {
                contexto.Categorias.Add(categoria);
                contexto.SaveChanges();
            }
        }

        public void Atualiza(Categoria categoria)
        {
            using (var contexto = new MatrixMaxContext())
            {
                contexto.Entry(categoria).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public IList<Categoria> ListaCategorias()
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Categorias.Where(c => c.CategoriaId == null).ToList();
            }
        }

        public IList<Categoria> ListaCategoriasDesativadas()
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Categorias.Where(c => c.CategoriaId == null && !c.Ativo).ToList();
            }
        }

        public IList<Categoria> ListaCategoriasAtivas()
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Categorias.Where(c => c.CategoriaId == null && c.Ativo).ToList();
            }
        }

        public IList<Categoria> ListaSubcategorias(int categoriaId)
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Categorias.Where(c => c.CategoriaId == categoriaId).ToList();
            }
        }

        public IList<Categoria> ListaSubcategoriasAtivas(int categoriaId)
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Categorias.Where(c => c.CategoriaId == categoriaId && c.Ativo).ToList();
            }
        }

        public IList<Categoria> ListaTodasAsSubcategoriasAtivas()
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Categorias.Where(c => c.CategoriaId.HasValue && c.Ativo).ToList();
            }
        }

        public IList<Categoria> ListaTodasAsSubcategorias()
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Categorias.Include(c => c.CategoriaDaSubcategoria).Where(c => c.CategoriaId.HasValue).ToList();
            }
        }

        public IList<Categoria> ListaTodasAsSubcategoriasDesativadas()
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Categorias.Include(c => c.CategoriaDaSubcategoria).Where(c => c.CategoriaId.HasValue && !c.Ativo).ToList();
            }
        }

        public Categoria BuscaPorId(int id)
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Categorias.Find(id);
            }
        }

        public void Ativa(int id)
        {
            using (var contexto = new MatrixMaxContext())
            {
                var categoria = contexto.Categorias.Find(id);
                categoria.Ativo = true;
                contexto.Entry(categoria).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Desativa(int id)
        {
            using (var contexto = new MatrixMaxContext())
            {
                var categoria = contexto.Categorias.Find(id);
                categoria.Ativo = false;
                contexto.Entry(categoria).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
}
