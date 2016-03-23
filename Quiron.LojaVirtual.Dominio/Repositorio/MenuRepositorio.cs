using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using FastMapper;
using Quiron.LojaVirtual.Dominio.Dto;
using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Entidades.Vitrine;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    public class MenuRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<Categoria> ObterCategorias()
        {
            return _context.Categorias.OrderBy(c => c.CategoriaDescricao);
        }

        /// <summary>
        /// Obtem algumas marcas 
        /// (Invoca a classe que chamará a view MarcaVitrine criada no banco)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MarcaVitrine> ObterMarcas()
        {
            return _context.MarcaVitrine.OrderBy(m => m.MarcaDescricao);
        }


        public IEnumerable<ClubesNacionais> ObterClubesNacionais()
        {
            return _context.ClubesNacionais.OrderBy(c => c.LinhaDescricao);
        }

        public IEnumerable<ClubesInternacionais> ObterClubesInternacionais()
        {
            return _context.ClubesInternacionais.OrderBy(c => c.LinhaDescricao);
        }

        public IEnumerable<Selecoes> ObterSelecoes()
        {
            return _context.Selecoes.OrderBy(s => s.LinhaDescricao);
        }

        //Obtenho as categorias pré definidas através da query na tabela categoria
        public IEnumerable<Categoria> ObterTenisCategoria()
        {
            var categorias = new[] {"0005", "0082", "0112", "0010", "0006", "0063"};
            return _context.Categorias.Where(c => categorias.Contains(c.CategoriaCodigo))
                .OrderBy(c => c.CategoriaDescricao);
        }


        //Subgrupo tênis

        public SubGrupo SubGrupoTenis()
        {
            return _context.SubGrupos.FirstOrDefault(s => s.SubGrupoCodigo == "0084");
        }

        #region [Menu lateral Casual]
            //Retorna a modalidade Casual
        public Modalidade ModalidadeCasual()
        {
            const string CODIGOMODALIDADE = "0001";

            return _context.Modalidades.FirstOrDefault(m => m.ModalidadeCodigo == CODIGOMODALIDADE);
        }

        //Quando falamos de coleções temos 3 coleções principais:
        //IEnumerable -> Lista somente leitura
        //IQueryable -> Lista leitura e pesquisa
        //IList -> Lista leitura, pesquisa, gravação = desde o .NET 2.0
        //ICollection -> Alternativa mais recente, moderna, mais leve que o ILIST = .NET 4.0
        public IEnumerable<SubGrupoDto> ObterCasualGrupo()
        {
            var subGrupos = new[] {"0001", "0102", "0103", "0738", "0084", "0921"};

            var query = from s in _context.SubGrupos
                //Claúsula in implementada no C#
                .Where(s => subGrupos.Contains(s.SubGrupoCodigo))
                .Select(s => new {s.SubGrupoCodigo, s.SubGrupoDescricao})
                .Distinct()
                .OrderBy(s => s.SubGrupoDescricao)

                select new
                {
                    s.SubGrupoCodigo,
                    s.SubGrupoDescricao
                };

            //Usabilidade do FastMapper
            return query.Project().To<SubGrupoDto>().ToList();
        }


        #endregion [Menu lateral Casual]

        #region [Menu Lateral Suplementos]

        public Categoria Suplementos()
        {
            var codigoSuplemento = "0008";

            return _context.Categorias.FirstOrDefault(s => s.CategoriaCodigo == codigoSuplemento);
        }


        public IEnumerable<SubGrupo> ObterSuplementos()
        {
            var Subgrupos = new[] {"0162","0387","0557","0565","1082","1083","1084","1085", "0977" };

            return _context.SubGrupos.Where(s => Subgrupos.Contains(s.SubGrupoCodigo) && s.GrupoCodigo == "0012")
                .OrderBy(s => s.SubGrupoDescricao);
        } 

            
        #endregion
    }
}