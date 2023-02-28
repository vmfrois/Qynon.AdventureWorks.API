using Qynon.AdventureWorks.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qynon.AdventureWorks.Infrastructure.Data.EfCore
{
    public interface ICompetidorDao : ICommand<Competidor>, IQuery<Competidor>
    {
        Task<IEnumerable<Competidor>> GetCompetidoresSemCorrida();
    }
}
