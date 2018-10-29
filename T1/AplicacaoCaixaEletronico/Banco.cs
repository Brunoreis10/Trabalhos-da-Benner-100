using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Benner.AplicacaoCaixaEletronico.Contas;

namespace Benner.AplicacaoCaixaEletronico.Processamento
{
    class Banco
    {
        public List<Conta> Contas { get; private set; }

        public Banco()
        {
            this.Contas = new List<Conta>();
        }

        public void Adiciona(Conta conta)
        {
            this.Contas.Add(conta);
        }

        public void Remove(Conta conta)
        {
            this.Contas.Remove(conta);
            Conta.RemoveConta();
        }
    }
}
