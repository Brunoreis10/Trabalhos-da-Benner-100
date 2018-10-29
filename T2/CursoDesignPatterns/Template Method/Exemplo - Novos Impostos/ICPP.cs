using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.Template_Method.Exemplo___Novos_Impostos
{
    public class ICPP : TemplateDeImpostoCondicional
    {
        protected override bool CondicaoTaxacaoMaxima(Orcamento orcamento)
        {
            return (orcamento.Valor > 500) && (TemItemComValorAcimaDeCem(orcamento));
        }

        private bool TemItemComValorAcimaDeCem(Orcamento orcamento)
        {
            foreach (var item in orcamento.Itens)
            {
                if (item.Valor > 100) return true;
            }
            return false;
        }

        protected override double MinimaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.06;
        }

        protected override double TaxacaoMaxima(Orcamento orcamento)
        {
            return orcamento.Valor * 0.1;
        }
    }
}
