using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Dto
{
    //Usando uma classe DTO invés da classe pronta Subgrupo pois queremos retornar apenas 2 campos e
    //não todas as propriedades
    public class SubGrupoDto
    {
        public string SubGrupoCodigo { get; set; }
        public string SubGrupoDescricao { get; set; }
    }
}
