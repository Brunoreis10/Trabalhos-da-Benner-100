using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns2.Command.Exemplo___Pedidos
{
    public class PagaPedido : IComando
    {
        public Pedido Pedido { get; private set; }

        public PagaPedido(Pedido pedido)
        {
            Pedido = pedido;
        }

        public void Executa()
        {
            Pedido.Paga();
            Console.WriteLine($"Pagando pedido do cliente {Pedido.Cliente}");
        }
    }
}
