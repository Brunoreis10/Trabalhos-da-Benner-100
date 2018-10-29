using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.Decorator.Exemplo___Impostos_Compostos
{
    class D_ICCC : D_Imposto
    {
        public D_ICCC() : base() { }

        public D_ICCC(D_Imposto outroImposto) : base(outroImposto) { }

        public override double Calcula(Orcamento orcamento)
        {
            if (orcamento.Valor < 1000) return (orcamento.Valor * 0.05) + CalculoDoOutroImposto(orcamento);
            else if (orcamento.Valor >= 1000 && orcamento.Valor <= 3000) return (orcamento.Valor * 0.07) + CalculoDoOutroImposto(orcamento);
            else return ((orcamento.Valor * 0.08) + 30.0) + CalculoDoOutroImposto(orcamento);
        }
    }
}
