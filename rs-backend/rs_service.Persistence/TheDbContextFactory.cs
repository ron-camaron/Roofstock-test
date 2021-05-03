using rs_service.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace rs_service.Persistence
{
    public class TheDbContextFactory : DesignTimeDbContextFactoryBase<TheDbContext>
    {
        protected override TheDbContext CreateNewInstance(DbContextOptions<TheDbContext> options)
        {
            return new TheDbContext(options);
        }
    }
}
