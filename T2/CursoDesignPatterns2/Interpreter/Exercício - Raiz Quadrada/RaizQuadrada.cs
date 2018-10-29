using CursoDesignPatterns2.Interpreter.Exemplo___Calculadora;
using CursoDesignPatterns2.Visitor.Exemplo___Impressão_de_Expressões;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns2.Interpreter.Exercício___Raiz_Quadrada
{
    public class RaizQuadrada : IExpressao
    {
        public IExpressao Numero { get; set; }

        public RaizQuadrada(IExpressao numero)
        {
            Numero = numero;
        }        

        public int Avalia()
        {
            return (int)Math.Sqrt(Numero.Avalia());
        }

        public void Aceita(IVisitor impressora)
        {
            impressora.VisitaRaizQuadrada(this);
        }
    }
}
