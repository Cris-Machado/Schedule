using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ScheduleSystem.API.Data._3._1._4_Interfaces;
using ScheduleSystem.API.Domain._1._1_Entities;
using ScheduleSystem.API.Domain._1._5_Interfaces._1._5._2_IRepositories;
using ScheduleSystem.API.Domain._2._1_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleSystem.API.Data._3._1._2_Repositories
{
    public class UsersRepository : RepositoryBase<Users>, IUsersRepository
    {
        private readonly ILogger<UsersRepository> _logger;
        public UsersRepository(IDbContext context, ILogger<UsersRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task<Users> GetByDocumentAsync(string document)
        {
            try
            {
                var storedProfile = await Context.Set<Profiles>()
                    .FirstOrDefaultAsync(x => x.Document.Equals(document)
                                              && !x.IsDeleted);

                if (storedProfile is null)
                    throw new Exception("Perfil não localizado");

                var storedUser = await Context.Set<Users>()
                    .FirstOrDefaultAsync(x => x.Id == storedProfile.UserId);

                if (storedUser is null)
                    throw new Exception("Usuario não localizado");

                return storedUser;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw;
            }

        }
    }
}
