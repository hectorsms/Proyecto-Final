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
    public class PersonalRepository : IPersonalRepository
    {
        private readonly DB_BUSContext _context;

        public PersonalRepository(DB_BUSContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Personal>> GetPersonal()
        {
            var Personal = await _context.Personal.ToListAsync();
            return Personal;
        }
        public async Task<Personal> GetPersonal(int id)
        {
            return await _context.Personal.Where(x => x.IdPersonal == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Personal Personal)
        {
            await _context.Personal.AddAsync(Personal);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Update(Personal Personal)
        {
            _context.Personal.Update(Personal);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Delete(int id)
        {
            var Personal = await _context.Personal.FindAsync(id);
            if (Personal == null)
                return false;

            _context.Personal.Remove(Personal);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

    }
}