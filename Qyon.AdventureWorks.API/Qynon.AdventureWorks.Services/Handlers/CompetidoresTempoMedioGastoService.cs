using Qynon.AdventureWorks.Infrastructure.Data.EfCore;
using Qynon.AdventureWorks.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qynon.AdventureWorks.Service.Handlers
{
    public class CompetidoresTempoMedioGastoService : ICompetidorService
    {
        private readonly ICompetidorService _competidorService;
        private readonly IHistoricoCorridaDao _historicoDao;
        
        public CompetidoresTempoMedioGastoService(ICompetidorDao competidorDao,IHistoricoCorridaDao historicoDao)
        {
            _competidorService = new DefaultCompetidorService(competidorDao);
            _historicoDao = historicoDao;
        }

        public async Task<IEnumerable<Competidor>> GetCompetidores()
        {
            var competidores = await _competidorService.GetCompetidores();

            foreach (var competidor in competidores)
            {
                var historicos = await _historicoDao.GetAllAsync();
                if (historicos.Any())
                {
                    var tempoMedioCorrida = historicos.Average(h => h.TempoGasto);
                    competidor.HistoricoCorrida.TempoGasto = tempoMedioCorrida;
                }
            }

            return competidores;
        }

        public async Task<Competidor> GetCompetidor(int id)
        {
            return await _competidorService.GetCompetidor(id);
        }

        public async Task InsertCompetidor(Competidor model)
        {
            await _competidorService.InsertCompetidor(model);
        }

        public async Task UpdateCompetidor(int id, Competidor model)
        {
            await _competidorService.UpdateCompetidor(id, model);
        }

        public async Task DeleteCompetidor(int id)
        {
            await _competidorService.DeleteCompetidor(id);
        }

    }
}
