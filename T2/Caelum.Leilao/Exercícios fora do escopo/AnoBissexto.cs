using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    public class AnoBissexto
    {
        public bool EhBissexto(int ano)
        {
            return ((ano % 4 == 0) && !(ano % 100 == 0 && !(ano % 400 == 0)));
        }
    }
}
