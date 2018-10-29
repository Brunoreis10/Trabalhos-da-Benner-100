using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.Decorator.Exemplo___Impostos_Compostos
{
    class D_IKCV : D_TemplateDeImpostoCondicional
    {
        public D_IKCV() : base() { }

        public D_IKCV(D_Imposto outroImposto) : base(outroImposto) { }

        protected override bool CondicaoTaxacaoMaxima(Orcamento orcamento)
        {
            return orcamento.Valor >= 500;
        }

        protected override double MinimaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.05;
        }

        protected override double TaxacaoMaxima(Orcamento orcamento)
        {
            return orcamento.Valor * 0.07;
        }
    }
}
