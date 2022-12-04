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
    public class ReservaRepository : IReservaRepository
    {
        private readonly DB_BUSContext _context;

        public ReservaRepository(DB_BUSContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reserva>> GetReservas()
        {
            var reservas = await _context.Reserva.ToListAsync();
            return reservas;
        }
        public async Task<Reserva> GetReserva(int id)
        {
            return await _context.Reserva.Where(x => x.IdReserva == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Reserva reserva)
        {
            await _context.Reserva.AddAsync(reserva);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Update(Reserva reserva)
        {
            _context.Reserva.Update(reserva);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Delete(int id)
        {
            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva == null)
                return false;

            _context.Reserva.Remove(reserva);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }




    }
}