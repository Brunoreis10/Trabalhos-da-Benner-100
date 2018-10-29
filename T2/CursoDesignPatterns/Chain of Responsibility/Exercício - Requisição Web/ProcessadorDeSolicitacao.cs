using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.Chain_of_Responsibility.Exercício___Requisição_Web
{
    public class ProcessadorDeSolicitacao
    {
        public string Processa(Conta conta, Requisicao requisicao)
        {
            var solicitacoes = new SolicitacaoCSV(new SolicitacaoPorcento(new SolicitacaoXML(null)));
                        
            return solicitacoes.Solicitacao(conta, requisicao);
        }
    }
}
