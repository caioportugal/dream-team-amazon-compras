using System.Threading.Tasks;

namespace Amazon.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
