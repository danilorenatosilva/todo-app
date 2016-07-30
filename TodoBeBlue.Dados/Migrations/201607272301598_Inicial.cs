namespace TodoBeBlue.Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Todo",
                c => new
                    {
                        TodoId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Status = c.Int(nullable: false),
                        Categoria_CategoriaId = c.Int(),
                    })
                .PrimaryKey(t => t.TodoId)
                .ForeignKey("dbo.Categoria", t => t.Categoria_CategoriaId)
                .Index(t => t.Categoria_CategoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Todo", "Categoria_CategoriaId", "dbo.Categoria");
            DropIndex("dbo.Todo", new[] { "Categoria_CategoriaId" });
            DropTable("dbo.Todo");
            DropTable("dbo.Categoria");
        }
    }
}
