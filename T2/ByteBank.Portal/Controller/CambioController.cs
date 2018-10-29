using ByteBank.Portal.Infraestrutura;
using ByteBank.Service;
using ByteBank.Service.Cambio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Controller
{
    public class CambioController : ControllerBase
    {
        private ICambioService _cambioService;

        public CambioController()
        {
            _cambioService = new CambioTesteService();
        }

        public string MXN()
        {
            return View().Replace("VALOR_EM_BRL", _cambioService.Calcular("MXN", "BRL", 3).ToString());
        }

        public string USD()
        {
            return View().Replace("VALOR_EM_BRL", _cambioService.Calcular("USD", "BRL", 3).ToString());
        }

        public string Calculo(string moedaOrigem, string moedaDestino, decimal valor)
        {
            return View()
                .Replace("VALOR_MOEDA_ORIGEM", valor.ToString())
                .Replace("MOEDA_ORIGEM", moedaOrigem)
                .Replace("VALOR_MOEDA_DESTINO", _cambioService.Calcular(moedaOrigem, moedaDestino, valor).ToString())
                .Replace("MOEDA_DESTINO", moedaDestino);
        }

        public string Calculo(string moedaDestino, decimal valor) => Calculo("BRL", moedaDestino, valor);

        public string Calculo(string moedaDestino) => Calculo("BRL", moedaDestino, 1);

        public string Calculo(string moedaOrigem, string moedaDestino) => Calculo(moedaOrigem, moedaDestino, 1);

        public string Calculo() => Calculo("BRL", "USD", 1);
    }
}
