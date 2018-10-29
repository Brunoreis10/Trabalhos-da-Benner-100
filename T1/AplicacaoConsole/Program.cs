using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace AplicacaoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //string texto = Console.ReadLine();
            //while (texto != null)
            //{
            //    Console.WriteLine(texto);
            //    texto = Console.ReadLine();
            //}

            //^ Solução simples básica para o exercício.
            //v Solução proposta pelo curso.
            using (TextReader leitor = Console.In)
            using (TextWriter escritor = Console.Out)
            {
                string texto = leitor.ReadLine();
                while (texto != null)
                {
                    escritor.WriteLine(texto);
                    texto = leitor.ReadLine();
                }
            }
        }
    }
}
