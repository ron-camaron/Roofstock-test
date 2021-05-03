using rs_service.Application.Interfaces;
using rs_service.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace rs_service.Persistence
{
    public class TheDbContext : DbContext, IDatabaseContext
    {
        public TheDbContext(DbContextOptions<TheDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TheDbContext).Assembly);
        }

        public DbSet<Property> Properties { get; set; }
    }
}