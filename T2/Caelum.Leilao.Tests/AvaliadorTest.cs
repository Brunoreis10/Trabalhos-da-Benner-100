using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Caelum.Leilao
{
    [TestFixture]
    public class AvaliadorTest
    {
        private Avaliador avaliador;
        private Usuario joao;
        private Usuario maria;
        private Usuario pedro;

        [SetUp]
        public void SetUp()
        {
            //1-CENÁRIO:
            avaliador = new Avaliador();
            joao = new Usuario("João");
            maria = new Usuario("Maria");
            pedro = new Usuario("Pedro");
            Console.WriteLine("Iniciando teste...");
        }

        [TearDown]
        public void Finaliza()
        {
            Console.WriteLine("Teste finalizano.");
        }

        [Test]
        public void DeveEntenderLancesCrescentes()
        {
            var leilao = new LeilaoTDBuilder()
                .NovoLeilaoDe("Galaxy S9+")
                .comLance(joao, 200)
                .comLance(pedro, 300)
                .comLance(maria, 500)
                .Constroi();
            
            //2-AÇÃO:
            avaliador.Avalia(leilao);

            //3-VALIDAÇÃO:
            Assert.AreEqual(200, avaliador.MenorLance, 0.00001);
            Assert.AreEqual(500, avaliador.MaiorLance, 0.00001);
        }

        [Test]
        public void TestaCalculoDeMediaDosLances()
        {
            var leilao = new LeilaoTDBuilder()
                .NovoLeilaoDe("Ipad Air")
                .comLance(joao, 897)
                .comLance(maria, 2039)
                .comLance(joao, 183)
                .Constroi();
            
            avaliador.Avalia(leilao);

            Assert.AreEqual(1039.666666667, avaliador.LanceMedio, 0.00001);
        }

        [Test]
        public void TestaLeilaoComUmLance()
        {
            var leilao = new LeilaoTDBuilder()
                .NovoLeilaoDe("Cadeira Gamer")
                .comLance(joao, 200)
                .Constroi();
            
            avaliador.Avalia(leilao);
            
            Assert.AreEqual(200, avaliador.MenorLance, 0.00001);
            Assert.AreEqual(200, avaliador.MaiorLance, 0.00001);
        }

        [Test]
        public void TestaLeilaoComLancesAleatorios()
        {
            var leilao = new LeilaoTDBuilder()
                .NovoLeilaoDe("Net Gato")
                .comLance(joao, 200)
                .comLance(maria, 450)
                .comLance(joao, 120)
                .comLance(maria, 700)
                .comLance(joao, 630)
                .comLance(maria, 230)
                .Constroi();
            
            avaliador.Avalia(leilao);
            
            Assert.AreEqual(120, avaliador.MenorLance, 0.00001);
            Assert.AreEqual(700, avaliador.MaiorLance, 0.00001);
        }

        [Test]
        public void TestaLeilaoComLancesDecrescentes()
        {
            var leilao = new LeilaoTDBuilder()
                .NovoLeilaoDe("Guarda-chuva família")
                .comLance(joao, 400)
                .comLance(maria, 300)
                .comLance(joao, 200)
                .comLance(maria, 100)
                .Constroi();
            
            avaliador.Avalia(leilao);
            
            Assert.AreEqual(100, avaliador.MenorLance, 0.00001);
            Assert.AreEqual(400, avaliador.MaiorLance, 0.00001);
        }

        [Test]
        public void TestaMaioresComQuatroLances()
        {
            var leilao = new LeilaoTDBuilder()
                .NovoLeilaoDe("Caneta de pena")
                .comLance(joao, 400)
                .comLance(maria, 200)
                .comLance(joao, 300)
                .comLance(maria, 100)
                .Constroi();

            avaliador.Avalia(leilao);

            Assert.AreEqual(3, avaliador.TresMaiores.Count);
            Assert.AreEqual(400, avaliador.TresMaiores[0].Valor, 0.00001);
            Assert.AreEqual(300, avaliador.TresMaiores[1].Valor, 0.00001);
            Assert.AreEqual(200, avaliador.TresMaiores[2].Valor, 0.00001);
        }

        [Test]
        public void TestaMaioresComDoisLances()
        {
            var leilao = new LeilaoTDBuilder()
                .NovoLeilaoDe("Pendrive 1TB")
                .comLance(joao, 400)
                .comLance(maria, 200)
                .Constroi();

            avaliador.Avalia(leilao);

            Assert.AreEqual(2, avaliador.TresMaiores.Count);
            Assert.AreEqual(400, avaliador.TresMaiores[0].Valor, 0.00001);
            Assert.AreEqual(200, avaliador.TresMaiores[1].Valor, 0.00001);
        }

        [Test]
        public void TestaMaioresSemNenhumLance()
        {
            var leilao = new LeilaoTDBuilder()
                .NovoLeilaoDe("Amendoim torrado")
                .Constroi();
          
            Assert.That(() => avaliador.Avalia(leilao), Throws.TypeOf<Exception>());
            //Assert.Throws<Exception>(() => avaliador.Avalia(leilao)); <- Alternativa da internet.
        }
    }
}
