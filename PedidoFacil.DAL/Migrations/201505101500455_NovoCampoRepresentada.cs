namespace pedidofacil.ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NovoCampoRepresentada : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Representadas", "NovoCampo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Representadas", "NovoCampo");
        }
    }
}
