using Qynon.AdventureWorks.Infrastructure.Data.EfCore;
using Qynon.AdventureWorks.Models;
using Qynon.AdventureWorks.Service.Utils;
using Qynon.AdventureWorks.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qynon.AdventureWorks.Service.Handlers
{
    public class DefaultHistoricoCorridaService : IHistoricoCorridaService
    {
        private readonly IHistoricoCorridaDao _dao;

        public DefaultHistoricoCorridaService(IHistoricoCorridaDao dao)
        {
            _dao = dao;
        }

        public async Task<IEnumerable<HistoricoCorrida>> GetCompetidoresComTempoMedio()
        {
            return await _dao.GetCompetidoresComTempoMedio();
        }

        public async Task InsertHistorico(HistoricoCorrida model)
        {
            ValidacaoCorrida.ValidaDataEstaFuturo(model);
            await _dao.Insert(model);
        }

        public async Task UpdateHistorico(int id, HistoricoCorrida model)
        {
            ValidacaoCorrida.ValidaDataEstaFuturo(model);
            await _dao.Update(model);
        }

    }
}
