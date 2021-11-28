using Dominio.CasosDeUso;
using Dominio.Entidades;
using Infraestrutura;
using System;

namespace Aplicacao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var bancoDeDados = new ClientesBancoDeDados("Server=localhost;Port=3306;Database=testes;Uid=root;Pwd=1234;");

            CadastrarCliente(bancoDeDados);

            ConsultarClientes(bancoDeDados);

            RemoverCliente(bancoDeDados);

            ConsultarClientes(bancoDeDados);

            AlterarCliente(bancoDeDados);

            ConsultarClientes(bancoDeDados);
        }

        private static void CadastrarCliente(ClientesBancoDeDados bancoDeDados)
        {
            var cliente = new Cliente();
            Console.Write("Informe o nome do Cliente: ");
            cliente.Nome = Console.ReadLine();
            Console.Write("Informe o Email: ");
            cliente.Email = Console.ReadLine();
            Console.Write("Cliente está ativo? S ou N: ");
            if (Console.ReadLine().ToUpper().Trim().Equals("S"))

                cliente.Ativo = true;
            var (valido, mensagens) = cliente.Validar();
            if (!valido)
            {
                foreach (var mensagem in mensagens)
                {
                    Console.WriteLine(mensagem);
                }
            }

            new CadastrarCliente(bancoDeDados).Executar(cliente);
        }

        private static void ConsultarClientes(ClientesBancoDeDados bancoDeDados)
        {
            var clientes = new ListarClientes(bancoDeDados).Executar();
            foreach (var c in clientes)
                Console.WriteLine(c.ToString());
        }

        private static void RemoverCliente(ClientesBancoDeDados bancoDeDados)
        {
            Console.Write("Informe o ID do Cliente: ");

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                   new RemoverCliente(bancoDeDados).Executar(id);
                    return;
                }
                else
                {
                    Console.WriteLine("Valor deve ser um interio!");
                }
            }
        }

        public static void AlterarCliente(ClientesBancoDeDados bancoDeDados)
        {
            Console.Write("Informe o ID do Cliente: ");

            while (true)
            {

                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    var cliente = new Cliente();
                    cliente.Id = id;
                    Console.Write("Informe o nome: ");
                    cliente.Nome = Console.ReadLine();
                    Console.Write("Informe o Email: ");
                    cliente.Email = Console.ReadLine();
                    Console.Write("Cliente está ativo? S ou N: ");
                    if (Console.ReadLine().ToUpper().Trim().Equals("S"))
                        cliente.Ativo = true;
                    var (valido, mensagens) = cliente.Validar();
                    if (!valido)
                    {
                        foreach (var mensagem in mensagens)
                        {
                            Console.WriteLine(mensagem);
                        }
                    }
                    new AlterarCliente(bancoDeDados).Executar(cliente);
                    return;
                }
                else
                {
                    Console.WriteLine("Valor deve ser um Inteiro!");
                }
            }
        }

    }
}
