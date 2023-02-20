using Qynon.AdventureWorks.Models;

namespace Qynon.AdventureWorks.Infrastructure.Data.EfCore
{
    public interface ICompetidorDao : ICommand<Competidor>, IQuery<Competidor>
    {
    }
}
