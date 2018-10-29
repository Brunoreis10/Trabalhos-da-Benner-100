using System;

namespace Caelum.Leilao
{

    public class Lance
    {
        public Usuario Usuario { get; private set; }
        public double Valor { get; private set; }

        public Lance(Usuario usuario, double valor)
        {
            if (valor <= 0) throw new ArgumentException("O lance deve ter um valor maior que zero.");
            Usuario = usuario;
            Valor = valor;
        }
    }
}