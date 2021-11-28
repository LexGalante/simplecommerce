using System;
using System.Collections.Generic;
using System.Linq;

namespace exemplos
{
    public class Program
    {
        static readonly List<Cliente> clientes = new List<Cliente>();

        static void Main(string[] args)
        {
            //string a = "A";
            //var b = "B";

            //var x = 3;
            //var y = 4;

            //if (x > y)
            //{
            //    Console.WriteLine("x é maior que y");
            //}
            //else
            //{
            //    Console.WriteLine("x é menor que y");
            //}

            //Ola();

            //VerificaLetra(a);

            //var carro = new Carro("fiat 147", "fiat", "carroça");
            //Console.WriteLine(carro.QuilometragemRodada());

            //var caminhao = new Caminhao(3, 4);
            //caminhao.QuantidadeDeVagao();

            //ImprimeNome();

            // Criar uma classe de cliente, receber estes dados no console, depois imprimir os dados perguntando se estão tudo ok 

            Console.WriteLine("Sistema de cadastro de clientes");

            while (true)
            {
                var opcao = ProcessarMenu();                
                switch(opcao)
                {
                    case 1:
                        ProcessarCadastroCliente();
                        break;
                    case 2:
                        ProcessarConsultaClientes();
                        break;
                    case 3:
                        ProcessarAlteracaoCliente();
                        break;
                    case 4:
                        ProcessarExclusaoCliente();
                        break;
                }
            }
        }

        static int ProcessarMenu()
        {
            while (true)
            {                
                Console.WriteLine("[1] - Cadastrar [2] - Consultar  - [3] Alterar [4] - Deletar");                
                Console.WriteLine("Informe a opção desejada: ");
                if (int.TryParse(Console.ReadLine(), out int opcao))
                    if (new int[] { 1, 2, 3, 4 }.Contains(opcao))
                        return opcao;
                Console.Clear();
            }
        }

        static void ProcessarCadastroCliente()
        {
            Console.Clear();
            var cliente = new Cliente();
            cliente.PreencherDados();
            if (cliente.ConfirmarCadastro())
            {
                clientes.Add(cliente);
                Console.WriteLine("Cadastrado com sucesso!!!");
            }
            else
                Console.WriteLine("Operação cancelada!!!");
        }

        static void ProcessarConsultaClientes()
        {
            Console.Clear();            
            Console.WriteLine($"| {"ID".PadRight(2, ' ')} | {"EMAIL".PadRight(30, ' ')} | {"NOME".PadRight(30, ' ')} | {"DATA CADASTRAL".ToString().PadRight(20, ' ')} |");
            foreach (var cliente in clientes)
                cliente.ImprimirDados();
        }

        static bool ProcessarExclusaoCliente()
        {
            while(true)
            {
                Console.Clear();
                Console.Write("Informe o ID do cliente que deseja excluir: ");

                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    var cliente = clientes.SingleOrDefault(x => x.Id == id);
                    if (cliente == null)
                    {
                        Console.WriteLine($"Cliente ID {id} não encontrado");
                        return false;
                    }

                    if (cliente.ConfirmarExclusao())
                    {
                        clientes.Remove(cliente);
                        Console.WriteLine("Excluido com sucesso!!!");
                    }
                    else
                        Console.WriteLine("Operação cancelada!!!");

                    return default;
                }
            }
        }

        static bool ProcessarAlteracaoCliente()
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Informe o ID do cliente que deseja alterar: ");

                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    var cliente = clientes.SingleOrDefault(x => x.Id == id);
                    if (cliente == null)
                    {
                        Console.WriteLine($"Cliente ID {id} não encontrado");
                        return false;
                    }
                    Console.WriteLine($"Email = {cliente.Email}");
                    Console.WriteLine("Informe um novo Email ou aperte Enter para ignorar: ");
                    var email = Console.ReadLine();
                    if (email != cliente.Email && !string.IsNullOrEmpty(email))
                    {
                        cliente.Email = email;
                    }
                    Console.WriteLine($"Nome = {cliente.Nome}");
                    Console.WriteLine("Informe um novo nome ou aperte Enter para ignorar: ");
                    var nome = Console.ReadLine();
                    if (nome != cliente.Nome && !string.IsNullOrEmpty(nome))
                    {
                        cliente.Nome = nome;
                    }
                    if (!cliente.ConfirmarAlteracao())
                    {
                        cliente.Email = email;
                        cliente.Nome = nome;
                    }

                }
            }
        }

        //private static void ImprimeNome()
        //{
        //    Console.Write("Digite seu nome: ");
        //    var nome = Console.ReadLine();
        //    var dataAtual = DateTime.Now;
        //    Console.WriteLine($"Olá {nome} hoje é dia {dataAtual}");
        //}

        //private static void VerificaLetra(string a)
        //{
        //    switch (a)
        //    {
        //        case "A":
        //            Console.WriteLine("A");
        //            break;
        //        case "B":
        //            Console.WriteLine("B");
        //            break;
        //        default:
        //            Console.WriteLine("Não encontrei");
        //            break;
        //    }
        //}

        //private static void Ola()
        //{
        //    Console.WriteLine("Hello World!");
        //}
    }
}
