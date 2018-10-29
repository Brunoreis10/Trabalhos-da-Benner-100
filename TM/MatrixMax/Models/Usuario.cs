using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MatrixMax.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [MaxLength(30), MinLength(8)]
        public string Login { get; set; }

        public char TipoUsuario { get; set; }

        public byte[] Senha { get; set; }

        public Pessoa Pessoa { get; set; }

        public bool Ativo { get; set; }
    }
}