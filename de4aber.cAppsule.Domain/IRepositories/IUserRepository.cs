using System.Collections.Generic;
using cAppsule;

namespace de4aber.cAppsule.Domain.IRepositories
{
    public interface IUserRepository
    {
        public List<User> FindAll();

        public User ReadById(int id);

        public User Create(User user);
        
        public bool DeleteById(int id);

        public User UpdateUser(int id, User user);
        List<User> SearchByUsername(string search);
    }
}