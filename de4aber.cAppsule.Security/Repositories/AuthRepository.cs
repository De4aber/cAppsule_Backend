using System.Linq;
using System.Text;
using de4aber.cAppsule.Security;
using de4aber.cAppsule.Security.Entities;
using de4aber.cAppsule.Security.IRepositories;
using de4aber.cAppsule.Security.Models;

namespace de4aber.cAppsule.Security.Repositories
{
    public class AuthRepository: IAuthRepository
    {
        private readonly AuthDbContext _ctx;

        public AuthRepository(AuthDbContext ctx)
        {
            _ctx = ctx;
        }

        public AuthUser FindByUsernameAndPassword(string username, string password)
        {
            AuthUserEntity authUserEntity = _ctx.AuthUsers
                .FirstOrDefault(user => 
                    username.Equals(user.Username) 
                    && password.Equals(user.HashedPassword));
            return EntityToAuthUser(authUserEntity);
        }

        private AuthUser EntityToAuthUser(AuthUserEntity authUserEntity)
        {
            return new AuthUser()
            {
                Id = authUserEntity.Id,
                Username = authUserEntity.Username,
                HashedPassword = authUserEntity.HashedPassword,
                Salt = Encoding.ASCII.GetBytes(authUserEntity.Salt),
                EmployeeId = authUserEntity.EmployeeId,
            };
        }

        public AuthUser FindUser(string username)
        {
            AuthUserEntity entity = _ctx.AuthUsers
                .FirstOrDefault(user => username.Equals(user.Username));
            if (entity == null) return null;
            return EntityToAuthUser(entity);
        }

    }
}