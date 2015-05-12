using System;
using PedidoFacil.Entidades.Complementares;

namespace PedidoFacil.Entidades
{
	public class Cliente
	{
		private InformacoesFiscais _informacoesFiscais = new InformacoesFiscais();

        public int ID { get; set; }
		public Representada Representada { get; set; }
		public String Nome { get; set; }
		public String NomeAbreviado { get; set; }
		public String Documento { get; set; }
        public Endereco Endereco { get; set; }
        public Contato Contato { get; set; }
		public String IE { get; set; }
		public String CodigoFabrica { get; set; }
		public bool TributaIpi 
		{
			get { return _informacoesFiscais.TributaIpi; }
			set { _informacoesFiscais.TributaIpi = value; }
		}

		public Cliente (String nome, String documento, Representada representada)
		{
			this.Nome = nome;
			this.Documento = documento;
			this.TributaIpi = false;
            this.Representada = representada;

            this.Endereco = new Endereco();
            this.Contato = new Contato();
		}
	}
}

