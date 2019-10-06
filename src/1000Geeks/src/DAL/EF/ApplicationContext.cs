using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<Pictures> Pictures { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options) { Database.EnsureCreated(); }
    }
}
