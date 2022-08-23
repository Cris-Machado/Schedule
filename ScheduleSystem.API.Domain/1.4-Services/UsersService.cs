using ScheduleSystem.API.Application._1._1_IServices;
using ScheduleSystem.API.Domain._1._1_Entities;
using ScheduleSystem.API.Domain._1._4_Services.Base;
using ScheduleSystem.API.Domain._1._5_Interfaces._1._5._1_IUnitOfWork;
using ScheduleSystem.API.Domain._2._4_IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleSystem.API.Application._1._3_Services
{
    public class UsersService : ServiceBase<Users>,  IUsersService
    {
        public UsersService(IUnitOfWork unitOfWork, IRepositoryBase<Users> repository) : base(unitOfWork, repository)
        {
        }

        #region Methods
        public string CreateUserAsync()
        {
            return "teste";
        }
        #endregion
    }
}
