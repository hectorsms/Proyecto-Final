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
    public class NivelRepository : INivelRepository
    {
        private readonly DB_BUSContext _context;

        public NivelRepository(DB_BUSContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Nivel>> GetNiveles()
        {
            var niveles = await _context.Nivel.ToListAsync();
            return niveles;
        }
        public async Task<Nivel> GetNivel(int id)
        {
            return await _context.Nivel.Where(x => x.IdNivel == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Nivel nivel)
        {
            await _context.Nivel.AddAsync(nivel);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Update(Nivel nivel)
        {
            _context.Nivel.Update(nivel);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Delete(int id)
        {
            var nivel = await _context.Nivel.FindAsync(id);
            if (nivel == null)
                return false;

            _context.Nivel.Remove(nivel);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

    }
}