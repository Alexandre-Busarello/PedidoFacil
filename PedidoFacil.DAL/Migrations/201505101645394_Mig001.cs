namespace pedidofacil.ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Detalhes = c.String(),
                        PercentualIpi = c.Double(nullable: false),
                        Representada_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Representadas", t => t.Representada_ID)
                .Index(t => t.Representada_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "Representada_ID", "dbo.Representadas");
            DropIndex("dbo.Produtoes", new[] { "Representada_ID" });
            DropTable("dbo.Produtoes");
        }
    }
}
