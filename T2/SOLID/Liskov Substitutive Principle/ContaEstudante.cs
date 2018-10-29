using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Liskov_Substitutive_Principle
{
    public class ContaEstudante
    {
        private GerenciadorDeSaldo gerenciador;
        public int Milhas { get; private set; }

        public ContaEstudante()
        {
            gerenciador = new GerenciadorDeSaldo();
        }
        public void Deposita(double valor)
        {
            gerenciador.Deposita(valor);
            Milhas += (int)valor;
        }

        public void Saca(double valor)
        {
            gerenciador.Saca(valor);
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
