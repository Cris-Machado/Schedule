using ScheduleSystem.API.Data._3._1._4_Interfaces;
using ScheduleSystem.API.Domain._1._5_Interfaces._1._5._1_IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleSystem.API.Data._3._1._3_UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region ## Propriedades
        private readonly IDbContext _dbContext;
        private bool _disposed;
        #endregion

        #region ## Construtores e Dispose
        public UnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing) _dbContext.Dispose();
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region ## Transação
        public void BeginTransaction()
        {
            _disposed = false;
        }
        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}
