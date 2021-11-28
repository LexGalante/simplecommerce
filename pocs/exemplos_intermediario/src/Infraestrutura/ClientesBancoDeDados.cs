using MySql.Data.MySqlClient;
using Dapper;
using System;
using System.Collections.Generic;
using Dominio.Entidades;
using Dominio.Contrato;

namespace Infraestrutura
{
    public class ClientesBancoDeDados : IDisposable, IClientesRepositorio
    {
        private readonly string _connectionString;
        private readonly MySqlConnection _connection;

        public ClientesBancoDeDados(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new MySqlConnection(connectionString);
        }

        public IEnumerable<Cliente> ConsultaSql(string sql, object param = null)
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
                _connection.Open();

            return _connection.Query<Cliente>(sql, param);
        }
             
        public int ExecutarComandoSql(string sql, object param = null)
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
                _connection.Open();

            return _connection.Execute(sql, param);
        }

        public void Dispose()
        {
            if (_connection != null)
                _connection.Close();
        }
    }
}
