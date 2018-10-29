using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    [TestFixture]
    public class LanceTest
    {
        private Usuario jose;

        [OneTimeSetUp]
        public void IniciandoTeste()
        {
            jose = new Usuario("José");
        }

        [Test]
        public void TestandoExcecaoComValorZero()
        {
            Assert.Throws<ArgumentException>(() => new Lance(jose, 0));
        }

        [Test]
        public void TestandoExcecaoComValorNegativo()
        {
            Assert.Throws<ArgumentException>(() => new Lance(jose, -10));
        }
    }
}
