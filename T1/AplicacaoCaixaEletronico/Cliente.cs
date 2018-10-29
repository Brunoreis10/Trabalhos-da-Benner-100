using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benner.AplicacaoCaixaEletronico.Usuario
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Endereco { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }

        public Cliente(string nome) //Construtor! Convenção: Nome do parâmetro é o mesmo nome da propriedade.
        {
            this.Nome = nome;
        }

        public Cliente()
        {
            //Réplica do construtor default, tornando o primeiro construtor OPCIONAL.
        }
        public bool MaiordeIdade
        {
            get
            {
                //return idade >= 18 ? true : false; <- Minha solução, não eficiente. Solução do professor:
                return this.Idade >= 18;
            }
        }

        public override bool Equals(object obj)
        {
            var cliente = (Cliente)obj;
            return this.Rg == cliente.Rg;
        }

        public override string ToString()
        {
            return "Nome: " + this.Nome + " - RG: " + this.Rg + " - CPF: " + this.Cpf + " - Idade: " + this.Idade + ".";
        }
    }
}
