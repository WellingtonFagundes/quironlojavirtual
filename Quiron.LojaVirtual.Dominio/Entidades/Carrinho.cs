using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class Carrinho
    {

        private readonly List<ItemCarrinho> _itemcarrinho = new List<ItemCarrinho>();
 

        //Adicionar
        public void AdicionarItem(Produto produto, int quantidade)
        {
            //Verificando se existe o item no carrinho
            ItemCarrinho item = _itemcarrinho.FirstOrDefault(p => p.Produto.ProdutoId == produto.ProdutoId);

            //Caso não tenha adicionar o item no carrinho
            if (item == null)
            {
                _itemcarrinho.Add(new ItemCarrinho()
                {
                    Produto = produto,
                    Quantidade = quantidade 
                });
            }
            else
            {
                //Caso contrário recebe a quantidade informada
                item.Quantidade = quantidade;
            }
        }

        //Remover item do carrinho
        public void RemoverItem(Produto produto)
        {
            _itemcarrinho.RemoveAll(l => l.Produto.ProdutoId == produto.ProdutoId);
        }

        //Obter o valor total
        public decimal ObterValorTotal()
        {
            return _itemcarrinho.Sum(e => e.Produto.Preco*e.Quantidade);
        }
        
        //Limpar Carrinho
        public void LimparCarrinho()
        {
            _itemcarrinho.Clear();
        }

        //Itens Carrinho
        public IEnumerable<ItemCarrinho> ItensCarrinho
        {
            get { return _itemcarrinho; }
        }

    }

    public class ItemCarrinho
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}