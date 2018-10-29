using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns
{
    class Arrojado : IInvestimento
    {
        public double Calcula(Conta conta)
        {
            int sorteio = new Random().Next(101);
            if (sorteio <= 20) return conta.Saldo * 0.05;
            else if (sorteio > 20 && sorteio <= 50) return conta.Saldo * 0.03;
            else return conta.Saldo * 0.006;
        }
    }
}
