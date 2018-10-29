using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Infraestrutura
{
    public static class Utilidades
    {
        public static bool VerificaArquivo(string path)
        {
            return path
                .Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries)
                .Last()
                .Contains('.');
        }

        public static string PathParaAssembly(string path)
        {
            return $"ByteBank.Portal{path.Replace('/','.')}";
        }

        public static string TipoDeConteudo(string path)
        {
            if (path.EndsWith(".css"))
                return "text/css; charset=utf-8";
            if (path.EndsWith(".js"))
                return "application/js; charset=utf-8";
            if (path.EndsWith(".html"))
                return "text/html; charset=utf-8";
            throw new NotImplementedException("Extensão não prevista.");
        }
    }
}
