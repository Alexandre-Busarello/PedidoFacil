namespace pedidofacil.ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadoTabelasPrecoEPedidos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemPedido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantidade = c.Double(nullable: false),
                        ValorUnitario = c.Double(nullable: false),
                        ValorIpi = c.Double(nullable: false),
                        ValorTotal = c.Double(nullable: false),
                        Pedido_Id = c.Int(),
                        Produto_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pedido", t => t.Pedido_Id)
                .ForeignKey("dbo.Produto", t => t.Produto_ID)
                .Index(t => t.Pedido_Id)
                .Index(t => t.Produto_ID);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataDigitacao = c.DateTime(nullable: false),
                        DataEmissao = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        ValorTotal = c.Double(nullable: false),
                        ValorTotalIpi = c.Double(nullable: false),
                        Cliente_ID = c.Int(),
                        Representada_ID = c.Int(),
                        TabelaPreco_ID = c.Int(),
                        Vendedor_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.Cliente_ID)
                .ForeignKey("dbo.Representada", t => t.Representada_ID)
                .ForeignKey("dbo.TabelaPreco", t => t.TabelaPreco_ID)
                .ForeignKey("dbo.Vendedor", t => t.Vendedor_ID)
                .Index(t => t.Cliente_ID)
                .Index(t => t.Representada_ID)
                .Index(t => t.TabelaPreco_ID)
                .Index(t => t.Vendedor_ID);
            
            CreateTable(
                "dbo.TabelaPreco",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Codigo = c.String(),
                        Descricao = c.String(),
                        DataInicio = c.DateTime(nullable: false),
                        DataValidade = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        Representada_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Representada", t => t.Representada_ID)
                .Index(t => t.Representada_ID);
            
            CreateTable(
                "dbo.ItemTabelaPreco",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuantidadeMinima = c.Double(nullable: false),
                        PrecoUnitario = c.Double(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        Produto_ID = c.Int(),
                        TabelaPreco_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Produto", t => t.Produto_ID)
                .ForeignKey("dbo.TabelaPreco", t => t.TabelaPreco_ID)
                .Index(t => t.Produto_ID)
                .Index(t => t.TabelaPreco_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemPedido", "Produto_ID", "dbo.Produto");
            DropForeignKey("dbo.ItemPedido", "Pedido_Id", "dbo.Pedido");
            DropForeignKey("dbo.Pedido", "Vendedor_ID", "dbo.Vendedor");
            DropForeignKey("dbo.Pedido", "TabelaPreco_ID", "dbo.TabelaPreco");
            DropForeignKey("dbo.TabelaPreco", "Representada_ID", "dbo.Representada");
            DropForeignKey("dbo.ItemTabelaPreco", "TabelaPreco_ID", "dbo.TabelaPreco");
            DropForeignKey("dbo.ItemTabelaPreco", "Produto_ID", "dbo.Produto");
            DropForeignKey("dbo.Pedido", "Representada_ID", "dbo.Representada");
            DropForeignKey("dbo.Pedido", "Cliente_ID", "dbo.Cliente");
            DropIndex("dbo.ItemTabelaPreco", new[] { "TabelaPreco_ID" });
            DropIndex("dbo.ItemTabelaPreco", new[] { "Produto_ID" });
            DropIndex("dbo.TabelaPreco", new[] { "Representada_ID" });
            DropIndex("dbo.Pedido", new[] { "Vendedor_ID" });
            DropIndex("dbo.Pedido", new[] { "TabelaPreco_ID" });
            DropIndex("dbo.Pedido", new[] { "Representada_ID" });
            DropIndex("dbo.Pedido", new[] { "Cliente_ID" });
            DropIndex("dbo.ItemPedido", new[] { "Produto_ID" });
            DropIndex("dbo.ItemPedido", new[] { "Pedido_Id" });
            DropTable("dbo.ItemTabelaPreco");
            DropTable("dbo.TabelaPreco");
            DropTable("dbo.Pedido");
            DropTable("dbo.ItemPedido");
        }
    }
}
