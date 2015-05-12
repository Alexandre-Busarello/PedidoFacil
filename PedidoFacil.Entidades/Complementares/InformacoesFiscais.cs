using System;

namespace PedidoFacil.Entidades.Complementares
{
	public class InformacoesFiscais
	{
        private Double _percentualIpi;

		public bool TributaIpi { get; set; }
        public Double PercentualIpi { get { return _percentualIpi; } set { SetPercentualIpi(value); } }

		private void SetPercentualIpi(Double perIpi) 
		{
			this._percentualIpi = perIpi;
			this.TributaIpi = true;
		}
	}
}

