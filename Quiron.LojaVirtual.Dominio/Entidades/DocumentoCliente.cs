using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class DocumentoCliente
    {
        [Key,ForeignKey("Id")]
        public virtual Cliente Cliente { get; set; }

        public string Id { get; set; }
        public TipoDocumento Tipo { get; set; }
        public long Valor { get; set; }
        public DateTime DtNasc { get; set; }
    }

    public enum TipoDocumento
    {
        CPF
    }
}