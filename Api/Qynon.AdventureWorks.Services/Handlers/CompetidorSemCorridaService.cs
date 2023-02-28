using Qynon.AdventureWorks.Infrastructure.Data.EfCore;
using Qynon.AdventureWorks.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qynon.AdventureWorks.Service.Handlers
{
    public class CompetidorSemCorridaService : ICompetidorService
    {
        private readonly ICompetidorService _service;

        public CompetidorSemCorridaService(ICompetidorDao dao)
        {
            _service = new DefaultCompetidorService(dao);

        }

        public async Task DeleteCompetidor(int id)
        {
            await _service.DeleteCompetidor(id);
        }

        public async Task<IEnumerable<Competidor>> GetCompetidores()
        {
            return await _service.GetCompetidores();
        }

        public async Task<Competidor> GetCompetidor(int id)
        {
            return await _service.GetCompetidor(id);
        }

        public async Task<IEnumerable<Competidor>> GetCompetidorSemCorrida()
        {
            return await _service.GetCompetidorSemCorrida();
        }

        public async Task InsertCompetidor(Competidor model)
        {
            await _service.InsertCompetidor(model);
        }

        public async Task UpdateCompetidor(int id, Competidor model)
        {
            await _service.UpdateCompetidor(id, model);
        }
    }
}
