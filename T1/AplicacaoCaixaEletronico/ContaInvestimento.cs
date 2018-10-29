using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Benner.AplicacaoCaixaEletronico.Interfaces;
using Benner.AplicacaoCaixaEletronico.Usuario;
using Benner.AplicacaoCaixaEletronico.Excecoes;

namespace Benner.AplicacaoCaixaEletronico.Contas
{
    class ContaInvestimento : Conta, ITributavel
    {
        public ContaInvestimento(Cliente titular) : base(titular)
        {
            this.Titular = titular;
            Conta.TotalDeContas++;
        }

        public double CalculaTributos()
        {
            return this.Saldo * 0.03;
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
