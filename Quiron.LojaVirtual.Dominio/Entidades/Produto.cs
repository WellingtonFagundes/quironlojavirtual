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

        [Required(ErrorMessage = "Digite o nome do produto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite a descrição do produto")]
        //Para criar um TextArea
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Digite o preço do produto")]
        [Range(0.01,double.MaxValue,ErrorMessage = "Valor inválido")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Digite a categoria")]
        public string Categoria { get; set; }

        public byte[] Imagem { get; set; }

        public string ImagemMimeType { get; set; }

    }
}