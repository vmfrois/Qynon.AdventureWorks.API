using Qynon.AdventureWorks.Infrastructure.Data.EfCore;
using Qynon.AdventureWorks.Models;
using Qynon.AdventureWorks.Service.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qynon.AdventureWorks.Service.Handlers
{
    public class DefaultPistaCorridaService : IPistaCorridaService
    {
        private readonly IPistaCorridaDao _dao;
        public DefaultPistaCorridaService(IPistaCorridaDao dao)
        {
            _dao = dao;
        }

        public async Task<IEnumerable<PistaCorrida>> GetListPistasCorridas()
        {
            return await _dao.GetAllAsync();
        }

        public async Task<PistaCorrida> GetPistaCorrida(int id)
        {
            return await _dao.GetById(id);
        }

        public async Task InsertPistaCorrida(PistaCorrida model)
        {
            ValidacaoCorrida.ValidaDataNoFuturo(model.HistoricoCorrida);
            await _dao.Insert(model);
        }

        public async Task UpdatePistaCorrida(int id, PistaCorrida model)
        {
            ValidacaoCorrida.ValidaDataNoFuturo(model.HistoricoCorrida);
            await _dao.Update(model);
        }

        public async Task DeletePistaCorrida(int id)
        {
            await _dao.Delete(id);
        }

    }
}
