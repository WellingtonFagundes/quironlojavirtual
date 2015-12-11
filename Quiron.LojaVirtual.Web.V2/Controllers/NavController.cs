using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.V2.Models;

namespace Quiron.LojaVirtual.Web.V2.Controllers
{
    public class NavController : Controller
    {
        private ProdutoModeloRepositorio _repositorio;
        private ProdutosViewModel _model;
        //
        // GET: /Nav/
        public ActionResult Index()
        {
            _repositorio = new ProdutoModeloRepositorio();

            //Retorna produtos de forma aleatória
            var produtos = _repositorio.ObterProdutosVitrine();
            //É apresentado os produtos juntamente com a propriedade Titulo
            _model = new ProdutosViewModel {Produtos = produtos};

            return View(_model);
        }

        public JsonResult TesteMetodoVitrine()
        {
            ProdutoModeloRepositorio repositorio = new ProdutoModeloRepositorio();

            //var produtos = repositorio.ObterProdutosVitrine(categoria: "0083", marca: "1106");

            var produtos = repositorio.ObterProdutosVitrine(modalidade: "0051");

            
            return Json(produtos, JsonRequestBehavior.AllowGet);
        }


        [Route("nav/{id}/{marca}")]
        public ActionResult ObterProdutosPorMarcas(string id)
        {
           // ProdutoModeloRepositorio repositorio = new ProdutoModeloRepositorio();



            return View("Index", null);
        }
	}
}