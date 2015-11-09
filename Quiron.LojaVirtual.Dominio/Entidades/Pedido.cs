using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class Pedido
    {
        [Required(ErrorMessage = "Informe seu nome")]
        public string NomeCliente { get; set; }

        
        [Display(Name = "Cep:")]
        public string Cep { get; set; }

        
        [Required(ErrorMessage="Informe o endereço")]
        [Display(Name = "Endereço:")]
        public string Endereco { get; set; }

        
        [Display(Name = "Complemento:")]
        public string Complemento { get; set; }

        
        [Required(ErrorMessage="Informe a cidade")]
        [Display(Name = "Cidade:")]
        public string Cidade { get; set; }


        [Required(ErrorMessage="Informe o bairro")]
        [Display(Name = "Bairro:")]
        public string Bairro { get; set; }

        
        [Required(ErrorMessage="Informe o Estado")]
        [Display(Name = "Estado:")]
        public string Estado { get; set; }

        
        [Required(ErrorMessage="Informe o Email")]
        [Display(Name="Email:")]
        [EmailAddress(ErrorMessage="Email Inválido")]
        public string Email { get; set; }

        public bool EmbrulhaPresente { get; set; }
    }
}