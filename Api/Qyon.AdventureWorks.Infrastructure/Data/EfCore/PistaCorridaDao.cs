using Microsoft.EntityFrameworkCore;
using Qynon.AdventureWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qynon.AdventureWorks.Infrastructure.Data.EfCore
{
    public class PistaCorridaDao : IPistaCorridaDao
    {
        private readonly AppDbContext _context;
        public PistaCorridaDao(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PistaCorrida>> GetAllAsync()
        {
            return await _context.PistasCorrida.ToListAsync();
        }

        public async Task<IEnumerable<PistaCorrida>> GetPistasUtilizadas()
        {
            var historicos = await _context.PistasCorrida.Select(p => p.HistoricoCorridas).ToListAsync();
          

            var listPistaCorrida = await _context.PistasCorrida.ToListAsync();
            return listPistaCorrida.Where(p => historicos.Contains(p.HistoricoCorridas));
        }


        public async Task<PistaCorrida> GetById(int id)
        {
            return await _context.PistasCorrida.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Insert(PistaCorrida model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Update(PistaCorrida model)
        {
            _context.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var pistaCorrida = await _context.PistasCorrida.FirstOrDefaultAsync(p => p.Id == id);
            _context.Remove(pistaCorrida);
            await _context.SaveChangesAsync();

        }

    }
}
