using System;
using System.Collections.Generic;

namespace PedidoFacil.Entidades
{
	public class TabelaPreco
	{
		private List<ItemTabelaPreco> _itensProduto { get; set; }

        public int ID { get; set; }
		public Representada Representada { get; set; }
		public String Codigo { get; set; }
		public String Descricao { get; set; }
		public DateTime? DataInicio { get; set; }
		public DateTime? DataValidade { get; set; }
		public bool Ativo { get; set; }
		public ICollection<ItemTabelaPreco> ItensProduto 
		{
			get { return _itensProduto; }
		}

		public TabelaPreco (Representada representada)
		{
            _itensProduto = new List<ItemTabelaPreco>();
            this.Representada = representada;
		}

		public void AdicionarItem(Produto produto, Double precoUnitario) 
		{
			_itensProduto.Add (new ItemTabelaPreco (produto, precoUnitario));
		}	

		public Double BuscarPrecoUnitario(Produto produto)
		{
			foreach(ItemTabelaPreco item in ItensProduto)
			{
				if (item.Produto.ID == produto.ID) 
				{
					return item.PrecoUnitario;
				}
			}	
			return 0;
		}
	}
}

