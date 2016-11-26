using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class Cliente: IdentityUser
    {
        //Com o virtual relação de 1 para 1 neste caso
        //Telefone
        [Required]
        public virtual TelefoneCliente Telefone { get; set; }
        //Documento
        [Required]
        public virtual DocumentoCliente Documento { get; set; }
        //Endereço
        [Required]
        public virtual EnderecoCliente Endereco { get; set; }
    }
}