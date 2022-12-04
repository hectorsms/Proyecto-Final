using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces
{
    public interface IAsientoProgramacionRepository
    {
        Task<bool> Delete(int id);       
        Task<AsientoProgramacion> GetAsientoProgramacionById(int id);
        Task<bool> Insert(Asiento asiento);
        Task<bool> Update(Asiento asiento);
        Task<IEnumerable<AsientoProgramacion>> GetAsientoProgramacionByProgramacion(int idProgramacion);        
        Task<IEnumerable<OutProgramacionViaje>> GetOutProgramacionViaje(InProgramacionViaje inProgramacionViaje);

        Task<IEnumerable<OutProgramacionAsiento>> GetOutProgramacionAsiento(int idProgramacion);

    }
}