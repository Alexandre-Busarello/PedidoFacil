using System;

namespace PedidoFacil.Entidades
{
	public class ItemPedido
	{
		private Produto _produto;
		private Double _quantidade;

		public int ID { get; set; }
		public Pedido Pedido { get; set; }
		public Produto Produto { get { return _produto; } set{ SetProduto(value); } }
		public Double Quantidade { get{ return _quantidade; } set { SetQuantidade(value); } } 
		public Double ValorUnitario { get; set; }
		public Double ValorIpi { get; set; }
		public Double ValorTotal { get; set; }

		private void SetQuantidade(Double quantidade) 
		{
			this._quantidade = quantidade;
			this.ValorTotal = ValorUnitario * quantidade;
		}

		private void SetProduto(Produto produto)
		{
			this._produto = produto;
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

