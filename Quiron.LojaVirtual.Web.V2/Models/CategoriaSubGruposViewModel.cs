using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiron.LojaVirtual.Dominio.Entidades;

namespace Quiron.LojaVirtual.Web.V2.Models
{
    public class CategoriaSubGruposViewModel
    {
        public Categoria Categoria { get; set; }
        public IEnumerable<SubGrupo> SubGrupos { get; set; }

    }
}
