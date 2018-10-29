using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Infraestrutura
{
    public abstract class ControllerBase
    {
        protected string View([CallerMemberName]string view = null)
        {
            var controller = GetType().Name.Replace("Controller", null);
           
            var streamPagina = Assembly
                .GetExecutingAssembly()
                .GetManifestResourceStream($"ByteBank.Portal.View.{controller}.{view}.html");

            return new StreamReader(streamPagina).ReadToEnd();
        }
    }
}
