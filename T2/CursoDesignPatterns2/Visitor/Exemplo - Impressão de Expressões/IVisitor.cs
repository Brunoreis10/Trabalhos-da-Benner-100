using CursoDesignPatterns2.Interpreter.Exemplo___Calculadora;
using CursoDesignPatterns2.Interpreter.Exercício___Raiz_Quadrada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns2.Visitor.Exemplo___Impressão_de_Expressões
{
    public interface IVisitor
    {
        void VisitaSoma(Soma soma);
        void VisitaSubtracao(Subtracao subtracao);
        void VisitaNumero(Numero numero);
        void VisitaRaizQuadrada(RaizQuadrada raizquadrada);
        void VisitaMultiplicacao(Multiplicacao multiplicacao);
        void VisitaDivisao(Divisao divisao);
    }
}
