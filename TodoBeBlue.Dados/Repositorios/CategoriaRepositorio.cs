using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoBeBlue.Dominio;

namespace TodoBeBlue.Dados.Repositorios
{
    public class CategoriaRepositorio
    {
        private TodoContext Context { get; set; }

        public CategoriaRepositorio()
        {
            Context = new TodoContext();
        }

        public void Add(Categoria categoria)
        {
            Context.Categorias.Add(categoria);
        }

        public IQueryable<Categoria> GetAll()
        {
            return Context.Categorias;
        }

        public Categoria GetById(int id)
        {
            return GetAll().Single(c => c.CategoriaId == id);
        }

        public IQueryable<Categoria> GetByDescricao(string descricao)
        {
            return GetAll().Where(c => c.Descricao.Contains(descricao)).OrderBy(c => c.Descricao);
        }

        public void Commit()
        {
            Context.SaveChanges();
        }
    }
}
