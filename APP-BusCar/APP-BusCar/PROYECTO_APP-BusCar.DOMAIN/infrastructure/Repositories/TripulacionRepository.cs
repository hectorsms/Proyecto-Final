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
    public class TripulacionRepository : ITripulacionRepository
    {
        private readonly DB_BUSContext _context;

        public TripulacionRepository(DB_BUSContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tripulacion>> GetTripulacions()
        {
            var tripulacions = await _context.Tripulacion.ToListAsync();
            return tripulacions;
        }
        public async Task<Tripulacion> GetTripulacion(int id)
        {
            return await _context.Tripulacion.Where(x => x.IdTripulacion == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Tripulacion tripulacion)
        {
            await _context.Tripulacion.AddAsync(tripulacion);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Update(Tripulacion tripulacion)
        {
            _context.Tripulacion.Update(tripulacion);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Delete(int id)
        {
            var tripulacion = await _context.Tripulacion.FindAsync(id);
            if (tripulacion == null)
                return false;

            _context.Tripulacion.Remove(tripulacion);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }



    }
}