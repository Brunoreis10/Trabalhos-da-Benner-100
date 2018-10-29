using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMax.DAO
{
    [TestFixture]
    public class CategoriaDAOTest
    {
        [Test]
        public void DeveRetornarCategorias()
        {
            var dao = new CategoriaDAO();
            var categorias = dao.ListaCategorias();

            var devesertrue = categorias.Where(c => c.Nome == "Cartuchos").ToList().Count == 1;
            var deveserfalse = categorias.Where(c => c.Nome == "Compatíveis").ToList().Count >= 1;

            Assert.IsTrue(devesertrue);
            Assert.IsFalse(deveserfalse);
        }

        [Test]
        public void DeveRetornarSubcategoriasCartucho()
        {
            var dao = new CategoriaDAO();
            var subcategorias = dao.ListaSubcategorias(2);

            var devesertrue = subcategorias.Where(c => c.Nome == "Compatíveis").ToList().Count == 1;

            Assert.IsTrue(devesertrue);
            Assert.AreEqual(3, subcategorias.Count);
        }

        [Test]
        public void DeveRetornarTodasAsSubcategorias()
        {
            var dao = new CategoriaDAO();
            var subcategorias = dao.ListaTodasAsSubcategorias();

            var devesertrue = subcategorias.Where(c => c.CategoriaId <= 0).ToList().Count == 0;

            Assert.IsTrue(devesertrue);
            Assert.AreEqual(12, subcategorias.Count);
        }

        [Test]
        public void DeveRetornarSubcategoriasDesativadas()
        {
            var dao = new CategoriaDAO();
            var subcategorias = dao.ListaTodasAsSubcategoriasDesativadas();

            Assert.AreEqual(1, subcategorias.Count);
        }

        [Test]
        public void DeveRetornarCategoriasDesativadas()
        {
            var dao = new CategoriaDAO();
            var categorias = dao.ListaCategoriasDesativadas();

            Assert.AreEqual(1, categorias.Count);
        }
    }
}
