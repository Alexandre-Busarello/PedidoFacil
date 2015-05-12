using System;

namespace PedidoFacil.Entidades
{
	public class ItemTabelaPreco
	{
        public int ID { get; set; }
		public Produto Produto { get; set; }
		public TabelaPreco TabelaPreco { get; set; }
		public Double QuantidadeMinima { get; set; }
		public Double PrecoUnitario { get; set; }
		public bool Ativo { get; set; }

		public ItemTabelaPreco (Produto produto, Double precoUnitario)
		{
			this.Produto = produto;
			this.QuantidadeMinima = 1;
			this.PrecoUnitario = precoUnitario;
			this.Ativo = true;
		}
	}
}

