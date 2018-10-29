using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronicoV2
{
    class Conta
    {
        public int Numero { get; set; }
        public double Saldo { get; private set; }
        public int Agencia { get; set; }
        public Cliente Titular { get; set; }

        public bool Saca(double valor)
        {

            if (valor <= this.Saldo && valor > 0)
            {
                if (!Titular.MaiordeIdade && valor > 200.0) this.Saldo -= 200.0;
                else this.Saldo -= valor;
                return true;
            } else return false;
        }

        public void Deposita(double valor)
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
    }
}
