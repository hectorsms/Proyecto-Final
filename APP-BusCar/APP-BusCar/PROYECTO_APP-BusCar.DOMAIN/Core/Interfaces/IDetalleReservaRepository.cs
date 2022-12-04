using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces
{
    public interface IDetalleReservaRepository
    {
        Task<bool> Delete(int idDetalleReserva);
        Task<DetalleReserva> GetDetalleReserva(int idDetalleReserva);
        Task<IEnumerable<DetalleReserva>> GetDetallesReserva(int idReserva);
        Task<bool> Insert(DetalleReserva detalleReserva);
        Task<bool> Update(DetalleReserva detalleReserva);
    }
}