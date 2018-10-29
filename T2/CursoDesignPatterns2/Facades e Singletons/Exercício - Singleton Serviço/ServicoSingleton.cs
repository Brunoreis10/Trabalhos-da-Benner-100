using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns2.Facades_e_Singletons.Exercício___Singleton_Serviço
{
    public class ServicoSingleton
    {
        private static Servico instancia = new Servico();

        public Servico Instancia
        {
            get
            {
                return instancia;
            }
        }
    }
}
