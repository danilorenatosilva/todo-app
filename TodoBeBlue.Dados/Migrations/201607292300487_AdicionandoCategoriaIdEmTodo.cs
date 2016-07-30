namespace TodoBeBlue.Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionandoCategoriaIdEmTodo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Todo", "Categoria_CategoriaId", "dbo.Categoria");
            DropIndex("dbo.Todo", new[] { "Categoria_CategoriaId" });
            RenameColumn(table: "dbo.Todo", name: "Categoria_CategoriaId", newName: "CategoriaId");
            AlterColumn("dbo.Todo", "CategoriaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Todo", "CategoriaId");
            AddForeignKey("dbo.Todo", "CategoriaId", "dbo.Categoria", "CategoriaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Todo", "CategoriaId", "dbo.Categoria");
            DropIndex("dbo.Todo", new[] { "CategoriaId" });
            AlterColumn("dbo.Todo", "CategoriaId", c => c.Int());
            RenameColumn(table: "dbo.Todo", name: "CategoriaId", newName: "Categoria_CategoriaId");
            CreateIndex("dbo.Todo", "Categoria_CategoriaId");
            AddForeignKey("dbo.Todo", "Categoria_CategoriaId", "dbo.Categoria", "CategoriaId");
        }
    }
}
