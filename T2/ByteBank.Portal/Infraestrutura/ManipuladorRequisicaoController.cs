using ByteBank.Portal.Infraestrutura.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Infraestrutura
{
    public class ManipuladorRequisicaoController
    {
        private readonly ActionBinder _actionBinder = new ActionBinder();

        public void Manipular(HttpListenerResponse resposta, string path)
        {
            var caminhoDividido = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            var controllerAssembly = $"ByteBank.Portal.Controller.{caminhoDividido[0]}Controller";
            var action = caminhoDividido[1];

            var controllerWrapper = Activator.CreateInstance("ByteBank.Portal", controllerAssembly, new object[0]);
            var controller = controllerWrapper.Unwrap();

            var methodInfo = _actionBinder.ObterActionBindInfo(controller, path);

            var resultadoAction = (string)methodInfo.Invoke(controller);

            var bufferArquivo = Encoding.UTF8.GetBytes(resultadoAction);

            resposta.StatusCode = 200;
            resposta.ContentType = "text/html; charset=utf-8";
            resposta.ContentLength64 = bufferArquivo.Length;

            resposta.OutputStream.Write(bufferArquivo, 0, bufferArquivo.Length);
            resposta.OutputStream.Close();
        }
    }
}
