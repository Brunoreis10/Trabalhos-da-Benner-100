using CursoDesignPatterns.Builder.Exemplo___Nota_Fiscal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.Builder.Exercício___Builder_de_Itens
{
    public class ItemDaNotaBuilder
    {
        public string Nome { get; set; }
        public double Valor { get; set; }

        public ItemDaNotaBuilder ComNome(string nome)
        {
            Nome = nome;
            return this;
        }
        public ItemDaNotaBuilder ComValor(double valor)
        {
            Valor = valor;
            return this;
        }
        public ItemDaNota Constroi()
        {
            return new ItemDaNota(Nome, Valor);
        }
    }
}
