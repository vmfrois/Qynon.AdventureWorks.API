using Qynon.AdventureWorks.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qynon.AdventureWorks.Service
{
    public interface ICompetidorService
    {
        Task<IEnumerable<Competidor>> GetCompetidores();

        Task<IEnumerable<Competidor>> GetCompetidorSemCorrida();
        Task<Competidor> GetCompetidor(int id);
        Task InsertCompetidor(Competidor model);
        Task UpdateCompetidor(int id,Competidor model);
        Task DeleteCompetidor(int id);
    }
}
