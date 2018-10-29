/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.State.Exercício___Estados_Conta
{
    public class Positivo : IEstadoConta
    {
        public void Deposita(Conta conta, double valor)
        {
            conta.Saldo += valor * 0.98;
        }

        public void Saca(Conta conta, double valor)
        {
            conta.Saldo -= valor;
            if (conta.Saldo < 0) conta.EstadoSaldo = new Negativo();
        }
    }
} MOVIDO PARA A PRÓPRIA CLASSE CONTA, PARA MANTER ENCAPSULAMENTO DO SALDO! */