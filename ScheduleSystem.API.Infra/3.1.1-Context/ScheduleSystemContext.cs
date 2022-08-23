using Microsoft.EntityFrameworkCore;
using ScheduleSystem.API.Data._3._1._4_Interfaces;
using ScheduleSystem.API.Domain._1._1_Entities;
using ScheduleSystem.API.Domain._2._1_Entities;
using System.Data.Common;

namespace ScheduleSystem.API.Infra._3._1_Context
{
    public class ScheduleSystemContext : DbContext, IDbContext
    {
        #region Ctor
#pragma warning disable CS8618
        public ScheduleSystemContext(DbContextOptions<ScheduleSystemContext> options) : base(options)
        {
        }
        #endregion

        #region Methods
        public DbConnection GetConnection()
        {
            return Database.GetDbConnection();
        }
        #endregion

        #region DbSets
        public DbSet<Profiles> Profiles { get; set; }
        public DbSet<Users> Users { get; set; }
        #endregion

        #region Override
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Users>().ToTable("AspNetUsers", "Identity");
        }
        #endregion
    }
}
