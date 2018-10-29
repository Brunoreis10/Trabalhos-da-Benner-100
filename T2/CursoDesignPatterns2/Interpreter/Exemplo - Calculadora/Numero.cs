using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CursoDesignPatterns2.Visitor.Exemplo___Impressão_de_Expressões;

namespace CursoDesignPatterns2.Interpreter.Exemplo___Calculadora
{
    public class Numero : IExpressao
    {
        public int Valor { get; private set; }
        public Numero(int numero)
        {
            Valor = numero;
        }

        public int Avalia()
        {
            return Valor;
        }

        public void Aceita(IVisitor impressora)
        {
            impressora.VisitaNumero(this);
        }
    }
}
