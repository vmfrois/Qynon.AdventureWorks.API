using Qynon.AdventureWorks.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qynon.AdventureWorks.Services
{
    public interface IHistoricoCorridaService
    {
        Task<IEnumerable<HistoricoCorrida>> GetCompetidoresComTempoMedio();
        Task InsertHistorico(HistoricoCorrida model);
        Task UpdateHistorico(int id, HistoricoCorrida model);
    }
}
