using Microsoft.AspNetCore.Mvc;
using ScheduleSystem.API.Application._1._1_IServices;
using ScheduleSystem.API.Presentation.Controllers.Base;

namespace ScheduleSystem.API.Presentation.Controllers
{
    public class ProfilesController : BaseController
    {
        private readonly IUsersService _userService;
        public ProfilesController(IUsersService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return Ok(_userService.CreateUserAsync());
        }
    }
}
