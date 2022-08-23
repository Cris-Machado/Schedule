using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace ScheduleSystem.API.Presentation.Controllers.Base
{

    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        #region Ctor
        public BaseController()
        {
        }
        #endregion

}
}
