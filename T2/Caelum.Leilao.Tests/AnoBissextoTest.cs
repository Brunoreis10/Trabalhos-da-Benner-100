using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    [TestFixture]
    public class AnoBissextoTest
    {
        [Test]
        public void DeveRetornarQueO2020SeraBissexto()
        {
            Assert.IsTrue(new AnoBissexto().EhBissexto(2020));
        }

        [Test]
        public void DeveRetornarQueO2019NaoSeraBissexto()
        {
            Assert.IsFalse(new AnoBissexto().EhBissexto(2018));
        }

        [Test]
        public void DeveRetornarQueO2016FoiBissexto()
        {
            Assert.IsTrue(new AnoBissexto().EhBissexto(2020));
        }

        [Test]
        public void DeveRetornarQueO2017NaoFoiBissexto()
        {
            Assert.IsFalse(new AnoBissexto().EhBissexto(2018));
        }
    }
}
