using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.Decorator.Exemplo___Impostos_Compostos
{
    class D_ISS : D_Imposto
    {
        public D_ISS() : base() { }

        public D_ISS(D_Imposto outroImposto) : base(outroImposto) { }

        public override double Calcula(Orcamento orcamento)
        {
            return (orcamento.Valor * 0.06) + CalculoDoOutroImposto(orcamento);
        }
    }
}
