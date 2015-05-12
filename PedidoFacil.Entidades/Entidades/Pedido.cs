using System;
using System.Collections.Generic;
using PedidoFacil.Entidades.Complementares;

namespace PedidoFacil.Entidades
{
	public class Pedido
	{
		private List<ItemPedido> _itensProduto { get; set; }

        public int Id { get; set; }
		public Representada Representada { get; set; }
		public Cliente Cliente { get; set; }
		public Vendedor Vendedor { get; set; }
		public TabelaPreco TabelaPreco { get; set; }
		public DateTime DataDigitacao { get; set; }
		public DateTime DataEmissao { get; set; }
		public StatusEnum Status { get; set; }
		public Double ValorTotal { get; set; }
		public Double ValorTotalIpi { get; set; }

        private void iniciarPedido()
        {
            this.DataDigitacao = DateTime.Now;
            this.Status = StatusEnum.ABERTO;
        }

        public Pedido()
        {
            iniciarPedido();
        }

		public Pedido (Representada representada, Cliente cliente, Vendedor vendedor, TabelaPreco tabelaPreco)
		{
            this.Representada = representada;
            this.Cliente = cliente;
            this.Vendedor = vendedor;
            this.TabelaPreco = tabelaPreco;

            iniciarPedido();
		}

		public void AdicionarItem(Produto produto, Double quantidade) 
		{
			ItemPedido itemPedido = new ItemPedido (this, produto, quantidade);
			_itensProduto.Add (itemPedido);
			ValorTotal += itemPedido.ValorTotal;
			ValorTotalIpi += itemPedido.ValorIpi;
		}	

		public void FecharPedido()
		{
			DataEmissao = DateTime.Now;
			Status = StatusEnum.FECHADO;
		}
	}
}

