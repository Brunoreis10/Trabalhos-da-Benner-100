using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benner.AplicacaoCaixaEletronico.Usuario;

namespace Benner.AplicacaoCaixaEletronico.Contas
{
    public abstract class Conta
    {
        public int Numero { get; set; }
        public double Saldo { get; protected set; }
        public int Agencia { get; set; }
        public Cliente Titular { get; set; }
        public static int TotalDeContas { get; protected set; }

        public Conta(Cliente titular)
        {
            this.Titular = titular;
        }

        public static int ProximaConta()
        {
            return Conta.TotalDeContas + 1;
        }

        public static void RemoveConta()
        {
            Conta.TotalDeContas--;
        }

        public abstract void Saca(double valor);

        public virtual void Deposita(double valor)
        {
            if (valor > 0) this.Saldo += valor;
        }

        public void Transfere(double valor, Conta destino)
        {
            this.Saca(valor);
            destino.Deposita(valor);
        }

        public double RendimentoAnual()
        {
            double saldoprevisto = this.Saldo;
            for (int i = 0; i < 12; i++) saldoprevisto *= 1.007;
            return (saldoprevisto - this.Saldo);
        }

        public override bool Equals(object obj)
        {
            var conta = (Conta)obj;
            return (this.Numero == conta.Numero) 
                && (this.Agencia == conta.Agencia) 
                && (this.Titular.Nome == conta.Titular.Nome);
        }

        public override string ToString()
        {
            return "Número: " + this.Numero + " - Agência: " + this.Agencia + " - Saldo: " + this.Saldo + ".";
        }
    }
}
