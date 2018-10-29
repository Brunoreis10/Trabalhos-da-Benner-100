using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.Template_Method.Exemplo___Novos_Impostos
{
    public abstract class TemplateDeImpostoCondicional : IImposto
    {
        public double Calcula(Orcamento orcamento)
        {
            if (CondicaoTaxacaoMaxima(orcamento))
            {
                return (TaxacaoMaxima(orcamento));
            }

            return MinimaTaxacao(orcamento);
        }

        protected abstract double MinimaTaxacao(Orcamento orcamento);
        protected abstract double TaxacaoMaxima(Orcamento orcamento);
        protected abstract bool CondicaoTaxacaoMaxima(Orcamento orcamento);
    }
}
