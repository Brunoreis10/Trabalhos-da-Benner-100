using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Infraestrutura.Binding
{
    public class ActionBindInfo
    {
        public MethodInfo MethodInfo { get; private set; }
        public IReadOnlyCollection<ArgumentoNomeValor> ArgumentosNomeValor { get; private set; }

        public ActionBindInfo(MethodInfo methodInfo, IEnumerable<ArgumentoNomeValor> argumentosNomeValor)
        {
            MethodInfo = methodInfo ?? throw new ArgumentNullException(nameof(methodInfo));

            if (argumentosNomeValor == null) throw new ArgumentNullException(nameof(argumentosNomeValor));

            ArgumentosNomeValor = new ReadOnlyCollection<ArgumentoNomeValor>(argumentosNomeValor.ToList());
        }

        public object Invoke(object controller)
        {
            var qtdArgumentos = ArgumentosNomeValor.Count;
            var temArgumentos = qtdArgumentos > 0;

            if (!temArgumentos)
                return MethodInfo.Invoke(controller, new object[0]);

            var parametrosInvoke = new object[qtdArgumentos];
            var parametrosInfo = MethodInfo.GetParameters();

            for (int i = 0; i < qtdArgumentos; i++)
            {
                var parametro = parametrosInfo[i];

                var argumento = ArgumentosNomeValor.Single(a => a.Nome == parametro.Name);

                parametrosInvoke[i] = Convert.ChangeType(argumento.Valor, parametro.ParameterType);
            }

            return MethodInfo.Invoke(controller, parametrosInvoke);
        }
    }
}
