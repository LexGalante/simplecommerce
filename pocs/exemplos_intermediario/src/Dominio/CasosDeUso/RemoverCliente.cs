using Dominio.Contrato;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.CasosDeUso
{
    public class RemoverCliente
    {
        private readonly IClientesRepositorio _clientesRepositorio;

        public RemoverCliente(IClientesRepositorio clientesRepositorio)
        {
            _clientesRepositorio = clientesRepositorio;
        }

        public void Executar(int id)
        {
            _clientesRepositorio.ExecutarComandoSql("DELETE FROM testes.clientes where id = @id", new { id });
        }
    }
}
