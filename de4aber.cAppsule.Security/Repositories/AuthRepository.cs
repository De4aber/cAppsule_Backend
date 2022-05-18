using de4aber.cAppsule.Security.Entities;
using de4aber.cAppsule.Security.IRepositories;
using de4aber.cAppsule.Security.Models;

namespace de4aber.cAppsule.Security.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AuthDbContext _ctx;
        public AuthRepository(AuthDbContext ctx)
        {
            _ctx = ctx;
        }

        private AuthUser EntityToUser(AuthUserEntity e)
        {
            return new AuthUser()
            {
                Id = e.Id,
                Username = e.Username,
                HashedPassword = e.HashedPassword
            };
        }
        
        public AuthUser FindUser(string username)
        {
            AuthUserEntity user = _ctx.AuthUsers.FirstOrDefault(user => username.Equals(user.Username));
            return (user == null) ? null : EntityToUser(user);
        }
    }
}