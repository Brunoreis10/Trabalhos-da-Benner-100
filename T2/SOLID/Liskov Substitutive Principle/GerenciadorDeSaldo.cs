using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Liskov_Substitutive_Principle
{
    public class GerenciadorDeSaldo
    {
        public double Saldo { get; private set; }

        public GerenciadorDeSaldo()
        {
            Saldo = 0;
        }

        public void Deposita(double valor)
        {
            if (valor > 0) Saldo += valor;
            else throw new ArgumentException();
        }

        public void Saca(double valor)
        {
            if (valor <= Saldo)
            {
                Saldo -= valor;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void SomaInvestimento(double taxa)
        {
            Saldo *= taxa;
        }
    }
}
