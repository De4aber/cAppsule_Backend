using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using cAppsule;
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
    }
}