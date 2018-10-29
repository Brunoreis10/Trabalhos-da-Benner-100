using MatrixMax.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMax.DAO
{
    public class EnderecoDAO
    {
        public void Adiciona(Endereco endereco)
        {
            using (var contexto = new MatrixMaxContext())
            {
                contexto.Enderecos.Add(endereco);
                contexto.SaveChanges();
            }
        }

        public Endereco BuscaPorId(int id)
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Enderecos.Find(id);
            }
        }

        public void Atualiza(Endereco endereco)
        {
            using (var contexto = new MatrixMaxContext())
            {
                contexto.Entry(endereco).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public IList<Endereco> Lista()
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Enderecos.ToList();
            }
        }

        
    }
}
