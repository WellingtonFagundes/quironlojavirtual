using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Dominio.Entidades;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class TesteCarrinhoCompras
    {
        //Teste Adicionar Itens Ao Carrinho
        [TestMethod]
        public void AdicionarItensAoCarrinho()
        {
            //Arrange - criação dos produtos
            Produto produto1 = new Produto()
            {
                ProdutoId = 1,
                Nome = "Teste 1"
            };

            Produto produto2 = new Produto()
            {
                ProdutoId = 2,
                Nome = "Teste 2"
            };

            //Arrange
            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 2);

            carrinho.AdicionarItem(produto2,3);

            //Act - Agir
            ItemCarrinho[] itens = carrinho.ItensCarrinho.ToArray();

            //Assert (Testando se a quantidade de itens é igual a 2)
            Assert.AreEqual(itens.Length,2);

            //Assert (Testando se o produto é igual ou não)
            Assert.AreEqual(itens[0].Produto,produto1);

            Assert.AreEqual(itens[1].Produto,produto2);
        }
    }
}
