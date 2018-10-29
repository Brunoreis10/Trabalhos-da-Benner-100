using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.State.Exemplo___Estados_Orçamento
{
    public class Finalizado : IEstadoDeUmOrcamento
    {
        public bool DescontoAplicado { get; set; }

        public void AplicaDescontoExtra(Orcamento orcamento)
        {
            throw new Exception("Orçamentos finalizados não recebem desconto.");
        }

        public void Aprova(Orcamento orcamento)
        {
            throw new Exception("Orçamento já finalizado");
        }

        public void Finaliza(Orcamento orcamento)
        {
            throw new Exception("Orçamento já finalizado");
        }

        public void Reprova(Orcamento orcamento)
        {
            throw new Exception("Orçamento já finalizado");
        }
    }
}
