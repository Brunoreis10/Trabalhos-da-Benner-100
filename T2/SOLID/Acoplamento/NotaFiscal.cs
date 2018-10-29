using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Acoplamento
{
    public class NotaFiscal
    {
        public double ValorBruto { get; private set; }
        public double Impostos { get; private set; }
        public double ValorLiquido
        {
            get
            {
                return ValorBruto - Impostos;
            }
        }

        public NotaFiscal(double valorBruto, double impostos)
        {
            ValorBruto = valorBruto;
            Impostos = impostos;
        }
    }
}
