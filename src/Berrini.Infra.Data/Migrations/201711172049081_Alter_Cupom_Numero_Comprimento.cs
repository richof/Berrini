namespace Berrini.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_Cupom_Numero_Comprimento : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cupom", "NumeroCupom", c => c.String(nullable: false, maxLength: 10, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cupom", "NumeroCupom", c => c.String(nullable: false, maxLength: 5, unicode: false));
        }
    }
}
