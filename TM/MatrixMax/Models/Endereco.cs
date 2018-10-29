using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MatrixMax.Models
{
    public class Endereco
    {
        [MaxLength(50)]
        public string Logradouro { get; set; }

        public int? Numero { get; set; }
        public string Cep { get; set; }

        [MaxLength(100)]
        public string Referencia { get; set; }

        [MaxLength(50)]
        public string Bairro { get; set; }

        [MaxLength(50)]
        public string Complemento { get; set; }

        [MaxLength(50)]
        public string Cidade { get; set; }

        [MaxLength(50)]
        public string Estado { get; set; }

        //public Pessoa Pessoa { get; set; }
        public int PessoaId { get; set; }

        public bool Valida()
        {
            if (Logradouro == null ||
                Numero == null ||
                Cep == null ||
                Bairro == null ||
                Cidade == null ||
                Estado == null)
                return false;

            if (Logradouro.Length < 5 || Logradouro.Length > 50) return false;
            if (Cidade.Length < 3 || Cidade.Length > 50) return false;
            if (Bairro.Length < 3 || Bairro.Length > 50) return false;
            if (Estado.Length != 2 || Estado.Length > 50) return false;
            if (Numero <= 0) return false;
            if (Cep.Length != 9) return false;
            return true;
        }

        public override bool Equals(object obj)
        {
            Endereco outroEndereco = obj as Endereco;

            if (outroEndereco == null) return false;

            return Logradouro == outroEndereco.Logradouro &&
                    Numero == outroEndereco.Numero &&
                    Cep == outroEndereco.Cep &&
                    Referencia == outroEndereco.Referencia &&
                    Bairro == outroEndereco.Bairro &&
                    Complemento == outroEndereco.Complemento &&
                    Cidade == outroEndereco.Cidade &&
                    Estado == outroEndereco.Estado;
        }
    }
}