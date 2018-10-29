using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.Decorator.Exemplo___Impostos_Compostos
{
    public abstract class D_Imposto
    {
        public D_Imposto OutroImposto { get; set; }

        public D_Imposto(D_Imposto outroImposto)
        {
            OutroImposto = outroImposto;
        }

        public D_Imposto()
        {
            OutroImposto = null;
        }

        public abstract double Calcula(Orcamento orcamento);

        protected double CalculoDoOutroImposto(Orcamento orcamento)
        {
            return OutroImposto == null ? 0 : OutroImposto.Calcula(orcamento);
        }
    }
}
