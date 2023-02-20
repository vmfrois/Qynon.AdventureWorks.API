using Qynon.AdventureWorks.Infrastructure.Data.EfCore;
using Qynon.AdventureWorks.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qynon.AdventureWorks.Service.Handlers
{
    public class CompetiorSemCorridaService : ICompetidorService
    {
        public readonly ICompetidorService _competidorService;
        public CompetiorSemCorridaService(ICompetidorDao competidorDao)
        {
            _competidorService = new DefaultCompetidorService(competidorDao);
        }

        public async Task<IEnumerable<Competidor>> GetCompetidores()
        {
            var competidores = await _competidorService.GetCompetidores();
            var competidoresSemCorrida = competidores.Where(c => c.HistoricoCorrida == null);

            return competidoresSemCorrida;
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
