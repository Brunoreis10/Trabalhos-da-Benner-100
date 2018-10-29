using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.Chain_of_Responsibility.Exercício___Requisição_Web
{
    public interface ISolicitacao
    {
        //ISolicitacao Proxima { get; set; }
        string Solicitacao(Conta conta, Requisicao requisicao);
    }
}
