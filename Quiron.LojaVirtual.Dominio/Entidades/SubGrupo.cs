using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class SubGrupo
    {
        public int SubGrupoId { get; set; }
        public string GrupoCodigo { get; set; }
        public string SubGrupoCodigo { get; set; }
        public string SubGrupoDescricao { get; set; }
    }
}