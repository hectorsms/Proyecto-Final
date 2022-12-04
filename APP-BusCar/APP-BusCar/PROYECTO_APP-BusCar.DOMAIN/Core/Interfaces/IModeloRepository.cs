using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces
{
    public interface IModeloRepository
    {
        Task<bool> Delete(int id);
        Task<Modelo> GetModelo(int id);
        Task<IEnumerable<Modelo>> GetModelos();
        Task<bool> Insert(Modelo modelo);
        Task<bool> Update(Modelo modelo);
    }
}