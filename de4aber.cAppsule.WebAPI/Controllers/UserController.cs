using System.Collections.Generic;
using System.IO;
using System.Text;
using de4aber.cAppsule.Core.DTOs;
using de4aber.cAppsule.Core.IServices;
using de4aber.cAppsule.Security.IServices;
using Microsoft.AspNetCore.Mvc;

namespace cAppsule.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        private readonly ISecurityService _securityService;

        public UserController(IUserService userService, IAuthService authService, ISecurityService securityService)
        {
            _userService = userService ?? throw new InvalidDataException("UserController needs IUserService");
            _authService = authService ?? throw new InvalidDataException("UserController needs IAuthService");
            _securityService = securityService ?? throw new InvalidDataException("UserController needs ISecurityService");
        }

        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return _userService.GetUsers();
        }

        [HttpGet(nameof(GetAllDTOs))]
        public ActionResult<List<UserDTO>> GetAllDTOs()
        {
            return _userService.GetUserDtos();
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetById(int id)
        {
            return _userService.GetById(id);
        }

        [HttpPost(nameof(CreateUser))]
        public ActionResult<UserDTO> CreateUser(CreateUserDTO user)
        {
            var u = _userService.Create(user);
            _authService.Create(u.Id, u.Username, _securityService.HashedPassword(user.Password,Encoding.ASCII.GetBytes("123!#")));
            return u;
        }

        [HttpDelete]
        public ActionResult<bool> DeleteById(int id)
        {
            return _userService.DeleteById(id);
        }

        [HttpPut(nameof(UpdateUser))]
        public ActionResult<User> UpdateUser(int id, User user)
        {
            return _userService.UpdateUser(id, user);
        }

        [HttpGet(nameof(SearchByUsername) + "/{username}")]
        public ActionResult<List<UserLimitedInfoDTO>> SearchByUsername(string username)
        {
            return _userService.SearchByUsername(username);
        }
    }
}