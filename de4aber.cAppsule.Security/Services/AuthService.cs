using de4aber.cAppsule.Security.IRepositories;
using de4aber.cAppsule.Security.IServices;
using de4aber.cAppsule.Security.Models;
using de4aber.cAppsule.Security.Repositories;

namespace de4aber.cAppsule.Security.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repo;
        public AuthService(IAuthRepository repo)
        {
            _repo = repo;
        }
        public AuthUser Login(AuthUser user)
        {
            return _repo.FindUser(user);
        }
    }
}