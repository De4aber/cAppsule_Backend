using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using cAppsule;
using de4aber.cAppsule.DataAccess.Entities;
using de4aber.cAppsule.Domain.IRepositories;

namespace de4aber.cAppsule.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        
        private readonly MainDbContext _ctx;
        public UserRepository(MainDbContext ctx)
        {
            _ctx = ctx ?? throw new InvalidDataException("AdminRepository need a DBcontext");

        }

        public List<User> FindAll()
        {
            return _ctx.Users
                .Select(u => u.ToUser()).ToList();
        }

        public User ReadById(int id)
        {
            var userEntity = _ctx.Users.Find(id);
            return userEntity?.ToUser() ?? throw new InvalidOperationException();
        }
        
        /// <summary>
        /// Finds a given user within the database by a given <c>username</c>
        /// </summary>
        /// <param name="username">the username of the wanted user</param>
        /// <returns><c>UserEntity</c> of either the found <c>User</c>, or a new <c>User</c> with it's name set to <c>"null"</c></returns>
        public UserEntity findUser(string username)
        {
            return _ctx.Users.FirstOrDefault(user => user.Username == username)
                   ?? new UserEntity{ Username = "null" };
        }
        
        public User Create(User user)
        {g
            if (findUser(user.Username).Username != "null") throw new Exception("User already exists");
            
            UserEntity userEntity = new UserEntity()
            {
                Username = user.Username,
                Password = user.Password,
                BirthDate =  user.BirthDate
            };
            UserEntity createdUserEntity = _ctx.Users.Add(userEntity).Entity;

            _ctx.SaveChanges();

            return createdUserEntity.ToUser();
        }

        public bool DeleteById(int id)
        {
            var toDelete = _ctx.Users.Find(id);
            if (toDelete == null) return false;
            _ctx.Users.Remove(toDelete);
            _ctx.SaveChanges();
            return true;

        }

        public Login Login(User user)
        {
            UserEntity foundUser = findUser(user.Username);
            if (foundUser.Username == "null") throw new Exception("User not found in the database!");
            if (foundUser.Password != user.Password)
                throw new Exception("Username doesn't match with found password from database!");

            //TODO: Add a token system
            Login login = new Login()
            {
                Id = foundUser.Id,
                Username = foundUser.Username
            };
            
            return login;
        }

        public User UpdateUser(int id, User user)
        {
            user.Id = id;
            var updatedUser = _ctx.Users.Update(new UserEntity(user)).Entity;
            _ctx.SaveChanges();
            return updatedUser.ToUser();
        }

        public List<User> SearchByUsername(string search)
        {
            return _ctx.Users
                .Where(u => u.Username.ToLower().Contains(search.ToLower()))
                .Select(u => u.ToUser()
            ).ToList();
        }
        
        
    }
}