﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Repositorio;

namespace Quiron.LojaVirtual.Web.Areas.Administrativo.Controllers
{
    [Authorize]
    public class ProdutoController : Controller
    {
        private ProdutosRepositorio _repositorio;

        public ActionResult Index()
        {
            _repositorio = new ProdutosRepositorio();

            var produtos = _repositorio.Produtos;
            return View(produtos);
        }

        //GET
        public ViewResult Alterar(int produtoId)
        {
            _repositorio = new ProdutosRepositorio();

            Produto produto = _repositorio.Produtos
                .FirstOrDefault(p => p.ProdutoId == produtoId);

            return View(produto);
        }

        //Post
        [HttpPost]
        public ActionResult Alterar(Produto produto,HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    produto.ImagemMimeType = image.ContentType;
                    produto.Imagem = new byte[image.ContentLength];
                    image.InputStream.Read(produto.Imagem, 0, image.ContentLength);
                }

                _repositorio = new ProdutosRepositorio();
                _repositorio.Salvar(produto);

                TempData["mensagem"] = string.Format("{0} foi salvo com sucesso.", produto.Nome);

                return RedirectToAction("Index");
            }

            return View(produto);
        }

       
        public ViewResult NovoProduto()
        {
            return View("Alterar", new Produto());
        }

        
        //[HttpPost]
        //public ActionResult Excluir(int produtoid)
        //{
        //    _repositorio = new ProdutosRepositorio();

        //    Produto prod = _repositorio.Excluir(produtoid);

        //    if (prod != null)
        //    {
        //        TempData["mensagem"] = string.Format("{0} excluído com sucesso!!", prod.Nome);
        //    }

        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public JsonResult Excluir(int produtoid)
        {
            //Aguardando 5 segundos após aparecer a animação de excluir
            //System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));

            string mensagem = String.Empty;

            _repositorio = new ProdutosRepositorio();

            Produto prod = _repositorio.Excluir(produtoid);

            if (prod != null)
            {
                mensagem = string.Format("{0} excluído com sucesso!!", prod.Nome);
            }

            return Json(mensagem, JsonRequestBehavior.AllowGet);
        }

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