using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace ScheduleSystem.API.Data._3._1._4_Interfaces
{
    public interface IDbContext
    {
        DbConnection GetConnection();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        void Dispose();
    }
}
