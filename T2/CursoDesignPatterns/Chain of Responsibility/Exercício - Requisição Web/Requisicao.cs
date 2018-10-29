using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.Chain_of_Responsibility.Exercício___Requisição_Web
{
    public enum Formato
    {
        XML,
        CSV,
        PORCENTO,
        OUTRO
    }
    public class Requisicao
    {        
        public Formato Formato { get; private set; }
        public Requisicao(Formato formato)
        {
            Formato = formato;
        }
    }
}
