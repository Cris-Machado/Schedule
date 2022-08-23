using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleSystem.API.Domain._2._1_Entities
{
    public class Profiles : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        public Guid UserId { get; set; }
    }
}
