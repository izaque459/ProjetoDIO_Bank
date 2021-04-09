using System;
using System.Collections.Generic;

namespace DIO_Bank
{
    class Program
    {
        static List<TipoContaPoupanca> listaContasPoupancas = new List<TipoContaPoupanca>();
        static List<TipoContaCorrente> listaContasCorrentes = new List<TipoContaCorrente>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper()!="X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por usar nossos serviços.");
            
        }

        private static void Sacar()
		{
            Console.WriteLine("=>Sacar ");
            Console.WriteLine("Escolhao 1 para conta poupança ou 2 para conta corrente: ");
            int escolhaTipoConta = int.Parse(Console.ReadLine());
            if(escolhaTipoConta==1)
			{
                Console.Write("Digite o número da conta: ");
			    int indiceConta = int.Parse(Console.ReadLine());

			    Console.Write("Digite o valor a ser sacado: ");
			    double valorSaque = double.Parse(Console.ReadLine());

                listaContasPoupancas[indiceConta].Sacar(valorSaque);
            }
            else
            {
                Console.Write("Digite o número da conta: ");
			    int indiceConta = int.Parse(Console.ReadLine());

			    Console.Write("Digite o valor a ser sacado: ");
			    double valorSaque = double.Parse(Console.ReadLine());

                listaContasCorrentes[indiceConta].Sacar(valorSaque);
            }
		}
        private static void Depositar()
		{
            Console.WriteLine("=>Depositar");
            Console.WriteLine("Escolha 1 para conta poupança ou 2 para conta corrente: ");
            int escolhaTipoConta = int.Parse(Console.ReadLine());
			if(escolhaTipoConta==1)
            {
                Console.Write("Digite o número da conta: ");
			    int indiceConta = int.Parse(Console.ReadLine());

			    Console.Write("Digite o valor a ser depositado: ");
			    double valorDeposito = double.Parse(Console.ReadLine());

                listaContasPoupancas[indiceConta].Depositar(valorDeposito);
            }
            else
            {
                Console.Write("Digite o número da conta: ");
			    int indiceConta = int.Parse(Console.ReadLine());

			    Console.Write("Digite o valor a ser depositado: ");
			    double valorDeposito = double.Parse(Console.ReadLine());

                listaContasCorrentes[indiceConta].Depositar(valorDeposito);
            }
		}

        private static void InserirConta()
        {
            TipoContaPoupanca conta1;
            TipoContaCorrente conta2;

            Console.WriteLine("=>Inserir nova conta");
            Console.Write("Digite 1 para Contrato de Conta Poupanca ou 2 para Contrato de Conta Corrente: ");
            int entradaTipoContrato = Int32.Parse(Console.ReadLine());
            Console.Write("Digite 0 para Pessoa Fisica ou 1 para Pessoa Juridica: ");
            int entradaTipoPessoa = Int32.Parse(Console.ReadLine());
            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();
            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());
            Console.Write("Digite o credito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            if(entradaTipoContrato==1)
            {
                conta1 = new TipoContaPoupanca((TipoPessoa)entradaTipoPessoa,entradaNome,entradaSaldo,entradaCredito);
                listaContasPoupancas.Add(conta1);
            }
            else
            {
                conta2 = new TipoContaCorrente((TipoPessoa)entradaTipoPessoa,entradaNome,entradaSaldo,entradaCredito);
                listaContasCorrentes.Add(conta2);
            }
        }

        private static void ListarContas()
        {
                Console.WriteLine("=>Listar contas");
                Console.WriteLine("  ");

                if (listaContasPoupancas.Count == 0)
                    Console.WriteLine("Nenhuma conta poupança cadastrada.");
                else
                    Console.WriteLine("Contas Poupanças Cadastradas: ");
      

                for (int i = 0; i < listaContasPoupancas.Count; i++)
                {
                    TipoContaPoupanca conta = listaContasPoupancas[i];
                    Console.Write("#{0} - ", i);
                    Console.WriteLine(conta);
                }
                
                Console.WriteLine(" ");

                if (listaContasCorrentes.Count == 0)
                    Console.WriteLine("Nenhuma conta corrente cadastrada.");
                else
                    Console.WriteLine("Contas Correntes Cadastradas: ");

                for (int j = 0; j < listaContasCorrentes.Count; j++)
                {
                    TipoContaCorrente conta = listaContasCorrentes[j];
                    Console.Write("#{0} - ", j);
                    Console.WriteLine(conta);
                }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("Informe a opcao desejada:");
            Console.WriteLine(" ");
            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("6 - Usar credito");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine($"Opcao do Usario: {opcaoUsuario} ");
            return opcaoUsuario;
        }
    }
}
