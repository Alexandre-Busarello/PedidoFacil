namespace pedidofacil.ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Representadas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        NomeAbreviado = c.String(),
                        Cnpj = c.String(),
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
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Representadas");
        }
    }
}
