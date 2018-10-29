using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns2.Memento.Exemplo___Contratos
{
    public class Estado
    {
        public Contrato Contrato { get; private set; }
        public DateTime AdicionadoEm { get; private set; }

        public Estado(Contrato contrato)
        {
            Contrato = contrato;
            AdicionadoEm = DateTime.Now;
        }
    }
}
