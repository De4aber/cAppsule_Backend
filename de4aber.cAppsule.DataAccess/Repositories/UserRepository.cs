using System;
using System.Collections.Generic;
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

        public User ReadById(int id)
        {
            var userEntity = _ctx.Users.Find(id);
            return userEntity?.ToUser() ?? throw new InvalidOperationException();
        }

        public User Create(User user)
        {
            UserEntity userEntity = new()
            {
                Username = user.Username
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

        public User UpdateUser(int id, User user)
        {
            user.Id = id.ToString();
            var updatedUser = _ctx.Users.Update(new UserEntity(user)).Entity;
            _ctx.SaveChanges();
            return updatedUser.ToUser();
        }

        public List<User> SearchByUsername(string search)
        {
            return _ctx.Users.Where(u => u.Username.ToLower().Contains(search.ToLower())).Select(u => new User()
            {
                Id = u.Id.ToString(),
                Username = u.Username
            }).ToList();
        }
    }
}