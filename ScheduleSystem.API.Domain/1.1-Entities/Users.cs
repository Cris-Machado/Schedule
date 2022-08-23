using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleSystem.API.Domain._1._1_Entities
{
    public class Users
    {
        public virtual Guid Id { get; protected set; }
        public virtual string Name { get; protected set; } = string.Empty;
        public virtual string Email { get; protected set; } = string.Empty;
        public virtual bool EmailConfirmed { get; protected set; }
        public virtual string Password { get; protected set; } = string.Empty;
        public virtual string PhoneNumber { get; protected set; } = string.Empty;
    }
}
