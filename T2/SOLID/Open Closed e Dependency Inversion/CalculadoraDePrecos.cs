using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Open_Closed_e_Dependency_Inversion
{
    public class CalculadoraDePrecos
    {
        public IServicoDeEntrega Entrega { get; private set; }
        public ITabelaDePreco Tabela { get; private set; }

        public CalculadoraDePrecos(IServicoDeEntrega entrega, ITabelaDePreco tabela)
        {
            Entrega = entrega;
            Tabela = tabela;
        }
        public double Calcula(Compra produto)
        {
            double desconto = Tabela.DescontoPara(produto.Valor);
            double frete = Entrega.Para(produto.Cidade);

            return produto.Valor * (1 - desconto) + frete;
        }
    }
}
