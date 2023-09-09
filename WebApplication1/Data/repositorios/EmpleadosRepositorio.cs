using Dapper;
using model;
using MySql.Data.MySqlClient;
using ParcialVisual.Modelo;

namespace ParcialVisual.Data.repositorios
{
    public class EmpleadosRepositorio: iEmpleadosRepositorio
    {
        public readonly mysqlConfig _connection;
        public EmpleadosRepositorio(mysqlConfig connection)
        {
            _connection = connection;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connection._connectionstring);
        }
        public async Task<bool> deleteempleados(int id)
        {
            var db = dbConnection();
            var sql = @"delete from empleados where Idempleados=@Id";
            var result = await db.ExecuteAsync(sql, new { id });
            return result > 0;
        }

        public Task<empleados> getempleadosById(int id)
        {
            var db = dbConnection();
            var consulta = @"select * from empleados where idempleados=@Id";
            return db.QueryFirstOrDefaultAsync<empleados>(consulta, new { Id = id });
        }

        public Task<IEnumerable<empleados>> getempleados()
        {
            var db = dbConnection();
            var consulta = @"select * from empleados";
            return db.QueryAsync<empleados>(consulta);
        }

        public async Task<bool> insertempleados(empleados empleados)
        {
            var db = dbConnection();
            var sql = @"insert into empleados(IdEmpleados, Nombre, Documento) values(@IdEmpleados, @Nombre, @Documento)";
            var result = await db.ExecuteAsync(sql, new {empleados.IdEmpleados, empleados.Nombre, empleados.Documento });
            return result > 0;
        }

        public async Task<bool> updateempleados(empleados empleados)
        {
            var db = dbConnection();
            var sql = @"Update empleados set Nombre=@Nombre, Documento=@Documento where (idEmpleados=@IdEmpleados)";
            var result = await db.ExecuteAsync(sql, new {empleados.Nombre, empleados.Documento, empleados.IdEmpleados });
            return result > 0;
        }
    }
}

