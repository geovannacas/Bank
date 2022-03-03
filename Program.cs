using System.Collections.Generic;

namespace Bank
{ 
    class Program
    {
     static List<conta> listconta = new List<conta>();
     static void Main(string[] args)
     {
       string opcao = ObterOpcao();
      
       while(opcao.ToUpper() != "X")
       {
           switch(opcao)
           {
               case "1":
                   ListarContas();
                   break;
               case "2":
                   Inserir();
                   break;
               case "3":
                   Transferir();
                   break;
               case "4":
                  Sacar();
                  break;
               case "5":
                  Depositar();
                  break;
               case "6":
                  Doar();
                  break;
               case "7":
                  Emprestimos();
                  break;
               case "C":
                  Console.Clear();
                  break;
               default:
                  throw new ArgumentOutOfRangeException();
            }
            opcao = ObterOpcao();
        }

        Console.WriteLine("Obrigada por utilizar Bank, seu console de transferências bancárias único.");
        Console.WriteLine("Volte sempre!");
        Console.ReadLine();
    }

       private static void Depositar()
       {
           Console.Write("Digite o número da conta: ");
           int numeroconta = int.Parse(Console.ReadLine());
           Console.Write("Digite o valor a ser depositado: ");
		   double valordepositar = double.Parse(Console.ReadLine());

            listconta[numeroconta].Depositar(valordepositar);

            Console.Write("Valor depositado com sucesso!");
        }
        private static void Sacar()
		{
			Console.Write("Digite o número da conta: ");
			int numeroconta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser sacado: ");
			double valorsacar = double.Parse(Console.ReadLine());

            listconta[numeroconta].Sacar(valorsacar);

            Console.Write("Valor sacado com sucesso!");
		}
       private static void Transferir()
       {
           Console.Write("Digite o número da conta do remetente: ");
           int numerocontaremetente = int.Parse(Console.ReadLine());
           Console.Write("Digite o número da conta do destinatário: ");
           int numerocontadestinatario = int.Parse(Console.ReadLine());
           Console.Write("Digite o valor da transferência: ");
           double valortransferir = double.Parse(Console.ReadLine());

           listconta[numerocontaremetente].Transferir(valortransferir, listconta[numerocontadestinatario]);
           Console.Write("Valor transferido com sucesso!");
       }
       private static void Inserir()
       {
           Console.WriteLine("Inserir nova conta");

			Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
			int entradatipoconta = int.Parse(Console.ReadLine());

			Console.Write("Digite o nome do cliente: ");
			string entradanome = Console.ReadLine();

			Console.Write("Digite o saldo inicial: ");
			double entradasaldo = double.Parse(Console.ReadLine());

			Console.Write("Digite o crédito: ");
			double entradacredito = double.Parse(Console.ReadLine());

			conta novaConta = new conta(tipo: (tipo)entradatipoconta,
										saldo: entradasaldo,
										credito: entradacredito,
										nome: entradanome);

			listconta.Add(novaConta);
            Console.Write("Conta adicionada com sucesso!");
       }
       private static void ListarContas()
		{
			Console.WriteLine("... Listando contas ...");

			if (listconta.Count == 0)
			{
				Console.WriteLine("Nenhuma conta cadastrada.");
				return;
			}

			for (int i = 0; i < listconta.Count; i++)
			{
				conta conta = listconta[i];
				Console.Write("#{0} - ", i);
				Console.WriteLine(conta);
                Console.Write("Listado com sucesso!");
			}
		}
        private static void Doar()
		{
			Console.Write("Digite o número da conta: ");
			int numeroconta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser doado: ");
			double valordoar = double.Parse(Console.ReadLine());

            listconta[numeroconta].Doar(valordoar);

            Console.Write("Valor doado com sucesso!");
		}
        private static void Emprestimos()
        {
           Console.Write("Digite o número da conta: ");
           int numeroconta = int.Parse(Console.ReadLine());
           Console.Write("Digite o valor do empréstimo: ");
		   double valoremprestar = double.Parse(Console.ReadLine());

            listconta[numeroconta].Emprestimos(valoremprestar);

            Console.Write("Valor de empréstimo debitado com sucesso!");
        }
        private static string ObterOpcao()
		{
			Console.WriteLine();
			Console.WriteLine("*----------*Bank*----------*");
            Console.WriteLine();
			Console.WriteLine("-> Digite a opção escolhida:");
            Console.WriteLine();
			Console.WriteLine("(1) Lista de contas existentes");
			Console.WriteLine("(2) Adicionar nova conta");
			Console.WriteLine("(3) Transferência");
			Console.WriteLine("(4) Saque");
			Console.WriteLine("(5) Depósito");
            Console.WriteLine("(6) Doações");
            Console.WriteLine("(7) Empréstimos");
            Console.WriteLine("(C) Limpar Tela");
			Console.WriteLine("(X) Sair");
            Console.WriteLine();
            Console.WriteLine("*---------------------*");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
   }
}