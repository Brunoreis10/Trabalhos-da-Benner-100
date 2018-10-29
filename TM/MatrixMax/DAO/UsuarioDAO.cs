using MatrixMax.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMax.DAO
{
    public class UsuarioDAO
    {
        public void Adiciona(Usuario usuario)
        {
            using (var context = new MatrixMaxContext())
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
            }
        }

        public void Atualiza(Usuario usuario)
        {
            using (var contexto = new MatrixMaxContext())
            {
                contexto.Entry(usuario).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public Usuario Autentica(string login, string senha)
        {
            using (var contexto = new MatrixMaxContext())
            {
                byte[] senhaHash = Encoding.ASCII.GetBytes(senha);
                senhaHash = new SHA256Managed().ComputeHash(senhaHash);
                return contexto.Usuarios.Include(u => u.Pessoa).FirstOrDefault(u => u.Login == login && u.Senha == senhaHash);
            } 
        }

        public void TrocaAtivo(int id)
        {
            using (var contexto = new MatrixMaxContext())
            {
                var usuario = contexto.Usuarios.Find(id);
                usuario.Ativo = !usuario.Ativo;
                contexto.Entry(usuario).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void TrocaPrivilegio(int id)
        {
            using (var contexto = new MatrixMaxContext())
            {
                var usuario = contexto.Usuarios.Find(id);
                usuario.TipoUsuario = usuario.TipoUsuario == 'F' ? 'A' : 'F';
                contexto.Entry(usuario).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public IList<Usuario> Lista()
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.Usuarios.Include(u => u.Pessoa).ToList();
            }
        }
    }
}
