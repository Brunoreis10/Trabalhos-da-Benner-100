using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.Decorator.Exemplo___Impostos_Compostos
{
    class D_ICMS : D_Imposto
    {
        public D_ICMS() { }
        
        public D_ICMS(D_Imposto outroImposto) : base(outroImposto) { }
        
        public override double Calcula(Orcamento orcamento)
        {
            return ((orcamento.Valor * 0.05) + 50.0) + CalculoDoOutroImposto(orcamento);
        }
    }
}
