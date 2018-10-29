using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.Decorator.Exemplo___Impostos_Compostos
{
    public abstract class D_TemplateDeImpostoCondicional : D_Imposto
    {
        public D_TemplateDeImpostoCondicional(D_Imposto outroImposto) : base(outroImposto) { }

        public D_TemplateDeImpostoCondicional() : base() { }

        public override double Calcula(Orcamento orcamento)
        {
            if (CondicaoTaxacaoMaxima(orcamento))
            {
                return TaxacaoMaxima(orcamento) + CalculoDoOutroImposto(orcamento);
            }

            return MinimaTaxacao(orcamento) + CalculoDoOutroImposto(orcamento);
        }

        protected abstract double MinimaTaxacao(Orcamento orcamento);
        protected abstract double TaxacaoMaxima(Orcamento orcamento);
        protected abstract bool CondicaoTaxacaoMaxima(Orcamento orcamento);
    }
}
