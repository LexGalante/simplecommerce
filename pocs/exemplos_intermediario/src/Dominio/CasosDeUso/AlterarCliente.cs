using Dominio.Contrato;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.CasosDeUso
{
    public class AlterarCliente
    {
        private readonly IClientesRepositorio _clienteRepositorio;

        public AlterarCliente(IClientesRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public void Executar(Cliente cliente)
        {
            var ativo = cliente.Ativo ? 1 : 0;
            _clienteRepositorio.ExecutarComandoSql("UPDATE testes.clientes SET email = @email, nome = @nome, ativo = @ativo WHERE id = @id;", 
                new
                {
                    email = cliente.Email,
                    nome = cliente.Nome,
                    ativo = ativo,
                    id = cliente.Id,

                });
        }

    }
}
