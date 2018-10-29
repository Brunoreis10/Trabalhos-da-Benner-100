using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Encapsulamento
{
    public class Boleto
    {
        public double Valor { get; private set; }

        public Boleto(double valor)
        {
            Valor = valor;
        }
    }
}
