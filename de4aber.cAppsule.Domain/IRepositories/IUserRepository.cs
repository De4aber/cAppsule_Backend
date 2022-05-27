using System.Collections.Generic;
using cAppsule;

namespace de4aber.cAppsule.Domain.IRepositories
{
    public interface IUserRepository
    {
        public List<User> FindAll();

        
        /// <summary>
        /// Creates a new <c>User</c> entity and places it into the SQL-based database.
        /// Before inserting into the database, it will confirm that the given username doesn't already exist within the database.
        /// </summary>
        /// <param name="user">the <c>User</c> object containing the user-data to be inserted</param>
        /// <returns>The created <c>User</c> object, or throws an exception if already exists</returns>
        public User Create(User user);

        public User ReadById(int id);
        
        public bool DeleteById(int id);

        public User UpdateUser(int id, User user);
        List<User> SearchByUsername(string search);

        public User FindByUsername(string username);

    }
}