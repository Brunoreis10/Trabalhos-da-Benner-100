using MatrixMax.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMax.DAO
{
    public class MarcaDAO
    {
        public void Adiciona(Marca marca)
        {
            using (var contexto = new MatrixMaxContext())
            {
                contexto.Marcas.Add(marca);
                contexto.SaveChanges();
            }
        }

        public void Atualiza(Marca marca)
        {
            using (var contexto = new MatrixMaxContext())
            {
                contexto.Entry(marca).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public IList<Marca> Lista()
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Marcas.ToList();
            }
        }

        public IList<Marca> ListaDesativadas()
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Marcas.Where(m => !m.Ativo).ToList();
            }
        }

        public IList<Marca> ListaAtivas()
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Marcas.Where(m => m.Ativo).ToList();
            }
        }

        public Marca BuscaPorId(int id)
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Marcas.Find(id);
            }
        }

        public void Ativa(int id)
        {
            using (var contexto = new MatrixMaxContext())
            {
                var marca = contexto.Marcas.Find(id);
                marca.Ativo = true;
                contexto.Entry(marca).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Desativa(int id)
        {
            using (var contexto = new MatrixMaxContext())
            {
                var marca = contexto.Marcas.Find(id);
                marca.Ativo = false;
                contexto.Entry(marca).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
}