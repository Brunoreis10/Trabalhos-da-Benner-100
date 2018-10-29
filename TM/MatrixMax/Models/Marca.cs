using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MatrixMax.Models
{
    public class Marca
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Nome { get; set; }

        public bool Ativo { get; set; }

        public override bool Equals(object obj)
        {
            var outraMarca = (Marca)obj;

            return Id == outraMarca.Id && Nome == outraMarca.Nome;
        }
    }
}