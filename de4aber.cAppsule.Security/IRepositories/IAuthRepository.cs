using de4aber.cAppsule.Security.Models;

namespace de4aber.cAppsule.Security.IRepositories
{
    public interface IAuthRepository
    {
        //public AuthUser FindByUsernameAndPassword(string username, string password);

        AuthUser FindUser(string username);
    }
}