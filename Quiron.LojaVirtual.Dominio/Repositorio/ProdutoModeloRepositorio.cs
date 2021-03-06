﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Html;
using Quiron.LojaVirtual.Dominio.Entidades.Vitrine;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    public class ProdutoModeloRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

        /// <summary>
        /// Obter produtos da view SQL ProdutoVitrine
        /// </summary>
        /// <param name="categoria"></param>
        /// <param name="genero"></param>
        /// <param name="grupo"></param>
        /// <param name="subgrupo"></param>
        /// <param name="linha"></param>
        /// <param name="marca"></param>
        /// <param name="modalidade"></param>
        /// <returns></returns>
        public List<ProdutoVitrine> ObterProdutosVitrine(string categoria = null,string genero = null
             ,string grupo = null,string subgrupo = null,string linha = null,string marca = null, string modalidade = null
             ,string busca = null)
        {
            var query = from p in _context.ProdutoVitrine select p;

            if (!string.IsNullOrEmpty(categoria))
                query = query.Where(c => c.CategoriaCodigo == categoria);

            if (!string.IsNullOrEmpty(genero))
                query = query.Where(c => c.GeneroCodigo == genero);

            if (!string.IsNullOrEmpty(grupo))
                query = query.Where(c => c.GrupoCodigo == grupo);

            if (!string.IsNullOrEmpty(subgrupo))
                query = query.Where(c => c.SubGrupoCodigo == subgrupo);


            if (!string.IsNullOrEmpty(linha))
                query = query.Where(c => c.LinhaCodigo == linha);

            if (!string.IsNullOrEmpty(marca))
                query = query.Where(c => c.MarcaCodigo == marca);

            if (!string.IsNullOrEmpty(modalidade))
                query = query.Where(c => c.ModalidadeCodigo == modalidade);

            if (!string.IsNullOrEmpty(busca))
                //query = query.Where(p => p.ProdutoDescricao.StartsWith(busca)); //%proteina
                //query = query.Where(p => p.ProdutoDescricao.EndsWith(busca)); //proteina%
                query = query.Where(p => p.ProdutoDescricao.Contains(busca)); //%proteina%

            // O Guid retorna dados aleatoriamente
            query = query.OrderBy(r => Guid.NewGuid());
            //Carrega 40 itens
            query = query.Take(40);

            return query.ToList();
        }


        //public List<ProdutoVitrine> ObterProdutos()
        //{
        //    var produtos = _context.ProdutoVitrine
        //        .OrderBy(r => Guid.NewGuid())
        //        .Take(20).ToList();

        //    return produtos;
        //}

        //public List<ProdutoVitrine> ObterProdutosPorGenero(string genero)
        //{
        //    var produtos = _context.ProdutoVitrine
        //        .Where(g => g.GeneroCodigo == genero)
        //        .OrderBy(r => Guid.NewGuid())
        //        .Take(20).ToList();

        //    return produtos;
        //}
    }
}