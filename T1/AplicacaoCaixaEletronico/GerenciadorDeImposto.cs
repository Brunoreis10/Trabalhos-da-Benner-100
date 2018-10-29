using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Benner.AplicacaoCaixaEletronico.Interfaces;

namespace Benner.AplicacaoCaixaEletronico.Processamento
{
    class GerenciadorDeImposto
    {
        public double Total { get; private set; }

        public void Adiciona(ITributavel tributavel)
        {
            this.Total += tributavel.CalculaTributos();
        }
    }
}
