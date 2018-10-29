using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMax.DAO
{
    [TestFixture]
    class MarcaDAOTest
    {
        [Test]
        public void DeveRetornarMarcasDesativada()
        {
            var marcas = new MarcaDAO().ListaDesativadas();

            Assert.AreEqual(1, marcas.Count);
        }
    }
}
