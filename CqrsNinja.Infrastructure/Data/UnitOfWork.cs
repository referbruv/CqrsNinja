using CqrsNinja.Contracts.Data;
using CqrsNinja.Contracts.Data.Repositories;
using CqrsNinja.Core.Data.Repositories;
using CqrsNinja.Migrations;

namespace CqrsNinja.Core.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }
        public INinjaRepository Ninjas => new NinjaRepository(_context);

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}