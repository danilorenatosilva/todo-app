using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoBeBlue.Dominio;

namespace TodoBeBlue.Dados.Repositorios
{
    public class TodoRepositorio
    {
        private TodoContext Contexto { get; set; }

        public TodoRepositorio()
        {
            Contexto = new TodoContext();
        }

        public void Add(Todo todo)
        {
            Contexto.Todos.Add(todo);
        }

        public void Remove(int id)
        {
            var todo = GetById(id);
            Contexto.Todos.Remove(todo);
        }

        public void Edit(int id, bool feito)
        {
            var _todo = GetById(id);
            _todo.Feito = feito;
            Contexto.Entry<Todo>(_todo).State = EntityState.Modified;
        }

        public IQueryable<Todo> GetAll()
        {
            return Contexto.Todos.Include("Categoria").OrderByDescending(t => t.Prioridade);
        }

        public Todo GetById(int id)
        {
            return GetAll().Single(t => t.TodoId == id);
        }

        public IQueryable<Todo> GetByStatus(bool status)
        {
            return GetAll().Where(t => t.Feito == status);
        }

        public IQueryable<Todo> GetByPrioridade(TodoPrioridade prioridade)
        {
            return GetAll().Where(t => t.Prioridade == prioridade);
        }

        public IQueryable<Todo> GetByCategoria(int idCategoria)
        {
            return from todo in GetAll()
                   join categoria in Contexto.Categorias
                   on todo.CategoriaId equals categoria.CategoriaId
                   select todo;
        }

        public void Commit()
        {
            Contexto.SaveChanges();
        }

    }
}
