using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    public class Avaliador
    {
        private double menorLance = Double.MaxValue;
        private double maiorLance = Double.MinValue;
        private double lanceMedio;
        private IList<Lance> maioresLances;

        public void Avalia(Leilao leilao)
        {
            if (leilao.Lances.Count == 0) throw new Exception("Não é possível avaliar um leilão sem lances.");

            double soma = 0;
            foreach (var lance in leilao.Lances)
            {
                soma += lance.Valor;
                if (lance.Valor > maiorLance) maiorLance = lance.Valor;
                if (lance.Valor < menorLance) menorLance = lance.Valor;
            }
            lanceMedio = soma / leilao.Lances.Count;
            pegaOsMaiores(leilao);
        }

        private void pegaOsMaiores(Leilao leilao)
        {
            var filtro = leilao.Lances.OrderByDescending(l => l.Valor).Take(3);
            maioresLances = new List<Lance>(filtro);
        }

        public IList<Lance> TresMaiores { get { return maioresLances; } }
        public double MaiorLance { get { return maiorLance; } }
        public double MenorLance { get { return menorLance; } }
        public double LanceMedio { get { return lanceMedio; } }
    }
}
