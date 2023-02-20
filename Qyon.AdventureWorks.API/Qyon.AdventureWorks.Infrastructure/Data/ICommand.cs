using System.Threading.Tasks;

namespace Qynon.AdventureWorks.Infrastructure.Data
{
    public interface ICommand<T>
    {
        Task Insert(T model);
        Task Update(T model);
        Task Delete(int id);
    }
}
