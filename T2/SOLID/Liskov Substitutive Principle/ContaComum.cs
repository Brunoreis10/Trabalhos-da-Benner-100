using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Liskov_Substitutive_Principle
{
    public class ContaComum
    {
        private GerenciadorDeSaldo gerenciador;

        public ContaComum()
        {
            gerenciador = new GerenciadorDeSaldo();
        }

        public virtual void Deposita(double valor)
        {
            gerenciador.Deposita(valor);
        }

        public void Saca(double valor)
        {
            gerenciador.Saca(valor);
        }

        public void SomaInvestimento()
        {
            gerenciador.SomaInvestimento(1.1);
        }

        public double Saldo
        {
            get
            { 
                return gerenciador.Saldo;
            }
        }
    }
}
