/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.State.Exercício___Estados_Conta
{
    public class Negativo : IEstadoConta
    {
        public void Deposita(Conta conta, double valor)
        {
            conta.Saldo += valor * 0.95;
            if (conta.Saldo >= 0) conta.EstadoSaldo = new Positivo();
        }

        public void Saca(Conta conta, double valor)
        {
            throw new Exception("Conta com saldo negativo não aceita saques!");
        }
    }
} MOVIDO PARA A PRÓPRIA CLASSE CONTA, PARA MANTER ENCAPSULAMENTO DO SALDO! */
