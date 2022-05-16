using System.Collections.Generic;
using System.IO;
using de4aber.cAppsule.Core.DTOs;
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
        public ActionResult<UserDTO> CreateUser(string username, string password, string birthDate)
        {
            return _userService.Create(new CreateUserDTO
            {
                Username = username,
                Password = password,
                BirthDate = birthDate
            });
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
        
        [HttpGet(nameof(SearchByUsername) +"/{username}")]
        public ActionResult<List<UserLimitedInfoDTO>> SearchByUsername(string username)
        {
            return _userService.SearchByUsername(username);
        }
        
        
    }
}