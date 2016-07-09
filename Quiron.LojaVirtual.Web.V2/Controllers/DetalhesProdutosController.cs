using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.V2.Models;

namespace Quiron.LojaVirtual.Web.V2.Controllers
{

    [RoutePrefix("produto")]
    public class DetalhesProdutosController : Controller
    {
        [Route("{codigo}/{marca}/{produto}/{corcodigo}")]
        public ActionResult Detalhes(string codigo, string corcodigo)
        {
            var repositorio = new DetalhesProdutoRepositorio();
            var produto = repositorio.ObterProdutoModelo(codigo, corcodigo);
            var model = Mapper.DynamicMap<DetalhesProdutoViewModel>(produto);
            //Combos List
            model.CoresList = new SelectList(produto.Cores,"CorCodigo","CorDescricao",corcodigo);
            model.TamanhoList = new SelectList(produto.Tamanhos,"TamanhoCodigo","TamanhoDescricaoResumida");
            model.BreadCrumb = repositorio.ObterBreadCrumbDto(produto.Produto.ProdutoModeloCodigo);
            return View(model);
        }
    }
}