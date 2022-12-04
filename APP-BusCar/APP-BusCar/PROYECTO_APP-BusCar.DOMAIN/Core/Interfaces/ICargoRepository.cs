using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces
{
    public interface ICargoRepository
    {
        Task<bool> Delete(int id);
        Task<Cargo> GetCargo(int id);
        Task<IEnumerable<Cargo>> GetCargos();
        Task<bool> Insert(Cargo cargo);
        Task<bool> Update(Cargo cargo);
    }
}