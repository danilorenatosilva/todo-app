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
    public class TodosController : ApiController
    {

        public TodoRepositorio todoRepositorio { get; set; }

        public TodosController()
        {
            todoRepositorio = new TodoRepositorio();
        }

        // GET api/todos
        [HttpGet]
        public IEnumerable<Todo> Get()
        {
            var todos = todoRepositorio.GetAll().ToList();
            return todos;
        }

        // GET api/todos/5
        public Todo Get(int id)
        {
            return todoRepositorio.GetById(id);
        }

        // POST api/todos
        public void Post([FromBody]Todo todo)
        {
            if (todo.CategoriaId == 0 || string.IsNullOrEmpty(todo.Descricao))
                return;

            todoRepositorio.Add(todo);
            todoRepositorio.Commit(); 
        }

        // PUT api/todos/5         
        public void Put([FromBody]Todo todo)
        {            
            todoRepositorio.Edit(todo.TodoId, todo.Feito);
            todoRepositorio.Commit();           
        }

        // DELETE api/todos/5
        public void Delete(int id)
        {
            todoRepositorio.Remove(id);
            todoRepositorio.Commit();
        }
    }
}
