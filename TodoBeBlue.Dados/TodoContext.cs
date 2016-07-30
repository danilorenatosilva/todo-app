using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoBeBlue.Dominio;

namespace TodoBeBlue.Dados
{
    public class TodoContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Todo> Todos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
