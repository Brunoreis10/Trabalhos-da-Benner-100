using MatrixMax.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatrixMax.DAO
{
    public class PessoaDAO
    {
        public void Adiciona(Pessoa pessoa)
        {
            using (var contexto = new MatrixMaxContext())
            {
                contexto.Pessoas.Add(pessoa);
                contexto.SaveChanges();
            }
        }

        public void Atualiza(Pessoa pessoa)
        {
            using (var contexto = new MatrixMaxContext())
            {
                contexto.Pessoas.Update(pessoa);
                contexto.SaveChanges();
            }
        }

        public IList<Pessoa> Lista()
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Pessoas.Include(p => p.Endereco).ToList();
            }
        }

        public Pessoa Existe(string cpfCnpj)
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Pessoas.Where(p => p.CpfCnpj == cpfCnpj).FirstOrDefault();
            }
        }

        public Pessoa BuscaPorId(int id)
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Pessoas.Find(id);
            }
        }

        public IList<Pessoa> BuscaPessoas(string query)
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Pessoas.Where(p => Regex.IsMatch(p.NomeRazaoSocial, query, RegexOptions.IgnoreCase)).ToList();
            }
        }
    }
}
