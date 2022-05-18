using de4aber.cAppsule.Security.Models;

namespace de4aber.cAppsule.Security.IRepositories
{
    public interface IAuthRepository
    {
        AuthUser FindUser(string username);
    }
}