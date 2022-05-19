using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using de4aber.cAppsule.Core.IServices;
using de4aber.cAppsule.Security.Entities;
using de4aber.cAppsule.Security.IServices;
using de4aber.cAppsule.Security.Models;
using Microsoft.AspNetCore.Mvc;

namespace cAppsule.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IAuthService _authService;
        
        public AuthController(ISecurityService securityService, IUserService userService, IAuthService authService) {
            _securityService = securityService ?? throw new InvalidDataException("AppointmentController needs IAppointmentService");
            _authService = authService ?? throw new InvalidDataException("AppointmentController needs IAppointmentService");;
        }
        
        //TODO slet inden aflevering
        /*
        [HttpGet]
        public ActionResult<List<AuthUserEntity>> GetAll()
        {
            return _authService.GetAll();
        }

        [HttpPost(nameof(test))]
        public ActionResult<string> test(string str)
        {
            string hashedPasswordFromPlain = _securityService.HashedPassword(str, Encoding.ASCII.GetBytes("123!#"));
            return hashedPasswordFromPlain;
        }
        */
        
        [HttpPost(nameof(Login))]
        public ActionResult<TokenDto> Login(LoginDto dto)
        {
            var token = _securityService.GenerateJwtToken(dto.Username, dto.Password);
            return new TokenDto()
            {
                Jwt = token.Jwt,
                Message = token.Message,
                UserId = token.UserId
            };
        }
    }
    
    public class TokenDto
    {
        public string Jwt { get; set; }
        public string Message { get; set; }

        public int UserId { get; set; }
    }
    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}