using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatrixMax.Models
{
    public class ProdutosDaVenda
    {
        public Produto Produto { get; set; }
        public int ProdutoId { get; set; }

        public Venda Venda { get; set; }
        public int VendaId { get; set; }

        public int Quantidade { get; set; }

        public double PrecoSelecionado { get; set; }
    }
}