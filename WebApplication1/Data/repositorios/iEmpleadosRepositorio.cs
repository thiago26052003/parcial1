using ParcialVisual.Modelo;

namespace model
{

    public interface iEmpleadosRepositorio
    {
        Task<IEnumerable<empleados>> getempleados();
        Task<empleados> getempleadosById(int id);
        Task<bool> insertempleados(empleados empleados);
        Task<bool> updateempleados(empleados empleados);
        Task<bool> deleteempleados(int id);

    }
}

