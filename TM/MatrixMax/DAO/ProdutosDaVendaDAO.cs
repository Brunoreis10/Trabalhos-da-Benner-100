using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixMax.Models;

namespace MatrixMax.DAO
{
    public class ProdutosDaVendaDAO
    {
        public IList<ProdutosDaVenda> ListaPorVenda(int id)
        {
            using (var contexto = new MatrixMaxContext())
            {
                return contexto.ProdutosDaVenda.Where(pv => pv.VendaId == id).Include(pv => pv.Produto).ToList();
            }
        }
    }
}
