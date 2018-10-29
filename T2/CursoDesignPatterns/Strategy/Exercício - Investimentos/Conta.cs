using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns
{
    public class Conta
    {
        public string Titular { get; private set; }
        public double Saldo { get; private set; }
        public int Agencia { get; private set; }
        public int Numero { get; private set; }
        public DateTime DataAbertura { get; private set; }
        public IEstadoConta EstadoSaldo { get; set; }

        public interface IEstadoConta
        {
            void Saca(Conta conta, double valor);
            void Deposita(Conta conta, double valor);
        }

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

        public Conta()
        {
            EstadoSaldo = new Positivo();
        }
        
        public Conta(string titular)
        {
            Titular = titular;
            EstadoSaldo = new Positivo();
        }

        public Conta(string titular, int agencia, int numero)
        {
            Titular = titular;
            Agencia = agencia;
            Numero = numero;
            EstadoSaldo = new Positivo();
        }

        public Conta(string titular, int agencia, int numero, DateTime dataAbertura)
        {
            Titular = titular;
            Agencia = agencia;
            Numero = numero;
            DataAbertura = dataAbertura;
            EstadoSaldo = new Positivo();
        }

        public void Deposita(double valor)
        {
            EstadoSaldo.Deposita(this, valor);
        }

        public void Saca(double valor)
        {
            EstadoSaldo.Saca(this, valor);
        }
    }
}
