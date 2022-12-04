using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces
{
    public interface IBusRepository
    {
        Task<bool> Delete(int id);
        Task<Bus> GetBus(int id);
        Task<IEnumerable<Bus>> GetBuses();
        Task<bool> Insert(Bus bus);
        Task<bool> Update(Bus bus);
    }
}