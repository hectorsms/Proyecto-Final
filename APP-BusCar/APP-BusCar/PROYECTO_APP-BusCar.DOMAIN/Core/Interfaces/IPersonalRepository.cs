using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces
{
    public interface IPersonalRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Personal>> GetPersonal();
        Task<Personal> GetPersonal(int id);
        Task<bool> Insert(Personal Personal);
        Task<bool> Update(Personal Personal);
    }
}