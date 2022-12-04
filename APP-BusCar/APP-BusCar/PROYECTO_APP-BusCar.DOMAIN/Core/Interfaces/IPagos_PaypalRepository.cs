using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces
{
    public interface IPagos_PaypalRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<PagosPaypal>> GetPagosPaypal();
        Task<PagosPaypal> GetPagosPaypal(int id);
        Task<bool> Insert(PagosPaypal PagosPaypal);
        Task<bool> Update(PagosPaypal PagosPaypal);
    }
}