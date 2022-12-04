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
    public class DestinoRepository : IDestinoRepository
    {
        public readonly DB_BUSContext _context;
        public DestinoRepository(DB_BUSContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Destino>> GetDestinos()
        {
            var destinos = await _context.Destino.ToListAsync();
            return destinos;
        }

        public async Task<Destino> GetDestino(int idDestino)
        {
            return await _context.Destino.Where(x => x.IdDestino == idDestino).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Destino destino)
        {
            await _context.Destino.AddAsync(destino);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Update(Destino destino)
        {
            _context.Destino.Update(destino);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Delete(int idDestino)
        {
            var destino = await _context.Destino.FindAsync(idDestino);
            if (destino == null)
                return false;

            _context.Destino.Remove(destino);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);

        }

    }
}
