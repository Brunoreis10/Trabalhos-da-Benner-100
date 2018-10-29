using CursoDesignPatterns.Builder.Exemplo___Nota_Fiscal;
using CursoDesignPatterns.Observer.Exemplo___Ações_Nota_Fiscal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.Observer.Exercício___Ação_Multiplicador
{
    public class Multiplicador : IAcaoAposGerarNota
    {
        public double Fator { get; private set; }
        public Multiplicador(double fator)
        {
            Fator = fator;
        }
        public void Executa(NotaFiscal notaFiscal)
        {
            Console.WriteLine($"{notaFiscal.ValorBruto}x{Fator}={notaFiscal.ValorBruto * Fator}");
        }
    }
}
