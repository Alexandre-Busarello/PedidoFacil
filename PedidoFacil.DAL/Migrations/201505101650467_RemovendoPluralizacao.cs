namespace pedidofacil.ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovendoPluralizacao : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Produtoes", newName: "Produto");
            RenameTable(name: "dbo.Representadas", newName: "Representada");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Representada", newName: "Representadas");
            RenameTable(name: "dbo.Produto", newName: "Produtoes");
        }
    }
}
