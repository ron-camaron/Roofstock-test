using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace rs_service.Application.Interfaces
{
    public interface IDatabaseContext
    {
        DbSet<Domain.Entities.Property> Properties { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
