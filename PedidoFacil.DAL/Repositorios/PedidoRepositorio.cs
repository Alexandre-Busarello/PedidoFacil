using System;
using PedidoFacil.DAL.Base;
using PedidoFacil.Entidades;
using PedidoFacil.Entidades.Complementares;
using System.Collections.Generic;

namespace PedidoFacil.DAL
{
	public class PedidoRepositorio : Repositorio<Pedido>
	{
		public PedidoRepositorio ()
		{
		}

		public ICollection<Pedido> ObterTodosPedidosFechados () 
		{
			return CastToList<Pedido>(this.Get (p => p.Status.Equals (StatusEnum.FECHADO)));
		}

		public void ApurarComissoes () 
		{
			foreach (Pedido pedidoFechado in ObterTodosPedidosFechados()) 
			{
				ComissaoRepositorio comRep = new ComissaoRepositorio ();		
				if (!comRep.TemRegistroComissao(pedidoFechado, pedidoFechado.Vendedor)) 
				{
					comRep.GerarComissao (pedidoFechado);
				}
			}
		}	
	}
}

