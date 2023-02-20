using Microsoft.EntityFrameworkCore;
using Qynon.AdventureWorks.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qynon.AdventureWorks.Infrastructure.Data.EfCore
{
    public class CompetidorDao : ICompetidorDao
    {
        private readonly AppDbContext _context;

        public CompetidorDao(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Competidor>> GetAllAsync()
        {
            return await _context.Competidores.ToListAsync();
        }

        public async Task<Competidor> GetById(int id)
        {
            return await _context.Competidores.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Insert(Competidor model)
        {
            await _context.Competidores.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Competidor model)
        {
            _context.Competidores.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {   
            var model = await _context.Competidores.FirstOrDefaultAsync(x => x.Id == id);
            _context.Competidores.Remove(model);
            await _context.SaveChangesAsync();
        }

      
    }
}
