using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns2.Bridges.Exemplo___Mensagens
{
    public class MensagemCliente : IMensagem
    {
        public string Nome { get; private set; }
        public IEnviador Enviador { get; private set; }

        public MensagemCliente(string nome, IEnviador enviador)
        {
            Nome = nome;
            Enviador = enviador;
        }

        public void Envia()
        {
            Enviador.Envia(this);
        }

        public string Formata()
        {
            return $"Enviando mensagem para o cliente {Nome}:";
        }
    }
}
