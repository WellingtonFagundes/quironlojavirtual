using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.Models;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        private ProdutosRepositorio _repositorio;


        public ViewResult Index(Carrinho carrinho, string returnurl)
        {
            return View(new CarrinhoViewModel
            {
                Carrinho = carrinho,
                ReturnUrl = returnurl
            });
        }


        public PartialViewResult Resumo(Carrinho carrinho)
        {
            //Carrinho carrinho = ObterCarrinho();

            return PartialView(carrinho);
        }

        public RedirectToRouteResult Adicionar(Carrinho carrinho, int produtoId, int quantidade, string returnUrl) 
        {
            _repositorio = new ProdutosRepositorio();

            Produto produto = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

            if (produto != null)
            {
                carrinho.AdicionarItem(produto,quantidade);
            }

            return RedirectToAction("Index", new {returnUrl});
        }

        //private Carrinho ObterCarrinho()
        //{
        //    Carrinho carrinho = (Carrinho)Session["Carrinho"];

        //    if (carrinho == null)
        //    {
        //        carrinho = new Carrinho();
        //        Session["Carrinho"] = carrinho;
        //    }

        //    return carrinho;
        //}

        public RedirectToRouteResult Remover(Carrinho carrinho, int produtoId, string returnUrl)
        {
            _repositorio = new ProdutosRepositorio();

            Produto produto = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

            if (produto != null)
            {
                carrinho.RemoverItem(produto);
            }

            return RedirectToAction("Index", new {returnUrl});
        }

      

        public ViewResult FecharPedido()
        {
            return View(new Pedido());
        }

        [HttpPost]
        public ViewResult FecharPedido(Carrinho carrinho, Pedido pedido)
        {
            //Carrinho carrinho = ObterCarrinho();

            EmailConfiguracoes email = new EmailConfiguracoes
            {
                EscreverArquivo = bool.Parse(ConfigurationManager.AppSettings["Email.EscreverArquivo"] ?? "false")
            };

            EmailPedido emailpedido = new EmailPedido(email);

            //Se estiver vazio mostre a mensagem de erro
            if (!carrinho.ItensCarrinho.Any())
            {
                ModelState.AddModelError("","Não foi possível concluir o pedido, seu carrinho está vazio!!!");                
            }

            //Se todos os campos estiverem preenchidos gravar o pedido
            if (ModelState.IsValid)
            {
                emailpedido.ProcessarPedido(carrinho,pedido);
                carrinho.LimparCarrinho();

                return View("PedidoConcluido");
            }
            else
            {
                return View(pedido);
            }

        }

        public ViewResult PedidoConcluido()
        {
            return View();
        }
    }
}