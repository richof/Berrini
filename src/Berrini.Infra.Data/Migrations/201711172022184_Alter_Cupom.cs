namespace Berrini.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_Cupom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cupom", "Criacao", c => c.DateTime(nullable: false));
            DropColumn("dbo.Cupom", "Criação");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cupom", "Criação", c => c.DateTime(nullable: false));
            DropColumn("dbo.Cupom", "Criacao");
        }
    }
}
