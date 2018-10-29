using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.Template_Method.Exercício___Relatórios
{
    public class RelatorioSimples : TemplateDeRelatorio
    {
        protected override string Cabecalho()
        {
            return "Banco que não existe";
        }

        protected override string Corpo(Conta conta)
        {
            return $"{conta.Titular}\n{conta.Saldo}\n";
        }

        protected override string Rodape()
        {
            return "(47) 3333-0000";
        }
    }
}
