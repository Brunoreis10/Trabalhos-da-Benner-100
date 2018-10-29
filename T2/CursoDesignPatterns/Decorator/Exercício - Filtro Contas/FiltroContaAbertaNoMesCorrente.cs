using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.Decorator.Exercício___Filtro_Contas
{
    public class FiltroContaAbertaNoMesCorrente : Filtro
    {
        public FiltroContaAbertaNoMesCorrente() : base() { }

        public FiltroContaAbertaNoMesCorrente(Filtro outroFiltro) : base(outroFiltro) { }

        public override IList<Conta> Filtra(IList<Conta> contas)
        {
            var filtrada = new List<Conta>();
            foreach (var conta in contas)
            {
                if (conta.DataAbertura.CompareTo(DateTime.Today.AddMonths(-1)) > 0)
                {
                    filtrada.Add(conta);
                }
            }
            return filtrada.Concat(VerificaOutroFiltro(contas)).ToList();
        }
    }
}
