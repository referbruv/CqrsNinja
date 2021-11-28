using CqrsNinja.Contracts.Data.Entities;
using CqrsNinja.Contracts.Data.Repositories;
using CqrsNinja.Migrations;

namespace CqrsNinja.Core.Data.Repositories
{
    public class NinjaRepository : Repository<Ninja>, INinjaRepository
    {
        public NinjaRepository(DatabaseContext context) : base(context)
        {
        }
    }
}