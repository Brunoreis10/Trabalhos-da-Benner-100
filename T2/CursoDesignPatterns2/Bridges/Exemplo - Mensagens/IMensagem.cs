using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns2.Bridges.Exemplo___Mensagens
{
    public interface IMensagem
    {
        IEnviador Enviador { get; }

        void Envia();

        string Formata();
    }
}
