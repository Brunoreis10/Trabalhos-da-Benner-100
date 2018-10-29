using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benner.AplicacaoCaixaEletronico.Processamento
{
    static class StringUtils
    {
        //                               v This antes do parâmetro é o que define um Extention Method.
        public static string Pluralizar(this string palavra)
        {
            if (palavra.EndsWith("s")) return palavra;
            else return palavra + "s";
        }

        public static int Somar(this int nro, int asomar)
        {
            return nro + asomar;
        }
    }
}
