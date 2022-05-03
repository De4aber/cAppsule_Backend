using System;
using System.IO;
using de4aber.cAppsule.Core.IServices;
using de4aber.cAppsule.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace cAppsule.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController
    {
        private readonly IUserService _userService;
        
        public LoginController(IUserService userService)
        {
            _userService = userService ??
                           throw new InvalidDataException("AppointmentController needs IAppointmentService");

        }

        [HttpPost]
        public ActionResult<Login> login([FromBody] User user)
        {
            return _userService.Login(user);
        }
    }
}