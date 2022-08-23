using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleSystem.API.Identity.Dtos
{
    public class UserToken
    {
        #region ## Properties
        public string AccessToken { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime Expires { get; set; }
        public bool IsAdm { get; set; } 
        #endregion
    }
}
