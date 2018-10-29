using CursoDesignPatterns2.Visitor.Exemplo___Impressão_de_Expressões;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns2.Interpreter.Exemplo___Calculadora
{
    public interface IExpressao
    {
        int Avalia();

        void Aceita(IVisitor impressora);
    }
}
