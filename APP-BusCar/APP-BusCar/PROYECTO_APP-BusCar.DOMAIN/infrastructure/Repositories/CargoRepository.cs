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
    public class CargoRepository : ICargoRepository
    {
        private readonly DB_BUSContext _context;

        public CargoRepository(DB_BUSContext context)
        {
            _context = context;

        }


        public async Task<IEnumerable<Cargo>> GetCargos()
        {
            var cargo = await _context.Cargo.ToListAsync();
            return cargo;
        }

        public async Task<Cargo> GetCargo(int id)
        {
            return await _context.Cargo.Where(x => x.IdCargo == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Cargo cargo)
        {
            await _context.Cargo.AddAsync(cargo);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Update(Cargo cargo)
        {
            _context.Cargo.Update(cargo);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Delete(int id)
        {
            var cargo = await _context.Cargo.FindAsync(id);
            if (cargo == null)
                return false;
            _context.Cargo.Remove(cargo);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }
    }
}
