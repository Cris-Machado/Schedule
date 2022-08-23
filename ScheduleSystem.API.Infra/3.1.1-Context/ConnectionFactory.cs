using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ScheduleSystem.API.Infra._3._1_Context
{
    public class ConnectionFactory : IDesignTimeDbContextFactory<ScheduleSystemContext>
    {
        public ScheduleSystemContext CreateDbContext(string[] args)
        {
            var conn = "Server=(localdb)\\mssqllocaldb;Database=ScheduleDb;";
            var optionsBuilder = new DbContextOptionsBuilder<ScheduleSystemContext>();

            optionsBuilder.UseSqlServer(conn);
            return new ScheduleSystemContext(optionsBuilder.Options);
        }
    }
}
