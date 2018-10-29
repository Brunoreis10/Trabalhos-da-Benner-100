using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.Template_Method.Exercício___Relatórios
{
    public class RelatorioComplexo : TemplateDeRelatorio
    {
        protected override string Cabecalho()
        {
            return "Banco que não existe\nRua dos Bobos, 0\n(47) 3333-0000";
        }

        protected override string Corpo(Conta conta)
        {
            return $"{conta.Titular}\n{conta.Agencia}\n{conta.Numero}\n{conta.Saldo}\n";
        }

        protected override string Rodape()
        {
            return "email@do.banco\n01/01/2001";
        }
    }
}
