using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    [TestFixture]
    public class PalindromoTest
    {
        [Test]
        public void TestaPalindromo()
        {
            var verificador = new Palindromo();

            var palindromo = verificador.EhPalindromo("Socorram-me subi no onibus em Marrocos");
            var palindromo2 = verificador.EhPalindromo("Anotaram a data da maratona");
            var naopalindromo = verificador.EhPalindromo("Frase qualquer");

            Assert.IsTrue(palindromo);
            Assert.IsFalse(naopalindromo);
            Assert.IsTrue(palindromo2);
        }
    }
}
