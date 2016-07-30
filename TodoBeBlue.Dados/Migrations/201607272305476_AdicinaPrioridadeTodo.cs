namespace TodoBeBlue.Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicinaPrioridadeTodo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Todo", "Prioridade", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Todo", "Prioridade");
        }
    }
}
