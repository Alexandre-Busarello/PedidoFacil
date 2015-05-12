using System;

namespace PedidoFacil.Entidades
{
	public class ItemPedido
	{
		public int Id { get; set; }
		public Pedido Pedido { get; set; }
		public Produto Produto { get { return Produto; } set{ SetProduto(value); } }
		public Double Quantidade { get{ return Quantidade; } set { SetQuantidade(value); } } 
		public Double ValorUnitario { get; set; }
		public Double ValorIpi { get; set; }
		public Double ValorTotal { get; set; }

		private void SetQuantidade(Double quantidade) 
		{
			this.Quantidade = quantidade;
			this.ValorTotal = ValorUnitario * quantidade;
		}

		private void SetProduto(Produto produto)
		{
			this.Produto = produto;
			this.ValorIpi = 15;
		}

		public ItemPedido (Pedido pedido, Produto produto, Double quantidade) 
		{
			this.Pedido = pedido;
			this.Produto = produto;
			this.Quantidade = quantidade;
			this.ValorUnitario = pedido.TabelaPreco.BuscarPrecoUnitario (produto);
			this.ValorTotal = this.ValorUnitario * quantidade;
			this.ValorIpi = (this.ValorTotal / 100) * produto.PercentualIpi;
		}
	}
}

