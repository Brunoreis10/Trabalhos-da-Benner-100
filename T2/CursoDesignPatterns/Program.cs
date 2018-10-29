using CursoDesignPatterns.Builder.Exemplo___Nota_Fiscal;
using CursoDesignPatterns.Builder.Exercício___Builder_de_Itens;
using CursoDesignPatterns.Chain_of_Responsibility.Exemplo___Descontos;
using CursoDesignPatterns.Chain_of_Responsibility.Exercício___Requisição_Web;
using CursoDesignPatterns.Decorator.Exemplo___Impostos_Compostos;
using CursoDesignPatterns.Decorator.Exercício___Filtro_Contas;
using CursoDesignPatterns.Observer.Exemplo___Ações_Nota_Fiscal;
using CursoDesignPatterns.Observer.Exercício___Ação_Multiplicador;
using CursoDesignPatterns.Template_Method.Exemplo___Novos_Impostos;
using CursoDesignPatterns.Template_Method.Exercício___Relatórios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns
{
    public class Program
    {
        static void Main(string[] args)
        {
            var acoes = new List<IAcaoAposGerarNota>()
            {
                new Multiplicador(3.5),
                new EnviadorDeSms(),
                new EnviadorDeEmail(),
                new NotaFiscalDao()
            };

            var nf = new NotaFiscalBuilder(acoes)
            .ParaEmpresa("MatrixMax")
            .ComCnpj("12.345.678.0001-12")
            .Com(new ItemDaNota("Banana", 30))
            .Com(new ItemDaNota("Amendoim", 20))
            .ComObservacao("Comprei bananas e amendoins.")
            .Constroi();

            Console.ReadKey();
        }

        private static void TestaObserverMultiplicador()
        {
            var nf = new NotaFiscalBuilder()
            .ParaEmpresa("MatrixMax")
            .ComCnpj("12.345.678.0001-12")
            .Com(new ItemDaNota("Banana", 30))
            .Com(new ItemDaNota("Amendoim", 20))
            .ComObservacao("Comprei bananas e amendoins.")
            .ComAcaoPosterior(new Multiplicador(3))
            .Constroi();

            Console.ReadKey();
        }

        private static void TestaObserverAcaoAposNota()
        {
            var nf = new NotaFiscalBuilder()
                .ParaEmpresa("MatrixMax")
                .ComCnpj("12.345.678.0001-12")
                .Com(new ItemDaNota("Banana", 30))
                .Com(new ItemDaNota("Amendoim", 20))
                .ComObservacao("Comprei bananas e amendoins.")
                .ComAcaoPosterior(new EnviadorDeEmail())
                .ComAcaoPosterior(new EnviadorDeSms())
                .ComAcaoPosterior(new NotaFiscalDao())
                .Constroi();

            Console.ReadKey();
        }

        private static void TestaDataOpcionalEDefaultNoNotaFiscalBuilder()
        {
            var nf = new NotaFiscalBuilder()
                .ParaEmpresa("MatrixMax")
                .ComCnpj("12.345.678.0001-12")
                .Com(new ItemDaNota("Banana", 30))
                .Com(new ItemDaNota("Amendoim", 20))
                .ComObservacao("Comprei bananas e amendoins.")
                .Constroi();

            Console.WriteLine($"{nf.DataDeEmissao.ToShortDateString()}\n{nf.ValorBruto} - {nf.Impostos}");
            foreach (var item in nf.Itens)
            {
                Console.WriteLine(item.Nome);
            }
            Console.WriteLine(nf.Observavoes);

            var nf2 = new NotaFiscalBuilder()
                .NaData(new DateTime(2000, 01, 01))
                .ParaEmpresa("MatrixMax")
                .ComCnpj("12.345.678.0001-12")
                .Com(new ItemDaNota("Ovo", 10))
                .Com(new ItemDaNota("Farinha", 5))
                .ComObservacao("Comprei ovos e farinha.")
                .Constroi();

            Console.WriteLine($"{nf2.DataDeEmissao.ToShortDateString()}\n{nf2.ValorBruto} - {nf2.Impostos}");
            foreach (var item in nf2.Itens)
            {
                Console.WriteLine(item.Nome);
            }
            Console.WriteLine(nf2.Observavoes);

            Console.ReadKey();
        }

        private static void TestaItemDaNotaBuilder()
        {
            var item = new ItemDaNotaBuilder()
                .ComNome("Item 1")
                .ComValor(33)
                .Constroi();

            Console.WriteLine(item.Nome + "\n" + item.Valor);

            Console.ReadKey();
        }

        private static void TestaNotaFiscalBuilder()
        {
            var nf = new NotaFiscalBuilder()
                            .ParaEmpresa("MatrixMax")
                            .ComCnpj("12.345.678.0001-12")
                            //.NaDataAtual() <- Substituído no exercício.
                            .Com(new ItemDaNota("Banana", 30))
                            .Com(new ItemDaNota("Amendoim", 20))
                            .ComObservacao("Comprei bananas e amendoins.")
                            .Constroi();

            Console.WriteLine($"{nf.DataDeEmissao.ToShortDateString()}\n{nf.ValorBruto} - {nf.Impostos}");
            foreach (var item in nf.Itens)
            {
                Console.WriteLine(item.Nome);
            }
            Console.WriteLine(nf.Observavoes);

            Console.ReadKey();
        }

        private static void TestaStatesEstadoSaldoConta()
        {
            var conta = new Conta();
            conta.Deposita(100);
            Console.WriteLine(conta.Saldo);

            conta.Saca(100);
            Console.WriteLine(conta.Saldo);

            conta.Deposita(3);
            Console.WriteLine(conta.Saldo);

            conta.Saca(1);
            Console.WriteLine(conta.Saldo);

            //conta.Saca(0.1); <- Joga exceção :)

            Console.ReadKey();
        }

        private static void TestaStateEstadosOrcamento()
        {
            var reforma = new Orcamento(500);

            Console.WriteLine(reforma.Valor);

            reforma.AplicaDescontoExtra();
            reforma.AplicaDescontoExtra();

            Console.WriteLine(reforma.Valor);

            reforma.Aprova();

            reforma.AplicaDescontoExtra();

            Console.WriteLine(reforma.Valor);

            reforma.Finaliza();

            //reforma.AplicaDescontoExtra(); -> Joga exceção.

            Console.ReadKey();
        }

        private static void TestaDecoratorFiltrosContas()
        {
            var contas = new List<Conta>()
            {
                new Conta("Conta 1", 1234, 56789, new DateTime(2018, 07, 09)),
                new Conta("Conta 2", 1002, 58673, new DateTime(1999, 01, 01)),
                new Conta("Conta 3", 3020, 09573, new DateTime(2018, 08, 07)),
                new Conta("Conta 4", 1234, 56789, new DateTime(1999, 01, 01)),
                new Conta("Conta 5", 1002, 58673, new DateTime(1999, 01, 01)),
                new Conta("Conta 6", 3020, 09573, new DateTime(1999, 01, 01)),
                new Conta("Conta 7", 1234, 56789, new DateTime(1999, 01, 01)),
                new Conta("Conta 8", 1002, 58673, new DateTime(1999, 01, 01)),
                new Conta("Conta 9", 3020, 09573, new DateTime(1999, 01, 01))
            };

            foreach (var conta in contas)
            {
                if (conta.Titular.Equals("Conta 6")) conta.Deposita(510000);
                else if (!(conta.Titular.Equals("Conta 8") || conta.Titular.Equals("Conta 9"))) conta.Deposita(500);
            }

            var filtro = new FiltroContaAbertaNoMesCorrente(new FiltroSaldoMaiorQueQuinhentosMilReais(new FiltroSaldoMenorQueCemReais()));

            var filtradas = filtro.Filtra(contas);

            foreach (var conta in filtradas)
            {
                Console.WriteLine(conta.Titular);
            }

            Console.ReadKey();
        }

        private static void TestaDecoratorIKCVeICPP()
        {
            var impostoComplexo = new D_IKCV(new D_ICPP());

            Orcamento orcamento = new Orcamento(501);
            orcamento.AdicionaItem(new Item("Item", 101));

            Console.WriteLine(impostoComplexo.Calcula(orcamento));

            Console.ReadKey();
        }

        private static void TestaTemplateMethodRelatorios()
        {
            var contas = new List<Conta>()
            {
                new Conta("Joãozinho", 1234, 56789),
                new Conta("Pedrinho", 1002, 58673),
                new Conta("Mariazinha", 3020, 09573)
            };

            int i = 1;
            foreach (var conta in contas)
            {
                conta.Deposita(++i * 100);
            }

            Console.WriteLine(new RelatorioComplexo().ImprimeRelatorio(contas));

            Console.ReadKey();
        }

        private static void TestaTemplateMethodImpostoIHIT()
        {
            var orcamento = new Orcamento(100);
            orcamento.AdicionaItem(new Item("Item", 1));
            orcamento.AdicionaItem(new Item("Itex", 1));

            var calculador = new CalculadorDeImpostos();

            calculador.RealizaCalculo(orcamento, new IHIT());

            Console.ReadKey();
        }

        private static void TestaChainOfResponsibilityRequisicaoWeb()
        {
            Conta conta = new Conta("José");
            conta.Deposita(500);

            Requisicao req = new Requisicao(Formato.XML);

            var processador = new ProcessadorDeSolicitacao();

            Console.WriteLine(processador.Processa(conta, req));

            Console.ReadLine();
        }

        private static void TestaChainOfResponsibilityDescontos()
        {
            CalculadorDeDescontos calculador = new CalculadorDeDescontos();

            Orcamento orcamento = new Orcamento(200);
            orcamento.AdicionaItem(new Item("LaPiS", 100));
            orcamento.AdicionaItem(new Item("caneta", 100));

            double desconto = calculador.Calcula(orcamento);

            Console.WriteLine(desconto);

            Console.ReadKey();
        }

        private static void TestaStrategyImpostoEInvesitmento()
        {
            var iss = new ISS();
            var icms = new ICMS();
            var iccc = new ICCC();

            var orcamento = new Orcamento(500);

            var calculador = new CalculadorDeImpostos();

            calculador.RealizaCalculo(orcamento, icms);
            calculador.RealizaCalculo(orcamento, iss);
            calculador.RealizaCalculo(orcamento, iccc);

            Console.ReadKey();

            var conta = new Conta();
            conta.Deposita(500);

            var investidor = new RealizadorDeInvestimentos();

            var conservador = new Conservador();
            var moderado = new Moderado();
            var arrojado = new Arrojado();

            investidor.RealizaInvestimento(conta, conservador);
            investidor.RealizaInvestimento(conta, moderado);
            investidor.RealizaInvestimento(conta, arrojado);

            Console.ReadKey();
        }
    }
}
