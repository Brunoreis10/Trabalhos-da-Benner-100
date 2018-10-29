using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Infraestrutura.Binding
{
    public class ActionBinder
    {
        public ActionBindInfo ObterActionBindInfo(object controller, string path)
        {
            // /Cambio/Calculo?moedaOrigem=BRL&moedaDestino=USD&valor=10
            // /Cambio/Calculo?moedaDestino=USD&moedaOrigem=BRL&valor=10
            // /Cambio/Calculo?valor=10&moedaOrigem=BRL&moedaDestino=USD
            // /Cambio/Calculo?moedaDestino=USD&valor=10

            var indexInterrogacao = path.IndexOf('?');
            var temInterrogacao = (indexInterrogacao >= 0);

            if (!temInterrogacao)
            {
                var nomeAction = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries)[1];
                var methodInfo = controller.GetType().GetMethod(nomeAction);
                return new ActionBindInfo(methodInfo, Enumerable.Empty<ArgumentoNomeValor>());
            }
            else
            {
                var nomeControllereActionSemParametros = path.Substring(0, indexInterrogacao);
                var nomeAction = nomeControllereActionSemParametros.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries)[1];
                var queryString = path.Substring(indexInterrogacao + 1);
                var argumentosNomeValor = ObterArgumentoNomeValores(queryString);
                var nomeArgumentos = argumentosNomeValor.Select(a => a.Nome).ToArray();
                var methodInfo = MethodInfoComArgumentos(nomeAction, nomeArgumentos, controller);

                return new ActionBindInfo(methodInfo, argumentosNomeValor);
            }
        }

        private IEnumerable<ArgumentoNomeValor> ObterArgumentoNomeValores(string queryString)
        {
            var argumentosSeparados = queryString.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var argumento in argumentosSeparados)
            {
                var nomeEValorArgumento = argumento.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                yield return new ArgumentoNomeValor(nomeEValorArgumento[0], nomeEValorArgumento[1]);
            }
        }

        private MethodInfo MethodInfoComArgumentos(string nomeAction, string[] argumentos, object controller)
        {
            var bindingFlags = BindingFlags.Instance |
                    BindingFlags.Static |
                    BindingFlags.Public |
                    BindingFlags.DeclaredOnly;

            var metodos = controller.GetType().GetMethods(bindingFlags);
            var argumentosCount = argumentos.Length;

            var sobrecargas = metodos.Where(m => m.Name.Equals(nomeAction));

            foreach (var sobrecarga in sobrecargas)
            {
                var parametros = sobrecarga.GetParameters();

                if (argumentosCount != parametros.Length) continue;

                var argumentosBatem = parametros.All(p => argumentos.Contains(p.Name));

                if (argumentosBatem)
                {
                    return sobrecarga;
                }
            }

            throw new ArgumentException($"Sobrecarga do método {nomeAction} não encontrada.");
        }
    }
}
