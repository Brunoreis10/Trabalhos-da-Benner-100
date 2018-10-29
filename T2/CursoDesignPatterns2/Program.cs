using CursoDesignPatterns2.Adapter.Exemplo___XML_Cliente;
using CursoDesignPatterns2.Bridges.Exemplo___Mensagens;
using CursoDesignPatterns2.Command.Exemplo___Pedidos;
using CursoDesignPatterns2.Facades_e_Singletons.Exemplo___Fachada_Empresa;
using CursoDesignPatterns2.Factory.Exemplo___Conexão_BD;
using CursoDesignPatterns2.Flyweight.Exemplo___Notas_Musicais;
using CursoDesignPatterns2.Flyweight.Singleton;
using CursoDesignPatterns2.Interpreter.Exemplo___Calculadora;
using CursoDesignPatterns2.Interpreter.Exercício___Raiz_Quadrada;
using CursoDesignPatterns2.Memento.Exemplo___Contratos;
using CursoDesignPatterns2.Visitor.Exemplo___Impressão_de_Expressões;
using CursoDesignPatterns2.Visitor.Exercício___Visitor_Pré_fixo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CursoDesignPatterns2
{
    class Program 
    {
        static void Main(string[] args)
        {
            ExemploFacadeESingleton();
        }

        private static void ExemploFacadeESingleton()
        {
            var empresa = new EmpresaFacadeSingleton().Instancia;

            empresa.BuscaCliente("1234");
            empresa.CriaFatura(new Cliente(), 123.5);
            empresa.FazContato();
            empresa.GeraCobranca();

            //Simulação de utilização da FACHADA com a instância SINGLETON.

            Console.ReadKey();
        }

        private static void TestaExemploAdapterGeradorXML()
        {
            var cliente = new Cliente
            {
                Nome = "Zé Ninguém",
                Endereco = "Rua Tal, 3.",
                DataDeNascimento = DateTime.Now
            };

            Console.WriteLine(new GeradorDeXml().GeraXml(cliente));

            Console.ReadKey();
        }

        private static void TestaCommandExemploPedidos()
        {
            var fila = new FilaDeTrabalho();
            var pedido1 = new Pedido("José", 500.0);
            var pedido2 = new Pedido("Maria", 200.0);

            fila.Adiciona(new PagaPedido(pedido1));
            fila.Adiciona(new PagaPedido(pedido2));
            fila.Adiciona(new FinalizaPedido(pedido1));

            fila.Processa();

            Console.ReadKey();
        }

        private static void TestaBridgeExemploMensagensEEnviadores()
        {
            new MensagemAdministrativa("Fulano", new EnviaPorSMS()).Envia();

            Console.ReadKey();
        }

        private static void TestaVisitorExercicioImpressoraPreFixa()
        {
            var esquerda = new Soma(new Soma(new Numero(1), new Numero(100)), new Numero(10)); // (1+100) + 10 = 111
            var direita = new Subtracao(new Numero(20), new Numero(10)); // 20 - 10 = 10
            var soma = new Soma(esquerda, direita); // 111 + 10 = 121

            var impressora = new ImpressoraPreFixaVisitor();
            soma.Aceita(impressora); //Imprime expressão.
            Console.WriteLine($" = {soma.Avalia()}."); //Imprime resultado.

            Console.ReadKey();
        }

        private static void TestaVisitorExemploCalculadora()
        {
            var esquerda = new Soma(new Soma(new Numero(1), new Numero(100)), new Numero(10)); // (1+100) + 10 = 111
            var direita = new Subtracao(new Numero(20), new Numero(10)); // 20 - 10 = 10
            var soma = new Soma(esquerda, direita); // 111 + 10 = 121

            var impressora = new ImpressoraVisitor();
            soma.Aceita(impressora); //Imprime expressão.
            Console.WriteLine($" = {soma.Avalia()}."); //Imprime resultado.

            var multiplicacao = new Multiplicacao(new Subtracao(new RaizQuadrada(new Numero(9)), new Numero(2)), new Divisao(new Numero(6), new Numero(3))); // (((√9)-2)*(6/3))
            multiplicacao.Aceita(impressora);
            Console.WriteLine($" = {multiplicacao.Avalia()}.");
            Console.ReadKey();
        }

        private static void TestaInterpreterExemploRaizQuadrada()
        {
            var raizDeNove = new RaizQuadrada(new Numero(9));

            Console.WriteLine(raizDeNove.Avalia());

            Console.ReadKey();
        }

        private static void TestaInterpreterExemploMultiplicacao()
        {
            var esquerda = new Divisao(new Divisao(new Numero(8), new Numero(2)), new Numero(2)); // (8/2) / 2 = 4 / 2 = 2
            var direita = new Multiplicacao(new Numero(3), new Numero(2)); // 3 * 2 = 6
            Console.WriteLine(new Multiplicacao(esquerda, direita).Avalia()); // 2 * 6 = 12

            Console.ReadKey();
        }

        private static void TestaInterpreterExemploSomaSubtracao()
        {
            var esquerda = new Soma(new Soma(new Numero(1), new Numero(100)), new Numero(10)); // (1+100) + 10 = 111
            var direita = new Subtracao(new Numero(20), new Numero(10)); // 20 - 10 = 10
            Console.WriteLine(new Soma(esquerda, direita).Avalia()); // 111 + 10 = 121

            Console.ReadKey();
        }

        private static void TestaInterpreterInternoExpressions()
        {
            //Interpreter interno do C#:
            var soma = Expression.Add(Expression.Constant(10), Expression.Constant(20));
            var funcao = Expression.Lambda<Func<int>>(soma).Compile();
            Console.WriteLine(funcao());

            Console.ReadKey();
        }

        private static void TestaMemementoContratos()
        {
            var historico = new Historico();

            var contrato = new Contrato(DateTime.Now, "Titular", TipoContrato.Novo);
            historico.Adiciona(contrato.SalvaEstado());

            Console.ReadKey();

            contrato.Avanca();
            historico.Adiciona(contrato.SalvaEstado());

            Console.ReadKey();

            contrato.Avanca();
            historico.Adiciona(contrato.SalvaEstado());

            Console.ReadKey();

            contrato.Avanca();
            historico.Adiciona(contrato.SalvaEstado());

            Console.WriteLine(contrato.Tipo);

            Console.ReadKey();

            Console.WriteLine($"{historico.Recupera(0).Contrato.Tipo} - {historico.Recupera(0).AdicionadoEm.ToString()}");
            Console.WriteLine($"{historico.Recupera(1).Contrato.Tipo} - {historico.Recupera(1).AdicionadoEm.ToString()}");
            Console.WriteLine($"{historico.Recupera(2).Contrato.Tipo} - {historico.Recupera(2).AdicionadoEm.ToString()}");

            Console.ReadKey();
        }

        private static void TestandoSingleton()
        {
            var singleton = Singleton.Instancia;
            Console.ReadKey();
        }

        private static void TestandoFlyweightNotasMusicais()
        {
            var criadordenotas = new NotasMusicais();

            var notas = new List<INota>()
            {
                criadordenotas.PegaNota("do"),
                criadordenotas.PegaNota("re"),
                criadordenotas.PegaNota("mi"),
                criadordenotas.PegaNota("fa"),
                criadordenotas.PegaNota("sol"),
                criadordenotas.PegaNota("la"),
                criadordenotas.PegaNota("si"),
            };

            var piano = new Piano();

            piano.Toca(notas);
        }

        private static void ExemploFactoryConexaoBD()
        {
            var conexao = new ConnectionFactory().GetConnection();
            var comando = conexao.CreateCommand();
            comando.CommandText = "SELECT * FROM Tabela";

            Console.ReadKey();
        }
    }
}
