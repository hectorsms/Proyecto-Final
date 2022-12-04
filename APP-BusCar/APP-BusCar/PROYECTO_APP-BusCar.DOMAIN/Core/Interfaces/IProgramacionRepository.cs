using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces
{
    public interface IProgramacionRepository
    {
        Task<bool> Delete(int id);
        Task<Programacion> GetProgramacion(int id);
        Task<IEnumerable<Programacion>> GetProgramacions();
        Task<bool> Insert(Programacion programacion);
        Task<bool> Update(Programacion programacion);
    }
}