using ScheduleSystem.API.Domain._1._1_Entities;
using ScheduleSystem.API.Domain._1._5_Interfaces._1._5._3_IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleSystem.API.Application._1._1_IServices
{
    public interface IUsersService : IServiceBase<Users>
    {
        string CreateUserAsync();
    }
}
