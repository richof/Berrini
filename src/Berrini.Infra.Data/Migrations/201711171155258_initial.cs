namespace Berrini.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClienteCupom",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ClienteId = c.Guid(nullable: false),
                        CupomId = c.Guid(nullable: false),
                        Cadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Cupom", t => t.CupomId, cascadeDelete: true)
                .Index(t => t.ClienteId)
                .Index(t => t.CupomId);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        CPF = c.String(nullable: false, maxLength: 11, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cupom",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NumeroCupom = c.String(nullable: false, maxLength: 5, unicode: false),
                        Criação = c.DateTime(nullable: false),
                        MesesValidade = c.Int(nullable: false),
                        Premiado = c.Boolean(nullable: false),
                        Premio = c.String(maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClienteCupom", "CupomId", "dbo.Cupom");
            DropForeignKey("dbo.ClienteCupom", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.ClienteCupom", new[] { "CupomId" });
            DropIndex("dbo.ClienteCupom", new[] { "ClienteId" });
            DropTable("dbo.Cupom");
            DropTable("dbo.Cliente");
            DropTable("dbo.ClienteCupom");
        }
    }
}
