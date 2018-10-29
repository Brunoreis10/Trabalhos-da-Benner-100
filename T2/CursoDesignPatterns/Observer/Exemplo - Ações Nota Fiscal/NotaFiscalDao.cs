using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CursoDesignPatterns.Builder.Exemplo___Nota_Fiscal;

namespace CursoDesignPatterns.Observer.Exemplo___Ações_Nota_Fiscal
{
    public class NotaFiscalDao : IAcaoAposGerarNota
    {
        public void Executa(NotaFiscal notaFiscal)
        {
            Console.WriteLine("Simulador de BD");
        }
    }
}
