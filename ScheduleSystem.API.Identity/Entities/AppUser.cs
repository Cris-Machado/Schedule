using Microsoft.AspNetCore.Identity;

namespace ScheduleSystem.API.Identity.Entities
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
    }
}
