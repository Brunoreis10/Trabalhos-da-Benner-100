using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexEmCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Regex.Replace("Alura", @"[Aa]", "*"));

            Console.WriteLine(Regex.Replace("2007-12-31", @"[-]", "/"));

            var match = Regex.Match("2007-12-31", @"(\d{4})(-)(\d\d)(-)(\d\d)");

            Console.WriteLine($"{match.Groups[5]}{match.Groups[4]}{match.Groups[3]}{match.Groups[2]}{match.Groups[1]}".Replace("-","/"));

            Console.ReadKey();
        }

        private static void Exercicio1Data()
        {
            var match = Regex.Match("2007-12-31", @"(\d{4})-(\d\d)-(\d\d)");

            Console.WriteLine($"{match.Groups[3]}/{match.Groups[2]}/{match.Groups[1]}");

            Console.ReadKey();
        }

        private static void RegexEmCSharp()
        {
            string target = "11a22b33c";
            var regex = new Regex(@"(\d\d)(\w)");

            //Match individual - Match():
            var match = regex.Match(target);

            Console.WriteLine($"{match.Groups[0].Value} - {match.Groups[1].Value} - {match.Groups[2].Value} - {match.Groups.Count}"); //Array dos grupos do match, se houverem.
            Console.WriteLine(match.Value); // Valor do match.
            Console.WriteLine(match.Index); // Posição inicial.
            Console.WriteLine(match.Length); //Tamanho.

            //Todos os matches - Matches():
            var matches = regex.Matches(target);
            foreach (Match _match in matches)
            {
                Console.WriteLine($"{_match.Groups[0].Value} - {_match.Groups[1].Value} - {_match.Groups[2].Value} - {_match.Groups.Count}");

                Console.WriteLine(_match.Value);
                Console.WriteLine(_match.Index);
                Console.WriteLine(_match.Length);
            }

            Console.ReadKey();
        }
    }
}
