using System.Collections.Generic;
using System.IO;
using de4aber.cAppsule.Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace cAppsule.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        
        public UserController(IUserService userService)
        {
            _userService = userService ??
                           throw new InvalidDataException("AppointmentController needs IAppointmentService");

        }
        
        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return _userService.GetUsers();
        }

        [HttpPost(nameof(CreateUser))]

        public ActionResult<User> CreateUser(User user)
        {
            return _userService.Create(user);
        }
    }
}