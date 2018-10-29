using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.Template_Method.Exercício___Relatórios
{
    public abstract class TemplateDeRelatorio
    {
        public string ImprimeRelatorio(IList<Conta> contas)
        {
            return $"CABEÇALHO\n{Cabecalho()}" +
                $"\n\nCORPO\n{ GeraCorpo(contas) }" +
                $"\n\nRODAPÉ\n{Rodape()}";
        }

        protected string GeraCorpo(IList<Conta> contas)
        {
            string corpo = "";
            foreach (var conta in contas) { corpo += Corpo(conta); }
            return corpo;
        }

        protected abstract string Cabecalho();
        protected abstract string Corpo(Conta conta);
        protected abstract string Rodape();
    }
}
