using System;
using PedidoFacil.Entidades.Complementares;

namespace PedidoFacil.Entidades
{
	public class Representada
	{
        public int ID { get; set; }
		public String Nome { get; set; }
		public String NomeAbreviado { get; set; }
		public String Cnpj { get; set; }
		public Endereco Endereco { get; set; }
		public Contato Contato { get; set; }

        public Representada()
        {
            Endereco = new Endereco();
            Contato = new Contato();
        }
	}
}

