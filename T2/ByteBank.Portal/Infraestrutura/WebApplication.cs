using ByteBank.Portal.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Infraestrutura
{
    public class WebApplication
    {
        private readonly string[] _prefixos;

        public WebApplication(string[] prefixos)
        {
            _prefixos = prefixos ?? throw new ArgumentNullException(nameof(prefixos));
        }

        public void Iniciar()
        {
            while (true)
                ManipularRequisicao();
        }

        private void ManipularRequisicao()
        {
            var httpListener = new HttpListener();

            foreach (var prefixo in _prefixos)
                httpListener.Prefixes.Add(prefixo);

            httpListener.Start();

            var contexto = httpListener.GetContext();
            var requisicao = contexto.Request;
            var resposta = contexto.Response;
            var path = requisicao.Url.PathAndQuery;    

            if (Utilidades.VerificaArquivo(path))
            {
                new ManipuladorRequisicaoArquivo().Manipular(resposta, path);
            }
            else
                new ManipuladorRequisicaoController().Manipular(resposta, path);
            
            httpListener.Stop();
        }
    }
}
