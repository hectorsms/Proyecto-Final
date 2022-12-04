using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces
{
    public interface IPrecioRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Precio>> GetPrecio();
        Task<Precio> GetPrecio(int id);
        Task<bool> Insert(Precio Precio);
        Task<bool> Update(Precio Precio);
    }
}