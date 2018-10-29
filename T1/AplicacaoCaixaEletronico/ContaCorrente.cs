using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Benner.AplicacaoCaixaEletronico.Usuario;
using Benner.AplicacaoCaixaEletronico.Excecoes;

namespace Benner.AplicacaoCaixaEletronico.Contas
{
    public class ContaCorrente : Conta
    {
        public ContaCorrente(Cliente titular) : base(titular)
        {
            this.Titular = titular;
            Conta.TotalDeContas++;
        }

        public override void Saca(double valor)
        {
            if (valor > this.Saldo) throw new SaldoInsuficienteException();
            else if (valor < 0) throw new ArgumentException();
            else if (!Titular.MaiordeIdade && valor > 200.0) throw new SaqueMenorDeIdadeException();
            else this.Saldo -= valor;
        }
    }
}
