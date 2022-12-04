using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces
{
    public interface INivelRepository
    {
        Task<bool> Delete(int id);
        Task<Nivel> GetNivel(int id);
        Task<IEnumerable<Nivel>> GetNiveles();
        Task<bool> Insert(Nivel nivel);
        Task<bool> Update(Nivel nivel);
    }
}