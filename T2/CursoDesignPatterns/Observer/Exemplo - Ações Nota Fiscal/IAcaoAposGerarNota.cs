using CursoDesignPatterns.Builder.Exemplo___Nota_Fiscal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.Observer.Exemplo___Ações_Nota_Fiscal
{
    public interface IAcaoAposGerarNota
    {
        void Executa(NotaFiscal notaFiscal);
    }
}
