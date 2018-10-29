using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CursoDesignPatterns2.Visitor.Exemplo___Impressão_de_Expressões;

namespace CursoDesignPatterns2.Interpreter.Exemplo___Calculadora
{
    public class Soma : IExpressao
    {
        public IExpressao Esquerda { get; private set; }
        public IExpressao Direita { get; private set; }
        public Soma(IExpressao esquerda, IExpressao direita)
        {
            Esquerda = esquerda;
            Direita = direita;
        }

        public int Avalia()
        {
            return Esquerda.Avalia() + Direita.Avalia();
        }

        public void Aceita(IVisitor impressora)
        {
            impressora.VisitaSoma(this);
        }
    }
}
