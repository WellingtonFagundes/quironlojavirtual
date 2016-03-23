using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.V2.HTMLHelpers;
using Quiron.LojaVirtual.Web.V2.Models;

namespace Quiron.LojaVirtual.Web.V2.Controllers
{
    public class NavController : Controller
    {
        private ProdutoModeloRepositorio _repositorio;
        private ProdutosViewModel _model;
        private MenuRepositorio _menuRepositorio;
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


        [Route("nav/{id}/{Categoria}")]
        public ActionResult ObterProdutosPorCategorias(string id, string categoria)
        {
            _repositorio = new ProdutoModeloRepositorio();
            var produtos = _repositorio.ObterProdutosVitrine(categoria: id);
            _model = new ProdutosViewModel
            {
                Produtos = produtos,
                Titulo = categoria
            };

            return View("Navegacao", _model);
        }


        [Route("nav/{id}/{marca}")]
        public ActionResult ObterProdutosPorMarcas(string id,string marca)
        {
           _repositorio = new ProdutoModeloRepositorio();
            var produtos = _repositorio.ObterProdutosVitrine(marca: id);
            _model = new ProdutosViewModel
            {
                Produtos = produtos,
                Titulo = marca
            };


            return View("Navegacao",_model);
        }

        [Route("nav/times/{id}/{clube}")]
        public ActionResult ObterProdutosPorClubes(string id, string clube)
        {
            _repositorio = new ProdutoModeloRepositorio();
            var produtos = _repositorio.ObterProdutosVitrine(linha: id);
            _model = new ProdutosViewModel
            {
                Produtos = produtos,
                Titulo = clube
            };


            return View("Navegacao", _model);
        }

        

        [Route("nav/genero/{id}/{genero}")]
        public ActionResult ObterProdutosPorGenero(string id, string genero)
        {
            _repositorio = new ProdutoModeloRepositorio();
            var produtos = _repositorio.ObterProdutosVitrine(linha: id);
            _model = new ProdutosViewModel
            {
                Produtos = produtos,
                Titulo = genero
            };


            return View("Navegacao", _model);
        }

        #region [Tênis por categoria]
        /// <summary>
        /// Obtêm categoria de tênis exibido no menu
        /// </summary>
        /// <returns></returns>
        /// Filha de uma View (Vitrine - pai) como se fosse no usercontrols do webforms 
        [ChildActionOnly]
        [OutputCache(Duration = 3600,VaryByParam = "*")]
        public ActionResult TenisCategoria()
        {
            _menuRepositorio = new MenuRepositorio();
            var categorias = _menuRepositorio.ObterTenisCategoria();
            var subgrupo = _menuRepositorio.SubGrupoTenis();

            SubGrupoCategoriasViewModel model = new SubGrupoCategoriasViewModel()
            {
                Categorias = categorias,
                SubGrupo = subgrupo
            };

            return PartialView("_TenisCategoria", model);
        }

        [Route("calcados/{subGrupoCodigo}/tenis/{categoriaCodigo}/{categoriaDescricao}")]
        public ActionResult ObterTenisPorCategoria(string subGrupoCodigo,string categoriaCodigo,string categoriaDescricao)
        {
            _repositorio = new ProdutoModeloRepositorio();
            var produtos = _repositorio.ObterProdutosVitrine(categoriaCodigo, subgrupo: subGrupoCodigo);
            _model = new ProdutosViewModel { Produtos = produtos,Titulo = categoriaDescricao};
            return View("Navegacao", _model);
        }

        #endregion


        #region [Casual]

        //Obtém modalidades de casual exibido no Menu
        [ChildActionOnly]
        [OutputCache(Duration = 3600, VaryByParam = "*")]
        public ActionResult CasualSubGrupo()
        {
            _menuRepositorio = new MenuRepositorio();
            var casual = _menuRepositorio.ModalidadeCasual();
            var subGrupo = _menuRepositorio.ObterCasualGrupo();

            var model = new ModalidadeSubGrupoViewModel
            {
                Modalidade = casual,
                SubGrupos = subGrupo
            };

            return PartialView("_CasualSubGrupo",model);
        }


        [Route("{modalidadeCodigo}/casual/{subGrupoCodigo}/{subGrupoDescricao}")]
        public ActionResult ObterModalidadeSubgrupo(string modalidadeCodigo, string subGrupoCodigo, string subGrupoDescricao)
        {
             _repositorio = new ProdutoModeloRepositorio();

            var produtos = _repositorio.ObterProdutosVitrine(modalidade: modalidadeCodigo, subgrupo: subGrupoCodigo);

            _model = new ProdutosViewModel
            {
                Produtos = produtos,
                Titulo = subGrupoDescricao
            };

            return View("Navegacao", _model);
        }


        #endregion

        #region [Menu Lateral Suplementos]

        [ChildActionOnly]
        [OutputCache(Duration = 3600, VaryByParam = "*")]
        public ActionResult Suplementos()
        {
            _menuRepositorio = new MenuRepositorio();
            var categoria = _menuRepositorio.Suplementos();
            var subgrupos = _menuRepositorio.ObterSuplementos();

            CategoriaSubGruposViewModel model = new CategoriaSubGruposViewModel
            {
                Categoria = categoria,
                SubGrupos = subgrupos
            };

            return PartialView("_Suplementos", model);
        }


        [Route("{categoriaCodigo}/suplementos/{subGrupoCodigo}/{subGrupoDescricao}")]
        public ActionResult ObterCategoriaSubgrupos(string categoriaCodigo, string subGrupoCodigo, string subGrupoDescricao)
        {
            _repositorio = new ProdutoModeloRepositorio();

            var produtos = _repositorio.ObterProdutosVitrine(categoria: categoriaCodigo, subgrupo: subGrupoCodigo);

            _model = new ProdutosViewModel
            {
                Produtos = produtos,
                Titulo = subGrupoDescricao
            };

            return View("Navegacao", _model);
        }
        #endregion
    }
}