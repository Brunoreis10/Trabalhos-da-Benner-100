using MatrixMax.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMax.DAO
{
    public class FormaDePagamentoDAO
    {
        public void Adiciona(FormaDePagamento formaDePagamento)
        {
            using (var contexto = new MatrixMaxContext())
            {
                contexto.FormasDePagamento.Add(formaDePagamento);
                contexto.SaveChanges();
            }
        }

        public void Atualiza(FormaDePagamento formaDePagamento)
        {
            using (var contexto = new MatrixMaxContext())
            {
                contexto.Entry(formaDePagamento).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public IList<FormaDePagamento> ListaFormasDePagamento()
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.FormasDePagamento.Where(fp => !fp.BandeiraCartao).ToList();
            }
        }

        public IList<FormaDePagamento> ListaBandeiras()
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.FormasDePagamento.Where(fp => fp.BandeiraCartao).ToList();
            }
        }

        public FormaDePagamento BuscaPorId(int id)
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.FormasDePagamento.Find(id);
            }
        }
    }
}
