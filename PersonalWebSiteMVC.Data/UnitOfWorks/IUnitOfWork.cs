using PersonalWebSiteMVC.Core.Entities;
using PersonalWebSiteMVC.Data.Repositories.Abstractions;

namespace PersonalWebSiteMVC.Data.UnitOfWorks
{
    public interface IUnitOfWork: IAsyncDisposable
    {
        IRepository<T> GetRepository<T>() where T : class, IEntityBase, new();
        Task<int> SaveAsync();
        int Save();
    }
}
