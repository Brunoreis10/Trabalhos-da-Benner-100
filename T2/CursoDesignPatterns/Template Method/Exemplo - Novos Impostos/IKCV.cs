using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.Template_Method.Exemplo___Novos_Impostos
{
    public class IKCV : TemplateDeImpostoCondicional
    {
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
