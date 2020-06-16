using Microsoft.EntityFrameworkCore;
using ReadersCqrsApp.Models.Entities;

namespace ReadersCqrsApp.Providers.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Reader> Readers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}