using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaelumEstoque.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required, StringLength(20)]
        public String Nome { get; set; }

        [Required, Range(0.1, Double.MaxValue, ErrorMessage = "Preço do produto deve ser maior que zero!")]
        public float Preco { get; set; }

        public CategoriaDoProduto Categoria { get; set; }

        [Required]
        public int? CategoriaId { get; set; }

        [Required]
        public String Descricao { get; set; }

        [Required, Range(1, 9999, ErrorMessage = "O produto deve ter ao menos uma unidade em estoque.")]
        public int Quantidade { get; set; }
    }
}