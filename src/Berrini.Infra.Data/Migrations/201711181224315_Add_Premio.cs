namespace Berrini.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Premio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Premio",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(maxLength: 200, unicode: false),
                        Descricao = c.String(maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Cupom", "PremioId", c => c.Guid());
            CreateIndex("dbo.Cupom", "PremioId");
            AddForeignKey("dbo.Cupom", "PremioId", "dbo.Premio", "Id");
            DropColumn("dbo.Cupom", "Premiado");
            DropColumn("dbo.Cupom", "Premio");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cupom", "Premio", c => c.String(maxLength: 150, unicode: false));
            AddColumn("dbo.Cupom", "Premiado", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Cupom", "PremioId", "dbo.Premio");
            DropIndex("dbo.Cupom", new[] { "PremioId" });
            DropColumn("dbo.Cupom", "PremioId");
            DropTable("dbo.Premio");
        }
    }
}
