using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quiron.LojaVirtual.Dominio.Entidades;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    public class ProdutosRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<Produto> Produtos
        {
            get {return _context.Produtos; }
        }


        //Retorna apenas um produto
        public Produto ObterProduto(int id)
        {
            return _context.Produtos.Single(p => p.ProdutoId == id);
        }


        //Salvar Produto - Alterar Produto
        public void Salvar(Produto produto)
        {
            //Salvado
            if (produto.ProdutoId == 0)
            {
                _context.Produtos.Add(produto);
            }
            else
            {
                //Alteração
                Produto prod = _context.Produtos.Find(produto.ProdutoId);

                if (prod != null)
                {
                    prod.Nome = produto.Nome;
                    prod.Descricao = produto.Descricao;
                    prod.Categoria = produto.Categoria;
                    prod.Preco = produto.Preco;
                    prod.Imagem = produto.Imagem;
                    prod.ImagemMimeType = produto.ImagemMimeType;
                }
            }

            _context.SaveChanges();
        }


        //Excluir Produto
        public Produto Excluir(int produtoid)
        {
            Produto prod = _context.Produtos.Find(produtoid);

            if (prod != null)
            {
                _context.Produtos.Remove(prod);
                _context.SaveChanges();
            }

            return prod;
        }
    }
}