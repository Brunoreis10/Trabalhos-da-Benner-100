using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns
{
    public interface IInvestimento
    {
        double Calcula(Conta conta);
    }
}
