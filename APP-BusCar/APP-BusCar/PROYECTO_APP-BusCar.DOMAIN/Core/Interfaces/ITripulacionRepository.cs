using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces
{
    public interface ITripulacionRepository
    {
        Task<bool> Delete(int id);
        Task<Tripulacion> GetTripulacion(int id);
        Task<IEnumerable<Tripulacion>> GetTripulacions();
        Task<bool> Insert(Tripulacion tripulacion);
        Task<bool> Update(Tripulacion tripulacion);
    }
}