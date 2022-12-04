using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces
{
    public interface IMarcaRepository
    {
        Task<bool> Delete(int id);
        Task<Marca> GetMarca(int id);
        Task<IEnumerable<Marca>> GetMarcas();
        Task<bool> Insert(Marca marca);
        Task<bool> Update(Marca marca);
    }
}