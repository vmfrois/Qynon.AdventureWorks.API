using Qynon.AdventureWorks.Infrastructure.Data.EfCore;
using Qynon.AdventureWorks.Models;
using Qynon.AdventureWorks.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qynon.AdventureWorks.Service.Handlers
{
    public class PistaUtilizadasService : IPistaCorridaService
    {
        private readonly IPistaCorridaService _service;

        public PistaUtilizadasService(IPistaCorridaDao dao )
        {
            _service = new DefaultPistaCorridaService(dao);

        }

        public async Task DeletePistaCorrida(int id)
        {
            await _service.DeletePistaCorrida(id);   
        }

        public async Task<IEnumerable<PistaCorrida>> GetListPistasCorridas()
        {
            return await _service.GetListPistasCorridas();
        }

        public async Task<PistaCorrida> GetPistaCorrida(int id)
        {
            return await _service.GetPistaCorrida(id);
        }

        public async Task<IEnumerable<PistaCorrida>> GetPistasUtilizadas()
        {
            return await _service.GetPistasUtilizadas();
        }

        public async Task InsertPistaCorrida(PistaCorrida model)
        {
            await _service.InsertPistaCorrida(model);
        }

        public async Task UpdatePistaCorrida(int id, PistaCorrida model)
        {
            await _service.UpdatePistaCorrida(id, model);
        }
    }
}
