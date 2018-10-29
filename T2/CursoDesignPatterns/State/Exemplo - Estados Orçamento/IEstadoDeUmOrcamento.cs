using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.State.Exemplo___Estados_Orçamento
{
    public interface IEstadoDeUmOrcamento
    {
        void AplicaDescontoExtra(Orcamento orcamento);

        bool DescontoAplicado { get; set; }

        void Aprova(Orcamento orcamento);
        void Reprova(Orcamento orcamento);
        void Finaliza(Orcamento orcamento);
    }
}
