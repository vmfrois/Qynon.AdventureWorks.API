using Qynon.AdventureWorks.Infrastructure.Data.EfCore;
using Qynon.AdventureWorks.Models;
using Qynon.AdventureWorks.Service.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qynon.AdventureWorks.Service.Handlers
{
    public class DefaultCompetidorService : ICompetidorService
    {
        private readonly ICompetidorDao _dao;

        public DefaultCompetidorService(ICompetidorDao dao)
        {
            _dao = dao;
        }

        public async Task<IEnumerable<Competidor>> GetCompetidores()
        {
            return await _dao.GetAllAsync();
        }

        public async Task<IEnumerable<Competidor>> GetCompetidorSemCorrida()
        {
            return await _dao.GetCompetidoresSemCorrida();
        }

        public async Task<Competidor> GetCompetidor(int id)
        {
           return await _dao.GetById(id);
        }

        public async Task InsertCompetidor(Competidor model)
        {
            ValidacaoCompetidor.ValidarTipoSexo(model);
            ValidacaoCompetidor.ValidarPesoEAltura(model);
            ValidacaoCompetidor.ValidarTemperaturaCorporal(model);
            await _dao.Insert(model);
        }

        public async Task UpdateCompetidor(int id,Competidor model)
        {
            ValidacaoCompetidor.ValidarTipoSexo(model);
            ValidacaoCompetidor.ValidarPesoEAltura(model);
            ValidacaoCompetidor.ValidarTemperaturaCorporal(model);
            await _dao.Update(model);
        }

        public async Task DeleteCompetidor(int id)
        {
             await _dao.Delete(id);
        }

    }
}
