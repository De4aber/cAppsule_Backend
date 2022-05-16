using System.Collections.Generic;
using cAppsule;
using de4aber.cAppsule.Core.DTOs;

namespace de4aber.cAppsule.Core.IServices
{
    public interface IUserService
    {
        List<User> GetUsers();

        public List<UserDTO> GetUserDtos();
        public User GetById(int id);
        User Create(CreateUserDTO user);
        Login Login(User user);
        public bool DeleteById(int id);
        public User UpdateUser(int id, User user);
        public List<UserLimitedInfoDTO> SearchByUsername(string search);
        
    }
}