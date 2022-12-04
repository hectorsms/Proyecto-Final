using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces
{
    public interface IBoletoRepository
    {
        Task<bool> Delete(int id);
        Task<Boleto> GetBoleto(int id);
        Task<IEnumerable<Boleto>> getBoletos();
        Task<bool> Insert(Boleto boleto);
        Task<bool> Update(Boleto boleto);
    }
}