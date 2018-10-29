using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns
{
    class Moderado : IInvestimento
    {
        public double Calcula(Conta conta)
        {
            bool escolhido = new Random().Next(101) > 50;
            return escolhido ? conta.Saldo * 0.025 : conta.Saldo * 0.007;
        }
    }
}
