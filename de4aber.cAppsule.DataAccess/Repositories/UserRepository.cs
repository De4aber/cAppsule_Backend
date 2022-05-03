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
                .Select(u => new User()
                {
                    Id = u.Id.ToString(),
                    Username = u.Username
                }).ToList();
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
        {
            if (findUser(user.Username).Username == "null") throw new Exception("User already exists");
            
            UserEntity userEntity = new UserEntity()
            {
                Username = user.Username,
                Password = user.Password,
                BirthDate =  user.BirthDate
            };
            UserEntity createdUserEntity = _ctx.Users.Add(userEntity).Entity;

            _ctx.SaveChanges();
            User createdUser = new User()
            {
                Id = createdUserEntity.Id.ToString(),
                Username = createdUserEntity.Username,
            };

            return createdUser;
        }

        public Login Login(User user)
        {
            throw new NotImplementedException();
        }
    }
}