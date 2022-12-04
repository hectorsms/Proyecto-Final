using Microsoft.EntityFrameworkCore;
using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;
using PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces;
using PROYECTO_APP_BusCar.DOMAIN.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_APP_BusCar.DOMAIN.infrastructure.Repositories
{
    public class ProgramacionRepository : IProgramacionRepository
    {
        private readonly DB_BUSContext _context;

        public ProgramacionRepository(DB_BUSContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Programacion>> GetProgramacions()
        {
            var programacions = await _context.Programacion.ToListAsync();
            return programacions;
        }
        public async Task<Programacion> GetProgramacion(int id)
        {
            return await _context.Programacion.Where(x => x.IdProgramacion == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Programacion programacion)
        {
            await _context.Programacion.AddAsync(programacion);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Update(Programacion programacion)
        {
            _context.Programacion.Update(programacion);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Delete(int id)
        {
            var programacion = await _context.Programacion.FindAsync(id);
            if (programacion == null)
                return false;

            _context.Programacion.Remove(programacion);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }



    }
}
