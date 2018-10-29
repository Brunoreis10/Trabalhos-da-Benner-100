using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMax.Models
{
    [TestFixture]
    public class ProdutoTest
    {
        [Test]
        public void TestaProdutoEquals()
        {
            var produto = new Produto()
            {
                Id = 1,
                Nome = "Teste",
                Ativo = true,
                Estoque = 10,
                MarcaId = 1,
                SubcategoriaId = 2,
                PrecoUnitario = 20
            };

            var outroProduto = new Produto()
            {
                Id = 1,
                Nome = "Teste",
                Ativo = true,
                Estoque = 10,
                MarcaId = 1,
                SubcategoriaId = 2,
                PrecoUnitario = 20
            };

            Assert.IsTrue(produto.Equals(outroProduto));

            outroProduto.PrecoRecarga = 2;

            Assert.IsFalse(produto.Equals(outroProduto));
        }

        [Test]
        public void TestaValidacaoDeProduto()
        {
            var produto = new Produto();

            Assert.IsFalse(produto.Valida());

            produto.Id = 1;
            produto.Nome = "Teste";
            produto.Ativo = true;
            produto.Estoque = 10;
            produto.MarcaId = 1;
            produto.SubcategoriaId = 2;
            produto.PrecoUnitario = 20;

            Assert.IsTrue(produto.Valida());
        }
    }
}
