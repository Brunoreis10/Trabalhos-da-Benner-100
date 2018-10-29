using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns
{
    class RealizadorDeInvestimentos
    {
        public void RealizaInvestimento(Conta conta, IInvestimento investimento)
        {
            double retorno = investimento.Calcula(conta);
            conta.Deposita(retorno * 0.75);
            Console.WriteLine("Novo saldo = R$" + conta.Saldo);
        }
    }
}
