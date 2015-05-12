namespace pedidofacil.ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovidoNovoCampoRepresentada : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Representadas", "NovoCampo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Representadas", "NovoCampo", c => c.String());
        }
    }
}
