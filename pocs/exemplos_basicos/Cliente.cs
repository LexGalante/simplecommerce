using System;

namespace exemplos
{
    internal class Cliente
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastral { get; set; }        
        public DateTime DataAlteracao { get; set; }        

        public Cliente()
        {

        }

        public void PreencherDados()
        {
            Console.Write("Digite seu email: ");
            Email = Console.ReadLine();
            Console.Write("Digite seu nome: ");
            Nome = Console.ReadLine();                      
        }

        public bool ConfirmarCadastro()
        {
            Console.WriteLine($"Email = {Email}");
            Console.WriteLine($"Nome = {Nome}");
            Console.Write("Deseja confirmar o cadastro S ou N?: ");
            var confirmacao = Console.ReadLine().ToUpper().Trim();
            if (confirmacao.Equals("S"))
            {
                Id = new Random().Next(1, 99);
                DataCadastral = DateTime.Now;
                return true;
            }
            else
                return false;
        }

        public bool ConfirmarExclusao()
        {
            Console.WriteLine($"Email = {Email}");
            Console.WriteLine($"Nome = {Nome}");
            Console.Write("Deseja confirmar a exclusão S ou N?: ");
            var confirmacao = Console.ReadLine().ToUpper().Trim();
            if (confirmacao.Equals("S"))
                return true;
            else
                return false;
        }

        public bool ConfirmarAlteracao()
        {
            Console.WriteLine($"Email = {Email}");
            Console.WriteLine($"Nome = {Nome}");
            Console.Write("Deseja confirmar a alteração S ou N: ");
            var confirmacao = Console.ReadLine().ToUpper().Trim();
            if (confirmacao.Equals("S"))
            {
                DataAlteracao = DateTime.Now;
                return true;
            }
            else
                return false;
        }

        public void ImprimirDados() 
            => Console.WriteLine($"| {Id.ToString().PadRight(2, ' ')} | {Email.PadRight(30, ' ')} | {Nome.PadRight(30, ' ')} | {DataCadastral} | {DataAlteracao} |");

    }
}
