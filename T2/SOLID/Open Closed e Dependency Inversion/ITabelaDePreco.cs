using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Open_Closed_e_Dependency_Inversion
{
    public interface ITabelaDePreco
    {
        double DescontoPara(double valor);
    }
}
