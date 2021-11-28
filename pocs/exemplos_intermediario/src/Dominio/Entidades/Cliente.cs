using System.Collections.Generic;
using System.Linq;

namespace Dominio.Entidades
{
    public class Cliente
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public (bool valido, List<string> mensagens) Validar()
        {
            var mensagens = new List<string>();

            if (string.IsNullOrEmpty(Email) || Email.Length > 250)
                mensagens.Add("[email] é obrigatório e deve conter no máximo 250 caracteres");                
            if (string.IsNullOrEmpty(Email) || Email.Length > 100)
                mensagens.Add("[nome] é obrigatório e deve conter no máximo 100 caracteres");

            return (!mensagens.Any(), mensagens);
        }

        public override string ToString() 
            => $"Cliente(Id={Id}, Email={Email}, Nome={Nome}, Ativo={Ativo})";
    }
}
