using de4aber.cAppsule.Security.Models;

namespace de4aber.cAppsule.Security.IServices
{
    public interface IAuthService
    {
        public AuthUser Login(AuthUser user);
    }
}