using System;
using System.Threading.Tasks;

namespace Nif.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAsync(DateTime lastModifyDateTime);
    }
}