using System;
using System.IO;
using de4aber.cAppsule.Core.IServices;
using de4aber.cAppsule.DataAccess.Entities;
using de4aber.cAppsule.Security.IServices;
using de4aber.cAppsule.Security.Models;
using Microsoft.AspNetCore.Mvc;

namespace cAppsule.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController
    {
        private readonly IAuthService _authService;
        
        public AuthController(IAuthService authService)
        {
            _authService = authService ??
                          throw new InvalidDataException("AppointmentController needs IAppointmentService");

        }

        [HttpPost]
        public ActionResult<Login> login([FromBody] AuthUser user)
        {
            
            AuthUser au = _authService.Login(user);
            return new Login()
            {
                Id = au.Id,
                Username = au.Username
            };
        }
    }
}