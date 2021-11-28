using Dominio.Contrato;
using Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Dominio.CasosDeUso
{
    public class ListarClientes
    {
        private readonly IClientesRepositorio _repositorio;

        public ListarClientes(IClientesRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public List<Cliente> Executar() 
            => _repositorio.ConsultaSql("SELECT * FROM testes.clientes WHERE ativo = 1").ToList();
    }
}
