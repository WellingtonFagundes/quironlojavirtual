using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string CategoriaCodigo { get; set; }
        public string CategoriaDescricao { get; set; }
    }
}