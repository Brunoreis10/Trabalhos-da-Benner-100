using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    public class LeilaoTDBuilder
    {
        private Leilao leilao;

        public LeilaoTDBuilder NovoLeilaoDe(string descricao)
        {
            leilao = new Leilao(descricao);
            return this;
        }

        public LeilaoTDBuilder comLance(Usuario usuario, double valor)
        {
            leilao.Propoe(new Lance(usuario, valor));
            return this;
        }

        public Leilao Constroi()
        {
            return leilao;
        }
    }
}
