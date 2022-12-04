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
    public class BusRepository : IBusRepository
    {
        private readonly DB_BUSContext _context;

        public BusRepository(DB_BUSContext context)
        {
            _context = context;

        }


        public async Task<IEnumerable<Bus>> GetBuses()
        {
            var buses = await _context.Bus.ToListAsync();
            return buses;
        }

        public async Task<Bus> GetBusById(int id)
        {
            return await _context.Bus.Where(x => x.IdBus == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Bus bus)
        {
            await _context.Bus.AddAsync(bus);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Update(Bus bus)
        {
            _context.Bus.Update(bus);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Delete(int id)
        {
            var bus = await _context.Bus.FindAsync(id);
            if (bus == null)
                return false;
            _context.Bus.Remove(bus);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public Task<Bus> GetBus(int id)
        {
            throw new NotImplementedException();
        }
    }
}