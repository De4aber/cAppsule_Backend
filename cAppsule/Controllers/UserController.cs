using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace cAppsule.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController
    {
        private List<User> _users = new List<User>();
        public UserController()
        {
            _users.Add(new User
            {
                Id = 0,
                Username = "john"
            });

            _users.Add(new User
            {
                Id = 1,
                Username = "joe"
            });
        }
        
        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return _users;
        }
        
    }
}