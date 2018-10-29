using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Acoplamento
{
    public class GeradorDeNotaFiscal
    {
        public IList<IAcaoAposGerarNota> Acoes { get; private set; }

        public GeradorDeNotaFiscal(IList<IAcaoAposGerarNota> acoes)
        {
            Acoes = acoes;
        }

        public NotaFiscal Gera(Fatura fatura)
        {

            double valor = fatura.ValorMensal;

            NotaFiscal nf = new NotaFiscal(valor, ImpostoSimplesSobreO(valor));

            foreach (var acao in Acoes)
            {
                acao.Executa(nf);
            }

            return nf;
        }

        private double ImpostoSimplesSobreO(double valor)
        {
            return valor * 0.06;
        }
    }
}
