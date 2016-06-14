using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiron.LojaVirtual.Dominio.Entidades;

namespace Quiron.LojaVirtual.Dominio.Dto
{
    public class DetalhesProdutoDto
    {
        //Dto que representará o detalhamento do produto ao clicar nele
        public QuironProduto Produto { get; set; }
        public IEnumerable<Cor>Cores { get; set; }
        public IEnumerable<Tamanho> Tamanhos { get; set; }  
    }
}
