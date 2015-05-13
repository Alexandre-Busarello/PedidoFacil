using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pedidofacil.ef.Migrations;
using System.Data.Entity.Migrations;
using PedidoFacil.DAL.Repositorios;
using PedidoFacil.Entidades;
using PedidoFacil.DAL;

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

            using (var ctx = new PedidoFacilContexto())
            {
                Representada r = new Representada();
                r.Nome = "Alexandre";
                r.Cnpj = "122487488";
                r.Endereco.Logradouro = "Rua Fraiburgo, 373";
                r.Endereco.Numero = 373;
                r.Endereco.Municipio = "Blumenau";

                ctx.Representadas.Add(r);
                ctx.SaveChanges();
            }

            /*
			RepresentadaRepositorio repRepresentadas = new RepresentadaRepositorio ();

			ClienteRepositorio cliRep = new ClienteRepositorio ();
			Cliente cliente = new Cliente ("Alexandre", "07063272926", repRepresentadas.Find (1));			
			cliente.Documento = "07063272926";
			cliente.Endereco.Logradouro = "Rua Fraiburgo";
			cliente.Endereco.Numero = 373;
			cliRep.Adicionar (cliente);

			VendendorRepositorio venRep = new VendendorRepositorio ();
			Vendedor vendedor = new Vendedor ("Juquinha", "857487");
			vendedor.Endereco.Logradouro = "Sei la";
			vendedor.Endereco.Numero = 10;
			vendedor.PercentualComissao = 10;
			vendedor.Ativo = true;
			venRep.Adicionar (vendedor);

			ProdutoRepositorio proRep = new ProdutoRepositorio ();
			Produto produto = new Produto (repRepresentadas.Find (1));
			produto.Descricao = "Fogão Dako";
			produto.Detalhes = "Dako é bom";
			produto.PercentualIpi = 15;
			proRep.Adicionar (produto);
				
			TabelaPrecoRepositorio tabPreRep = new TabelaPrecoRepositorio ();
			TabelaPreco tabPreco = new TabelaPreco (produto.Representada);
			tabPreco.Descricao = "TAB001";
			//tabPreco.DataInicio = DateTime.Now;
			//tabPreco.DataValidade = DateTime.Now.AddYears(1);
			tabPreco.AdicionarItem (produto, 150);
			tabPreRep.Adicionar (tabPreco);

			cliRep.SalvarTodos ();
			venRep.SalvarTodos ();
			proRep.SalvarTodos ();
			tabPreRep.SalvarTodos ();

			Pedido pedido = new Pedido();
			pedido.Representada = produto.Representada;
			pedido.Cliente = cliente;
			pedido.Vendedor = vendedor;
			pedido.TabelaPreco = tabPreco;
			pedido.AdicionarItem (produto, 5);

			PedidoRepositorio pedRep = new PedidoRepositorio ();
			pedRep.Adicionar (pedido);
			pedRep.SalvarTodos ();

			pedido.FecharPedido ();
			pedRep.Atualizar (pedido);

			ComissaoRepositorio comRep = new ComissaoRepositorio ();
			comRep.GerarComissao (pedido);
			comRep.SalvarTodos ();
           
			System.Console.WriteLine (" ");
			System.Console.WriteLine (" ");
			System.Console.WriteLine("=======  representadas cadastradas ===========");
			foreach (var r in repRepresentadas.GetAll()) 
			{
				System.Console.WriteLine("{0} - {1} - {2} - {3}", r.ID, r.Nome, r.Cnpj, r.Endereco.Logradouro);
			}
             * /

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
