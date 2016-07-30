using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TodoBeBlue.Dados.Repositorios;
using TodoBeBlue.Dominio;

namespace TodoBeBlue.Controllers
{
    public class CategoriasController : ApiController
    {

        public CategoriaRepositorio categoriaRepositorio { get; set; }

        public CategoriasController()
        {
            categoriaRepositorio = new CategoriaRepositorio();
        }

        // GET api/categorias
        public IEnumerable<Categoria> Get()
        {
            return categoriaRepositorio.GetAll().OrderBy(c => c.Descricao);
        }
        
        // POST api/categorias
        public void Post([FromBody]Categoria categoria)
        {
            categoriaRepositorio.Add(categoria);
            categoriaRepositorio.Commit();
        }

    }
}
