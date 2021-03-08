using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {  
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
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
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Volte sempre!");
            Console.ReadLine();
        }
//////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor da transferencia: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }
//////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor do deposito:");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }

///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor do saque:");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

//////////////////////////////////////////////////////////////////////////
        private static void ListarContas()
        {
            Console.WriteLine("Lista de Consta: ");

            if (listContas.Count == 0)
            {
                Console.WriteLine("Não há nenhuma conta registrada.");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} -", i);
                Console.WriteLine(conta);
            }
        }
//////////////////////////////////////////////////////////////////////////
        private static void InserirConta()
        {
            Console.WriteLine("Inserir uma nova conta:");
            
            Console.WriteLine("Digite 1 para Pessoa Fisica ou 2 para Pessoa Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();
            
            Console.WriteLine("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o limite de crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);
            listContas.Add(novaConta);
                
        }
////////////////////////////////////////
        private static string ObterOpcaoUsuario ()
        {
            Console.WriteLine();
            Console.WriteLine("Bem-vindo ao Mega Bank!");
            Console.WriteLine("Como podemos te ajudar?");

            Console.WriteLine("1- Lista de contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Tranferencia");
            Console.WriteLine("4- Saque");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
