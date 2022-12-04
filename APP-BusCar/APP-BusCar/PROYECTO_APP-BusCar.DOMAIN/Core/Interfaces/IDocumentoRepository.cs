using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces
{
    public interface IDocumentoRepository
    {
        Task<bool> Delete(int id);
        Task<Documento> GetDocumento(int id);
        Task<IEnumerable<Documento>> GetDocumentos();
        Task<bool> Insert(Documento documento);
        Task<bool> Update(Documento documento);
    }
}