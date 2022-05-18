using de4aber.cAppsule.Security.IRepositories;
using de4aber.cAppsule.Security.Models;

namespace de4aber.cAppsule.Security.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        public AuthRepository()
        {
            
        }
        public AuthUser FindUser(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}