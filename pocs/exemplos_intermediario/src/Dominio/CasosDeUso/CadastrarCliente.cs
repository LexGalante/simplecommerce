using Dominio.Contrato;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.CasosDeUso
{
    public class CadastrarCliente
    {
        private readonly IClientesRepositorio _clienteRepositorio;

        public CadastrarCliente(IClientesRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public void Executar(Cliente cliente)
        {
            var ativo = cliente.Ativo ? 1 : 0;
            _clienteRepositorio.ExecutarComandoSql(
                $"INSERT INTO testes.clientes (email, nome, ativo) VALUES (@email, @nome, @ativo);",
                new 
                {
                    email=cliente.Email,
                    nome =cliente.Nome,
                    ativo = ativo
                });
        }
    }
}
