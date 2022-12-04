using Microsoft.EntityFrameworkCore;
using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;
using PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces;
using PROYECTO_APP_BusCar.DOMAIN.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PROYECTO_APP_BusCar.DOMAIN.infrastructure.Repositories.DetalleReservaRepository;

namespace PROYECTO_APP_BusCar.DOMAIN.infrastructure.Repositories
{
    public class DetalleReservaRepository : IDetalleReservaRepository
    {

        public readonly DB_BUSContext _context;

        public DetalleReservaRepository(DB_BUSContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<DetalleReserva>> GetDetallesReserva(int idReserva)
        {
            var detalleReserva = await _context.DetalleReserva.Where(x => x.IdReserva == idReserva).ToListAsync();
            return detalleReserva;
        }

        public async Task<DetalleReserva> GetDetalleReserva(int idDetalleReserva)
        {
            return await _context.DetalleReserva.Where(x => x.IdDetalleReserva == idDetalleReserva).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(DetalleReserva detalleReserva)
        {
            await _context.DetalleReserva.AddAsync(detalleReserva);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Update(DetalleReserva detalleReserva)
        {
            _context.DetalleReserva.Update(detalleReserva);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Delete(int idDetalleReserva)
        {
            var detalleReserva = await _context.DetalleReserva.FindAsync(idDetalleReserva);
            if (detalleReserva == null)
                return false;

            _context.DetalleReserva.Remove(detalleReserva);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);

        }


    }
}