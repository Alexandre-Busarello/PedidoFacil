namespace pedidofacil.ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig002 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        NomeAbreviado = c.String(),
                        Documento = c.String(),
                        Endereco_Logradouro = c.String(),
                        Endereco_Numero = c.Int(nullable: false),
                        Endereco_Bairro = c.String(),
                        Endereco_Cep = c.String(),
                        Endereco_Municipio = c.String(),
                        Endereco_Pais = c.String(),
                        Contato_Telefone = c.String(),
                        Contato_Fax = c.String(),
                        Contato_Celular = c.String(),
                        Contato_Email = c.String(),
                        IE = c.String(),
                        CodigoFabrica = c.String(),
                        TributaIpi = c.Boolean(nullable: false),
                        Representada_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Representada", t => t.Representada_ID)
                .Index(t => t.Representada_ID);
            
            CreateTable(
                "dbo.Vendedor",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cpf = c.String(),
                        Endereco_Logradouro = c.String(),
                        Endereco_Numero = c.Int(nullable: false),
                        Endereco_Bairro = c.String(),
                        Endereco_Cep = c.String(),
                        Endereco_Municipio = c.String(),
                        Endereco_Pais = c.String(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cliente", "Representada_ID", "dbo.Representada");
            DropIndex("dbo.Cliente", new[] { "Representada_ID" });
            DropTable("dbo.Vendedor");
            DropTable("dbo.Cliente");
        }
    }
}
