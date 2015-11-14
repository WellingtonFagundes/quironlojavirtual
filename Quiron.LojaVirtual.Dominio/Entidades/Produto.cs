using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class Produto
    {
        //Para ocultar o produtoId
        [HiddenInput(DisplayValue=false)]
        public int ProdutoId { get; set; }

        public string Nome { get; set; }

        //Para criar um TextArea
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        public decimal Preco { get; set; }

        public string Categoria { get; set; }
    }
}