using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces
{
    public interface IComprobanteRepository
    {
        Task<bool> Delete(int idComprobante);
        Task<Comprobante> GetComprobante(int idComprobante);
        Task<IEnumerable<Comprobante>> GetComprobantes();
        Task<bool> Insert(Comprobante comprobante);
        Task<bool> Update(Comprobante comprobante);
    }
}