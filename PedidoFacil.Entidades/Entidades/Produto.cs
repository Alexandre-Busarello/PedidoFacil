using System;
using PedidoFacil.Entidades.Complementares;

namespace PedidoFacil.Entidades
{
	public class Produto
	{
		private InformacoesFiscais _informacoesFiscais = new InformacoesFiscais();

        public int ID { get; set; }
		public virtual Representada Representada { get; set; }
		public String Descricao { get; set; }
		public String Detalhes { get; set; }
		public Double PercentualIpi 
		{
			get { return _informacoesFiscais.PercentualIpi; }
			set { _informacoesFiscais.PercentualIpi = value; }
		}

		public Produto (Representada representada) 
		{
			this.Representada = representada;
		}
	}
}

