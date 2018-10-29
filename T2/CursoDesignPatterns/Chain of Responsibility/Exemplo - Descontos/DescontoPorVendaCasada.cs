using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.Chain_of_Responsibility.Exemplo___Descontos
{
    class DescontoPorVendaCasada : IDesconto
    {
        public IDesconto Proximo { get; set; }

        public double Desconta(Orcamento orcamento)
        {
            var temcaneta = false;
            var temlapis = false;
            foreach (var item in orcamento.Itens)
            {
                if (item.Nome.ToUpper().Equals("LAPIS")) temlapis = true;
                else if (item.Nome.ToUpper().Equals("CANETA")) temcaneta = true;
            }
            if (temlapis && temcaneta) return orcamento.Valor * 0.05;
            return Proximo.Desconta(orcamento);
        }
    }
}
