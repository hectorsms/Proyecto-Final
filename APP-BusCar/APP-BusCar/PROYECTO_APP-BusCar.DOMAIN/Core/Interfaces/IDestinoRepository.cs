using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces
{
    public interface IDestinoRepository
    {
        Task<bool> Delete(int idDestino);
        Task<Destino> GetDestino(int idDestino);
        Task<IEnumerable<Destino>> GetDestinos();
        Task<bool> Insert(Destino destino);
        Task<bool> Update(Destino destino);
    }
}