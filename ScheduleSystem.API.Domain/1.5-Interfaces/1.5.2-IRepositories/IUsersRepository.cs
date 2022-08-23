using ScheduleSystem.API.Domain._1._1_Entities;
using ScheduleSystem.API.Domain._2._4_IRepositories;

namespace ScheduleSystem.API.Domain._1._5_Interfaces._1._5._2_IRepositories
{
    public interface IUsersRepository : IRepositoryBase<Users>
    {
        Task<Users> GetByDocumentAsync(string document);
    }
}
