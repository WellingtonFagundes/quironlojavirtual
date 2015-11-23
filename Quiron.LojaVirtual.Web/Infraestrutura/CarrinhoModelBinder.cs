using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Entidades;
//using IModelBinder = System.Web.Http.ModelBinding.IModelBinder;
//using ModelBindingContext = System.Web.Http.ModelBinding.ModelBindingContext;

namespace Quiron.LojaVirtual.Web.Infraestrutura
{
    public class CarrinhoModelBinder : IModelBinder
    {
        private const string SessionKey = "Carrinho";

        //IModelBinder interface define o método BindModel
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //Obtenho o carrinho da sessão
            Carrinho carrinho = null;

            if (controllerContext.HttpContext.Session != null)
            {
                carrinho = (Carrinho) controllerContext.HttpContext.Session[SessionKey];
            }

            //Cria o carrinho se não tenho a sessão
            if (carrinho == null)
            {
                carrinho = new Carrinho();

                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[SessionKey] = carrinho;
                }
            }

            //Retorna o carrinho
            return carrinho;

        }
    }
}