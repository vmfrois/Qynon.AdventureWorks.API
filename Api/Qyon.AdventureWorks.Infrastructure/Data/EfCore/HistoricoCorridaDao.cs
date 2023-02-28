using Microsoft.EntityFrameworkCore;
using Qynon.AdventureWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qynon.AdventureWorks.Infrastructure.Data.EfCore
{
    public class HistoricoCorridaDao : IHistoricoCorridaDao
    {
        private readonly AppDbContext _context;
        public HistoricoCorridaDao(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HistoricoCorrida>> GetAllAsync()
        {
            return await _context.HistoricoCorrida.ToListAsync();
        }
        
        public async Task<IEnumerable<HistoricoCorrida>> GetCompetidoresComTempoMedio()
        {
            var historico = await _context.HistoricoCorrida.ToListAsync();
            var tempoMedio = historico.Average(h => h.TempoGasto);
            var competidoresTempoMedio = historico
                .Select(h => new HistoricoCorrida
                {
                    CompetidorId = h.CompetidorId,
                    PistaCorridaId = h.PistaCorridaId,
                    DataCorrida = h.DataCorrida,
                    TempoGasto = tempoMedio
                });

            return competidoresTempoMedio;
        }

        public async Task<HistoricoCorrida> GetById(int id)
        {
            return await _context.HistoricoCorrida.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Insert(HistoricoCorrida model)
        {
            _context.HistoricoCorrida.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task Update(HistoricoCorrida model)
        {
            var historicoCorrida = await _context.HistoricoCorrida.FirstAsync(h => h.Id == model.Id);
            if(historicoCorrida == null)
            {
                throw new Exception("");
            }
            _context.Update(model);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var model = await _context.HistoricoCorrida.FirstOrDefaultAsync(x => x.Id == id);
            _context.HistoricoCorrida.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}
