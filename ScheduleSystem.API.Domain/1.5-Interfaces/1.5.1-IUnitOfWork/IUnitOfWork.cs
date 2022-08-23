using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleSystem.API.Domain._1._5_Interfaces._1._5._1_IUnitOfWork
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        Task<int> SaveChangesAsync();
    }
}
