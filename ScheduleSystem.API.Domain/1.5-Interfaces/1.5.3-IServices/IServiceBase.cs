using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleSystem.API.Domain._1._5_Interfaces._1._5._3_IServices
{
    public interface IServiceBase<TEntity> : IDisposable where TEntity : class
    {
        #region ## CRUD
        Task<TEntity> InsertAsync(TEntity entity);
        Task<bool> InsertListAsync(IEnumerable<TEntity> listEntity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        Task<bool> DeleteAsync(string id);
        #endregion

        #region ## Searches
        Task<IEnumerable<TEntity>> FindAllAsync();
        Task<TEntity> FindByIdAsync(string id);
        Task<IEnumerable<TEntity>> FindAsync(int skip, int take);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<int> CountAllAsync();
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
        #endregion
    }
}
