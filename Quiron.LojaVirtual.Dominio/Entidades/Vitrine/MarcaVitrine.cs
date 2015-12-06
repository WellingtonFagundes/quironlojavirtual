using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quiron.LojaVirtual.Dominio.Entidades.Vitrine
{
    //Classe que representa a view MarcaVitrine do banco
    public class MarcaVitrine
    {
        [Key]
        public string MarcaCodigo { get; set; }

        public string MarcaDescricao { get; set; }
    }
}