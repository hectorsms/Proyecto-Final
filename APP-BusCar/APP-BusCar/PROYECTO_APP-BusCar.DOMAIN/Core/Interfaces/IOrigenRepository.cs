using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces
{
    public interface IOrigenRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Origen>> GetOrigen();
        Task<Origen> GetOrigen(int id);
        Task<bool> Insert(Origen Origen);
        Task<bool> Update(Origen Origen);
    }
}