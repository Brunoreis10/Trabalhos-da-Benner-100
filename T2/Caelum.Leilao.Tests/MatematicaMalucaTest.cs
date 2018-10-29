using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    [TestFixture]
    class MatematicaMalucaTest
    {
        [Test]
        public void TestaNumeroMaiorQueTrinta()
        {
            var matematica = new MatematicaMaluca();

            Assert.AreEqual(124, matematica.ContaMaluca(31));
        }

        [Test]
        public void TestaNumeroMaiorQueDezMasMenorQueTrinta()
        {
            var matematica = new MatematicaMaluca();

            Assert.AreEqual(45, matematica.ContaMaluca(15));
        }

        [Test]
        public void TestaNumeroMenorQueDez()
        {
            var matematica = new MatematicaMaluca();

            Assert.AreEqual(4, matematica.ContaMaluca(2));
        }

        [Test]
        public void TestaTrinta()
        {
            var matematica = new MatematicaMaluca();

            Assert.AreEqual(90, matematica.ContaMaluca(30));
        }

        [Test]
        public void TestaDez()
        {
            var matematica = new MatematicaMaluca();

            Assert.AreEqual(20, matematica.ContaMaluca(10));
        }
    }
}
