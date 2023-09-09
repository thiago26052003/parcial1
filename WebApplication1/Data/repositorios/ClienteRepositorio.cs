using Dapper;
using model;
using MySql.Data.MySqlClient;
using ParcialVisual.Modelo;

namespace ParcialVisual.Data.repositorios
{
    public class ClienteRepositorio : iClienteRepositorio
    {
        public readonly mysqlConfig _connection;
        public ClienteRepositorio(mysqlConfig connection)
        {
            _connection = connection;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connection._connectionstring);
        }
        public async Task<bool> deleteClientes(int id)
        {
            var db = dbConnection();
            var sql = @"delete from clientes where IdClientes=@Id";
            var result = await db.ExecuteAsync(sql, new { id });
            return result > 0;
        }
        public Task<Clientes> getClientesById(int id)
        {
            var db = dbConnection();
            var consulta = @"select * from clientes where idClientes=@Id";
            return db.QueryFirstOrDefaultAsync<Clientes>(consulta, new { Id = id });
        }

        public Task<IEnumerable<Clientes>> getClientes()
        {
            var db = dbConnection();
            var consulta = @"select * from clientes";
            return db.QueryAsync<Clientes>(consulta);
        }

        public async Task<bool> insertClientes(Clientes Clientes)
        {
            var db = dbConnection();
            var sql = @"insert into clientes(Documento, Nombre, Edad) values(@Documento, @Nombre, @Edad)";
            var result = await db.ExecuteAsync(sql, new { Clientes.Documento, Clientes.Nombre, Clientes.Edad});

            return result > 0;
        }

        public async Task<bool> updateClientes(Clientes clientes)
        {
            var db = dbConnection();
            var sql = @"Update clientes set Documento=@Documento, Nombre=@Nombre, Edad=@Edad where (idClientes=@IdClientes)";
            var result = await db.ExecuteAsync(sql, new { clientes.Documento, clientes.Nombre, clientes.Edad, clientes.IdClientes });
            return result > 0;



            {
                throw new NotImplementedException();
            }
        }
    }
}
