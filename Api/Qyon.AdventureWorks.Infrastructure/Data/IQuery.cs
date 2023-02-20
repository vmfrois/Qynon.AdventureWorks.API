using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qynon.AdventureWorks.Infrastructure.Data
{
    public interface IQuery<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetById(int id);
    }
}
