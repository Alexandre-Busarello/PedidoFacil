using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PedidoFacil.Entidades;

namespace PedidoFacil.DAL
{
    class PedidoFacilContexto : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Representada> Representadas { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<TabelaPreco> TabelasPreco { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        public PedidoFacilContexto()
        {

        }

        protected override void OnModelCreating (DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
