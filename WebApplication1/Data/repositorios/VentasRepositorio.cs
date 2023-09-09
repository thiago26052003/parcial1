using Dapper;
using MySql.Data.MySqlClient;
using ParcialVisual.Modelo;
using System.Data.Common;

namespace ParcialVisual.Data.repositorios
{
    public class VentasRepositorio:iVentasRepositorio
    {
        public readonly mysqlConfig _connection;
        public VentasRepositorio(mysqlConfig connection)
        {
            _connection = connection;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connection._connectionstring);
        }
        public async Task<bool> insertventas(Ventas Ventas)
        {
            var db = dbConnection();
            var sql = @"insert into ventas(Empleados_Id, Clientes_Id, Producto_Id) values(@Empleados_Id, @Clientes_Id, @Productos_Id)";
            var result = await db.ExecuteAsync(sql, new { Ventas.Empleados_Id, Ventas.Clientes_Id, Ventas.Productos_Id });

            return result > 0;  
        }
    }
        


}
