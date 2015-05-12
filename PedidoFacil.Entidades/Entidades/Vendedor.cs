using System;
using PedidoFacil.Entidades.Complementares;

namespace PedidoFacil.Entidades
{
	public class Vendedor
	{
        public int ID { get; set; }
		public String Nome { get; set; }
		public String Cpf { get; set; }
        public Endereco Endereco { get; set; }
		public bool Ativo { get; set; }

		public Vendedor (String nome, String cpf)
		{
			this.Nome = nome;
			this.Cpf = cpf;
			this.Ativo = true;

            this.Endereco = new Endereco();
		}
	}
}

