using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pedidofacil.ef.Migrations;
using System.Data.Entity.Migrations;
using PedidoFacil.DAL.Repositorios;

namespace pedidofacil.ef
{
    class Program
    {
        static void Main(string[] args)
        {
			System.Console.WriteLine ("Opções:");
			System.Console.WriteLine ("   1. Atualizar DB;");
			System.Console.WriteLine ("   2. Sair;");

			ConsoleKeyInfo key = System.Console.ReadKey ();
			while (!((key.Key.Equals(ConsoleKey.NumPad2) || key.Key.Equals(ConsoleKey.D2))))
			{
				if (key.Key.Equals (ConsoleKey.NumPad1) || key.Key.Equals (ConsoleKey.D1)) {
					var configuration = new Configuration ();
					var migrator = new DbMigrator (configuration);
					migrator.Update ();		

					System.Console.WriteLine (" ");
					System.Console.WriteLine (" ");
					System.Console.WriteLine ("Base atualizada com sucesso!");
					System.Console.WriteLine (" ");
				} else {
					System.Console.WriteLine (" ");
					System.Console.WriteLine (" ");
					System.Console.WriteLine ("Opção invalida!");
					System.Console.WriteLine (" ");
				}

				System.Console.WriteLine (" ");
				System.Console.WriteLine ("Opções:");
				System.Console.WriteLine ("   1. Atualizar DB;");
				System.Console.WriteLine ("   2. Sair;");
				key = System.Console.ReadKey ();
			}
				
			RepresentadaRepositorio repRepresentadas = new RepresentadaRepositorio ();
			System.Console.WriteLine (" ");
			System.Console.WriteLine (" ");
			System.Console.WriteLine("=======  representadas cadastradas ===========");
			foreach (var r in repRepresentadas.GetAll()) 
			{
				System.Console.WriteLine("{0} - {1} - {2} - {3}", r.ID, r.Nome, r.Cnpj, r.Endereco.Logradouro);
			}

			/*
            using (var ctx = new PedidoFacilContexto())
            {
                Representada r = new Representada();
                r.Nome = "Alexandre";
                r.Cnpj = "122487488";
                r.Endereco.Logradouro = "Rua Fraiburgo, 373";
                r.Endereco.Numero = 373;
                r.Endereco.Municipio = "Blumenau";

                Produto p = new Produto(r);
                p.Descricao = "Fogão a lenha";
                p.Detalhes = "Incrivel fogão a lenha";
                p.PercentualIpi = 7;

                Vendedor v = new Vendedor("Joelvis", "123456");

                TabelaPreco tp = new TabelaPreco(r);
                tp.DataInicio = DateTime.Now;
                tp.DataValidade = DateTime.Now.AddYears(1);
                tp.AdicionarItem(p, 160);

                ctx.Representadas.Add(r);
                ctx.Produtos.Add(p);
                ctx.Vendedores.Add(v);
                ctx.TabelasPreco.Add(tp);

                ctx.SaveChanges();

                Console.WriteLine("Representada inserida!");
            } */
        }
    }
}
