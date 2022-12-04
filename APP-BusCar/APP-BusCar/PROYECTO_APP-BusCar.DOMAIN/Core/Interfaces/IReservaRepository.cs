using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces
{
    public interface IReservaRepository
    {
        Task<bool> Delete(int id);
        Task<Reserva> GetReserva(int id);
        Task<IEnumerable<Reserva>> GetReservas();
        Task<bool> Insert(Reserva reserva);
        Task<bool> Update(Reserva reserva);
    }
}