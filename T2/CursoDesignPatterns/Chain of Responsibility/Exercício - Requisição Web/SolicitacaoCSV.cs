using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.Chain_of_Responsibility.Exercício___Requisição_Web
{
    public class SolicitacaoCSV : ISolicitacao
    {
        public ISolicitacao Proxima { get; private set; }
        public SolicitacaoCSV(ISolicitacao proxima)
        {
            Proxima = proxima;
        }

        public string Solicitacao(Conta conta, Requisicao requisicao)
        {          
            if (requisicao.Formato.Equals(Formato.CSV))
            {
                return $"{conta.Titular};{conta.Saldo}";
            }
            return Proxima != null ? Proxima.Solicitacao(conta, requisicao) : "nulo";
        }
    }
}
