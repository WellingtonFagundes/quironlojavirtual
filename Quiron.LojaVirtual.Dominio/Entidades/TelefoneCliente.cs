using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class TelefoneCliente
    {
        [Key,ForeignKey("Id")]
        public virtual Cliente cliente { get; set; }
        public string Id { get; set; }
        public string CodigoArea { get; set; }
        public string Numero { get; set; }
    }
}