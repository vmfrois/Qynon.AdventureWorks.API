using Qynon.AdventureWorks.Infrastructure.Data.EfCore;
using Qynon.AdventureWorks.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qynon.AdventureWorks.Service.Handlers
{
    public class PistaUtilizadasService : IPistaCorridaService
    {
        private readonly IPistaCorridaService _pistaCorridaService;
        public PistaUtilizadasService(IPistaCorridaDao dao)
        {
            _pistaCorridaService = new DefaultPistaCorridaService(dao);

        }

        public async Task<IEnumerable<PistaCorrida>> GetListPistasCorridas()
        {
            var listPistaCorrida = await _pistaCorridaService.GetListPistasCorridas();
            return listPistaCorrida.Where(p => p.HistoricoCorrida != null);
        }

        public async Task<PistaCorrida> GetPistaCorrida(int id)
        {
            return await _pistaCorridaService.GetPistaCorrida(id);
        }

        public async Task InsertPistaCorrida(PistaCorrida model)
        {
            await _pistaCorridaService.InsertPistaCorrida(model);
        }
        
        public async Task UpdatePistaCorrida(int id, PistaCorrida model)
        {
            await _pistaCorridaService.UpdatePistaCorrida(id,model);
        }

        public async Task DeletePistaCorrida(int id)
        {
            await _pistaCorridaService.DeletePistaCorrida(id);
        }


    }
}
