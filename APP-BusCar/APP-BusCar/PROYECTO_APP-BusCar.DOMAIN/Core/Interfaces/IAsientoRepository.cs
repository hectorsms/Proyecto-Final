using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces
{
    public interface IAsientoRepository
    {
        Task<bool> Delete(int id);
        Task<Asiento> GetAsiento(int id);
        Task<IEnumerable<Asiento>> GetAsientos();
        Task<bool> Insert(Asiento asiento);
        Task<bool> Update(Asiento asiento);
    }
}