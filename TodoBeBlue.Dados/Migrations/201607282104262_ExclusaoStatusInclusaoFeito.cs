namespace TodoBeBlue.Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExclusaoStatusInclusaoFeito : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Todo", "Feito", c => c.Boolean(nullable: false));
            DropColumn("dbo.Todo", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Todo", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.Todo", "Feito");
        }
    }
}
