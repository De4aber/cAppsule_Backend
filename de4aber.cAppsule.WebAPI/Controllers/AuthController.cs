using System;
using System.IO;
using de4aber.cAppsule.Security.IServices;
using de4aber.cAppsule.Security.Models;
using Microsoft.AspNetCore.Mvc;

namespace cAppsule.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController
    {
        private readonly ISecurityService _securityService;
        
        public AuthController(ISecurityService securityService)
        {
            _securityService = securityService ??
                               throw new InvalidDataException("AppointmentController needs IAppointmentService");

        }

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