using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MatrixMax.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public int Estoque { get; set; }
        public int EstoqueMinimo { get; set; }
        public Categoria Subcategoria { get; set; }
        public int? SubcategoriaId { get; set; }
        public Marca Marca { get; set; }
        public int? MarcaId { get; set; }
        public bool Ativo { get; set; }

        [MaxLength(50)]
        public string Nome { get; set; }

        public double PrecoUnitario { get; set; }
        
        public double? PrecoRecarga { get; set; }

        public double? PrecoTroca { get; set; }

        public override bool Equals(object obj)
        {
            Produto outroProduto = obj as Produto;

            if (outroProduto == null) return false;

            return outroProduto.Ativo == Ativo &&
                    outroProduto.Estoque == Estoque &&
                    outroProduto.EstoqueMinimo == EstoqueMinimo &&
                    outroProduto.Id == Id &&
                    outroProduto.MarcaId == MarcaId &&
                    outroProduto.Nome == Nome &&
                    outroProduto.PrecoRecarga == PrecoRecarga &&
                    outroProduto.PrecoTroca == PrecoTroca &&
                    outroProduto.PrecoUnitario == PrecoUnitario &&
                    outroProduto.SubcategoriaId == SubcategoriaId;
        }

        public bool Valida()
        {
            if (Nome == null ||
                MarcaId == null ||
                SubcategoriaId == null ||
                MarcaId <= 0 ||
                SubcategoriaId <= 0) return false;

            if (!Ativo) return false;

            if (Nome.Length < 5 || Nome.Length > 50) return false;

            //if (Estoque <= 0 || Estoque > 100) return false;

            if (EstoqueMinimo <= 0 || EstoqueMinimo > 100) return false;

            if (PrecoUnitario < 1) return false;

            if (PrecoTroca != null && PrecoTroca < 1) return false;

            if (PrecoRecarga != null && PrecoRecarga < 1) return false;

            return true;
        }

        public string ProcessaEstoque()
        {
            if (Estoque == 0) return "Sem estoque";
            else if (Estoque <= EstoqueMinimo) return "Alerta";
            else if (Estoque <= (EstoqueMinimo * 1.5)) return "Neutro";
            else return "Positivo";
        }
    }
}