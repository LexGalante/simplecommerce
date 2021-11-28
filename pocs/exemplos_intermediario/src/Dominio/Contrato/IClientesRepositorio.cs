using Dominio.Entidades;
using System.Collections.Generic;

namespace Dominio.Contrato
{
    public interface IClientesRepositorio
    {
        IEnumerable<Cliente> ConsultaSql(string sql, object param = null);
        int ExecutarComandoSql(string sql, object param = null);
    }
}
