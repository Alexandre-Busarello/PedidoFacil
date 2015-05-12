using System;

namespace PedidoFacil.Entidades
{
	public class Comissao
	{
		public int ID { get; set; }
		public Vendedor Vendedor { get; set; }
		public Pedido Pedido { get; set; }
		public Double Percentual { get; set; }
		public Double Valor { get; set; }

		public Comissao (Pedido pedido, Vendedor vendedor)
		{
			this.Pedido = pedido;
			this.Vendedor = vendedor;
		}

		public void CalcularComissao() 
		{
			this.Percentual = Pedido.Vendedor.PercentualComissao;
			this.Valor = (Pedido.ValorTotal / 100) * this.Percentual;
		}
	}
}

