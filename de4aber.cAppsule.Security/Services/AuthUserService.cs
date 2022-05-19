using de4aber.cAppsule.Security.IRepositories;
using de4aber.cAppsule.Security.IServices;
using de4aber.cAppsule.Security.Models;

namespace de4aber.cAppsule.Security.Services
{
    public class AuthUserService: IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthUserService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        
        public AuthUser GetUser(string username)
        {
            return _authRepository.FindUser(username);
        }
    }
}