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

        /// <summary>
        /// Validates the information sent from the user based on the given input.
        /// If the user-data is valid, a Login object will be sent back up the system, which then is used in the frontend
        /// </summary>
        /// <param name="user">User object containing everything that is needed for logging in</param>
        /// <returns>Login object containing needed info about the user, and valid token</returns>
        Login Login(User user);

        public User ReadById(int id);

        public User Create(User user);
        
        public bool DeleteById(int id);

        public User UpdateUser(int id, User user);
        List<User> SearchByUsername(string search);

    }
}