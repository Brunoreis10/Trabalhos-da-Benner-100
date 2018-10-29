using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    [TestFixture]
    public class LeilaoTest
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Console.WriteLine("Iniciando LeilaoTest.");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Console.WriteLine("Finalizando LeilaoTest.");
        }

        [SetUp]
        public void SetUp()
        {
            Console.WriteLine("Iniciando teste.");
        }

        [Test]
        public void DeveReceberUmLance()
        {
            var leilao = new LeilaoTDBuilder().NovoLeilaoDe("Notebook Acer").Constroi();
            Assert.AreEqual(0, leilao.Lances.Count);

            leilao.Propoe(new Lance(new Usuario("Bill Gates"), 5000));

            Assert.AreEqual(1, leilao.Lances.Count());
            Assert.AreEqual(5000, leilao.Lances[0].Valor, 0.0001);
        }

        [Test]
        public void DeveReceberVariosLances()
        {
            var leilao = new LeilaoTDBuilder()
                .NovoLeilaoDe("Notebook Avell")
                .comLance(new Usuario("Bill Gates"), 5000)
                .comLance(new Usuario("Rita Lee"), 4000)
                .Constroi();

            Assert.AreEqual(2, leilao.Lances.Count());
            Assert.AreEqual(5000, leilao.Lances[0].Valor, 0.0001);
            Assert.AreEqual(4000, leilao.Lances[1].Valor, 0.0001);
        }

        [Test]
        public void NaoDeveAceitarLancesSeguidosDoMesmoUsuario()
        {
            var michelTemer = new Usuario("Michel Temer");

            var leilao = new LeilaoTDBuilder()
                .NovoLeilaoDe("Notebook Positivo")
                .comLance(michelTemer, 1500)
                .comLance(michelTemer, 4000)
                .Constroi();

            Assert.AreEqual(1, leilao.Lances.Count());
            Assert.AreEqual(1500, leilao.Lances[0].Valor, 0.0001);
        }

        [Test]
        public void NaoDeveAceitarMaisDeCincoLancesDoMesmoUsuario()
        {
            var michelTemer = new Usuario("Michel Temer");
            var dilmaRoussef = new Usuario("Dulma Roussef");

            var leilao = new LeilaoTDBuilder()
                .NovoLeilaoDe("Notebook Positivo")
                .comLance(michelTemer, 100)
                .comLance(dilmaRoussef, 200)
                .comLance(michelTemer, 300)
                .comLance(dilmaRoussef, 400)
                .comLance(michelTemer, 500)
                .comLance(dilmaRoussef, 600)
                .comLance(michelTemer, 700)
                .comLance(dilmaRoussef, 800)
                .comLance(michelTemer, 900)
                .comLance(dilmaRoussef, 1000)
                .comLance(michelTemer, 1100)
                .Constroi();

            Assert.AreEqual(10, leilao.Lances.Count());

            var ultimoIndex = leilao.Lances.Count - 1;
            var ultimoLance = leilao.Lances[ultimoIndex];
            Assert.AreEqual(1000, ultimoLance.Valor, 0.00001);
        }

        [Test]
        public void DeveDuplicarUmLance()
        {
            var alguem = new Usuario("Uma Pessoa");
            var outroalguem = new Usuario("Outra Pessoa");

            var leilao = new LeilaoTDBuilder()
                .NovoLeilaoDe("Ultrabook Acer")
                .comLance(alguem, 300)
                .comLance(outroalguem, 400)
                .Constroi();

            leilao.DobraLance(alguem);

            Assert.AreEqual(3, leilao.Lances.Count);
            Assert.AreEqual(600, leilao.Lances.Last().Valor);
        }

        [Test]
        public void NaoDeveDuplicarPoisNaoHaLancesAnteriores()
        {
            var alguem = new Usuario("Uma Pessoa");
            var outroalguem = new Usuario("Outra Pessoa");

            var leilao = new LeilaoTDBuilder()
                .NovoLeilaoDe("Ipad 2")
                .comLance(alguem, 300)
                .Constroi();

            leilao.Propoe(new Lance(alguem, 300));

            leilao.DobraLance(outroalguem);

            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(300, leilao.Lances.Last().Valor);
        }

        [Test]
        public void DeveDuplicarApenasOUltimoLanceEntreDois()
        {
            var alguem = new Usuario("Uma Pessoa");
            var outroalguem = new Usuario("Outra Pessoa");

            var leilao = new LeilaoTDBuilder()
                .NovoLeilaoDe("Laser Pointer")
                .comLance(alguem, 300)
                .comLance(outroalguem, 400)
                .comLance(alguem, 500)
                .comLance(outroalguem, 600)
                .Constroi();

            leilao.DobraLance(alguem);

            Assert.AreEqual(5, leilao.Lances.Count);
            Assert.AreEqual(1000, leilao.Lances.Last().Valor);
        }
    }
}
