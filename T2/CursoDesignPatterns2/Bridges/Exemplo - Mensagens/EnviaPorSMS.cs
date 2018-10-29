using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns2.Bridges.Exemplo___Mensagens
{
    public class EnviaPorSMS : IEnviador
    {
        public void Envia(IMensagem mensagem)
        {
            Console.Write($"{mensagem.Formata()}\n\tMétodo - SMS.");
        }
    }
}
