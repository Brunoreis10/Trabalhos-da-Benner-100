using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.Template_Method.Exemplo___Novos_Impostos
{
    class IHIT : TemplateDeImpostoCondicional
    {
        protected override bool CondicaoTaxacaoMaxima(Orcamento orcamento)
        {
            foreach (var item in orcamento.Itens)
            {
                if (orcamento.Itens.Where(o => o.Nome == item.Nome).ToList().Count > 1) return true;
            }
            return false;
        }

        protected override double MinimaTaxacao(Orcamento orcamento)
        {
            return (orcamento.Valor * 0.01) * orcamento.Itens.Count;
        }

        protected override double TaxacaoMaxima(Orcamento orcamento)
        {
            return (orcamento.Valor * 0.13) + 100;
        }
    }
}
