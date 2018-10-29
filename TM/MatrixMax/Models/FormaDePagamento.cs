using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MatrixMax.Models
{
    public class FormaDePagamento
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Nome { get; set; }

        public bool BandeiraCartao { get; set; }

        public int Previsao { get; set; }
    }
}