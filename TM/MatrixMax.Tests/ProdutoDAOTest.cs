using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMax.DAO
{
    [TestFixture]
    public class ProdutoDAOTest
    {
        [Test]
        public void TestaAtivadorDeProduto()
        {
            var dao = new ProdutoDAO();
            var produto = dao.BuscaPorId(1);

            dao.Ativa(produto.Id);

            produto = dao.BuscaPorId(1);

            Assert.IsTrue(produto.Ativo);
        }

        [Test]
        public void TestaDesativadorDeProduto()
        {
            var dao = new ProdutoDAO();
            var produto = dao.BuscaPorId(1);

            Assert.IsTrue(produto.Ativo);

            dao.Desativa(produto.Id);

            produto = dao.BuscaPorId(1);

            Assert.IsFalse(produto.Ativo);
        }

        [Test]
        public void TestaVerificaExistenciaDeProduto()
        {
            var dao = new ProdutoDAO();
            var existe = dao.Existe(1);

            Assert.IsTrue(existe);

            var naoexiste = dao.Existe(999);

            Assert.IsFalse(naoexiste);
        }
    }
}
