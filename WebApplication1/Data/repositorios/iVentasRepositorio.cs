using ParcialVisual.Modelo;

namespace ParcialVisual.Data.repositorios
{
    public interface iVentasRepositorio
    {
        Task<bool> insertventas(Ventas ventas);
        
    }
}
