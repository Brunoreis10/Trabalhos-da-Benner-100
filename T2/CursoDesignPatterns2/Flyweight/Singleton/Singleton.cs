using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns2.Flyweight.Singleton
{
    public class Singleton
    {
        private static Singleton instancia;

        private Singleton() { Console.WriteLine("Testando singleton."); }

        public static Singleton Instancia { get { return instancia == null ? new Singleton() : instancia; } }        
    }
}
