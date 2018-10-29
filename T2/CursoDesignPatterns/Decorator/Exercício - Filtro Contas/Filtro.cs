using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.Decorator.Exercício___Filtro_Contas
{
    public abstract class Filtro
    {
        public Filtro OutroFiltro { get; set; }

        public Filtro()
        {
            OutroFiltro = null;
        }

        public Filtro(Filtro outroFiltro)
        {
            OutroFiltro = outroFiltro;
        }

        public abstract IList<Conta> Filtra(IList<Conta> contas);

        protected IList<Conta> VerificaOutroFiltro(IList<Conta> contas)
        {
            var vazio = new List<Conta>();
            return OutroFiltro == null ? vazio : OutroFiltro.Filtra(contas);
        }
    }
}
