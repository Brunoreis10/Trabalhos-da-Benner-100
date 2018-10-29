using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.Decorator.Exercício___Filtro_Contas
{
    public class FiltroSaldoMenorQueCemReais : Filtro
    {
        public FiltroSaldoMenorQueCemReais() : base() { }

        public FiltroSaldoMenorQueCemReais(Filtro outroFiltro) : base(outroFiltro) { }

        public override IList<Conta> Filtra(IList<Conta> contas)
        {
            var filtrada = new List<Conta>();
            foreach (var conta in contas)
            {
                if (conta.Saldo < 100)
                {
                    filtrada.Add(conta);
                }
            }
            return filtrada.Concat(VerificaOutroFiltro(contas)).ToList();
        }
    }
}
