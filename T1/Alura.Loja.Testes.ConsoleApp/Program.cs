using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new LojaContext())
            {
                ChamaLogger(contexto);
                var cliente = contexto.Clientes
                    .Include(c => c.EnderecoDeEntrega)
                    .FirstOrDefault();
                Console.WriteLine($"Endereço: {cliente.EnderecoDeEntrega}");

                //var produto = contexto
                //    .Produtos
                //    .Where(p => p.Id == 2002)
                //    .Include(p => p.Compras)
                //    .FirstOrDefault();

                var produto = contexto
                    .Produtos
                    .Where(p => p.Id == 2002)
                    .FirstOrDefault();

                contexto.Entry(produto)
                    .Collection(p => p.Compras)
                    .Query() // <- Sub consulta
                    .Where(c => c.Preco > 20) // <- Agora sim podemos aplicar condições às compras
                    .Load();

                Console.WriteLine($"\nCompras de {produto.Nome} com valor acima de R$20,00:");
                foreach (var item in produto.Compras)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static void BuscaProdutosPromocao()
        {
            using (var contexto = new LojaContext())
            {
                ChamaLogger(contexto);
                var promocao = new Promocao()
                {
                    Descricao = "Criança Feliz 2018",
                    DataInicio = new DateTime(2018, 10, 12),
                    DataTermino = new DateTime(2018, 10, 12)
                };

                var doces = contexto
                    .Produtos
                    .Where(p => p.Categoria == "Doce")
                    .ToList();

                foreach (var item in doces)
                {
                    promocao.IncluiProduto(item);
                }

                contexto.Promocoes.Add(promocao);

                ImprimeChangeTracker(contexto.ChangeTracker.Entries());

                contexto.SaveChanges();
            }

            using (var contexto2 = new LojaContext())
            {
                ChamaLogger(contexto2);
                var promo = contexto2
                    .Promocoes
                    .Include(p => p.Produtos)
                    .ThenInclude(pp => pp.Produto)
                    .FirstOrDefault();
                Console.WriteLine("\n" + promo.Descricao + " - Produtos:\n");
                foreach (var item in promo.Produtos)
                {
                    Console.WriteLine(item.Produto);
                }
            }
        }

        private static void ImprimeChangeTracker(IEnumerable<EntityEntry> entries)
        {
            Console.WriteLine("------------------------");
            foreach (var e in entries)
            {
                Console.WriteLine(e.Entity.ToString() + " - " + e.State);
            }
            Console.WriteLine("------------------------");
        }

        private static void UmParaUm()
        {
            var fulano = new Cliente();
            fulano.Nome = "Fulano de Tal";
            fulano.EnderecoDeEntrega = new Endereco()
            {
                Logradouro = "Rua São Paulo",
                Numero = "593",
                Complemento = "Casa 2",
                Bairro = "Centro",
                Cidade = "Blumenau"
            };

            using (var contexto = new LojaContext())
            {
                contexto.Clientes.Add(fulano);
                contexto.SaveChanges();
            }
        }

        private static void MuitosParaMuitos()
        {
            var chocolate = new Produto() { Nome = "Chocolate", Categoria = "Doce", PrecoUnitario = 4.5, Unidade = "Gramas" };
            var bala = new Produto() { Nome = "Bala", Categoria = "Doce", PrecoUnitario = 0.05, Unidade = "Unidade" };
            var caneta = new Produto() { Nome = "Caneta", Categoria = "Material", PrecoUnitario = 0.5, Unidade = "Unidade" };

            var promocaoDePascoa = new Promocao();
            promocaoDePascoa.Descricao = "Páscoa Alegre";
            promocaoDePascoa.DataInicio = DateTime.Now;
            promocaoDePascoa.DataTermino = DateTime.Now.AddMonths(3);
            promocaoDePascoa.IncluiProduto(chocolate);
            promocaoDePascoa.IncluiProduto(bala);
            promocaoDePascoa.IncluiProduto(caneta);

            using (var contexto = new LojaContext())
            {
                ChamaLogger(contexto);

                var promo = contexto.Promocoes.Find(1);

                contexto.Promocoes.Remove(promo);

                contexto.SaveChanges();
            }
        }

        private static void ChamaLogger(LojaContext contexto)
        {
            var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
            var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            loggerFactory.AddProvider(SqlLoggerProvider.Create());
        }
    }
}