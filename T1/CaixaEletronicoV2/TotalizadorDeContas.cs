using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronicoV2
{
    /*public <- Se descomentar, a classe produzirá um erro.*/ class TotalizadorDeContas
    {
        public double Saldo { get; private set; }
        public void Adiciona(Conta c)
        {
            this.Saldo = c.Saldo;
        }
    }
}
