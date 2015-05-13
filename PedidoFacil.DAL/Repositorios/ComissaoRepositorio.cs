using System;
using PedidoFacil.Entidades;
using PedidoFacil.DAL.Base;
using System.Collections.Generic;

namespace PedidoFacil.DAL.Repositorios
{
	public class ComissaoRepositorio : Repositorio<Comissao>
	{
		public ComissaoRepositorio ()
		{
		}

		public bool TemRegistroComissao (Pedido pedido, Vendedor vendedor)
		{
			ICollection<Comissao> comissoes = CastToList<Comissao>(this.Get (c => ((c.Pedido.ID == pedido.ID) && (c.Vendedor.ID == pedido.Vendedor.ID))));
			return comissoes.Count > 0;
		}

		public void GerarComissao (Pedido pedido)
		{
			Comissao comissao = new Comissao (pedido, pedido.Vendedor);
			comissao.CalcularComissao ();
			this.Adicionar (comissao);
		}
	}
}

