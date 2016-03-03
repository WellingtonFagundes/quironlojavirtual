using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.Models;

namespace Quiron.LojaVirtual.Web.Controllers
{
    
    public class VitrineController : Controller
    {
        private ProdutosRepositorio _repositorio;
        public int ProdutosPorPagina = 12;

        //public ViewResult ListaProdutos(string categoria,int pagina = 1)
        //{
        //   _repositorio = new ProdutosRepositorio();

        //    ProdutosViewModel model = new ProdutosViewModel
        //    {
        //        Produtos = _repositorio.Produtos
        //            .Where(p => categoria == null || p.Categoria == categoria)
        //            .OrderBy(p => p.Descricao)
        //            .Skip((pagina - 1)*ProdutosPorPagina)
        //            .Take(ProdutosPorPagina),

        //        Paginacao = new Paginacao
        //        {
        //            PaginaAtual = pagina,
        //            ItensPorPagina = ProdutosPorPagina,
        //            ItensTotal = categoria == null? _repositorio.Produtos.Count() : _repositorio.Produtos.Count(p => p.Categoria == categoria)
        //        },

        //        CategoriaAtual = categoria

        //    };

        //    return View(model);
        //}

        public ViewResult ListaProdutos(string categoria)
        {
            /*ListaProdutos modificado para exibir produtos 
             * aleatoriamente e preparando para exibir os
             * detalhes da imagem do produto
             */

            _repositorio = new ProdutosRepositorio();

           var model = new ProdutosViewModel();

           //Gera valores randômicos
            var rnd = new Random();

            if (categoria != null)
            {
                model.Produtos = _repositorio.Produtos
                    .Where(p => p.Categoria == categoria)
                    .OrderBy(x => rnd.Next()).ToList();
            }
            else
            {
                //Lista todos os produtos aleatoriamente, pulando por 12 páginas
                model.Produtos = _repositorio.Produtos
                    .OrderBy(x => rnd.Next())
                    .Take(ProdutosPorPagina).ToList();
            }

            return View(model);
        }


        [Route("DetalhesProduto/{id}/{produto}")]
        public ViewResult Detalhes(int id)
        {
            _repositorio = new ProdutosRepositorio();

            Produto produto = _repositorio.ObterProduto(id);
            return View(produto);
        }


        [Route("Vitrine/ObterImagem/{produtoid}")]
        public FileContentResult ObterImagem(int produtoid)
        {
            _repositorio = new ProdutosRepositorio();

            Produto prod = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoid);

            if (prod != null)
            {
                return File(prod.Imagem, prod.ImagemMimeType);
            }

            return null;
        }
	}
}