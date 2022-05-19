using de4aber.cAppsule.Security.Models;

namespace de4aber.cAppsule.Security.IServices
{
    public interface ISecurityService
    {
        JwtToken GenerateJwtToken(string username, string password);

        public string HashedPassword(string plainPassword, byte[] userSalt);
    }
}