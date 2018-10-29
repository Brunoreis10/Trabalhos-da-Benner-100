using SOLID.Acoplamento;
using SOLID.Encapsulamento;
using SOLID.Liskov_Substitutive_Principle;
using SOLID.Open_Closed_e_Dependency_Inversion;
using SOLID.Single_Responsibility_Principle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaComum conta1 = new ContaComum();
            conta1.Deposita(100);
            ContaComum conta2 = new ContaComum();
            conta2.Deposita(150);
            ContaEstudante conta3 = new ContaEstudante();
            conta3.Deposita(100.5);

            IList<ContaComum> contas = new List<ContaComum>()
            {
                conta1,
                conta2,
            };

            foreach (ContaComum conta in contas)
            {
                conta.SomaInvestimento();

                Console.WriteLine("Novo saldo: " + conta.Saldo);
            }

            Console.WriteLine("Milhas estudante: " + conta3.Milhas + "\nSaldo estudante: " + conta3.Saldo);

            Console.ReadKey();
        }

        private static void TestaEncapsulamentoExemploProcessadorDeBoletos()
        {
            var boletos = new List<Boleto>()
            {
                new Boleto(500),
                new Boleto(200),
                new Boleto(350)
            };

            var fatura = new EFatura("Fulano", 1000);

            var processador = new ProcessadorDeBoletos();

            processador.Processa(boletos, fatura);

            Console.WriteLine(fatura.Pago ? "Pagou." : "Não pagou.");
            Console.ReadKey();
        }

        private static void TestaDIPeOCPExemploCalculadoraDePrecos()
        {
            var calculadora = new CalculadoraDePrecos(new Frete(), new TabelaDePrecoPadrao());
            var compra = new Compra() { Cidade = "sao paulo", Valor = 1000 };
            Console.WriteLine("Preço final da compra: R$" + calculadora.Calcula(compra) + ",00.");
            Console.ReadKey();
        }

        private static void TestaAula2Acoplamento()
        {
            var acoes = new List<IAcaoAposGerarNota>()
            {
                new NotaFiscalDao(),
                new EnviadorDeEmail(),
                new EnviadorDeSMS()
            };

            var gerador = new GeradorDeNotaFiscal(acoes);
            var fatura = new Fatura(2000, "Fulano");
            var nf = gerador.Gera(fatura);
            Console.ReadKey();
        }

        private static void TestaSRPCalculadoraDeSalario()
        {
            var desenvolvedor = new Funcionario(new Desenvolvedor(new DezOuVintePorcento()), 2000);
            Console.WriteLine($"Um desenvolvedor com salário base de R${desenvolvedor.SalarioBase},00 receberá R${new CalculadoraDeSalario().Calcula(desenvolvedor)},00.");
            Console.ReadKey();
        }
    }
}