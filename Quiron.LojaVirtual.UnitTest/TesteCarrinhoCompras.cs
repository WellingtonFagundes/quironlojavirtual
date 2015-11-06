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

        [TestMethod]
        public void AdicionarProdutoExistenteParaCarrinho()
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

            //Produto produto3 = new Produto()
            //{
            //    ProdutoId = 3,
            //    Nome = "Teste 3"
            //};

            //Arrange
            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 1);

            carrinho.AdicionarItem(produto2, 3);

            carrinho.AdicionarItem(produto1, 10);

            //Act - Agir
            ItemCarrinho[] resultado = carrinho.ItensCarrinho
                        .OrderBy(c => c.Produto.ProdutoId).ToArray();
                

            //Assert - (2 produtos adicionados testar igualdade)
            Assert.AreEqual(resultado.Length,2);

            //Assert - (Quantidade de produtos no produto 1)
            Assert.AreEqual(resultado[0].Quantidade, 11);

            Assert.AreEqual(resultado[1].Quantidade,3);
        }

        [TestMethod]
        public void RemoverItensCarrinho()
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

            Produto produto3 = new Produto()
            {
                ProdutoId = 3,
                Nome = "Teste 3"
            };

            //Arrange
            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 1);

            carrinho.AdicionarItem(produto2, 3);

            carrinho.AdicionarItem(produto3, 5);

            carrinho.AdicionarItem(produto2, 1);

            //Act
            carrinho.RemoverItem(produto2);

            //Assert - Quantidade de produtos após a remoção
            Assert.AreEqual(carrinho.ItensCarrinho.Where(c => c.Produto == produto2).Count(),0);

            //Assert - Quantos itens tem no carrinho depois de removido um produto
            Assert.AreEqual(carrinho.ItensCarrinho.Count(),2);


        }

        [TestMethod]
        public void CalcularValorTotal()
        {
            //Arrange - criação dos produtos
            Produto produto1 = new Produto()
            {
                ProdutoId = 1,
                Nome = "Teste 1",
                Preco = 100M
            };

            Produto produto2 = new Produto()
            {
                ProdutoId = 2,
                Nome = "Teste 2",
                Preco = 50M
            };

            

            //Arrange
            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 1);

            carrinho.AdicionarItem(produto2, 1);

            carrinho.AdicionarItem(produto1, 3);

            
            //Act
            decimal resultado = carrinho.ObterValorTotal();


            //Assert
            Assert.AreEqual(resultado, 450M);
        }

        [TestMethod]
        public void LimparItensCarrinho()
        {
            //Arrange - criação dos produtos
            Produto produto1 = new Produto()
            {
                ProdutoId = 1,
                Nome = "Teste 1",
                Preco = 100M
            };

            Produto produto2 = new Produto()
            {
                ProdutoId = 2,
                Nome = "Teste 2",
                Preco = 50M
            };

            
            //Arrange
            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 1);

            carrinho.AdicionarItem(produto2, 1);


            //Act
            carrinho.LimparCarrinho();


            //Assert
            Assert.AreEqual(carrinho.ItensCarrinho.Count(),0);
        }
    }

  
}
