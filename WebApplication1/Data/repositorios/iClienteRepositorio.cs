using ParcialVisual.Modelo;

namespace model
{
    
        public interface iClienteRepositorio
        {
            Task<IEnumerable<Clientes>> getClientes();
            Task<Clientes> getClientesById(int id);
            Task<bool> insertClientes(Clientes cliente);
            Task<bool> updateClientes(Clientes cliente);
            Task<bool> deleteClientes(int id);
        
        }
}
