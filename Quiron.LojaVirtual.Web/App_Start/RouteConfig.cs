using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Quiron.LojaVirtual.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapMvcAttributeRoutes();

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //1 - Início (equivale a / - Produtos de todas as categorias)
            routes.MapRoute(null,
                "",
                new { controller = "Vitrine"
                    , action = "ListaProdutos"
                    , categoria = (string)null , pagina = 1 }
             );


            //2 - (Equivale a /Pagina2 - Todas as categorias da página 2)
            routes.MapRoute(null,
                "Pagina{pagina}",
                new { controller = "Vitrine"
                    , action = "ListaProdutos"
                    , categoria = (string)null }
                    , new { pagina = @"\d+" }
             );


            //3 - (Equivale a /Futebol - Primeira página da categoria futebol)
            routes.MapRoute(
                name: null,
                url: "{categoria}",
                defaults: new { controller = "Vitrine",action = "ListaProdutos",pagina = 1}
                );


            //4 - (Equivale a /Futebol/Pagina2 - Página 2 da categoria futebol)
            routes.MapRoute(null,
                "{categoria}/Pagina{pagina}",
                 new {controller = "Vitrine"
                     , action = "ListaProdutos"}
                     ,new { pagina = @"\d+"}
                );


            ////Rota para imagem
            //routes.MapRoute("ObterImagem",
            //    "Vitrine/ObterImagem/{produtoId}",
            //    new {controller = "Vitrine", action = "ObterImagem", produtoId = UrlParameter.Optional});

            //Default
            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
