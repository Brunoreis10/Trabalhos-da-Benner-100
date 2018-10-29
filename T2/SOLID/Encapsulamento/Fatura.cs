using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Encapsulamento
{
    public class EFatura
    {
        public string Cliente { get; private set; }
        public double Valor { get; set; }
        public IList<Pagamento> Pagamentos { get; private set; }
        public bool Pago { get; set; }

        public EFatura(string cliente, double valor)
        {
            Cliente = cliente;
            Valor = valor;
            Pagamentos = new List<Pagamento>();
            Pago = false;
        }

        public void AdicionaPagamento(Pagamento pagamento)
        {
            Pagamentos.Add(pagamento);

            if (TotalPagamentos() >= Valor) Pago = true;
        }

        private double TotalPagamentos()
        {
            double totalPagamentos = 0;
            foreach (var pagamento in Pagamentos)
            {
                totalPagamentos += pagamento.Valor;
            }
            return totalPagamentos;
        }
    }
}
