using System.Collections.Generic;
using cAppsule;

namespace de4aber.cAppsule.Core.IServices
{
    public interface IUserService
    {
        List<User> GetUsers();
        public User GetById(int id);
        User Create(User user);
        
        public bool DeleteById(int id);

        public User UpdateUser(int id, User user);

        public List<User> SearchByUsername(string search);
    }
}