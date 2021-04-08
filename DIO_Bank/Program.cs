using System;
using System.Collections.Generic;

namespace DIO_Bank
{
    class Program
    {
        static List<TipoConta> listaContas= new List<TipoConta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper()!="X")
            {
                switch(opcaoUsuario)
                {
                    case "2":
                        InserirConta();
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

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta:");
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

            ContaFactory contaFactory = new ContaFactory();
            TipoConta novaConta = contaFactory.GetConta(entradaTipoContrato,(TipoPessoa)entradaTipoPessoa, entradaNome, entradaSaldo, entradaCredito);
            listaContas.Add(novaConta);
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
            Console.WriteLine(" ");
            return opcaoUsuario;
        }
    }
}
