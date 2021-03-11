using System;
using System.Collections.Generic;

namespace bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();  // banco de dados
        static void Main(string[] args)
        {

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "0")
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

                    case "6":

                        Console.Clear();
                        break;

                    default:

                        throw new ArgumentOutOfRangeException();

                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços!\n");
        }

        private static void ListarContas()
        {
            Console.WriteLine("Operação Selecionada: Listar Contas");

            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.WriteLine("Conta {0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void Depositar()
        {
            Console.WriteLine("Operação Selecionada: Depositar");

            Console.WriteLine("Digite o numero da conta:");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser depositado: ");
            string entradaDeposito = Console.ReadLine();

            if (entradaDeposito.Contains("."))
            {
                entradaDeposito = entradaDeposito.Replace(".", ",");
            }

            double valorDeposito = double.Parse(entradaDeposito);

            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.WriteLine("Operação Selecionada: Sacar");

            Console.WriteLine("Digite o numero da conta:");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado:");
            string entradaSaque = Console.ReadLine();

            if (entradaSaque.Contains("."))
            {
                entradaSaque = entradaSaque.Replace(".", ",");
            }

            double valorSaque = Convert.ToDouble(entradaSaque);

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void Transferir()
        {
            Console.WriteLine("Operação Selecionada: Transferir");

            Console.WriteLine("Digite o numero da conta origem: ");
            int indiceOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o numero da conta origem: ");
            int indiceDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido: ");
            string entradaString = Console.ReadLine();

            if (entradaString.Contains("."))
            {
                entradaString = entradaString.Replace(".", ",");
            }

            double valorTransferencia = double.Parse(entradaString);

            listContas[indiceOrigem].Transferir(valorTransferencia, listContas[indiceDestino]);


        }

        private static void InserirConta()
        {
            Console.WriteLine("Operação Selecionada: Inserir Nova Conta");

            Console.WriteLine("Digite 1 para conta Física ou 2 para conta Jurídica: ");
            int entradaTipoConta = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial: ");
            string entradaString = Console.ReadLine();


            if (entradaString.Contains("."))
            {
                entradaString = entradaString.Replace(".", ",");
            }

            double entradaSaldo = double.Parse(entradaString);


            Console.WriteLine("Digite o crédito: ");
            entradaString = Console.ReadLine();

            if (entradaString.Contains("."))
            {
                entradaString = entradaString.Replace(".", ",");
            }

            double entradaCredito = double.Parse(entradaString);

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        nome: entradaNome,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito);

            listContas.Add(novaConta);  // add novo objeto criado na lista (bd)
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank ao seu dispor!\n");

            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir Nova Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("6 - Limpar Tela");
            Console.WriteLine("0 - Sair\n");

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
