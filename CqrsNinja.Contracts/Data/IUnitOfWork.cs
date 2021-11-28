using CqrsNinja.Contracts.Data.Repositories;

namespace CqrsNinja.Contracts.Data
{
    public interface IUnitOfWork
    {
        INinjaRepository Ninjas { get; }
        Task CommitAsync();
    }
}